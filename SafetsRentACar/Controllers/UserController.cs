//using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SafetsRentACar.Models;
using SafetsRentACar.Service;
using SafetsRentACar.ViewModels.User;
using System.Security.Cryptography;
using System.Text;

namespace SafetsRentACar.Controllers
{
    public class UserController : Controller
    {
        //private readonly SafetsRentalContext _context;

        //private readonly IUserService _userService;

        private readonly IUnitOfWork _unitOfWork;

        //public UserController(SafetsRentalContext context)
        //{
        //    _context = context;
        //}

        //public UserController(IUserService userService)
        //{
        //    _userService = userService;
        //}

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index( )
        {
           // var users = _context.Users.AsQueryable();
            //var users = Util.UserData.InitUsers();

           // var users = _userService.GetAllUsers();

            var users = _unitOfWork.UserService.GetAllUsers();

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
           // var users = Util.UserData.InitUsers();


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
                   
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Username = username,
                    PasswordHash = HashPassword(model.PasswordHash),
                    Address = model.Address,
                };

                //users.Add(newUser);
               // Util.UserData.AddUser(newUser);

            // _context.Users.Add(newUser);
            // _context.SaveChanges();
              // _userService.AddUser(newUser);

            _unitOfWork.UserService.AddUser(newUser);
            _unitOfWork.SaveChanges();

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
            //  var users = Util.UserData.InitUsers();


            // var users = _context.Users.AsQueryable();

           // var users = _userService.GetAllFilteredUsers(UserId, FirstName, LastName, Username, Email, PhoneNumber, Address);

            var users = _unitOfWork.UserService.GetAllFilteredUsers(UserId, FirstName, LastName, Username, Email, PhoneNumber, Address);

            //if (UserId != null)
            //{
            //    users = users.Where(u => u.UserId == UserId);
            //}

            //if (FirstName != null)
            //{
            //    users = users.Where(u => u.FirstName.ToLower() == FirstName.ToLower().Trim());
            //}

            //if( LastName != null)
            //{
            //    users = users.Where(u => u.LastName.ToLower() == LastName.ToLower().Trim());
            //}

            //if( Username != null)
            //{
            //    users = users.Where(u => u.Username.ToLower() == Username.ToLower().Trim());
            //}

            //if( Email != null)
            //{
            //    users = users.Where(u => u.Email.ToLower() == Email.ToLower().Trim());
            //}

            //if(PhoneNumber != null)
            //{
            //    users = users.Where(u => u.PhoneNumber.ToLower() == PhoneNumber.ToLower().Trim());
            //}

            //if (Address != null)
            //{
            //    users = users.Where(u => u.Address.ToLower() == Address.ToLower().Trim());
            //}



            return View(users);
        }


        // GET User edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // var users = Util.UserData.InitUsers();
            //  User singleUser = users.FirstOrDefault(u => u.UserId == id);


            //var user = _context.Users.FirstOrDefault(u => u.UserId == id);

           // var user = _userService.GetUserById(id);
            var user = _unitOfWork.UserService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            UserViewModel model = new UserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                Username = user.Username,
                PasswordHash = HashPassword(user.PasswordHash),
            };

            return View(model);

        }

        // POST Edit user
        [HttpPost]
        public IActionResult Edit(int id, UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

           // var user = _userService.GetUserById(id);
            var user = _unitOfWork.UserService.GetUserById(id);
            //  var users = Util.UserData.InitUsers();
            // User user = users.FirstOrDefault( u => u.UserId == id);

            // var user = _context.Users.FirstOrDefault(u => u.UserId == id);


            if ( user == null)
            {
                return NotFound();
            }


            ModelState.Remove("Username");
            

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.Address = model.Address;
            user.Username = string.IsNullOrWhiteSpace(model.Username) ? model.Email : model.Username;
            user.PasswordHash = model.PasswordHash;


            // _context.SaveChanges();
           // _userService.UpdateUser(user);
            _unitOfWork.UserService.UpdateUser(user);
            _unitOfWork.SaveChanges();

            return RedirectToAction("ShowAllUsers");
        }

        // GET Delete user
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // var users = Util.UserData.InitUsers();
            // User singleUser = users.FirstOrDefault(u => u.UserId == id);


            //var user = _context.Users.FirstOrDefault(u => u.UserId == id);

           // var user = _userService.GetUserById(id);
            var user = _unitOfWork.UserService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST Delete user 
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            //var users = Util.UserData.InitUsers();
            // User user = users.FirstOrDefault(u => u.UserId == id);

            // var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            //var user = _userService.GetUserById(id);
            var user = _unitOfWork.UserService.GetUserById(id);


            if ( user == null )
            {
                return NotFound();
            }
           // _userService.DeleteUser(id);
            _unitOfWork.UserService.DeleteUser(id);
            _unitOfWork.SaveChanges();

            //_users.Remove(user);
            // Util.UserData.RemoveUser(id);

            // _context.Users.Remove(user);
            // _context.SaveChanges();

            return RedirectToAction("ShowAllUsers");
        }
    }

}
