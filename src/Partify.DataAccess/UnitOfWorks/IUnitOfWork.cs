using Partify.DataAccess.Repositories;
using Partify.Domain.Entities.Ads;
using Partify.Domain.Entities.Commons;
using Partify.Domain.Entities.Facilities;
using Partify.Domain.Entities.Users;

namespace Partify.DataAccess.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
	IRepository<Ad> AdRepository { get; }
	IRepository<User> UserRepository { get; }
	IRepository<AssetViewModel> AssetRepository { get; }
	IRepository<AdView> AdViewRepository { get; }
	IRepository<AdImage> AdImageRepository { get; }
	IRepository<AdScore> AdScoreRepository { get; }
	IRepository<Merchant> MerchantRepository { get; }
	IRepository<Facility> FacilityRepository { get; }
	IRepository<UserRole> UserRoleRepository { get; }
	IRepository<AdComment> AdCommentRepository { get; }
	IRepository<Permission> PermissionRepository { get; }
	IRepository<AdFacility> AdFacilityRepository { get; }
	IRepository<FavoriteAd> FavoriteAdRepository { get; }
	IRepository<AdCategory> AdCategoryRepository { get; }
	IRepository<AdCommentFile> AdCommentFileRepository { get; }
	IRepository<AdPropertyValue> AdPropertyValueRepository { get; }
	IRepository<UserRolePermission> UserRolePermissionRepository { get; }
	IRepository<AdCategoryProperty> AdCategoryPropertyRepository { get; }

	ValueTask<bool> SaveAsync();
	ValueTask BeginTransactionAsync();
	ValueTask CommitTransactionAsync();
	ValueTask Rollback();
}