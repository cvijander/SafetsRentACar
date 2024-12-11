using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SafetsRentACar.Models;
using SafetsRentACar.ViewModels.User;
using System.Security.Cryptography;
using System.Text;

namespace SafetsRentACar.Controllers
{
    public class UserController : Controller
    {


        public IActionResult Index( )
        {
            var users = Util.UserData.InitUsers();

            return View(users);
        }

        // GET Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new UserViewModel());
        }

        //POST Create
        [HttpPost]
        public IActionResult Create(UserViewModel model)
        {
            var users = Util.UserData.InitUsers();

            Console.WriteLine("Uneseno korisničko ime: " + model.Username);

            ModelState.Remove("Username");

            if(!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("ModelState greška: " + error.ErrorMessage);
                }
                return View(model);
            }
                      
                
                // ako korisnik nije uneo username onda uzimamo vrednost mejla , ako je uneo, onda ostaje taj username
                string username = string.IsNullOrWhiteSpace(model.Username) ? model.Email : model.Username;

                var newUser = new User
                {
                    UserId = users.Count() + 1,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Username = username,
                    PasswordHash = HashPassword(model.PasswordHash),
                    Address = model.Address,
                };

                //users.Add(newUser);
                Util.UserData.AddUser(newUser);

                return RedirectToAction("ShowAllUsers");
           

            return View(model);
        }
        /// <summary>
        /// ////////
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IActionResult Create1()
        {
            return View(new UserViewModel());
        }

        //POST Create
        [HttpPost]
        public IActionResult Create1(UserViewModel model)
        {
            var users = Util.UserData.InitUsers();

            Console.WriteLine("Uneseno korisničko ime: " + model.Username);

            ModelState.Remove("Username");

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("ModelState greška: " + error.ErrorMessage);
                }
                return View(model);
            }

            if (ModelState.IsValid)
            {

                // ako korisnik nije uneo username onda uzimamo vrednost mejla , ako je uneo, onda ostaje taj username
                string username = string.IsNullOrWhiteSpace(model.Username) ? model.Email : model.Username;

                var newUser = new User
                {
                    UserId = users.Count() + 1,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Username = username,
                    PasswordHash = HashPassword(model.PasswordHash),
                    Address = model.Address,
                };

                //users.Add(newUser);
                Util.UserData.AddUser(newUser);

                return RedirectToAction("ShowAllUsers");
            }

            return View(model);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        /// <summary>
        /// /////////
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Username"></param>
        /// <param name="Email"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="Address"></param>
        /// <returns></returns>

        public IActionResult ShowAllUsers(int? UserId, string FirstName, string LastName, string Username, string Email, string PhoneNumber, string Address)
        {
            var users = Util.UserData.InitUsers();

            if (UserId != null)
            {
                users = users.Where(u => u.UserId == UserId);
            }

            if (FirstName != null)
            {
                users = users.Where(u => u.FirstName.ToLower() == FirstName.ToLower().Trim());
            }

            if( LastName != null)
            {
                users = users.Where(u => u.LastName.ToLower() == LastName.ToLower().Trim());
            }

            if( Username != null)
            {
                users = users.Where(u => u.Username.ToLower() == Username.ToLower().Trim());
            }

            if( Email != null)
            {
                users = users.Where(u => u.Email.ToLower() == Email.ToLower().Trim());
            }

            if(PhoneNumber != null)
            {
                users = users.Where(u => u.PhoneNumber.ToLower() == PhoneNumber.ToLower().Trim());
            }

            if (Address != null)
            {
                users = users.Where(u => u.Address.ToLower() == Address.ToLower().Trim());
            }



            return View(users);
        }


        // GET User edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var users = Util.UserData.InitUsers();
            User singleUser = users.FirstOrDefault(u => u.UserId == id);

            if (singleUser == null)
            {
                return NotFound();
            }

            UserViewModel model = new UserViewModel
            {
                FirstName = singleUser.FirstName,
                LastName = singleUser.LastName,
                Email = singleUser.Email,
                PhoneNumber = singleUser.PhoneNumber,
                Address = singleUser.Address,
                Username = singleUser.Username,
                PasswordHash = HashPassword(singleUser.PasswordHash),
            };

            return View(model);

        }

        // POST Edit user
        [HttpPost]
        public IActionResult Edit(int id, UserViewModel model)
        {
            var users = Util.UserData.InitUsers();
            User user = users.FirstOrDefault( u => u.UserId == id);
            if ( user == null)
            {
                return NotFound();
            }

            ModelState.Remove("Username");

            if(!ModelState.IsValid)
            {
                return View(model);
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.Address = model.Address;
            user.Username = string.IsNullOrWhiteSpace(model.Username) ? model.Email : model.Username;
            user.PasswordHash = model.PasswordHash;

            return RedirectToAction("ShowAllUsers");
        }

        // GET Delete user
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var users = Util.UserData.InitUsers();
            User singleUser = users.FirstOrDefault(u => u.UserId == id);

            if(singleUser ==null)
            {
                return NotFound();
            }

            return View(singleUser);
        }

        // POST Delete user 
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var users = Util.UserData.InitUsers();
            User user = users.FirstOrDefault(u => u.UserId == id);

            if( user == null )
            {
                return NotFound();
            }

            //_users.Remove(user);
            Util.UserData.RemoveUser(id);

            return RedirectToAction("ShowAllUsers");
        }
    }

}
