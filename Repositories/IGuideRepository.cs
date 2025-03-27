using aspapp.Models;

namespace aspapp.Repositories
{
    public interface IGuideRepository
    {
        Task<IEnumerable<Guide>> GetAllGuides();
        Task<Guide> GetGuideById(int guideId);
        Task AddGuide(Guide guide);
        Task UpdateGuide(Guide guide);
        Task DeleteGuide(int guideId);
    }
}
