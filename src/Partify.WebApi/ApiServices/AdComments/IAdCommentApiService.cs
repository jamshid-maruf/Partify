using Partify.Service.Configurations;
using Partify.WebApi.Models.AddComments;

namespace Partify.WebApi.ApiServices.AdComments;

public interface IAdCommentApiService
{
	ValueTask<AdCommentViewModel> CreateAsync(AdCommentCreateModel createModel);
	ValueTask<AdCommentViewModel> UpdateAsync(long id, AdCommentUpdateModel updateModel);
	ValueTask<bool> DeleteAsync(long id);
	ValueTask<AdCommentViewModel> GetByIdAsync(long id);
	ValueTask<IEnumerable<AdCommentViewModel>> GetAllAsync(PaginationParams @params, Filter filter);
	ValueTask<AdCommentViewModel> AttachFileAsync(IFormFile file, long adCommentId);
}