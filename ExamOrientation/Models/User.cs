namespace ExamOrientation.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Report> Reports { get; set; }
    }
}
