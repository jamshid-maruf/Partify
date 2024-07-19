using Partify.Domain.Entities.Ads;
using Partify.Web.Models.Ads;
using X.PagedList;

namespace Partify.Web.WebServices.Ads;

public interface IAdWebService
{
    ValueTask<AdViewModel> CreateAsync(AdCreateModel createModel);
    ValueTask<AdViewModel> UpdateAsync(long id, AdUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<AdViewModel> GetByIdAsync(long id);
    ValueTask<IPagedList<Ad>> GetAllAsync(int? page, string search = null, long? categoryId = null);
    ValueTask<AdViewModel> AddCommentAsync(long adId, AdCommentCreateModel createModel);
    ValueTask<AdViewModel> UpdateCommentAsync(long adId, AdCommentUpdateModel updateModel);
    ValueTask<AdViewModel> UpsertScoreAsync(long adId, AdScoreCreatModel creatModel);
}