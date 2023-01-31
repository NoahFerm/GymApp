using Gym.Core.Entities;

namespace Gym.Data.Repositories
{
    public interface IGymClassRepository
    {
        Task<List<GymClass>> GetAsync();
        Task<IEnumerable<GymClass>> GetWithAttendingAsync();
        Task<GymClass?> GetAsync(int id);
        void Add(GymClass gymClass);
    }
}