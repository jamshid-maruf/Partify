using Partify.Domain.Entities.Ads;
using Partify.Domain.Entities.Users;
using Partify.Service.Configurations;
using X.PagedList;

namespace Partify.Service.Services.Ads;

public interface IAdService
{
    ValueTask<Ad> CreateAsync(Ad ad);
    ValueTask<Ad> UpdateAsync(long id, Ad ad);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Ad> GetByIdAsync(long id);
    ValueTask<IEnumerable<Ad>> GetAllAsync(
        PaginationParams @params,
        Filter filter,
        string search = null,
        long? categoryId = null);
    ValueTask<IPagedList<Ad>> GetAllAsync(int? page, string search = null, long? categoryId = null);
}