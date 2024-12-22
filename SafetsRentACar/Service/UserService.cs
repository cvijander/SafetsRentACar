using SafetsRentACar.Models;

namespace SafetsRentACar.Service
{

    public class UserService : IUserService
    {
        private readonly SafetsRentalContext _context;

        public UserService(SafetsRentalContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            //_context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if(user != null)
            {
                _context.Users.Remove(user);
                //_context.SaveChanges();

            }
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            //_context.SaveChanges();
        }

        public IEnumerable<User> GetAllFilteredUsers(int? UserId, string FirstName, string LastName, string Username, string Email, string PhoneNumber, string Address)
        {
          

             var users = _context.Users.AsQueryable();

            if (UserId != null)
            {
                users = users.Where(u => u.UserId == UserId);
            }

            if (FirstName != null)
            {
                users = users.Where(u => u.FirstName.ToLower() == FirstName.ToLower().Trim());
            }

            if (LastName != null)
            {
                users = users.Where(u => u.LastName.ToLower() == LastName.ToLower().Trim());
            }

            if (Username != null)
            {
                users = users.Where(u => u.Username.ToLower() == Username.ToLower().Trim());
            }

            if (Email != null)
            {
                users = users.Where(u => u.Email.ToLower() == Email.ToLower().Trim());
            }

            if (PhoneNumber != null)
            {
                users = users.Where(u => u.PhoneNumber.ToLower() == PhoneNumber.ToLower().Trim());
            }

            if (Address != null)
            {
                users = users.Where(u => u.Address.ToLower() == Address.ToLower().Trim());
            }
            return users;
        }
    }
}
