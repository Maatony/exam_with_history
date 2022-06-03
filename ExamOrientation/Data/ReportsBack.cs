using ExamOrientation.Models;

namespace ExamOrientation.Data
{
    public class ReportsBack
    {
        public string Result { get; set; }
        public List<Report> Reports { get; set; }

        public ReportsBack()
        {
            Reports = new List<Report>();
            Result = "Ok";
        }
    } 
}
