using ConestogaVirtualGameStore.Services;
using ConestogaVirtualGameStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConestogaVirtualGameStore.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReportService _reportService;
        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }
        public IActionResult Reports()
        {

            var reports = new List<Report>
            {
                new Report{Id = 1, Name = "Game List"},
                new Report{Id = 2, Name = "Game Detail"},
                new Report{Id = 3, Name = "Member List"},
                new Report{Id = 4, Name = "Member Detail"},
                new Report{Id = 5, Name = "Event List"},
                new Report{Id = 6, Name = "Wish List"},
                new Report{Id = 7, Name = "Most Popular Games in Wishlists"},
                new Report { Id = 8, Name = "Most Popular Events by Registrations" },
                new Report{Id = 9, Name = "Sales"}
            };

            return View(reports);
        }

        public async Task<IActionResult> DownloadReport(int id, string format)
        {
            var reports = new List<Report>
    {
        new Report{Id = 1, Name = "Game List"},
        new Report{Id = 2, Name = "Game Detail"},
        new Report{Id = 3, Name = "Member List"},
        new Report{Id = 4, Name = "Member Detail"},
        new Report{Id = 5, Name = "Event List"},
        new Report{Id = 6, Name = "Wish List"},
        new Report{Id = 7, Name = "Most Popular Games in Wishlists"},
        new Report { Id = 8, Name = "Most Popular Events by Registrations" },
        new Report{Id = 9, Name = "Sales"}
    };

            var report = reports.FirstOrDefault(r => r.Id == id);
            if (report == null)
            {
                return NotFound("Report not found.");
            }

            var reportData = await _reportService.GenerateReportAsync(id, format);
            if (reportData == null)
            {
                return NotFound("Unable to generate the report.");
            }

            string mimeType = format.ToLower() == "excel" ? "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" : "application/pdf";
            string fileExtension = format.ToLower() == "excel" ? "xlsx" : "pdf";
            string sanitizedReportName = report.Name.Replace(" ", "_"); 
            string fileName = $"{sanitizedReportName}_{id}.{fileExtension}";

            return File(reportData, mimeType, fileName);
        }
    }
}
