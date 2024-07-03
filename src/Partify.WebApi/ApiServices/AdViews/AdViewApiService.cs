using AutoMapper;
using Partify.Service.Services.AdViews;
using Partify.WebApi.Models.AdViews;

namespace Partify.WebApi.ApiServices.AdViews;

public class AdViewApiService(IMapper mapper, IAdViewService adViewService) : IAdViewApiService
{
	public async ValueTask<AdViewViewModel> IncrementViewCountAsync(long adId)
	{
		var createdAdView = await adViewService.IncrementViewCountAsync(adId);
		return mapper.Map<AdViewViewModel>(createdAdView);
	}
}
