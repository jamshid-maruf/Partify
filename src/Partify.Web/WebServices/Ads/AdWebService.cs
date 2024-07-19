using AutoMapper;
using Partify.Domain.Entities.Ads;
using Partify.Domain.Entities.Users;
using Partify.Service.Configurations;
using Partify.Service.Services.AdCategoryPropertyValues;
using Partify.Service.Services.AdComments;
using Partify.Service.Services.AdFacilities;
using Partify.Service.Services.AdImages;
using Partify.Service.Services.Ads;
using Partify.Service.Services.AdScores;
using Partify.Service.Services.AdViews;
using Partify.Web.Models.Ads;
using X.PagedList;

namespace Partify.Web.WebServices.Ads;

public class AdWebService(
    IMapper mapper,
    IAdService adService, 
    IAdViewService adViewService,
    IAdScoreService adScoreService, 
    IAdImageService adImageService,
    IAdCommentService adCommentService,
    IAdFacilityService adFacilityService,
    IAdCategoryPropertyValueService adCategoryPropertyValueService)
    : IAdWebService
{
    public ValueTask<AdViewModel> AddCommentAsync(long adId, AdCommentCreateModel createModel)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<AdViewModel> CreateAsync(AdCreateModel createModel)
    {
        var result = await adService.CreateAsync(mapper.Map<Ad>(createModel));
        return mapper.Map<AdViewModel>(result);
    }

    public ValueTask<bool> DeleteAsync(long id)
    {
        return adService.DeleteAsync(id);
    }

    public async ValueTask<IPagedList<Ad>> GetAllAsync(int? page, string search = null, long? categoryId = null)
    {
        return await adService.GetAllAsync(page, search, categoryId);
    }

    public async ValueTask<AdViewModel> GetByIdAsync(long id)
    {
        var result = await adService.GetByIdAsync(id);
        return mapper.Map<AdViewModel>(result);
    }

    public async ValueTask<AdViewModel> UpsertScoreAsync(long adId, AdScoreCreatModel creatModel)
    {
        var result = await adScoreService.AddOrUpdateScoreAsync(new AdScore
        {
            AdId = adId,
            Score = creatModel.Score,
            UserId = creatModel.UserId
        });
        var ad = await adService.GetByIdAsync(adId);

        return mapper.Map<AdViewModel>(ad);
    }

    public async ValueTask<AdViewModel> UpdateAsync(long id, AdUpdateModel updateModel)
    {
        var result = await adService.UpdateAsync(id, mapper.Map<Ad>(updateModel));
        return mapper.Map<AdViewModel>(result);
    }

    public async ValueTask<AdViewModel> UpdateCommentAsync(long adCommentId,  AdCommentUpdateModel updateModel)
    {
        var result = await adCommentService.UpdateAsync(adCommentId, mapper.Map<AdComment>(updateModel));
        var ad = await adService.GetByIdAsync(updateModel.AdId);
        return mapper.Map<AdViewModel>(ad);
    }
} 