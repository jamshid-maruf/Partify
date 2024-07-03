using Microsoft.EntityFrameworkCore;
using Partify.DataAccess.UnitOfWorks;
using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;
using Partify.Service.Exceptions;
using Partify.Service.Extensions;

namespace Partify.Service.Services.FavoriteAds;

public class FavoriteAdService(IUnitOfWork unitOfWork) : IFavoriteAdService
{
	public async ValueTask<FavoriteAd> CreateAsync(FavoriteAd favoriteAd)
	{
		var exsitUser = await unitOfWork.UserRepository.SelectAsync(user => user.Id == favoriteAd.UserId)
			?? throw new NotFoundException("This user is not found");

		var existAd = await unitOfWork.AdRepository.SelectAsync(ad => ad.Id == favoriteAd.AdId)
			?? throw new NotFoundException($"Ad is not found with this ID={favoriteAd.AdId}");

		var createdFavoriteAd = await unitOfWork.FavoriteAdRepository.InsertAsync(favoriteAd);
		await unitOfWork.SaveAsync();

		return createdFavoriteAd;
	}

	public async ValueTask<bool> DeleteAsync(long id)
	{
		var existFavoriteAd = await unitOfWork.FavoriteAdRepository.SelectAsync(fa => fa.Id == id)
			?? throw new NotFoundException($"Ad is not found with this ID={id}");

		await unitOfWork.FavoriteAdRepository.DeleteAsync(existFavoriteAd);
		await unitOfWork.SaveAsync();

		return true;
	}
	public async ValueTask<FavoriteAd> GetByIdAsync(long id)
	{
		var existFavoriteAd = await unitOfWork.FavoriteAdRepository.SelectAsync(fa => fa.Id == id)
			?? throw new NotFoundException($"Ad is not found with this ID={id}");

		return existFavoriteAd;
	}

	public async ValueTask<IEnumerable<FavoriteAd>> GetAllAsync(PaginationParams @params)
	{
		var favoriteAds = unitOfWork.FavoriteAdRepository.Select();
		var pagedFavorite = favoriteAds.ToPaginateAsQueryable(@params);

		return await pagedFavorite.ToListAsync();
	}
}