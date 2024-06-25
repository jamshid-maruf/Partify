using Partify.DataAccess.DbContexts;
using Partify.DataAccess.Repositories;
using Partify.Domain.Entities.Appartments;
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
		AppartmentRepository = new Repository<Appartment>(context);
		AppartmentViewRepository = new Repository<AppartmentView>(context);
		AppartmentImageRepository = new Repository<AppartmentImage>(context);
		AppartmentScoreRepository = new Repository<AppartmentScore>(context);
		AppartmentCommentRepository = new Repository<AppartmentComment>(context);
		AppartmentFacilityRepository = new Repository<AppartmentFacility>(context);
		FavoriteAppartmentRepository = new Repository<FavoriteAppartment>(context);
		AppartmentCommentFileRepository = new Repository<AppartmentCommentFile>(context);
	}

	public IRepository<User> UserRepository { get; }
	public IRepository<Asset> AssetRepository { get; }
	public IRepository<Merchant> MerchantRepository { get; }
	public IRepository<Facility> FacilityRepository { get; }
	public IRepository<Appartment> AppartmentRepository { get; }
	public IRepository<AppartmentView> AppartmentViewRepository { get; }
	public IRepository<AppartmentImage> AppartmentImageRepository { get; }
	public IRepository<AppartmentScore> AppartmentScoreRepository { get; }
	public IRepository<AppartmentComment> AppartmentCommentRepository { get; }
	public IRepository<AppartmentFacility> AppartmentFacilityRepository { get; }
	public IRepository<FavoriteAppartment> FavoriteAppartmentRepository { get; }
	public IRepository<AppartmentCommentFile> AppartmentCommentFileRepository { get; }

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