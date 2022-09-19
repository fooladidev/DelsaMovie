using DelsaMovie.Data.Entities;

namespace DelsaMovie.IRepository
{
    public interface IUnitOfWork :IDisposable
    {
        IGenericRepository<Movie> Movies { get; }
        IGenericRepository<User> Users { get; }
        IGenericRepository<Link> Links { get; }
        IGenericRepository<Comment> Comments { get; }
        Task Save();

    }
}
