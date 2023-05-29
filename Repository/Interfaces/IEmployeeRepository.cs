using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Nexus.Models; // Employee

namespace Controller.Repository.Interfaces;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<bool> TerminateAsync(Employee emp);
}