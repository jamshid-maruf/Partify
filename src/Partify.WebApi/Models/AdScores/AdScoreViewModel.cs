using Partify.WebApi.Models.Users;

namespace Partify.WebApi.Models.AdScores;

public class AdScoreViewModel
{
    public long Id { get; set; }
    public int Score { get; set; }
    public UserViewModel User { get; set; }
    public AdViewModel Ad { get; set; }
}
