using System;
using System.Linq;
using System.Linq.Expressions;
using Controller.Repository.Interfaces; // IPayStubRepository
using Microsoft.EntityFrameworkCore;
using Nexus.Data; // NexusContext
using Nexus.Models; //PayStub

namespace Controller.Repository;

public class PayStubRepository : Repository<PayStub>, IPayStubRepository
{
    private NexusContext _db;

    public PayStubRepository(NexusContext db) : base(db)
    {
        _db = db;
    }


}


