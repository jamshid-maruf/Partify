using Partify.DataAccess.DbContexts;
using Partify.DataAccess.Repositories;
using Partify.Domain.Entities.Ads;
using Partify.Domain.Entities.Commons;
using Partify.Domain.Entities.Facilities;
using Partify.Domain.Entities.Users;

namespace Partify.DataAccess.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
	private readonly ApplicationDbContext context;
	public UnitOfWork(ApplicationDbContext context)
	{
		this.context = context;
		AdRepository = new Repository<Ad>(context);
		UserRepository = new Repository<User>(context);
		AssetRepository = new Repository<AssetViewModel>(context);
		AdViewRepository = new Repository<AdView>(context);
		AdImageRepository = new Repository<AdImage>(context);
		AdScoreRepository = new Repository<AdScore>(context);
		MerchantRepository = new Repository<Merchant>(context);
		FacilityRepository = new Repository<Facility>(context);
		UserRoleRepository = new Repository<UserRole>(context);
		AdCommentRepository = new Repository<AdComment>(context);
		AdFacilityRepository = new Repository<AdFacility>(context);
		PermissionRepository = new Repository<Permission>(context);
		FavoriteAdRepository = new Repository<FavoriteAd>(context);
		AdCommentFileRepository = new Repository<AdCommentFile>(context);
		UserRolePermissionRepository = new Repository<UserRolePermission>(context);
	}

	public IRepository<Ad> AdRepository { get; }
	public IRepository<User> UserRepository { get; }
	public IRepository<AssetViewModel> AssetRepository { get; }
	public IRepository<AdView> AdViewRepository { get; }
	public IRepository<AdImage> AdImageRepository { get; }
	public IRepository<AdScore> AdScoreRepository { get; }
	public IRepository<Merchant> MerchantRepository { get; }
	public IRepository<Facility> FacilityRepository { get; }
	public IRepository<UserRole> UserRoleRepository { get; }
	public IRepository<AdComment> AdCommentRepository { get; }
	public IRepository<AdFacility> AdFacilityRepository { get; }
	public IRepository<FavoriteAd> FavoriteAdRepository { get; }
    public IRepository<AdCategory> AdCategoryRepository { get; }
	public IRepository<Permission> PermissionRepository { get; }
	public IRepository<AdCommentFile> AdCommentFileRepository { get; }
    public IRepository<AdPropertyValue> AdPropertyValueRepository { get; }
	public IRepository<UserRolePermission> UserRolePermissionRepository { get; }
    public IRepository<AdCategoryProperty> AdCategoryPropertyRepository { get; }

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