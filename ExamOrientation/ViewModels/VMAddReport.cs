using ExamOrientation.Models;

namespace ExamOrientation.ViewModels
{
    public class VMAddReport
    {
        public HashSet<string> Issue { get; set; }
        public List<User> Users { get; set; }

        public VMAddReport()
        {
            Issue = new HashSet<string>();
            Users = new List<User>();
        }
    }
}
