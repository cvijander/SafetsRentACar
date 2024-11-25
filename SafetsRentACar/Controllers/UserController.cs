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

        private IEnumerable<User> InitUsers()
            {
              var listOfUsers = new List<User>();

                listOfUsers.Add(

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
                    });
               
               listOfUsers.Add(
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
                    });
            return listOfUsers; 

            } 
        


        public IActionResult Index( )
        {
            var users = InitUsers(); 

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
            var users = InitUsers();

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


        public IActionResult ShowAllUsers(int? UserId, string FirstName, string LastName, string Username, string Email, string PhoneNumber, string Address)
        {
            var users = InitUsers();

            if (UserId != null)
            {
                users = users.Where(u => u.UserId == UserId);
            }

            if(!(FirstName == null || FirstName == ""))
            {
                users = users.Where(u => u.FirstName.ToLower() == FirstName.ToLower().Trim());
            }

            if(!(LastName == null )|| (LastName ==""))
            {
                users = users.Where(u => u.LastName.ToLower() == LastName.ToLower().Trim());
            }

            if(!(Username ==null )|| (Username==""))
            {
                users = users.Where(u => u.Username.ToLower() == Username.ToLower().Trim());
            }

            if(!(Email ==null) || (Email ==""))
            {
                users = users.Where(u => u.Email.ToLower() == Email.ToLower().Trim());
            }

            if(!(PhoneNumber ==null) || (PhoneNumber =="") )
            {
                users = users.Where(u => u.PhoneNumber.ToLower() == PhoneNumber.ToLower().Trim());
            }

            if (!(Address ==null) || (Address ==""))
            {
                users = users.Where(u => u.Address.ToLower() == Address.ToLower().Trim());
            }


           
            //    < th > Username </ th >
            //    < th > Email </ th >
            //    < th > PhoneNumber </ th >
            //    < th > Address </ th

            return View(users);
        }


        // GET User edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var users = InitUsers();
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
            var users = InitUsers();
            User user = users.FirstOrDefault( u => u.UserId == id);
            if ( user ==null)
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
            var users = InitUsers();
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
            var users = InitUsers();
            User user = users.FirstOrDefault(u => u.UserId == id);

            if( user == null )
            {
                return NotFound();
            }

            //_users.Remove(user);

            return RedirectToAction("ShowAllUsers");
        }
    }

}
