using Microsoft.EntityFrameworkCore;
using Partify.DataAccess.UnitOfWorks;
using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;
using Partify.Service.Exceptions;
using Partify.Service.Extensions;
using Partify.Service.Helpers;
namespace Partify.Service.Services.AdCategoryPropertyValues;

public class AdCategoryPropertyValueService(IUnitOfWork unitOfWork) : IAdCategoryPropertyValueService
{
    public async ValueTask<AdCategoryPropertyValue> CreateAsync(AdCategoryPropertyValue adCategoryPropertyValue)
    {
        var alreadyExistAdPropertyValue = await unitOfWork.AdCategoryPropertyValueRepository
            .SelectAsync(acpv => acpv.Value.ToLower() == adCategoryPropertyValue.Value.ToLower());
        if (alreadyExistAdPropertyValue is not null)
            throw new AlreadyExistException($"This Ad Category Property Value is already exist with this value= {adCategoryPropertyValue.Value}");

        adCategoryPropertyValue.CreatedById = HttpContextHelper.GetUserId;
        var createdAdCategoryPropertyValue = await unitOfWork.AdCategoryPropertyValueRepository.InsertAsync(adCategoryPropertyValue);
        await unitOfWork.SaveAsync();
        return adCategoryPropertyValue;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existAdCategoryPropertyValue = await unitOfWork.AdCategoryPropertyValueRepository.SelectAsync(acpv => acpv.Id == id)
             ?? throw new NotFoundException($"This Ad Category Property Value is not found with this ID={id}");

        await unitOfWork.AdCategoryPropertyValueRepository.DeleteAsync(existAdCategoryPropertyValue);
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<AdCategoryPropertyValue>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var adCategoryPropertyValues = unitOfWork.AdCategoryPropertyValueRepository.Select().OrderBy(filter);

        if (!string.IsNullOrWhiteSpace(search))
            adCategoryPropertyValues = adCategoryPropertyValues.Where(acpv => acpv.Value.ToLower().Contains(search.ToLower()));

        var pagedAdCategories = adCategoryPropertyValues.ToPaginateAsQueryable(@params);
        return await pagedAdCategories.ToListAsync();
    }
    public async ValueTask<IEnumerable<AdCategoryPropertyValue>> GetAllAsync()
    {
        return await unitOfWork.AdCategoryPropertyValueRepository.Select().ToListAsync();
    }

    public async ValueTask<AdCategoryPropertyValue> GetByIdAsync(long id)
    {
        var existAdCategoryPropertyValue = await unitOfWork.AdCategoryPropertyValueRepository.SelectAsync(acpv => acpv.Id == id)
            ?? throw new NotFoundException($"This Ad Category Property Value is not found with this ID={id}");
        return existAdCategoryPropertyValue;
    }

    public async ValueTask<AdCategoryPropertyValue> UpdateAsync(long id, AdCategoryPropertyValue adCategoryPropertyValue)
    {
        var existAdCategoryPropertyValue = await unitOfWork.AdCategoryPropertyValueRepository.SelectAsync(acpv => acpv.Id == id)
             ?? throw new NotFoundException($"This Ad Category Property Value is not found with this ID={id}");

        var alreadyExistAdCategoryPropertyValue = await unitOfWork.AdCategoryPropertyValueRepository
            .SelectAsync(acpv => acpv.Id != id && acpv.Value.ToLower() == adCategoryPropertyValue.Value.ToLower());
        if (adCategoryPropertyValue is not null)
            throw new AlreadyExistException($"This Ad Category Property Value is already exist with this value= {adCategoryPropertyValue.Value}");

        existAdCategoryPropertyValue.Value = adCategoryPropertyValue.Value;
        var updatedAdCategoryPropertyValue = await unitOfWork.AdCategoryPropertyValueRepository
            .UpdateAsync(existAdCategoryPropertyValue);
        await unitOfWork.SaveAsync();
        return updatedAdCategoryPropertyValue;
    }
}
