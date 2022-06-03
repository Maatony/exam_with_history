using ExamOrientation.Data;
using ExamOrientation.Databases;
using ExamOrientation.Interfaces;
using ExamOrientation.Models;
using ExamOrientation.ViewModels;
using ExamOrientation.Services;

namespace ExamOrientation.Services
{
    public class ReportService : IReportService
    {
        private readonly ReportDB ReportDb;
        public ReportService(ReportDB reportDB)
        {
            ReportDb = reportDB;
        }

        public VMAddReport? AddReport(Report report)
        {
            VMAddReport vMAddReport = new VMAddReport();
            if (report == null)
                vMAddReport.Issue.Add("No info provided!");
            else
            {
                if (report.Manufacturer == null)
                    vMAddReport.Issue.Add("Provide Manufacturer!");
                if (report.SerialNumber == 0)
                    vMAddReport.Issue.Add("Provide Serial Number!");
                if (report.Description == null)
                    vMAddReport.Issue.Add("Provide Description!");
            }

            if (vMAddReport.Issue.Count == 0)
            {
                Report addedReport = ReportDb.Reports.Add(report).Entity;
                ReportDb.SaveChanges();
            }

            return vMAddReport;
        }

        public int TryToCompleteReport(int id, SecretFromBody secret)
        {
            // Check if id is somehow valid (greater than 0) AND then if present in DB 
            if (id <= 0 || ReportDb.Reports.Find(id) == null)
            {
                return 404;
            }

            if (secret == null)
                return 400;

            if (secret.Secret != "voala")
                return 403;

            return 200;
        }
    }
}
