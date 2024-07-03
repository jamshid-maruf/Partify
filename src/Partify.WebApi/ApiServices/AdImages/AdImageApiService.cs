using AutoMapper;
using Partify.Service.Configurations;
using Partify.Service.Services.AdImages;
using Partify.WebApi.Models.AdImages;

namespace Partify.WebApi.ApiServices.AdImages;

public class AdImageApiService(IAdImageService adImageService, IMapper mapper) : IAdImageApiService
{
	public async ValueTask<AdImageViewModel> CreateAsync(long adId, IFormFile file)
	{
		var createdAdImage = await adImageService.CreateAsync(adId, file);
		return mapper.Map<AdImageViewModel>(createdAdImage);
	}

	public async ValueTask<bool> DeleteAsync(long id)
	{
		return await adImageService.DeleteAsync(id);
	}

	public async ValueTask<AdImageViewModel> GetByIdAsync(long id)
	{
		var adImage = await adImageService.GetAsync(id);
		return mapper.Map<AdImageViewModel>(adImage);
	}

	public async ValueTask<IEnumerable<AdImageViewModel>> GetAllAsync(long adId, Filter filter)
	{
		var adImages = await adImageService.GetAllByAdIdAsync(adId, filter);
		return mapper.Map<IEnumerable<AdImageViewModel>>(adImages);
	}
}

