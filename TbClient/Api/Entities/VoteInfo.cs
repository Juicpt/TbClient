namespace TbClient.Api.Entities;

public class VoteInfo
{
    public string Title { get; set; } = string.Empty;
    public bool IsMulti { get; set; }
    public List<VoteOption> Options { get; set; } = [];
    public long TotalVotes { get; set; }
    public long TotalUsers { get; set; }

    public static VoteInfo FromTbData(PollInfo voteInfo)
    {
        return new VoteInfo()
        {
            Title = voteInfo.Title,
            IsMulti = voteInfo.IsMulti == 1,
            Options = voteInfo.Options.Select(VoteOption.FromTbData).ToList(),
            TotalVotes = voteInfo.TotalPoll,
            TotalUsers = voteInfo.TotalNum
        };
    }
}