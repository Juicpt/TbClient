using TbClient.Api.GetUInfoGetUserInfoApp.Entities;
using TbClient.Enums;

namespace TbClient.Api.Profile.GetUInfoProfile.Entities;

public class UserInfoPf : UserInfoGuInfoApp
{
    public string NickNameNew { get; init; } = "";
    public string TieBaUid { get; init; } = "";
    public int GLevel { get; init; }
    public string Age { get; init; } = "";
    public int PostNum { get; init; }
    public int AgreeNum { get; init; }
    public int FanNum { get; init; }
    public int FollowNum { get; init; }
    public int ForumNum { get; init; }
    public string Sign { get; init; } = "";
    public string Ip { get; init; } = "";
    public string[] Icons { get; init; } = [];
    public required VirtualImagePf VImage { get; init; }
    public bool IsBlocked { get; init; }
    public PrivLike PrivLike { get; init; }
    public PrivReply PrivReply { get; init; }
    public new string NickName => NickNameNew;
    public string ShowName => NickNameNew == "" ? UserName : NickNameNew;

    public new string LogName =>
        UserName != "" ? UserName : Portrait != "" ? $"{NickNameNew}/{Portrait}" : UserId.ToString();

    public static UserInfoPf FromTbData(ProfileResIdl.Types.DataRes dataProto)
    {
        var userProto = dataProto.User;
        var antiStatProto = dataProto.AntiStat;
        var portrait = userProto.Portrait;
        if (portrait.Contains('?'))
        {
            portrait = portrait[..^13];
        }

        return new UserInfoPf
        {
            UserId = (int)userProto.Id,
            Portrait = portrait,
            UserName = userProto.Name,
            NickNameNew = userProto.NameShow,
            TieBaUid = userProto.TiebaUid,
            GLevel = (int)userProto.UserGrowth.LevelId,
            Gender = (Gender)userProto.Gender,
            Age = userProto.TbAge,
            PostNum = userProto.PostNum,
            AgreeNum = (int)dataProto.UserAgreeInfo.TotalAgreeNum,
            FanNum = userProto.FansNum,
            FollowNum = userProto.ConcernNum,
            ForumNum = userProto.MyLikeNum,
            Sign = userProto.Intro,
            Ip = userProto.IpAddress,
            Icons = userProto.Iconinfo.Where(i => !string.IsNullOrEmpty(i.Name)).Select(i => i.Name).ToArray(),
            VImage = VirtualImagePf.FromTbData(userProto.VirtualImageInfo),
            IsVip = userProto.NewTshowIcon.Count != 0,
            IsGod = userProto.NewGodData.Status == 1,
            IsBlocked = antiStatProto.BlockStat != 0 && antiStatProto.HideStat != 0 && antiStatProto.DaysTofree > 30,
            PrivLike = userProto.PrivSets.Like != 0 ? (PrivLike)userProto.PrivSets.Like : PrivLike.Public,
            PrivReply = userProto.PrivSets.Reply != 0 ? (PrivReply)userProto.PrivSets.Reply : PrivReply.All,
        };
    }


    public override string ToString()
    {
        return
            $"{nameof(NickNameNew)}: {NickNameNew}, {nameof(TieBaUid)}: {TieBaUid},{nameof(UserId)}: {UserId}, {nameof(GLevel)}: {GLevel}, {nameof(Age)}: {Age}, {nameof(PostNum)}: {PostNum}, {nameof(AgreeNum)}: {AgreeNum}, {nameof(FanNum)}: {FanNum}, {nameof(FollowNum)}: {FollowNum}, {nameof(ForumNum)}: {ForumNum}, {nameof(Sign)}: {Sign}, {nameof(Ip)}: {Ip}, {nameof(Icons)}: {Icons}, {nameof(VImage)}: {VImage}, {nameof(IsBlocked)}: {IsBlocked}, {nameof(PrivLike)}: {PrivLike}, {nameof(PrivReply)}: {PrivReply}, {nameof(NickName)}: {NickName}, {nameof(ShowName)}: {ShowName}, {nameof(LogName)}: {LogName}, {nameof(Portrait)}: {Portrait}";
    }
}