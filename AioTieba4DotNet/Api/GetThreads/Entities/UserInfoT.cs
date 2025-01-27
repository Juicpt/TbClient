using AioTieba4DotNet.Enums;

namespace AioTieba4DotNet.Api.GetThreads.Entities;

public class UserInfoT
{
    public long UserId { get; set; }
    public string UserName { get; set; } = "";
    public string Portrait { get; set; } = "";
    public string NickNameNew { get; init; } = "";
    public int Level { get; init; }
    public uint GLevel { get; init; }
    public Gender Gender { get; init; }
    public string[] Icons { get; init; } = [];
    public bool IsBawu { get; init; }
    public bool IsVip { get; init; }
    public bool IsGod { get; init; }
    public PrivLike PrivLike { get; init; }
    public PrivReply PrivReply { get; init; }

    public string NickName => NickNameNew;
    public string ShowName => NickNameNew == "" ? UserName : NickNameNew;

    public string LogName =>
        UserName != "" ? UserName : Portrait != "" ? $"{NickNameNew}/{Portrait}" : UserId.ToString();

    public static UserInfoT FromTbData(User dataProto)
    {
        var portrait = dataProto.Portrait;
        if (portrait.Contains('?'))
        {
            portrait = portrait[..^13];
        }

        var dataProtoId = dataProto.Id;
        var userName = dataProto.Name;
        var nickNameNew = dataProto.NameShow;
        var level = dataProto.LevelId;
        var gLevel = dataProto.UserGrowth.LevelId;
        var gender = (Gender)dataProto.Gender;
        var icons = dataProto.Iconinfo.Where(i => !string.IsNullOrEmpty(i.Name)).Select(i => i.Name).ToArray();
        var isBawu = dataProto.IsBawu == 1;
        var isVip = dataProto.NewTshowIcon.Count != 0;
        var isGod = dataProto.NewGodData is { Status: 1 };

        return new UserInfoT
        {
            UserId = dataProtoId,
            Portrait = portrait,
            UserName = userName,
            NickNameNew = nickNameNew,
            Level = level,
            GLevel = gLevel,
            Gender = gender,
            Icons = icons,
            IsBawu = isBawu,
            IsVip = isVip,
            IsGod = isGod,
            PrivLike = dataProto.PrivSets != null && dataProto.PrivSets.Like != 0
                ? (PrivLike)dataProto.PrivSets.Like
                : PrivLike.Public,
            PrivReply = dataProto.PrivSets != null && dataProto.PrivSets.Reply != 0
                ? (PrivReply)dataProto.PrivSets.Reply
                : PrivReply.All,
        };
    }

    public override string ToString()
    {
        return
            $"{nameof(UserId)}: {UserId}, {nameof(UserName)}: {UserName}, {nameof(Portrait)}: {Portrait}, {nameof(NickNameNew)}: {NickNameNew}, {nameof(Level)}: {Level}, {nameof(GLevel)}: {GLevel}, {nameof(Gender)}: {Gender}, {nameof(Icons)}: {Icons}, {nameof(IsBawu)}: {IsBawu}, {nameof(IsVip)}: {IsVip}, {nameof(IsGod)}: {IsGod}, {nameof(PrivLike)}: {PrivLike}, {nameof(PrivReply)}: {PrivReply}, {nameof(NickName)}: {NickName}, {nameof(ShowName)}: {ShowName}, {nameof(LogName)}: {LogName}";
    }
}