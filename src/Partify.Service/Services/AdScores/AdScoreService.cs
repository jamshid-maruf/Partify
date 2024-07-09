using Microsoft.EntityFrameworkCore;
using Partify.DataAccess.UnitOfWorks;
using Partify.Domain.Entities.Ads;
using Partify.Service.Exceptions;

namespace Partify.Service.Services.AdScores;

public class AdScoreService(IUnitOfWork unitOfWork) : IAdScoreService
{
    public async ValueTask<AdScore> AddOrUpdateScoreAsync(AdScore adScore)
    {
        var exsitUser = await unitOfWork.UserRepository.SelectAsync(user => user.Id == adScore.UserId)
                ?? throw new NotFoundException($"User is not found with this ID= {adScore.UserId}!");
        var existAd = await unitOfWork.AdRepository.SelectAsync(ad => ad.Id == adScore.AdId)
            ?? throw new NotFoundException($"Ad is not found with this ID= {adScore.AdId}!");

        var existAdScore = await unitOfWork.AdScoreRepository.SelectAsync(adScore => adScore.Id == adScore.AdId);

        if (existAdScore == null)
        {
            adScore = new AdScore { AdId = adScore.AdId, UserId = adScore.UserId, Score = adScore.Score };
            await unitOfWork.AdScoreRepository.InsertAsync(adScore);
        }
        else
        {
            adScore.Score = adScore.Score;
            await unitOfWork.AdScoreRepository.UpdateAsync(adScore);
        }

        await unitOfWork.SaveAsync();
        return adScore;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existAdScore = await unitOfWork.AdScoreRepository.SelectAsync(adScore => adScore.Id == adScore.AdId)
            ?? throw new NotFoundException($"Ad score is not found with this ID= {id}!");

        await unitOfWork.AdScoreRepository.DeleteAsync(existAdScore);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<double> GetAverageScoreAsync(long adId)
    {
        var scores = await unitOfWork.AdScoreRepository.Select(score => score.AdId == adId).ToListAsync();

        if (scores == null || !scores.Any())
        {
            return 0;
        }

        return scores.Average(s => s.Score);
    }
}
