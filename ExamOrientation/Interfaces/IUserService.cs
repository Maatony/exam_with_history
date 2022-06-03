using ExamOrientation.Models;

namespace ExamOrientation.Interfaces
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public User? AddUserToDB(User user);

    }
}
