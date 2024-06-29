using Partify.Domain.Entities.Ads;

namespace Partify.Service.Services.AdViews;

public interface IAdViewService
{
    ValueTask<AdView> IncrementViewCountAsync(long adId);
}
