using Partify.WebApi.Models.AdScores;

namespace Partify.WebApi.ApiServices.AdScores;

public interface IAdScoreApiService
{
    ValueTask<AdScoreViewModel> AddOrUpdateScoreAsync(AdScoreCreateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<double> GetAverageScoreAsync(long adId);
}