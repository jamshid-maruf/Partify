using Partify.Web.Models.Users;

namespace Partify.Web.Models.Ads;

public class AdCommentViewModel
{
    public AdCommentViewModel Parent { get; set; }
    public UserViewModel User { get; set; }
    public string Comment { get; set; }
    public ICollection<AdCommentFileViewModel> Files { get; set; }
}