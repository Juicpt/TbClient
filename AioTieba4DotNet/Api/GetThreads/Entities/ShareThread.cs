using AioTieba4DotNet.Api.Entities;

namespace AioTieba4DotNet.Api.GetThreads.Entities;

public class ShareThread
{
    public required Content Content { get; set; }
    public string Title { get; set; } = "";
    public long AuthorId { get; set; }
    public long Fid { get; set; } = 0;
    public string Fname { get; set; } = "";
    public int Tid { get; set; } = 0;
    public long Pid { get; set; } = 0;
    public VoteInfo? VoteInfo { get; set; }

    public static ShareThread FromTbData(ThreadInfo.Types.OriginThreadInfo threadInfo)
    {
        return new ShareThread()
        {
            Content = Content.FromTbData(threadInfo),
            AuthorId = threadInfo.Content.Count != 0 ? threadInfo.Content.First().Uid : 0,
            Title = threadInfo.Title,
            Fid = threadInfo.Fid,
            Fname = threadInfo.Fname,
            Tid = threadInfo.Tid != null ? Convert.ToInt16(threadInfo.Tid) : 0,
            Pid = threadInfo.Pid,
            VoteInfo = threadInfo.PollInfo != null ? VoteInfo.FromTbData(threadInfo.PollInfo) : null,
        };
    }
}