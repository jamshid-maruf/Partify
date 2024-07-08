using Microsoft.EntityFrameworkCore;
using Partify.DataAccess.UnitOfWorks;
using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;
using Partify.Service.Exceptions;
using Partify.Service.Extensions;
using Partify.Service.Helpers;

namespace Partify.Service.Services.AdFacilities;

public class AdFacilityService(IUnitOfWork unitOfWork) : IAdFacilityService
{
    public async ValueTask<AdFacility> CreateAsync(AdFacility adFacility)
    {
        var existFacility = await unitOfWork.FacilityRepository
        .SelectAsync(f => f.Id == adFacility.FacilityId)
            ?? throw new NotFoundException($"Facility is not found with this ID= {adFacility.FacilityId}!");

        var existAd = await unitOfWork.AdRepository
        .SelectAsync(a => a.Id == adFacility.AdId)
            ?? throw new NotFoundException($"Ad is not found with this ID= {adFacility.AdId}!");

        var alreadyExistAdFacility = await unitOfWork.AdFacilityRepository
        .SelectAsync(af =>
                    af.AdId == adFacility.AdId &&
                    af.FacilityId == adFacility.FacilityId);
        if (alreadyExistAdFacility is not null)
            throw new AlreadyExistException($"Ad facility is already exist with this ad ID= {adFacility.AdId} and facility ID= {adFacility.FacilityId}!");

        adFacility.CreatedById = HttpContextHelper.GetUserId;
        var createdAdFacility = await unitOfWork.AdFacilityRepository.InsertAsync(adFacility);
        await unitOfWork.SaveAsync();
        return createdAdFacility;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existAdFacility = await unitOfWork.AdFacilityRepository.SelectAsync(af => af.Id == id)
             ?? throw new NotFoundException($"Ad facility is not found with this ID= {id}!");

        await unitOfWork.AdFacilityRepository.DeleteAsync(existAdFacility);
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<AdFacility>> GetAllByFacilityIdAsync(long facilityId)
    {
        var existFacility = await unitOfWork.FacilityRepository
           .SelectAsync(expression: f => f.Id == facilityId)
           ?? throw new NotFoundException($"Facility is not found with this facility ID= {facilityId}!");

        return await unitOfWork.AdFacilityRepository
            .Select(expression: af => af.FacilityId == facilityId, includes: ["Ad", "Facility"])
            .ToListAsync();
    }

    public async ValueTask<IEnumerable<AdFacility>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var adFacilities = unitOfWork.AdFacilityRepository
            .Select(includes: ["Facility", "Ad"])
            .OrderBy(filter);

        if (!string.IsNullOrWhiteSpace(search))
            adFacilities = adFacilities.Where(adFacility =>
                adFacility.Facility.Name.ToLower().Contains(search.ToLower()) ||
                adFacility.Ad.Description.ToLower().Contains(search.ToLower()));

        var pagedAdFacilities = adFacilities.ToPaginateAsQueryable(@params);
        return await pagedAdFacilities.ToListAsync();
    }

    public async ValueTask<AdFacility> GetByIdAsync(long id)
    {

        var existAdFacility = await unitOfWork.AdFacilityRepository
            .SelectAsync(expression: af => af.Id == id, includes: ["Ad", "Facility"])
          ?? throw new NotFoundException($"Ad facility is not found with this ID= {id}!");

        return existAdFacility;
    }

    public async ValueTask<AdFacility> UpdateAsync(long id, AdFacility adFacility)
    {
        var existFacility = await unitOfWork.FacilityRepository
           .SelectAsync(f => f.Id == adFacility.FacilityId)
           ?? throw new NotFoundException($"Facility is not found with this ID= {adFacility.FacilityId}!");

        var existAd = await unitOfWork.AdRepository
            .SelectAsync(a => a.Id == adFacility.AdId)
            ?? throw new NotFoundException($"Ad is not found with this ID= {adFacility.AdId}!");

        var existAdFacility = await unitOfWork.AdFacilityRepository.SelectAsync(af => af.Id == id)
               ?? throw new NotFoundException($"Ad facility is not found with this ID= {id}!");

        var alreadyExistAdFacility = await unitOfWork.AdFacilityRepository
            .SelectAsync(
            af => af.Id != id &&
            af.FacilityId == adFacility.FacilityId &&
            af.AdId == adFacility.AdId);
        if (alreadyExistAdFacility is not null)
            throw new AlreadyExistException($"Ad facility is already exist with this facility ID= {adFacility.FacilityId} and ad ID= {adFacility.AdId}!");

        existAdFacility.FacilityId = adFacility.FacilityId;
        existAdFacility.AdId = adFacility.AdId;

        var updatedAdFacility = await unitOfWork.AdFacilityRepository.UpdateAsync(existAdFacility);
        await unitOfWork.SaveAsync();
        return updatedAdFacility;
    }
}
