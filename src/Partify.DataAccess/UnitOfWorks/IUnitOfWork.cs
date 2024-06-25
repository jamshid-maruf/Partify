using Partify.DataAccess.Repositories;
using Partify.Domain.Entities.Appartments;
using Partify.Domain.Entities.Commons;
using Partify.Domain.Entities.Facilities;
using Partify.Domain.Entities.Users;

namespace Partify.DataAccess.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
	IRepository<User> UserRepository { get; }
	IRepository<Asset> AssetRepository { get; }
	IRepository<Merchant> MerchantRepository { get; }
	IRepository<Facility> FacilityRepository { get; }
	IRepository<Appartment> AppartmentRepository { get; }
	IRepository<AppartmentView> AppartmentViewRepository { get; }
	IRepository<AppartmentImage> AppartmentImageRepository { get; }
	IRepository<AppartmentScore> AppartmentScoreRepository { get; }
	IRepository<AppartmentComment> AppartmentCommentRepository { get; }
	IRepository<AppartmentFacility> AppartmentFacilityRepository { get; }
	IRepository<FavoriteAppartment> FavoriteAppartmentRepository { get; }
	IRepository<AppartmentCommentFile> AppartmentCommentFileRepository { get; }

	ValueTask<bool> SaveAsync();
	ValueTask BeginTransactionAsync();
	ValueTask CommitTransactionAsync();
	ValueTask Rollback();
}