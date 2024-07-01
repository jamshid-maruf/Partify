using Partify.DataAccess.UnitOfWorks;
using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;
using Partify.WebApi.Models.AddComments;

namespace Partify.WebApi.ApiServices.AdComments;

public class AdCommentApiService(IUnitOfWork unitOfWork) : IAdCommentApiService
{
	public ValueTask<AdCommentViewModel> CreateAsync(AdCommentCreateModel createModel)
	{
		throw new NotImplementedException();
	}

	public ValueTask<AdCommentViewModel> UpdateAsync(long id, AdCommentUpdateModel updateModel)
	{
		throw new NotImplementedException();
	}

	public ValueTask<bool> DeleteAsync(long id)
	{
		throw new NotImplementedException();
	}

	public ValueTask<AdCommentViewModel> GetByIdAsync(long id)
	{
		throw new NotImplementedException();
	}

	public ValueTask<IEnumerable<AdCommentViewModel>> GetAllAsync(PaginationParams @params, Filter filter)
	{
		throw new NotImplementedException();
	}
}