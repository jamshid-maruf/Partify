using Microsoft.EntityFrameworkCore;
using Partify.DataAccess.UnitOfWorks;
using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;
using Partify.Service.Exceptions;
using Partify.Service.Extensions;
using Partify.Service.Helpers;

namespace Partify.Service.Services.AdCategories;

public class AdCategoryService(IUnitOfWork unitOfWork) : IAdCategoryService
{
    public async ValueTask<AdCategory> CreateAsync(AdCategory adCategory)
    {
        var alreadyExistAdCategory = await unitOfWork.AdCategoryRepository
            .SelectAsync(ac => ac.Name.ToLower() == adCategory.Name.ToLower());
        if (alreadyExistAdCategory is not null)
            throw new AlreadyExistException($"This Ad Category is already exist with this name={adCategory.Name}");

        adCategory.CreatedById = HttpContextHelper.GetUserId;
        var createdAdCategory = await unitOfWork.AdCategoryRepository.InsertAsync(adCategory);
        await unitOfWork.SaveAsync();
        return createdAdCategory;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existAdCategory = await unitOfWork.AdCategoryRepository.SelectAsync(ac => ac.Id == id)
             ?? throw new NotFoundException($"This Ad Category is not found with this ID={id}");

        await unitOfWork.AdCategoryRepository.DeleteAsync(existAdCategory);
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<AdCategory>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var adCategories = unitOfWork.AdCategoryRepository.Select().OrderBy(filter);

        if (!string.IsNullOrWhiteSpace(search))
            adCategories = adCategories.Where(ac => ac.Name.ToLower().Contains(search.ToLower()));

        var pagedAdCategories = adCategories.ToPaginateAsQueryable(@params);
        return await pagedAdCategories.ToListAsync();
    }
    public async ValueTask<IEnumerable<AdCategory>> GetAllAsync()
    {
        return await unitOfWork.AdCategoryRepository.Select().ToListAsync();
    }

    public async ValueTask<AdCategory> GetByIdAsync(long id)
    {
        var existAdCategory = await unitOfWork.AdCategoryRepository.SelectAsync(ac => ac.Id == id)
            ?? throw new NotFoundException($"This Ad Category is not found with this ID={id}");

        return existAdCategory;
    }

    public async ValueTask<AdCategory> UpdateAsync(long id, AdCategory adCategory)
    {
        var existAdCategory = await unitOfWork.AdCategoryRepository.SelectAsync(ac => ac.Id == id)
             ?? throw new NotFoundException($"This Ad Category is not found with this ID={id}");

        var alreadyExistAdCategory = await unitOfWork.AdCategoryRepository
            .SelectAsync(ac => ac.Id != id && ac.Name.ToLower() == adCategory.Name.ToLower());
        if (alreadyExistAdCategory is not null)
            throw new AlreadyExistException($"This Ad Category is already exist with this name={adCategory.Name}");

        existAdCategory.Name = existAdCategory.Name;
        var updatedAdCategory = await unitOfWork.AdCategoryRepository.UpdateAsync(existAdCategory);
        await unitOfWork.SaveAsync();
        return updatedAdCategory;
    }
}
