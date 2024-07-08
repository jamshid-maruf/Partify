using AutoMapper;
using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;
using Partify.Service.Services.Ads;
using Partify.WebApi.Models.Ads;

namespace Partify.WebApi.ApiServices.Ads;

public class AdApiService(IAdService adService, IMapper mapper) : IAdApiService
{
	public async ValueTask<AdViewModel> CreateAsync(AdCreateModel createModel)
	{
		var createdAd = await adService.CreateAsync(mapper.Map<Ad>(createModel));
		return mapper.Map<AdViewModel>(createdAd);
	}

	public async ValueTask<bool> DeleteAsync(long id)
	{
		return await adService.DeleteAsync(id);
	}

	public async ValueTask<IEnumerable<AdViewModel>> GetAllAsync(
		PaginationParams @params,
		Filter filter,
		string search = null)
	{
		var result = await adService.GetAllAsync(@params, filter, search);
		return mapper.Map<IEnumerable<AdViewModel>>(result);
	}

	public async ValueTask<AdViewModel> GetByIdAsync(long id)
	{
		var result = await adService.GetByIdAsync(id);
		return mapper.Map<AdViewModel>(result);
	}

	public async ValueTask<AdViewModel> UpdateAsync(long id, AdUpdateModel updateModel)
	{
		var updatedAd = await adService.UpdateAsync(id, mapper.Map<Ad>(updateModel));
		return mapper.Map<AdViewModel>(updatedAd);
	}
}
