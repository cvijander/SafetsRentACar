using SafetsRentACar.Models;
using System.Net;

namespace SafetsRentACar.Service
{
    public class CarService : ICarService
    {
        private readonly SafetsRentalContext _context;

        public CarService(SafetsRentalContext context)
        {
            _context = context;
        }


        public void AddCar(Car car)
        {
            _context.Cars.Add(car);
        }

        public void DeleteCar(int id)
        {
            var car = _context.Cars.Find(id);
            {
                if(car != null)
                {
                    _context.Cars.Remove(car);
                }
            }

            
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public IEnumerable<Car> GetAllFilteredCars(int? carId, string make, string model, int? year, int? minPrice, int? maxPrice, bool isAvailable, int? fuel, int? transmision, int? drive, int? type, int? seats, int? mileage, int? color)
        {

               var cars = _context.Cars.AsQueryable();


            //    if (carId != null)
            //    {
            //        cars = cars.Where(c => c.CarId == carId);
            //    }

            //    if (make != null)
            //    {
            //        cars = cars.Where(c => c.Make == make);
            //    }

            //    if (LastName != null)
            //    {
            //        users = users.Where(u => u.LastName.ToLower() == LastName.ToLower().Trim());
            //    }

            //    if (Username != null)
            //    {
            //        users = users.Where(u => u.Username.ToLower() == Username.ToLower().Trim());
            //    }

            //    if (Email != null)
            //    {
            //        users = users.Where(u => u.Email.ToLower() == Email.ToLower().Trim());
            //    }

            //    if (PhoneNumber != null)
            //    {
            //        users = users.Where(u => u.PhoneNumber.ToLower() == PhoneNumber.ToLower().Trim());
            //    }

            //    if (Address != null)
            //    {
            //        users = users.Where(u => u.Address.ToLower() == Address.ToLower().Trim());
            //    }
            //    return cars;
            //}
            return cars;
    }

        public Car GetCarById(int id)
        {
            return _context.Cars.Find(id);
        }

        public void UpdateCar(Car car)
        {
            _context.Cars.Update(car);
        }
    }
}
