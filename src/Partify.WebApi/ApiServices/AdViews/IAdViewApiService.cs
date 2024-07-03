using Partify.WebApi.Models.AdViews;

namespace Partify.WebApi.ApiServices.AdViews;

public interface IAdViewApiService
{
	ValueTask<AdViewViewModel> IncrementViewCountAsync(long adId);
}
