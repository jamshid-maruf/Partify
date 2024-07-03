using Partify.Domain.Entities.Ads;
using Partify.Domain.Entities.Users;

namespace Partify.WebApi.Models.AdScores;

public class AdScoreCreateModel
{
    public int Score { get; set; }
    public long UserId { get; set; }
    public long AdId { get; set; }
}
