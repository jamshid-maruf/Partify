using Partify.Domain.Entities.Ads;
using Partify.WebApi.Models.Ads;
using Partify.WebApi.Models.Users;

namespace Partify.WebApi.Models.AddComments;

public class AdCommentViewModel
{
	public AdCommentViewModel Parent { get; set; }
	public UserViewModel User { get; set; }
	public AdViewModel Ad { get; set; }
	public string Comment { get; set; }
	public ICollection<AdCommentFile> Files { get; set; }
}