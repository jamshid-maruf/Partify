namespace Partify.Web.Models.Ads;

public class AdCommentUpdateModel
{
    public long? ParentId { get; set; }
    public long UserId { get; set; }
    public long AdId { get; set; }
    public string Comment { get; set; }
    public ICollection<AdCommentFileCreateModel> Files { get; set; }
}