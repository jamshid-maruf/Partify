using Partify.Domain.Entities.Ads;

namespace Partify.Service.Services.AdScores;

public interface IAdScoreService
{
	ValueTask<AdScore> AddOrUpdateScoreAsync(AdScore adScore);
	ValueTask<bool> DeleteAsync(long id);
	ValueTask<double> GetAverageScoreAsync(long adId);
}
