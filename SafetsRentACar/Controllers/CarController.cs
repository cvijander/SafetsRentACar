using Microsoft.AspNetCore.Mvc;
using SafetsRentACar.Helpers;
using SafetsRentACar.Models;
using SafetsRentACar.Service;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace SafetsRentACar.Controllers
{
    public class CarController : Controller
    {

        //private static List<Car> _cars = new List<Car>
        // {
        //     new Car
        //         {
        //             CarId = 1,
        //             Make = Car.CarMake.Toyota,
        //             Model ="Supra MK4",
        //             Year = 1994,
        //             PricePerDay =120.0m,
        //             IsAvailable = true,
        //             Fuel = Car.FuelType.Gasoline,
        //             Transmision = Car.TransmisionType.Manual,
        //             Drive = Car.DriveType.RearWheel,
        //             Type = Car.CarType.Coupe,
        //             Color = Car.ColorType.Red,
        //             Seats =Car.NumberSeats.Two,
        //             Mileage = 70000,
        //             VIN = "JT2JA82J3R1234567",
        //             LicencePlate = "GT1234",
        //             ImageUrl = "/images/toyota_supra_mk4.jpg"
        //         },

        //          new Car
        //         {
        //             CarId = 2,
        //             Make = Car.CarMake.Nissan,
        //             Model = "Skyline GT-R R34",
        //             Year = 1999,
        //             PricePerDay = 140.0m,
        //             IsAvailable = true,
        //             Fuel = Car.FuelType.Gasoline,
        //             Transmision = Car.TransmisionType.Manual,
        //             Drive = Car.DriveType.AllWheel,
        //             Type = Car.CarType.Coupe,
        //             Color = Car.ColorType.Blue,
        //             Seats = Car.NumberSeats.Five,
        //             Mileage = 60000,
        //             VIN = "BNR34987654321",
        //             LicencePlate = "GT5678",
        //             ImageUrl = "/images/nissan_skyline_r34.jpg"
        //         },

        //         new Car
        //         {
        //             CarId = 3,
        //             Make = Car.CarMake.Mitsubishi,
        //             Model = "Lancer Evolution VI",
        //             Year = 1999,
        //             PricePerDay = 100.0m,
        //             IsAvailable = true,
        //             Fuel = Car.FuelType.Gasoline,
        //             Transmision = Car.TransmisionType.Manual,
        //             Drive = Car.DriveType.AllWheel,
        //             Type = Car.CarType.Sedan,
        //             Color = Car.ColorType.White,
        //             Seats = Car.NumberSeats.Five,
        //             Mileage = 80000,
        //             VIN = "JH4DC23989E123456",
        //             LicencePlate = "GT3456",
        //             ImageUrl = "/images/mitsubishi_evo_vi.jpg"
        //         },

        //         new Car
        //         {
        //             CarId = 4,
        //             Make = Car.CarMake.Mazda,
        //             Model = "RX-7 FD",
        //             Year = 1993,
        //             PricePerDay = 110.0m,
        //             IsAvailable = false,
        //             Fuel = Car.FuelType.Gasoline,
        //             Transmision = Car.TransmisionType.Manual,
        //             Drive = Car.DriveType.RearWheel,
        //             Type = Car.CarType.Coupe,
        //             Color = Car.ColorType.Yellow,
        //             Seats = Car.NumberSeats.Two,
        //             Mileage = 90000,
        //             VIN = "JM1FD3324R1234567",
        //             LicencePlate = "GT7890",
        //             ImageUrl = "/images/mazda_rx7_fd.jpg"
        //         },

        //          new Car
        //         {
        //             CarId = 5,
        //             Make = Car.CarMake.Honda,
        //             Model = "NSX",
        //             Year = 1995,
        //             PricePerDay = 150.0m,
        //             IsAvailable = true,
        //             Fuel = Car.FuelType.Gasoline,
        //             Transmision = Car.TransmisionType.Manual,
        //             Drive = Car.DriveType.RearWheel,
        //             Type = Car.CarType.Coupe,
        //             Color = Car.ColorType.Black,
        //             Seats = Car.NumberSeats.Two,
        //             Mileage = 50000,
        //             VIN = "JH4NA1151ST123456",
        //             LicencePlate = "GT2468",
        //             ImageUrl = "/images/honda_nsx.jpg"
        //         },

        //          new Car
        //         {
        //             CarId = 6,
        //             Make = Car.CarMake.Toyota,
        //             Model = "Celica GT-Four",
        //             Year = 1994,
        //             PricePerDay = 90.0m,
        //             IsAvailable = true,
        //             Fuel = Car.FuelType.Gasoline,
        //             Transmision = Car.TransmisionType.Manual,
        //             Drive = Car.DriveType.AllWheel,
        //             Type = Car.CarType.Coupe,
        //             Color = Car.ColorType.Green,
        //             Seats = Car.NumberSeats.Five,
        //             Mileage = 100000,
        //             VIN = "ST205123456789",
        //             LicencePlate = "GT9012",
        //             ImageUrl = "/images/toyota_celica_gtfour.jpg"
        //          },
        //         new Car
        //         {
        //             CarId = 7,
        //             Make = Car.CarMake.Mazda,
        //             Model = "MX-5 Miata",
        //             Year = 1996,
        //             PricePerDay = 80.0m,
        //             IsAvailable = true,
        //             Fuel = Car.FuelType.Gasoline,
        //             Transmision = Car.TransmisionType.Manual,
        //             Drive = Car.DriveType.RearWheel,
        //             Type = Car.CarType.Coupe,
        //             Color = Car.ColorType.Silver,
        //             Seats = Car.NumberSeats.Two,
        //             Mileage = 90000,
        //             VIN = "JM1NA3532T0123456",
        //             LicencePlate = "GT12345",
        //             ImageUrl = "/images/mazda_mx5_miata.jpg"
        //         },
        //         new Car
        //         {
        //             CarId = 8,
        //             Make = Car.CarMake.Honda,
        //             Model = "Civic Type R (EK9)",
        //             Year = 1997,
        //             PricePerDay = 70.0m,
        //             IsAvailable = true,
        //             Fuel = Car.FuelType.Gasoline,
        //             Transmision = Car.TransmisionType.Manual,
        //             Drive = Car.DriveType.FrontWheel,
        //             Type = Car.CarType.Hatchback,
        //             Color = Car.ColorType.White,
        //             Seats = Car.NumberSeats.Five,
        //             Mileage = 120000,
        //             VIN = "EK9123456789",
        //             LicencePlate = "GT4567",
        //             ImageUrl = "/images/honda_civic_ek9.jpg"
        //         },
        //         new Car
        //         {
        //             CarId = 9,
        //             Make = Car.CarMake.Nissan,
        //             Model = "300ZX",
        //             Year = 1990,
        //             PricePerDay = 85.0m,
        //             IsAvailable = false,
        //             Fuel = Car.FuelType.Gasoline,
        //             Transmision = Car.TransmisionType.Automatic,
        //             Drive = Car.DriveType.RearWheel,
        //             Type = Car.CarType.Coupe,
        //             Color = Car.ColorType.Red,
        //             Seats = Car.NumberSeats.Two,
        //             Mileage = 80000,
        //             VIN = "JN1RZ244123456789",
        //             LicencePlate = "GT6543",
        //             ImageUrl = "/images/nissan_300zx.jpg"
        //         },
        //         new Car
        //         {
        //             CarId = 10,
        //             Make = Car.CarMake.Mitsubishi,
        //             Model = "3000GT",
        //             Year = 1996,
        //             PricePerDay = 100.0m,
        //             IsAvailable = true,
        //             Fuel = Car.FuelType.Gasoline,
        //             Transmision = Car.TransmisionType.Automatic,
        //             Drive = Car.DriveType.AllWheel,
        //             Type = Car.CarType.Coupe,
        //             Color = Car.ColorType.Black,
        //             Seats = Car.NumberSeats.Five,
        //             Mileage = 95000,
        //             VIN = "JA3AM54J9TY123456",
        //             LicencePlate = "GT0987",
        //             ImageUrl = "/images/mitsubishi_3000gt.jpg"
        //         },
        //         new Car
        //         {
        //             CarId = 11,
        //             Make = Car.CarMake.Subaru,
        //             Model = "Impreza WRX STI",
        //             Year = 1999,
        //             PricePerDay = 120.0m,
        //             IsAvailable = true,
        //             Fuel = Car.FuelType.Gasoline,
        //             Transmision = Car.TransmisionType.Manual,
        //             Drive = Car.DriveType.AllWheel,
        //             Type = Car.CarType.Sedan,
        //             Color = Car.ColorType.Blue,
        //             Seats = Car.NumberSeats.Five,
        //             Mileage = 110000,
        //             VIN = "GC812345678901234",
        //             LicencePlate = "GT6789",
        //             ImageUrl = "/images/subaru_impreza_wrx_sti.jpg"
        //         },
        //         new Car
        //         {
        //             CarId = 12,
        //             Make = Car.CarMake.BMW,
        //             Model = "M3 E36",
        //             Year = 1995,
        //             PricePerDay = 130.0m,
        //             IsAvailable = true,
        //             Fuel = Car.FuelType.Gasoline,
        //             Transmision = Car.TransmisionType.Manual,
        //             Drive = Car.DriveType.RearWheel,
        //             Type = Car.CarType.Coupe,
        //             Color = Car.ColorType.Yellow,
        //             Seats = Car.NumberSeats.Five,
        //             Mileage = 75000,
        //             VIN = "WBSBG9320SY123456",
        //             LicencePlate = "GT1357",
        //             ImageUrl = "/images/bmw_m3_e36.jpg"
        //         },
        //         new Car
        //         {
        //             CarId = 13,
        //             Make = Car.CarMake.Ford,
        //             Model = "Mustang SVT Cobra",
        //             Year = 1993,
        //             PricePerDay = 140.0m,
        //             IsAvailable = true,
        //             Fuel = Car.FuelType.Gasoline,
        //             Transmision = Car.TransmisionType.Manual,
        //             Drive = Car.DriveType.RearWheel,
        //             Type = Car.CarType.Coupe,
        //             Color = Car.ColorType.Green,
        //             Seats = Car.NumberSeats.Five,
        //             Mileage = 60000,
        //             VIN = "1FACP42D3PF123456",
        //             LicencePlate = "GT4569",
        //             ImageUrl = "/images/ford_mustang_svt_cobra.jpg"
        //         },
        //         new Car
        //         {
        //             CarId = 14,
        //             Make = Car.CarMake.Toyota,
        //             Model = "MR2 Turbo",
        //             Year = 1991,
        //             PricePerDay = 95.0m,
        //             IsAvailable = true,
        //             Fuel = Car.FuelType.Gasoline,
        //             Transmision = Car.TransmisionType.Manual,
        //             Drive = Car.DriveType.RearWheel,
        //             Type = Car.CarType.Coupe,
        //             Color = Car.ColorType.Red,
        //             Seats = Car.NumberSeats.Two,
        //             Mileage = 85000,
        //             VIN = "JT2SW22J3N0123456",
        //             LicencePlate = "GT7531",
        //             ImageUrl = "/images/toyota_mr2.jpg"
        //         },
        //         new Car
        //         {
        //             CarId = 15,
        //             Make = Car.CarMake.Volkswagen,
        //             Model = "Corrado VR6",
        //             Year = 1992,
        //             PricePerDay = 80.0m,
        //             IsAvailable = false,
        //             Fuel = Car.FuelType.Gasoline,
        //             Transmision = Car.TransmisionType.Manual,
        //             Drive = Car.DriveType.FrontWheel,
        //             Type = Car.CarType.Coupe,
        //             Color = Car.ColorType.Black,
        //             Seats = Car.NumberSeats.Five,
        //             Mileage = 70000,
        //             VIN = "WVWEE4502LK123456",
        //             LicencePlate = "GT1123",
        //             ImageUrl = "/images/vw_corrado_vr6.jpg"
        //         }
        // };


        private readonly IUnitOfWork _unitOfWork;

        public CarController (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public IActionResult Index( int page = 1)
        {
            var cars = _unitOfWork.CarService.GetAllCars();

            //if (make != null)
            //{
            //    cars = cars.Where(c => c.Make.ToString().ToLower() == make.ToLower().Trim());
            //}

            //if (model != null)
            //{
            //    cars = cars.Where(c => c.Model.ToLower() == model.ToLower().Trim());
            //}

            //if (minPrice > 0)
            //{
            //    cars = cars.Where(c => c.PricePerDay >= minPrice);
            //}

            //if (maxPrice > 0)
            //{
            //    cars = cars.Where(c => c.PricePerDay <= maxPrice);
            //}

            var pageSize = 10;

            cars = cars.Skip(pageSize * (page -1)).Take(pageSize);



            return View(cars);



        }



        public IActionResult ReturnAll()
        {
            var cars = _unitOfWork.CarService.GetAllCars();

            return View(cars);
        }

        

        

        public IActionResult ShowAllCars()
        {

            var cars = _unitOfWork.CarService.GetAllCars();

            return View(cars);
        }

        // GET  create 
        [HttpGet]
        public IActionResult Create()
        {
            PopulateViewBags();

            return View();
        }

        // POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (Car car, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                //car.CarId = _cars.Max(c => c.CarId )+1;
                //_cars.Add(car);

                if(file != null )
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Cars");
                    path = $"{path}\\{car.Make.ToString()}_{car.Model}_{car.Year}.jpg";

                    FileStream stream = new FileStream(path, FileMode.Create);
                    file.CopyTo(stream);
                    car.ImageUrl = $"{car.Make.ToString()}_{car.Model}_{car.Year}.jpg";
                }

                _unitOfWork.CarService.AddCar(car);
                _unitOfWork.SaveChanges();

                IEnumerable<Car> cars = _unitOfWork.CarService.GetAllCars();


                return View("Index",cars);

            }
            

            return View(car);
        }

        private void PopulateViewBags()
        {
            ViewBag.CarMakes = Enum.GetValues(typeof(Car.CarMake));
            ViewBag.FuelTypes = Enum.GetValues(typeof(Car.FuelType));
            ViewBag.TransmisionTypes = Enum.GetValues(typeof(Car.TransmisionType));
            ViewBag.DriveType = Enum.GetValues(typeof(Car.DriveType));
            ViewBag.CarType = Enum.GetValues(typeof(Car.CarType));
            ViewBag.ColorTypes = Enum.GetValues(typeof(Car.ColorType));
            ViewBag.SeatOptions = Enum.GetValues(typeof(Car.NumberSeats));
        }

    }
}
