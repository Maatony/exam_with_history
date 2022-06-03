using ExamOrientation.Data;
using ExamOrientation.Models;
using ExamOrientation.ViewModels;

namespace ExamOrientation.Interfaces
{
    public interface IReportService
    {
        public int TryToCompleteReport(int id, SecretFromBody secret);
        public VMAddReport AddReport(Report report);
        public ReportsBack GetReportsForAPI(ReportFromAPI request);
    }
}
