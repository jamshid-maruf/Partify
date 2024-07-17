using Partify.DataAccess.DbContexts;
using Partify.DataAccess.Repositories;
using Partify.Domain.Entities.Ads;
using Partify.Domain.Entities.Commons;
using Partify.Domain.Entities.Facilities;
using Partify.Domain.Entities.Users;

namespace Partify.DataAccess.UnitOfWorks;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
	private readonly ApplicationDbContext context = context;
	public IRepository<Ad> AdRepository { get; } = new Repository<Ad>(context);
	public IRepository<User> UserRepository { get; } = new Repository<User>(context);
	public IRepository<Asset> AssetRepository { get; } = new Repository<Asset>(context);
	public IRepository<AdView> AdViewRepository { get; } = new Repository<AdView>(context);
	public IRepository<AdImage> AdImageRepository { get; } = new Repository<AdImage>(context);
	public IRepository<AdScore> AdScoreRepository { get; } = new Repository<AdScore>(context);
	public IRepository<Merchant> MerchantRepository { get; } = new Repository<Merchant>(context);
	public IRepository<Facility> FacilityRepository { get; } = new Repository<Facility>(context);
	public IRepository<UserRole> UserRoleRepository { get; } = new Repository<UserRole>(context);
	public IRepository<AdComment> AdCommentRepository { get; } = new Repository<AdComment>(context);
	public IRepository<AdFacility> AdFacilityRepository { get; } = new Repository<AdFacility>(context);
	public IRepository<FavoriteAd> FavoriteAdRepository { get; } = new Repository<FavoriteAd>(context);
	public IRepository<AdCategory> AdCategoryRepository { get; } = new Repository<AdCategory>(context);
	public IRepository<Permission> PermissionRepository { get; } = new Repository<Permission>(context);
	public IRepository<AdCommentFile> AdCommentFileRepository { get; } = new Repository<AdCommentFile>(context);
	public IRepository<AdCategoryPropertyValue> AdCategoryPropertyValueRepository { get; } = new Repository<AdCategoryPropertyValue>(context);
	public IRepository<UserRolePermission> UserRolePermissionRepository { get; } = new Repository<UserRolePermission>(context);
	public IRepository<AdCategoryProperty> AdCategoryPropertyRepository { get; } = new Repository<AdCategoryProperty>(context);

    public async ValueTask BeginTransactionAsync()
	{
		await context.Database.BeginTransactionAsync();
	}

	public async ValueTask CommitTransactionAsync()
	{
		await context.Database.CommitTransactionAsync();
	}

	public async ValueTask Rollback()
	{
		await context.Database.RollbackTransactionAsync();
	}

	public async ValueTask<bool> SaveAsync()
	{
		return await context.SaveChangesAsync() > 0;
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}
}