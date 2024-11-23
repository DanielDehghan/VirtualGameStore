namespace ConestogaVirtualGameStore.Services
{
    public interface IReportService
    {
        Task<byte[]> GenerateReportAsync(int reportId, string format);
        byte[] GenerateExcelReport(IEnumerable<object> data);
        byte[] GeneratePdfReport(IEnumerable<object> data);
    }
}
