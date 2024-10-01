using TbClient.Api.Entities;
using TbClient.Api.Profile.GetUInfoProfile;

namespace TbClient.Api.GetThreads.Entities;

public class Thread
{
    public Content Content { get; set; }
    public string Title { get; set; } = "";
    public long Fid { get; set; } = 0;
    public string Fname { get; set; } = "";
    public long Tid { get; set; } = 0;
    public long Pid { get; set; } = 0;
    public UserInfoT User { get; set; }
    public long AuthorId { get; set; } = 0;
    public VirtualImagePf VirtualImage { get; set; }
    public int Type { get; set; } = 0;
    public int TabId;
    public bool IsGood { get; set; } = false;
    public bool IsTop { get; set; } = false;
    public bool IsShare { get; set; } = false;
    public bool IsHide { get; set; } = false;
    public bool IsLivePost { get; set; } = false;
    public VoteInfo? VoteInfo { get; set; }
    public ShareThread? ShareThread { get; set; }
    public int ViewNum { get; set; } = 0;
    public int ReplyNum { get; set; } = 0;
    public int ShareNum { get; set; } = 0;
    public long Agree { get; set; } = 0;
    public long Disagree { get; set; } = 0;
    public int CreateTime { get; set; } = 0;
    public int UpdateTime { get; set; } = 0;

    public static Thread FromTbData(ThreadInfo threadInfo)
    {
        return new Thread()
        {
            Content = Content.FromTbData(threadInfo),
            Title = threadInfo.Title,
            Tid = threadInfo.Id,
            Pid = threadInfo.FirstPostId,
            AuthorId = threadInfo.AuthorId,
            VirtualImage = VirtualImagePf.FromTbData(threadInfo),
            Type = threadInfo.ThreadType,
            TabId = threadInfo.TabId,
            IsGood = threadInfo.IsGood == 1,
            IsTop = threadInfo.IsTop == 1,
            IsShare = threadInfo.IsShareThread == 1,
            IsHide = threadInfo.IsFrsMask == 1,
            IsLivePost = threadInfo.IsLivepost == 1,
            VoteInfo = threadInfo.PollInfo != null ? VoteInfo.FromTbData(threadInfo.PollInfo) : null,
            ShareThread = threadInfo is { IsShareThread: 1, OriginThreadInfo.Pid: 0 }
                ? ShareThread.FromTbData(threadInfo.OriginThreadInfo)
                : null,
            ViewNum = threadInfo.ViewNum,
            ReplyNum = threadInfo.ReplyNum,
            ShareNum = threadInfo.ShareNum,
            Agree = threadInfo.Agree.AgreeNum,
            Disagree = threadInfo.Agree.DisagreeNum,
            CreateTime = threadInfo.CreateTime,
            UpdateTime = threadInfo.LastTimeInt
        };
    }

    public override string ToString()
    {
        return
            $"{nameof(TabId)}: {TabId}, {nameof(Content)}: {Content}, {nameof(Title)}: {Title}, {nameof(Fid)}: {Fid}, {nameof(Fname)}: {Fname}, {nameof(Tid)}: {Tid}, {nameof(Pid)}: {Pid}, {nameof(User)}: {User}, {nameof(AuthorId)}: {AuthorId}, {nameof(VirtualImage)}: {VirtualImage}, {nameof(Type)}: {Type}, {nameof(IsGood)}: {IsGood}, {nameof(IsTop)}: {IsTop}, {nameof(IsShare)}: {IsShare}, {nameof(IsHide)}: {IsHide}, {nameof(IsLivePost)}: {IsLivePost}, {nameof(VoteInfo)}: {VoteInfo}, {nameof(ShareThread)}: {ShareThread}, {nameof(ViewNum)}: {ViewNum}, {nameof(ReplyNum)}: {ReplyNum}, {nameof(ShareNum)}: {ShareNum}, {nameof(Agree)}: {Agree}, {nameof(Disagree)}: {Disagree}, {nameof(CreateTime)}: {CreateTime}, {nameof(UpdateTime)}: {UpdateTime}";
    }
}