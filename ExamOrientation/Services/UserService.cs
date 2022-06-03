using ExamOrientation.Interfaces;
using ExamOrientation.Models;
using ExamOrientation.Databases;

namespace ExamOrientation.Services
{
    public class UserService : IUserService
    {
        private readonly ReportDB ReportDb;
        public UserService(ReportDB reportDB)
        {
            ReportDb = reportDB;
        }
        public List<User> GetUsers()
        {
            return ReportDb.Users.ToList();
        }


        
        public User? AddUserToDB(User user)
        {
            if (user == null && String.IsNullOrWhiteSpace(user.Name))
            return null;

            var usr = ReportDb.Users.Add(user);
            ReportDb.SaveChanges();

            return usr.Entity;
        }
    }
}
