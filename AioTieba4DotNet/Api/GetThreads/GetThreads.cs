using AioTieba4DotNet.Api.GetThreads.Entities;
using AioTieba4DotNet.Core;
using AioTieba4DotNet.Exceptions;
using Google.Protobuf;

namespace AioTieba4DotNet.Api.GetThreads;

/// <summary>
/// 
/// </summary>
/// <param name="httpCore"></param>
public class GetThreads(HttpCore httpCore)
{
    private const int Cmd = 301001;

    private static byte[] PackProto(string fname, int pn, int rn, int sort, int isGood)
    {
        var frsPageResIdl = new FrsPageReqIdl()
        {
            Data = new FrsPageReqIdl.Types.DataReq
            {
                Common = new CommonReq
                {
                    ClientType = 2,
                    ClientVersion = Const.MainVersion
                },
                Kw = fname,
                Pn = pn,
                Rn = rn,
                RnNeed = 10,
                IsGood = isGood,
                SortType = sort,
                LoadType = 1,
            }
        };
        return frsPageResIdl.ToByteArray();
    }

    private static Threads ParseBody(byte[] body)
    {
        var resProto = FrsPageResIdl.Parser.ParseFrom(body);
        var code = resProto.Error.Errorno;
        if (code != 0)
        {
            throw new TieBaServerException(code, resProto.Error.Errmsg ?? string.Empty);
        }

        var dataForum = resProto.Data;

        return Threads.FromTbData(dataForum);
    }
    /// <summary>
    /// 异步请求
    /// </summary>
    /// <param name="fname">贴吧名</param>
    /// <param name="pn">页码</param>
    /// <param name="rn">每页条数</param>
    /// <param name="sort">排序</param>
    /// <param name="isGood">是否精品贴</param>
    /// <returns></returns>
    public async Task<Threads> RequestAsync(string fname, int pn, int rn, int sort, int isGood)
    {
        var data = PackProto(fname, pn, rn, sort, isGood);
        var requestUri = new UriBuilder("https", Const.AppBaseHost, 443, "/c/f/frs/page")
        {
            Query = $"cmd={Cmd}"
        }.Uri;

        var responseMessage = await httpCore.PackProtoRequest(requestUri, data);
        var result = await responseMessage.Content.ReadAsByteArrayAsync();
        return ParseBody(result);
    }
}