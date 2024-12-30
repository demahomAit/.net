using AndalusRestaurant.Data;
using Microsoft.EntityFrameworkCore;

namespace AndalusRestaurant.Models
{
    public class Repository<T> : IRepository<T>  where T : class
    {
        protected ApplicationDbContext _context {  get; set; }
        private DbSet<T> _dbSet {  get; set; }
        public Repository(ApplicationDbContext context) { 
            _context = context;
            _dbSet = context.Set<T>();
        }
        // Ajouter une entité
        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        // Supprimer une entité par son identifiant
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        // Récupérer toutes les entités
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // Récupérer une entité par son identifiant avec options de requête
        public Task<T> GetByIdAsync(int id, QueryOptions<T> options)
        {
            throw new NotImplementedException();
        }

        // Mettre à jour une entité
        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }

}

