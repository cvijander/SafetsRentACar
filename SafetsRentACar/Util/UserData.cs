using SafetsRentACar.Models;

namespace SafetsRentACar.Util
{
    public static class UserData
    {
        private static List<User> _users = null;

        public static IEnumerable<User> InitUsers()
        {
            if (_users == null)
            {
                _users = new List<User>

                {
                    new User
                    {
                        UserId = 1,
                        FirstName = "Marko",
                        LastName = "Markovic",
                        Email = "marko@gmail.com",
                        PhoneNumber = "06412345678",
                        Address = "Beograd",
                        Username = "marko123",
                        PasswordHash = "Haspasss",
                    },


                    new User
                    {
                        UserId = 2,
                        FirstName = "Darko",
                        LastName = "MPetrovic",
                        Email = "darko@gmail.com",
                        PhoneNumber = "0641231111",
                        Address = "Beograd",
                        Username = "darko111",
                        PasswordHash = "Haspasss",
                    }
                };
            }

            return _users;
                        
        }

        public static void AddUser(User user)
        {
            if(_users == null)
            {
                InitUsers();
            }

            _users.Add(user);
        }

        public static void RemoveUser(int userId)
        {
            if(_users == null )
            {
                InitUsers();
            }

            User deleteUser = _users.FirstOrDefault(u => u.UserId == userId);

            if(deleteUser !=null)
            {
                _users.Remove(deleteUser);
            }
        }

    }
}
