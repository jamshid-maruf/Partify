using Partify.DataAccess.UnitOfWorks;
using Partify.Domain.Entities.Ads;

namespace Partify.Service.Services.AdViews;

public class AdViewService(IUnitOfWork unitOfWork) : IAdViewService
{
	public async ValueTask<AdView> IncrementViewCountAsync(long adId)
	{
		var adView = await unitOfWork.AdViewRepository.SelectAsync(av => av.AdId == adId);
		if (adView == null)
		{
			adView = new AdView { AdId = adId, ViewCount = 1 };
			await unitOfWork.AdViewRepository.InsertAsync(adView);
		}
		else
		{
			adView.ViewCount++;
			await unitOfWork.AdViewRepository.UpdateAsync(adView);
		}
		await unitOfWork.SaveAsync();

		return adView;
	}

}
