using System;
using Controller.Models;

namespace Controller.Repository.Interfaces
{
    public interface IVacationRepository : IRepository<VacationTime>
    {
        public Task<VacationTime?> RetrieveByEmpIdAsync(int id);
    }
}

