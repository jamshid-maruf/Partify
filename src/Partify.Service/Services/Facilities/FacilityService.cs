using Microsoft.EntityFrameworkCore;
using Partify.DataAccess.UnitOfWorks;
using Partify.Domain.Entities.Facilities;
using Partify.Service.Configurations;
using Partify.Service.Exceptions;
using Partify.Service.Extensions;
using Partify.Service.Helpers;

namespace Partify.Service.Services.Facilities;

public class FacilityService(IUnitOfWork unitOfWork) : IFacilityService
{
	public async ValueTask<Facility> CreateAsync(Facility facility)
	{
		var alreadyExistFacility = await unitOfWork.FacilityRepository
			.SelectAsync(f => f.Name.ToLower() == facility.Name.ToLower());
		if (alreadyExistFacility is not null)
			throw new AlreadyExistException($"This facility is already exist with this name={facility.Name}");

		facility.CreatedById = HttpContextHelper.GetUserId;
		var createdFacility = await unitOfWork.FacilityRepository.InsertAsync(facility);
		await unitOfWork.SaveAsync();
		return createdFacility;
	}

	public async ValueTask<Facility> UpdateAsync(long id, Facility facility)
	{
		var existFacility = await unitOfWork.FacilityRepository.SelectAsync(t => t.Id == id)
			?? throw new NotFoundException($"This facility is not found with this ID={id}");

		var alreadyExistFacility = await unitOfWork.FacilityRepository
			.SelectAsync(f => f.Id != id && f.Name.ToLower() == facility.Name.ToLower());
		if (alreadyExistFacility is not null)
			throw new AlreadyExistException($"This facility is already exist with this name={facility.Name}");

		existFacility.Name = facility.Name;
		existFacility.Icon = facility.Icon;
		var updatedFacility = await unitOfWork.FacilityRepository.UpdateAsync(existFacility);
		await unitOfWork.SaveAsync();
		return updatedFacility;
	}

	public async ValueTask<bool> DeleteAsync(long id)
	{
		var existFacility = await unitOfWork.FacilityRepository.SelectAsync(t => t.Id == id)
			?? throw new NotFoundException($"This facility is not found with this ID={id}");

		await unitOfWork.FacilityRepository.DeleteAsync(existFacility);
		await unitOfWork.SaveAsync();
		return true;
	}

	public async ValueTask<Facility> GetByIdAsync(long id)
	{
		var existFacility = await unitOfWork.FacilityRepository.SelectAsync(t => t.Id == id)
			?? throw new NotFoundException($"This facility is not found with this ID={id}");

		return existFacility;
	}

	public async ValueTask<IEnumerable<Facility>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
	{
		var facilities = unitOfWork.FacilityRepository.Select().OrderBy(filter);

		if (!string.IsNullOrWhiteSpace(search))
			facilities = facilities.Where(facility => facility.Name.ToLower().Contains(search.ToLower()));

		var pagedFacilities = facilities.ToPaginateAsQueryable(@params);
		return await pagedFacilities.ToListAsync();
	}
}
