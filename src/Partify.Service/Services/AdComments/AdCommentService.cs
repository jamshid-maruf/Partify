using Microsoft.EntityFrameworkCore;
using Partify.DataAccess.UnitOfWorks;
using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;
using Partify.Service.Exceptions;
using Partify.Service.Extensions;

namespace Partify.Service.Services.AdComments;

public class AdCommentService(IUnitOfWork unitOfWork) : IAdCommentService
{
	public async ValueTask<AdComment> CreateAsync(AdComment adComment)
	{
		var existUser = await unitOfWork.UserRepository.SelectAsync(user => user.Id == adComment.UserId)
			?? throw new NotFoundException($"User is not found with this ID={adComment.UserId}");

		var existAd = await unitOfWork.AdRepository.SelectAsync(ad => ad.Id == adComment.AdId)
			?? throw new NotFoundException($"Ad is not found with this ID={adComment.AdId}");

		if (adComment.ParentId.HasValue)
		{
			var existParentAd = await unitOfWork.AdRepository.SelectAsync(ad => ad.Id == adComment.ParentId)
				?? throw new NotFoundException($"Ad is not found with this ID={adComment.ParentId}");
		}

		var createdAdComment = await unitOfWork.AdCommentRepository.InsertAsync(adComment);
		await unitOfWork.SaveAsync();
		return createdAdComment;
	}

	public async ValueTask<AdComment> UpdateAsync(long id, AdComment adComment)
	{
		var existAdComment = await unitOfWork.AdCommentRepository.SelectAsync(ac => ac.Id == id)
			?? throw new NotFoundException($"Comment is not found with this ID={id}");

		existAdComment.Comment = adComment.Comment;
		var updatedAdComment = await unitOfWork.AdCommentRepository.UpdateAsync(adComment);
		await unitOfWork.SaveAsync();

		return updatedAdComment;
	}

	public async ValueTask<bool> DeleteAsync(long id)
	{
		var existAdComment = await unitOfWork.AdCommentRepository.SelectAsync(ac => ac.Id == id)
			?? throw new NotFoundException($"Comment is not found with this ID={id}");

		await unitOfWork.AdCommentRepository.DeleteAsync(existAdComment);
		await unitOfWork.SaveAsync();

		return true;
	}

	public async ValueTask<AdComment> GetByIdAsync(long id)
	{
		var existAdComment = await unitOfWork.AdCommentRepository.SelectAsync(ac => ac.Id == id)
			?? throw new NotFoundException($"Comment is not found with this ID={id}");

		return existAdComment;
	}

	public async ValueTask<IEnumerable<AdComment>> GetAllAsync(PaginationParams @params, Filter filter)
	{
		var adComments = unitOfWork.AdCommentRepository.Select().OrderBy(filter);
		var pagedAdComments = adComments.ToPaginateAsQueryable(@params);
		return await pagedAdComments.ToListAsync();
	}
}