using Microsoft.EntityFrameworkCore;
using Partify.DataAccess.UnitOfWorks;
using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;
using Partify.Service.Exceptions;
using Partify.Service.Extensions;
using Partify.Service.Helpers;

namespace Partify.Service.Services.AdCategoryProperties;

public class AdCategoryPropertyService(IUnitOfWork unitOfWork) : IAdCategoryPropertyService
{
    public async ValueTask<AdCategoryProperty> CreateAsync(AdCategoryProperty adCategoryProperty)
    {
        var existCategory = await unitOfWork.AdCategoryRepository
            .SelectAsync(ac => ac.Id == adCategoryProperty.AdCategoryId)
            ?? throw new NotFoundException($"Category is not found with this ID= {adCategoryProperty.AdCategoryId}!");

        var alreadyExistAdCategoryProperty = await unitOfWork.AdCategoryPropertyRepository
        .SelectAsync(acp => acp.AdCategoryId == adCategoryProperty.AdCategoryId &&
                    acp.Name == adCategoryProperty.Name);
        if (alreadyExistAdCategoryProperty is not null)
            throw new AlreadyExistException($"Ad category property is already exist with this ad category ID= {adCategoryProperty.AdCategoryId} and property name= {adCategoryProperty.Name}!");

        adCategoryProperty.CreatedById = HttpContextHelper.GetUserId;
        var createdAdCategoryProperty = await unitOfWork.AdCategoryPropertyRepository.InsertAsync(adCategoryProperty);
        await unitOfWork.SaveAsync();
        return createdAdCategoryProperty;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existAdCategoryProperty = await unitOfWork.AdCategoryPropertyRepository.SelectAsync(acp => acp.Id == id)
           ?? throw new NotFoundException($"Ad category property is not found with this ID= {id}!");

        await unitOfWork.AdCategoryPropertyRepository.DeleteAsync(existAdCategoryProperty);
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<AdCategoryProperty>> GetAllByAdCategoryIdAsync(long categoryId)
    {
        var existAdCategory = await unitOfWork.AdCategoryRepository
            .SelectAsync(expression: ac => ac.Id == categoryId)
            ?? throw new NotFoundException($"Ad category is not found with this category ID= {categoryId}!");

        return await unitOfWork.AdCategoryPropertyRepository
            .Select(expression: urp => urp.AdCategoryId == categoryId, includes: ["AdCategory"])
            .ToListAsync();
    }

    public async ValueTask<IEnumerable<AdCategoryProperty>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var adCategoryProperties = unitOfWork.AdCategoryPropertyRepository
           .Select(includes: ["AdCategory"])
           .OrderBy(filter);

        if (!string.IsNullOrWhiteSpace(search))
            adCategoryProperties = adCategoryProperties.Where(adCategoryProperty =>
                adCategoryProperty.Name.ToLower().Contains(search.ToLower()) ||
                adCategoryProperty.AdCategory.Name.ToLower().Contains(search.ToLower()));

        var pagedAdCategoryProperties = adCategoryProperties.ToPaginateAsQueryable(@params);
        return await pagedAdCategoryProperties.ToListAsync();
    }

    public async ValueTask<AdCategoryProperty> GetByIdAsync(long id)
    {
        var existAdCategoryProperty = await unitOfWork.AdCategoryPropertyRepository
            .SelectAsync(expression: acp => acp.Id == id, includes: ["AdCategory"])
          ?? throw new NotFoundException($"Ad category property is not found with this ID= {id}!");

        return existAdCategoryProperty;
    }

    public async ValueTask<AdCategoryProperty> UpdateAsync(long id, AdCategoryProperty adCategoryProperty)
    {
        var existAdCategory = await unitOfWork.AdCategoryRepository
            .SelectAsync(ac => ac.Id == adCategoryProperty.AdCategoryId)
            ?? throw new NotFoundException($"Ad category is not found with this ID= {adCategoryProperty.AdCategoryId}!");

        var existAdCategoryProperty = await unitOfWork.AdCategoryPropertyRepository.SelectAsync(acp => acp.Id == id)
                       ?? throw new NotFoundException($"Ad category property is not found with this ID= {id}!");

        var alreadyExistAdCategoryProperty = await unitOfWork.AdCategoryPropertyRepository
            .SelectAsync(acp => acp.Id != id && acp.AdCategoryId == adCategoryProperty.AdCategoryId && acp.Name.ToLower() == adCategoryProperty.Name.ToLower());
        if (alreadyExistAdCategoryProperty is not null)
            throw new AlreadyExistException($"Ad category property is already exist with this ad category ID= {adCategoryProperty.AdCategoryId} and property name= {adCategoryProperty.Name}!");

        existAdCategoryProperty.AdCategoryId = adCategoryProperty.AdCategoryId;
        existAdCategoryProperty.Name = adCategoryProperty.Name;

        var updatedAdCategoryProperty = await unitOfWork.AdCategoryPropertyRepository.UpdateAsync(existAdCategoryProperty);
        await unitOfWork.SaveAsync();
        return updatedAdCategoryProperty;
    }

    public async ValueTask<IEnumerable<AdCategoryProperty>> GetAllAsync()
    {
        return await unitOfWork.AdCategoryPropertyRepository.Select(includes: ["AdCategory"]).ToListAsync();
    }
}
