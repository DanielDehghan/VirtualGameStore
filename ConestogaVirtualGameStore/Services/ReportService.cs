using ConestogaVirtualGameStore.AppDbContext;
using System.Drawing;
using System.Collections.Generic;
using OfficeOpenXml;
using iText.IO;
using iText.Pdfa;
using System.Reflection.Metadata;
using iText.Kernel.Pdf;
using Microsoft.EntityFrameworkCore;
using iText.Kernel.Font;
using iText.Bouncycastleconnector;

namespace ConestogaVirtualGameStore.Services
{
    public class ReportService : IReportService
    {
        private readonly VirtualGameStoreContext _context;
        public ReportService(VirtualGameStoreContext context)
        {
            _context = context;
        }
        public async Task<byte[]> GenerateReportAsync(int reportId, string format)
        {
            List<Object> data = reportId switch
            {
                1 => await _context.Games.Select(g => new {g.Title, g.ReleaseDate }).ToListAsync<Object>(),
                2 => await _context.Games.Select(g => new { g.Title, g.Genere, g.ReleaseDate, g.Platform, g.Price, g.Description }).ToListAsync<Object>(),
                3 => await _context.Members.Select(m => new { m.FirstName, m.LastName, m.Email }).ToListAsync<object>(),
                4 => await _context.Members.Select(m => new { m.FirstName, m.LastName, m.Email,m.Phone_Number, m.Gender,m.DateOfBirth, m.PreferredLanguage, m.PreferredPlatform, m.PreferredCategory, m.Apt_suit, m.StreetAddress, m.City, m.Province, m.Country, m.Postal_Code, m.Register_Date }).ToListAsync<Object>(),
                5 => await _context.Events.Select(e => new {e.Name, e.Date,e.Description, e.Address, e.City, e.Province, e.Country, e.PostalCode}).ToListAsync<Object>(),
                6 => await _context.Wishlist.Select(w => new {w.Wishlist_Name, w.Member_ID, w.Member.LastName}).ToListAsync<object>(),
                7 => await GetMostPopularGamesAsync(),
                8 => await GetMostPopularEVentAsync(),
                _ => null

            };

            if (data == null) return null;

            return format.ToLower() switch
            {
                "excel" => GenerateExcelReport(data),
                "pdf" => GeneratePdfReport(data),
                _ => null
            };
        }

        public byte[] GenerateExcelReport(IEnumerable<Object> data)
        {
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Report");

            var firstItem = data.FirstOrDefault();
            if (firstItem == null)
                throw new ArgumentException("Data cannot be null or empty.", nameof(data));

            var properties = firstItem.GetType().GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                worksheet.Cells[1, i + 1].Value = properties[i].Name;
            }

            int row = 2;
            foreach (var item in data)
            {
                for (int col = 0; col < properties.Length; col++)
                {
                    worksheet.Cells[row, col + 1].Value = properties[col].GetValue(item)?.ToString();
                }
                row++;
            }

            return package.GetAsByteArray();
        }

        public byte[] GeneratePdfReport(IEnumerable<Object> data)
        {
            if (data == null || !data.Any())
                throw new ArgumentException("Data cannot be null or empty.", nameof(data));

            using var stream = new MemoryStream();
            var writer = new PdfWriter(stream); 
            using var pdfDocument = new PdfDocument(writer); 
            using var document = new iText.Layout.Document(pdfDocument);

            var boldFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
            var regularFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA); 

    
            document.Add(new iText.Layout.Element.Paragraph("Report")
                .SetFontSize(18)
                .SetFont(boldFont)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

            var firstItem = data.FirstOrDefault();
            if (firstItem == null)
            {
                document.Add(new iText.Layout.Element.Paragraph("No data available."));
                return stream.ToArray();
            }

            var properties = firstItem.GetType().GetProperties();
            var table = new iText.Layout.Element.Table(properties.Length).UseAllAvailableWidth();

            foreach (var property in properties)
            {
                table.AddHeaderCell(new iText.Layout.Element.Cell()
                    .Add(new iText.Layout.Element.Paragraph(property.Name))
                    .SetFont(boldFont)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
            }
            foreach (var item in data)
            {
                foreach (var property in properties)
                {
                    var value = property.GetValue(item)?.ToString() ?? string.Empty;
                    table.AddCell(new iText.Layout.Element.Cell()
                        .Add(new iText.Layout.Element.Paragraph(value))
                        .SetFont(regularFont)
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT));
                }
            }

            document.Add(table);
            document.Close();

            return stream.ToArray(); 
        }

        private async Task<List<Object>> GetMostPopularGamesAsync()
        {
            return await _context.Wishlist_Games.GroupBy(wg => wg.GameId).Select(group => new
            {
                GameTitle = group.First().Game.Title,
                WishlistCount = group.Count()

            }).OrderByDescending(g => g.WishlistCount)
            .ToListAsync<Object> ();

        }

        private async Task<List<Object>> GetMostPopularEVentAsync()
        {
            var data= await _context.MembersEvents
                    .GroupBy(me => me.Event_ID)  
                    .Select(group => new
                    {
                        EventName = _context.Events.FirstOrDefault(e => e.EventId == group.Key).Name,  
                        RegistrationCount = group.Count()  
                    })
                    .OrderByDescending(e => e.RegistrationCount)
                    .ToListAsync<Object>();

            if(data == null || !data.Any())
            {
                throw new ArgumentException("No events found with registrations.", nameof(data));
            }

            return data;
        }


    }
}
