﻿using Google.Protobuf;
using TbClient.Api.GetForumDetail.Entities;
using TbClient.Api.GetThreads.Entities;
using TbClient.core;
using TbClient.Exceptions;

namespace TbClient.Api.GetForumDetail;

public class GetForumDetail(HttpCore httpCore)
{
    private const int Cmd = 303021;

    public static byte[] PackProto(long fid)
    {
        var reqIdl = new GetForumDetailReqIdl()
        {
            Data = new()
            {
                Common = new()
                {
                    ClientVersion = Const.MainVersion
                },
               ForumId = fid
            }
        };
        return reqIdl.ToByteArray();
    }

    private static ForumDetail ParseBody(byte[] body)
    {
        var resProto = GetForumDetailResIdl.Parser.ParseFrom(body);
        var code = resProto.Error.Errorno;
        if (code != 0)
        {
            throw new TieBaServerException(code, resProto.Error.Errmsg ?? string.Empty);
        }

        var dataForum = resProto.Data;
       
        return ForumDetail.FromTbData(dataForum);
    }

    public async Task<ForumDetail> RequestAsync(long fid)
    {
        var data = PackProto(fid);
        var requestUri = new UriBuilder("https", Const.AppBaseHost, 443, "/c/f/forum/getforumdetail")
        {
            Query = $"cmd={Cmd}"
        }.Uri;

        var responseMessage = await httpCore.PackProtoRequest(requestUri, data);
        var result = await responseMessage.Content.ReadAsByteArrayAsync();
        return ParseBody(result);
    }
    
}