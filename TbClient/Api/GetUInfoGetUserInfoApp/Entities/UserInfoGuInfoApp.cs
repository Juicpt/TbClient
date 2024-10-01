using TbClient.Api.Login;
using TbClient.Enums;

namespace TbClient.Api.GetUInfoGetUserInfoApp.Entities;

public class UserInfoGuInfoApp : UserInfoLogin
{
    public string NickNameOld { get; init; } = "";
    public Gender Gender { get; init; }
    public bool IsVip { get; init; }
    public bool IsGod { get; init; }

    public string NickName => NickNameOld;

    public string LogName =>
        UserName != "" ? UserName : Portrait != "" ? $"{NickNameOld}/{Portrait}" : UserId.ToString();

    public static UserInfoGuInfoApp FromTbData(User dataProto)
    {
        var dataProtoPortrait = dataProto.Portrait;
        if (dataProtoPortrait.Contains('?'))
        {
            dataProtoPortrait = dataProtoPortrait[..^13];
        }

        return new UserInfoGuInfoApp()
        {
            UserId = (int)dataProto.Id,
            Portrait = dataProtoPortrait,
            UserName = dataProto.Name,
            NickNameOld = dataProto.NameShow,
            Gender = (Gender)dataProto.Gender,
            IsVip = dataProto.VipInfo.VStatus != 0,
            IsGod = dataProto.NewGodData.Status != 0,
        };
    }

    public override string ToString()
    {
        return
            $"{nameof(UserId)}: {UserId}, {nameof(Portrait)}: {Portrait}, {nameof(UserName)}: {UserName}, {nameof(NickNameOld)}: {NickNameOld}, {nameof(Gender)}: {Gender}, {nameof(IsVip)}: {IsVip}, {nameof(IsGod)}: {IsGod}, {nameof(NickName)}: {NickName}, {nameof(LogName)}: {LogName}";
    }
}