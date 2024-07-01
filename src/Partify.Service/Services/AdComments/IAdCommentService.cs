using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;

namespace Partify.Service.Services.AdComments;

public interface IAdCommentService
{
	ValueTask<AdComment> CreateAsync(AdComment adComment);
	ValueTask<AdComment> UpdateAsync(long id, AdComment adComment);
	ValueTask<bool> DeleteAsync(long id);
	ValueTask<AdComment> GetByIdAsync(long id);
	ValueTask<IEnumerable<AdComment>> GetAllAsync(PaginationParams @params, Filter filter);
}