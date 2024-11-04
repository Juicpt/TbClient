using Newtonsoft.Json.Linq;
using TbClient.core;
using TbClient.Entities;
using TbClient.Enums;

namespace TbClient.Api.GetUInfoPanel.Entities;

public class UserInfoPanel : BaseUser
{
    /// <summary>
    /// 新版昵称
    /// </summary>
    public string NickNameNew { get; init; } = "";

    /// <summary>
    /// 旧版昵称
    /// </summary>

    public string NickNameOld { get; init; } = "";

    /// <summary>
    /// 性别
    /// </summary>
    public Gender Gender { get; init; }

    /// <summary>
    /// 吧龄
    /// </summary>
    public float Age { get; init; }

    /// <summary>
    /// 发帖数
    /// </summary>
    public int PostNum { get; init; }

    /// <summary>
    /// 粉丝数
    /// </summary>
    public int FanNum { get; init; }

    /// <summary>
    /// 是否超级会员
    /// </summary>
    public bool IsVip { get; init; }

    /// <summary>
    /// 用户昵称
    /// </summary>
    public new string NickName => NickNameNew;

    /// <summary>
    /// 显示名称
    /// </summary>
    public string ShowName => NickNameNew != "" ? NickName : UserName;

    /// <summary>
    /// 用于在日志中记录用户信息
    /// </summary>
    public string LogName => UserName != "" ? UserName : $"{NickNameNew}/{Portrait}";


    public static UserInfoPanel FromTbData(JObject data)
    {
        var portrait = data.GetValue("portrait")?.ToObject<string>() ?? "";
        if (portrait.Contains('?'))
        {
            portrait = portrait[..^13];
        }

        var isVip = false;
        var vipInfoToken = data.GetValue("vipInfo");
        JObject? vipInfoObject = null;
        if (vipInfoToken is { Type: JTokenType.Object })
        {
            vipInfoObject = vipInfoToken.ToObject<JObject>();
        }

        var vStatus = vipInfoObject?.GetValue("v_status")?.ToObject<int>() ?? 0;
        float age = 0;
        if (data.GetValue("tb_age")?.ToObject<string>() != "-")
        {
            age = data.GetValue("tb_age")!.ToObject<float>();
        }

        if (vStatus == 3)
        {
            isVip = true;
        }

        return new UserInfoPanel()
        {
            Portrait = portrait,
            UserName = data["name"]?.ToObject<string>() ?? "",
            NickNameNew = data["show_nickname"]?.ToObject<string>() ?? "",
            NickNameOld = data["name_show"]?.ToObject<string>() ?? "",
            Gender = (data["gender"]?.ToObject<string>() ?? "") == "male" ? Gender.Male : Gender.Female,
            Age = age,
            IsVip = isVip,
            PostNum = Utils.TbNumToInt(data["post_num"]?.ToObject<string>() ?? "0"),
            FanNum = Utils.TbNumToInt(data["followed_count"]?.ToObject<string>() ?? "0"),
        };
    }

    public override string ToString()
    {
        return
            $"{base.ToString()}, {nameof(NickNameNew)}: {NickNameNew}, {nameof(NickNameOld)}: {NickNameOld}, {nameof(Gender)}: {Gender}, {nameof(Age)}: {Age}, {nameof(PostNum)}: {PostNum}, {nameof(FanNum)}: {FanNum}, {nameof(IsVip)}: {IsVip}, {nameof(NickName)}: {NickName}, {nameof(ShowName)}: {ShowName}, {nameof(LogName)}: {LogName}";
    }
}