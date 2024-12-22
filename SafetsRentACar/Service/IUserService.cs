using SafetsRentACar.Models;

namespace SafetsRentACar.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();

        IEnumerable<User> GetAllFilteredUsers(int? UserId, string FirstName, string LastName, string Username, string Email, string PhoneNumber, string Address);

        User GetUserById(int id);

        void AddUser(User user);
        void UpdateUser(User user);

        void DeleteUser(int id);

    }
}
