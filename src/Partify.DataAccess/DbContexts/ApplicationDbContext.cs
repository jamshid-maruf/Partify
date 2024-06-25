using Microsoft.EntityFrameworkCore;
using Partify.Domain.Entities.Appartments;
using Partify.Domain.Entities.Commons;
using Partify.Domain.Entities.Facilities;
using Partify.Domain.Entities.Users;

namespace Partify.DataAccess.DbContexts;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	public DbSet<Appartment> Appartments { get; set; }
	public DbSet<AppartmentComment> AppartmentComments { get; set; }
	public DbSet<AppartmentCommentFile> AppartmentCommentFiles { get; set; }
	public DbSet<AppartmentFacility> AppartmentFacilities { get; set; }
	public DbSet<AppartmentImage> AppartmentImages { get; set; }
	public DbSet<AppartmentScore> AppartmentScores { get; set; }
	public DbSet<AppartmentView> AppartmentViews { get; set; }
	public DbSet<FavoriteAppartment> FavoriteAppartments { get; set; }
	public DbSet<Asset> Assets { get; set; }
	public DbSet<Facility> Facilities { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<Merchant> Merchants { get; set; }
}