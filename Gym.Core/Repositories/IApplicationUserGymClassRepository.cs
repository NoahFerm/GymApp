using Gym.Core.Entities;

namespace Gym.Core.Repositories
{
    public interface IApplicationUserGymClassRepository
    {
        void Add(ApplicationUserGymClass booking);
        Task<ApplicationUserGymClass?> FindAsync(string userId, int gymClassId);
        void Remove(ApplicationUserGymClass attending);
    }
}