﻿using AioTieba4DotNet.Api.GetThreads.Entities;
using AioTieba4DotNet.Core;
using AioTieba4DotNet.Exceptions;
using Google.Protobuf;

namespace AioTieba4DotNet.Api.GetThreads;

public class GetThreads(HttpCore httpCore)
{
    private const int Cmd = 301001;

    public static byte[] PackProto(string fname, int pn, int rn, int sort, int isGood)
    {
        var frsPageResIdl = new FrsPageReqIdl()
        {
            Data = new()
            {
                Common = new()
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