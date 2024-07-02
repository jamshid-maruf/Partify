using Partify.Service.Configurations;
using Partify.WebApi.Models.AdImages;

namespace Partify.WebApi.ApiServices.AdImages;

public interface IAdImageApiService
{
    ValueTask<AdImageViewModel> CreateAsync(long adId, IFormFile file);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<AdImageViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<AdImageViewModel>> GetAllAsync(long adId, Filter filter);
}

