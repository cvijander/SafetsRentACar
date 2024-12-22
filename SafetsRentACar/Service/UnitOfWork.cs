using Microsoft.EntityFrameworkCore;

namespace SafetsRentACar.Service
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly SafetsRentalContext _context;

        public UnitOfWork(SafetsRentalContext context)
        {
            _context = context;

            UserService = new UserService(context);
            CarService = new CarService(context);
        }

        public IUserService UserService {  get; private set; }

        public ICarService CarService { get; private set; }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
