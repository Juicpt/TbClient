using AioTieba4DotNet.Entities;
using Newtonsoft.Json.Linq;

namespace AioTieba4DotNet.Api.GetUInfoUserJson.Entities;

public class UserInfoJson : BaseUser
{
    public long UserId { get; init; }
    public string LogName => UserName != "" ? UserName : Portrait != "" ? $"{UserId}/{Portrait}" : UserId.ToString();

    public static UserInfoJson FromTbData(JObject data)
    {
        return new UserInfoJson
        {
            UserName = "",
            UserId = data["id"]!.ToObject<long>(),
            Portrait = data["portrait"]!.ToString(),
        };
    }
    public override string ToString()
    {
        return
            $"{base.ToString()}, {nameof(UserId)}: {UserId}, {nameof(LogName)}: {LogName}, {nameof(UserName)}: {UserName}, {nameof(Portrait)}: {Portrait}";
    }
  
}