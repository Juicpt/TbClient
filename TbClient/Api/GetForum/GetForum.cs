using Newtonsoft.Json.Linq;
using TbClient.Api.GetForum.Entities;
using TbClient.core;
using TbClient.Exceptions;

namespace TbClient.Api.GetForum;

public record GetFormParams(string Fname);

public class GetForum(HttpCore httpCore) : BaseApiRequest<GetFormParams, Forum>
{
    public override Forum ParseBody(string body)
    {
        var o = JObject.Parse(body);
        var code = o.GetValue("error_code")?.ToObject<int>();
        if (code != null && code != 0)
        {
            throw new TieBaServerException(code ?? -1, o.GetValue("error_msg")?.ToObject<string>() ?? string.Empty);
        }

        var forumDict = o.GetValue("forum")?.ToObject<Dictionary<string, object>>();
        if (forumDict == null)
        {
            throw new TieBaServerException(-1, "无法获取到贴吧数据!");
        }

        return Forum.FromTbData(forumDict);
    }

    public override async Task<Forum> RequestAsync(GetFormParams requestParams)
    {
        var data = new List<KeyValuePair<string, string>>()
        {
            new("kw", requestParams.Fname)
        };
        var requestUri = new UriBuilder("https", Const.WebBaseHost, 443, "/c/f/frs/frsBottom").Uri;

        var responseMessage = await httpCore.PackAppFormRequest(requestUri, data);
        var result = await responseMessage.Content.ReadAsStringAsync();
        Console.WriteLine(result);
        return ParseBody(result);
    }
}