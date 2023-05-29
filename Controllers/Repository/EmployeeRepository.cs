using Nexus.Data; // NexusContext
using Nexus.Models; // Employee
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Controller.Repository.Interfaces; // IEmployeeRepository
using Controller.Repository; // Repository

namespace Controller.Repositories;
public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{

    private NexusContext _db;

    // Dependency Injection for the db context.
    public EmployeeRepository(NexusContext db) : base(db)
    {
        _db = db;
    }



    public async Task<bool> TerminateAsync(Employee emp)
    {
        // Marks the employee as terminated and sets the dateTime
        emp.Terminated = true;
        emp.TerminatedDate = DateTime.Now;
        emp.UpdatedDate = DateTime.Now;

        if (emp.Vacation is not null)
        {
            // Set employee vacation time to 0
            emp.Vacation.HolidayAvail = 0;
            emp.Vacation.HolidayAvailable = 0;
            emp.Vacation.VacationAvail = 0;
            emp.Vacation.VacationAvailable = 0;
        }

        // Updates the data in the DB and saves the changes.
        _db.Update(emp);
        int affected = await _db.SaveChangesAsync();

        // If data is affected in the table, returns true.
        return affected == 1;
    }
}