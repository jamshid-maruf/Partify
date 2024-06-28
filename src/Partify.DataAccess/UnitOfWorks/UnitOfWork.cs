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
		UserRepository = new Repository<User>(context);
		AssetRepository = new Repository<Asset>(context);
		MerchantRepository = new Repository<Merchant>(context);
		FacilityRepository = new Repository<Facility>(context);
		AdRepository = new Repository<Ad>(context);
		AdViewRepository = new Repository<AdView>(context);
		AdImageRepository = new Repository<AdImage>(context);
		AdScoreRepository = new Repository<AdScore>(context);
		AdCommentRepository = new Repository<AdComment>(context);
		AdFacilityRepository = new Repository<AdFacility>(context);
		FavoriteAdRepository = new Repository<FavoriteAd>(context);
		AdCommentFileRepository = new Repository<AdCommentFile>(context);
	}

	public IRepository<User> UserRepository { get; }
	public IRepository<Asset> AssetRepository { get; }
	public IRepository<Merchant> MerchantRepository { get; }
	public IRepository<Facility> FacilityRepository { get; }
	public IRepository<Ad> AdRepository { get; }
	public IRepository<AdView> AdViewRepository { get; }
	public IRepository<AdImage> AdImageRepository { get; }
	public IRepository<AdScore> AdScoreRepository { get; }
	public IRepository<AdComment> AdCommentRepository { get; }
	public IRepository<AdFacility> AdFacilityRepository { get; }
	public IRepository<FavoriteAd> FavoriteAdRepository { get; }
	public IRepository<AdCommentFile> AdCommentFileRepository { get; }

    public IRepository<AdCategory> AdCategoryRepository { get; }

    public IRepository<AdPropertyValue> AdPropertyValueRepository { get; }

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