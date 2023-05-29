using System;
using Nexus.Models;
using System.Linq.Expressions;
using Controller.Models;

namespace Controller.Repository.Interfaces;


public interface IRepository<T> where T : Model
{
    Task<T?> CreateAsync(T entity);
    Task<IEnumerable<T>> RetrieveAllAsync(Expression<Func<T, bool>>? filter = null);
    Task<T?> RetrieveAsync(int id);
    Task<T?> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
}


