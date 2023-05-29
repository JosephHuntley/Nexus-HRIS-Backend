using System;
using System.Linq.Expressions;
using Controller.Models;
using Controller.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Nexus.Data;

namespace Controller.Repository
{
    public class VacationRepository : Repository<VacationTime>, IVacationRepository
    {
        private NexusContext _db;

        // Pass the database context to the parent class
        public VacationRepository(NexusContext db) : base(db)
        {
            _db = db;
        }


        // Overidden so that it searches by employee ID and not VacationTime Id
        public async Task<VacationTime?> RetrieveByEmpIdAsync(int id)
        {
            // Filters the data to find the employee that matches that id
            VacationTime? entity = await _db.VacationTime.FirstOrDefaultAsync(entity => entity.EmployeeId == id);

            // Ensures that only a single entity is returned and that it was successfull
            if (entity is not null)
            {
                return entity;
            }

            return null;
        }

        public override async Task<VacationTime?> UpdateAsync(VacationTime entity)
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

