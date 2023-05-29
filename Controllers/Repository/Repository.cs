using System;
using Microsoft.EntityFrameworkCore;
using Nexus.Data;
using Nexus.Models;
using System.Linq.Expressions;
using Controller.Repository.Interfaces;
using Controller.Models;

namespace Controller.Repository
{
    public class Repository<T> : IRepository<T> where T : Model
    {
        private NexusContext _db;
        internal DbSet<T> dbSet;

        // Dependency Injection for the db context.
        public Repository(NexusContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public virtual async Task<T?> CreateAsync(T entity)
        {
            // Add createdDate field.
            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.Now;

            // Add entry into the db and save changes
            await dbSet.AddAsync(entity);
            int affected = await _db.SaveChangesAsync();

            // if the operation was successfull return the entity
            if (affected == 1)
            {
                return entity;
            }

            return null;

        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            // Remove entity from the db and save changes
            dbSet.Remove(entity);
            int affected = await _db.SaveChangesAsync();

            // Returns whether the operation was successfull or not.
            return affected == 1;
        }

        public virtual async Task<IEnumerable<T>> RetrieveAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            // Creates a variable to store the employees
            IQueryable<T> query;

            // If the user supplies a filter
            if (filter is not null)
            {
                query = dbSet.Where(filter);
            }
            else
            {
                query = dbSet;
            }

            // Return the employees
            return await query.ToListAsync();
        }

        public virtual async Task<T?> RetrieveAsync(int id)
        {
            // Filters the data to find the employee that matches that id
            T? entity = await dbSet.FirstOrDefaultAsync(entity => entity.Id == id);

            // Ensures that only a single employee is returned and that it was successfull
            if (entity is not null)
            {
                return entity;
            }

            return null;

        }

        public virtual async Task<T?> UpdateAsync(T entity)
        {
            // Add updatedDate field to entity
            entity.UpdatedDate = DateTime.UtcNow;

            // Update entry and save changes.
            _db.Update(entity);
            int affected = await _db.SaveChangesAsync();

            // If successfull
            if (affected == 1)
            {
                return entity;
            }

            return null;
        }
    }
}

