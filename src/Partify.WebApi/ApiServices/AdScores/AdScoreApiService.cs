using AutoMapper;
using Partify.Domain.Entities.Ads;
using Partify.Service.Services.AdScores;
using Partify.WebApi.Models.AdScores;


namespace Partify.WebApi.ApiServices.AdScores;

public class AdScoreApiService(IMapper mapper, IAdScoreService adScoreService) : IAdScoreApiService
{
	public async ValueTask<AdScoreViewModel> AddOrUpdateScoreAsync(AdScoreCreateModel createModel)
	{
		var createdAdScore = await adScoreService.AddOrUpdateScoreAsync(mapper.Map<AdScore>(createModel));
		return mapper.Map<AdScoreViewModel>(createdAdScore);
	}

	public async ValueTask<bool> DeleteAsync(long id)
	{
		return await adScoreService.DeleteAsync(id);
	}

	public async ValueTask<double> GetAverageScoreAsync(long adId)
	{
		return await adScoreService.GetAverageScoreAsync(adId);
	}
}
