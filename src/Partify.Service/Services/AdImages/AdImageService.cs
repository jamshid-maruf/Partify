using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Partify.DataAccess.UnitOfWorks;
using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;
using Partify.Service.Exceptions;
using Partify.Service.Extensions;
using Partify.Service.Helpers;
using Partify.Service.Services.Assets;

namespace Partify.Service.Services.AdImages;

public class AdImageService(IUnitOfWork unitOfWork, IAssetService assetService) : IAdImageService
{
	public async ValueTask<AdImage> CreateAsync(long adId, IFormFile file)
	{
		var exsitAd = await unitOfWork.AdRepository.SelectAsync(ad => ad.Id == adId)
			?? throw new NotFoundException($"Ad is not found with this ID={adId}");

		var createdAsset = await assetService.UploadAsync(file, "images");

		var adImage = new AdImage
		{
			AdId = adId,
			ImageId = createdAsset.Id,
			CreatedById = HttpContextHelper.GetUserId
		};
		var createdImage = await unitOfWork.AdImageRepository.InsertAsync(adImage);
		await unitOfWork.SaveAsync();

		return createdImage;
	}

	public async ValueTask<bool> DeleteAsync(long id)
	{
		var existAdImage = await unitOfWork.AdImageRepository.SelectAsync(image => image.Id == id)
			?? throw new NotFoundException($"Image is not found with this ID={id}");

		await unitOfWork.AdImageRepository.DeleteAsync(existAdImage);
		await unitOfWork.SaveAsync();
		return true;	
	}

	public async ValueTask<AdImage> GetAsync(long id)
	{
		var existAdImage = await unitOfWork.AdImageRepository
			.SelectAsync(expression: image => image.Id == id, includes: [ "Image", "Ad" ])
			?? throw new NotFoundException($"Image is not found with this ID={id}");

		return existAdImage;
	}
	
	public async ValueTask<IEnumerable<AdImage>> GetAllByAdIdAsync(long adId, Filter filter)
	{
		var exsitAd = await unitOfWork.AdRepository.SelectAsync(ad => ad.Id == adId)
			?? throw new NotFoundException($"Ad is not found with this ID={adId}");

		var images = await unitOfWork.AdImageRepository
			.Select(includes: ["Image", "Ad"])
			.OrderBy(filter)
			.ToListAsync();

		return images;
	}
}