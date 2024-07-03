using Partify.WebApi.Models.Users;

namespace Partify.WebApi.Models.AddComments;

public class AdCommentViewModel
{
	public AdCommentViewModel Parent { get; set; }
	public UserViewModel User { get; set; }
	// TODO: public AdViewModel Ad { get; set; }
	public string Comment { get; set; }
	// TODO: public ICollection<AdCommentFile> Files { get; set; }
}