namespace ExamOrientation.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public long SerialNumber { get; set; }
        public DateTimeOffset Date { get; set; }
        public User Reporter { get; set; }
        public int ReporterId { get; set; }
        public User Handler { get; set; }
        public int HandlerId { get; set; }
    }
}
