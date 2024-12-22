namespace SafetsRentACar.Service
{
    public interface IUnitOfWork
    {
        void SaveChanges();

        IUserService UserService { get; }

        ICarService CarService { get; }


    }
}
