using Microsoft.AspNetCore.Http;
using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;

namespace Partify.Service.Services.AdImages;

public interface IAdImageService
{
	ValueTask<AdImage> CreateAsync(long adId, IFormFile file);
	ValueTask<bool> DeleteAsync(long id);
	ValueTask<AdImage> GetAsync(long id);
	ValueTask<IEnumerable<AdImage>> GetAllByAdIdAsync(long adId, Filter filter);
}
