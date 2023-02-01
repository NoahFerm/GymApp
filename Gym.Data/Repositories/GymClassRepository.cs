using Gym.Core.Entities;
using Gym.Core.Repositories;
using Gym.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Data.Repositories
{
    public class GymClassRepository : IGymClassRepository
    {
        private readonly ApplicationDbContext db;
        public GymClassRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<List<GymClass>> GetAsync()
        {
            return await db.GymClasses.ToListAsync();
        }
        public async Task<IEnumerable<GymClass>> GetWithAttendingAsync()
        {
            return await db.GymClasses.Include(g => g.AttendingMembers).ToListAsync();
        }
        public async Task<GymClass?> GetAsync(int id)
        {
            ArgumentNullException.ThrowIfNull(id,nameof(id));
            return await db.GymClasses.FirstOrDefaultAsync(m => m.Id == id);
        }
        public void Add(GymClass gymClass)
        {
            db.Add(gymClass);
        }

        public async Task<IEnumerable<GymClass>> GetHistoryAsync()
        {
            return await db.GymClasses
                .Include(g => g.AttendingMembers)
                .IgnoreQueryFilters()
                .Where(g => g.StartTime < DateTime.Now)
                .ToListAsync();
        }
    }
    public class MockRepo : IGymClassRepository
    {
        private ApplicationDbContext db;

        public MockRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(GymClass gymClass)
        {
            throw new NotImplementedException();
        }

        public Task<List<GymClass>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GymClass?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GymClass>> GetHistoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GymClass>> GetWithAttendingAsync()
        {
            throw new NotImplementedException();
        }
    }
    public class MockUoW : IUnitOfWork
    {
        public IGymClassRepository GymClassRepository => throw new NotImplementedException();

        public IApplicationUserGymClassRepository ApplicationUserGymClassRepository => throw new NotImplementedException();

        public Task CompleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
