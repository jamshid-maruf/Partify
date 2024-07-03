using AutoMapper;
using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;
using Partify.Service.Services.AdComments;
using Partify.WebApi.Models.AddComments;

namespace Partify.WebApi.ApiServices.AdComments;

public class AdCommentApiService(IAdCommentService adCommentService, IMapper mapper) : IAdCommentApiService
{
    public async ValueTask<AdCommentViewModel> CreateAsync(AdCommentCreateModel createModel)
    {
        var createdComment = await adCommentService.CreateAsync(mapper.Map<AdComment>(createModel));
        return mapper.Map<AdCommentViewModel>(createdComment);
    }

    public async ValueTask<AdCommentViewModel> UpdateAsync(long id, AdCommentUpdateModel updateModel)
    {
        var updatedComment = await adCommentService.UpdateAsync(id, mapper.Map<AdComment>(updateModel));
        return mapper.Map<AdCommentViewModel>(updatedComment);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await adCommentService.DeleteAsync(id);
    }

    public async ValueTask<AdCommentViewModel> GetByIdAsync(long id)
    {
        var result = await adCommentService.GetByIdAsync(id);
        return mapper.Map<AdCommentViewModel>(result);
    }

    public async ValueTask<IEnumerable<AdCommentViewModel>> GetAllAsync(
        PaginationParams @params,
        Filter filter)
    {
        var result = await adCommentService.GetAllAsync(@params, filter);
        return mapper.Map<IEnumerable<AdCommentViewModel>>(result);
    }

	public async ValueTask<AdCommentViewModel> AttachFileAsync(IFormFile file, long adCommentId)
	{
        var result = await adCommentService.AttachFileAsync(file, adCommentId);
        return mapper.Map<AdCommentViewModel>(result);
	}
}