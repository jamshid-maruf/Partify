using Microsoft.EntityFrameworkCore;
using Partify.DataAccess.EntityConfigurations;
using Partify.Domain.Entities.Ads;
using Partify.Domain.Entities.Commons;
using Partify.Domain.Entities.Facilities;
using Partify.Domain.Entities.Users;

namespace Partify.DataAccess.DbContexts;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	public DbSet<Ad> Ads { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<Asset> Assets { get; set; }
	public DbSet<AdView> AdViews { get; set; }
	public DbSet<AdImage> AdImages { get; set; }
	public DbSet<AdScore> AdScores { get; set; }
	public DbSet<Merchant> Merchants { get; set; }
	public DbSet<UserRole> UserRoles { get; set; }
	public DbSet<Facility> Facilities { get; set; }
	public DbSet<AdComment> AdComments { get; set; }
	public DbSet<Permission> Permissions { get; set; }
	public DbSet<FavoriteAd> FavoriteAds { get; set; }
	public DbSet<AdFacility> AdFacilities { get; set; }
	public DbSet<AdCategory> AdCategories { get; set; }
	public DbSet<AdCommentFile> AdCommentFiles { get; set; }
	public DbSet<AdCategoryPropertyValue> AdPropertyValues { get; set; }
	public DbSet<UserRolePermission> UserRolePermissions { get; set; }
	public DbSet<AdCategoryProperty> AdCategoryProperties { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdEntityTypeConfiguration).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityTypeConfiguration).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssetEntityTypeConfiguration).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdViewEntityTypeConfiguration).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdImageEntityTypeConfiguration).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdScoreEntityTypeConfiguration).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserRoleEntityTypeConfiguration).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(FacilityEntityTypeConfiguration).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(MerchantEntityTypeConfiguration).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdCommentEntityTypeConfiguration).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(PermissionEntityTypeConfiguration).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdCategoryEntityTypeConfiguration).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdFacilityEntityTypeConfiguration).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(FavoriteAdEntityTypeConfiguration).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdCommentFileEntityTypeConfiguration).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdPropertyValueEntityTypeConfiguration).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserRolePermissionEntityTypeConfiguration).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdCategoryPropertyEntityTypeConfiguration).Assembly);

		modelBuilder.Entity<Ad>().HasQueryFilter(entity => !entity.IsDeleted);
		modelBuilder.Entity<User>().HasQueryFilter(entity => !entity.IsDeleted);
		modelBuilder.Entity<Asset>().HasQueryFilter(entity => !entity.IsDeleted);
		modelBuilder.Entity<AdView>().HasQueryFilter(entity => !entity.IsDeleted);
		modelBuilder.Entity<AdImage>().HasQueryFilter(entity => !entity.IsDeleted);
		modelBuilder.Entity<AdScore>().HasQueryFilter(entity => !entity.IsDeleted);
		modelBuilder.Entity<UserRole>().HasQueryFilter(entity => !entity.IsDeleted);
		modelBuilder.Entity<Merchant>().HasQueryFilter(entity => !entity.IsDeleted);
		modelBuilder.Entity<Facility>().HasQueryFilter(entity => !entity.IsDeleted);
		modelBuilder.Entity<AdComment>().HasQueryFilter(entity => !entity.IsDeleted);
		modelBuilder.Entity<Permission>().HasQueryFilter(entity => !entity.IsDeleted);
		modelBuilder.Entity<AdCategory>().HasQueryFilter(entity => !entity.IsDeleted);
		modelBuilder.Entity<AdFacility>().HasQueryFilter(entity => !entity.IsDeleted);
		modelBuilder.Entity<FavoriteAd>().HasQueryFilter(entity => !entity.IsDeleted);
		modelBuilder.Entity<AdCommentFile>().HasQueryFilter(entity => !entity.IsDeleted);
		modelBuilder.Entity<AdCategoryPropertyValue>().HasQueryFilter(entity => !entity.IsDeleted);
		modelBuilder.Entity<UserRolePermission>().HasQueryFilter(entity => !entity.IsDeleted);
		modelBuilder.Entity<AdCategoryProperty>().HasQueryFilter(entity => !entity.IsDeleted);
	}
}