using Microsoft.EntityFrameworkCore;
using Partify.DataAccess.UnitOfWorks;
using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;
using Partify.Service.Exceptions;
using Partify.Service.Extensions;

namespace Partify.Service.Services.Ads;

public class AdService(IUnitOfWork unitOfWork) : IAdService
{
	public async ValueTask<Ad> CreateAsync(Ad ad)
	{
		var existAdCategory = await unitOfWork.AdCategoryRepository
			.SelectAsync(category => category.Id == ad.AdCategoryId)
			?? throw new NotFoundException($"Category is not found with this ID={ad.AdCategoryId}");

		var exsitMerchant = await unitOfWork.MerchantRepository
			.SelectAsync(merchant => merchant.Id == ad.MerchantId)
			?? throw new NotFoundException($"Merchant is not found with this ID={ad.MerchantId}");

		var createdAd = await unitOfWork.AdRepository.InsertAsync(ad);
		await unitOfWork.SaveAsync();

		return createdAd;
	}

	public async ValueTask<Ad> UpdateAsync(long id, Ad ad)
	{
		var existAd = await unitOfWork.AdRepository.SelectAsync(ad => ad.Id == id)
			?? throw new NotFoundException($"Ad is not found with this ID={id}");

		existAd.Phone = ad.Phone;
		existAd.Price = ad.Price;
		existAd.Title = ad.Title;
		existAd.Address = ad.Address;
		existAd.Description = ad.Description;

		existAd.Properties.Clear();
		foreach (var property in ad.Properties)
			existAd.Properties.Add(property);

		var updatedAd = await unitOfWork.AdRepository.UpdateAsync(existAd);
		await unitOfWork.SaveAsync();

		return updatedAd;
	}

	public async ValueTask<bool> DeleteAsync(long id)
	{
		var existAd = await unitOfWork.AdRepository.SelectAsync(ad => ad.Id == id)
			?? throw new NotFoundException($"Ad is not found with this ID={id}");

		await unitOfWork.AdRepository.DeleteAsync(existAd);
		await unitOfWork.SaveAsync();

		return true;
	}

	public async ValueTask<Ad> GetByIdAsync(long id)
	{
		var existAd = await unitOfWork.AdRepository.SelectAsync(ad => ad.Id == id)
			?? throw new NotFoundException($"Ad is not found with this ID={id}");

		return existAd;
	}

	public async ValueTask<IEnumerable<Ad>> GetAllAsync(PaginationParams @params, Filter filter, string search = null, long? categoryId = null)
	{
		var ads = unitOfWork.AdRepository.Select().OrderBy(filter);

		if (categoryId.HasValue)
			ads = ads.Where(ad => ad.AdCategoryId == categoryId);

		if (!string.IsNullOrWhiteSpace(search))
			ads = ads.Where(ad =>
				ad.Title.ToLower().Contains(search.ToLower()) ||
				ad.Address.ToLower().Contains(search.ToLower()) ||
				ad.Price.ToString().Contains(search.ToLower()));

		var pagedAds = ads.ToPaginateAsQueryable(@params);
		return await pagedAds.ToListAsync();
	}
}