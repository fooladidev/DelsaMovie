using DelsaMovie.Data;
using DelsaMovie.Data.Entities;
using DelsaMovie.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DelsaMovie.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Movie> _movies;
        private IGenericRepository<User> _users;
        private IGenericRepository<Comment> _comments;
        private IGenericRepository<Link> _links;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;

        }
        public IGenericRepository<Movie> Movies => _movies ??= new GenericRepository<Movie>(_context);

        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);

        public IGenericRepository<Link> Links => _links ??= new GenericRepository<Link>(_context);

        public IGenericRepository<Comment> Comments => _comments ??= new GenericRepository<Comment>(_context);

        public void Dispose()
        {
            _context.Dispose(); 
            GC.SuppressFinalize(this);  
        }
        
        public async Task Save()
        {
            await _context.SaveChangesAsync();
            
        }
    }
}
