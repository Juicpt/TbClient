﻿using System.Text;
using Google.Protobuf;
using TbClient.Api.GetUInfoGetUserInfoApp.Entities;
using TbClient.core;
using TbClient.Exceptions;

namespace TbClient.Api.GetUInfoGetUserInfoApp;

public class GetUInfoGetUserInfoApp(HttpCore httpCore) : BaseApiRequest<int, UserInfoGuInfoApp, byte[]>
{
    private const int Cmd = 303024;

    public override async Task<UserInfoGuInfoApp> RequestAsync(int userId)
    {
        var data = PackProto(userId);
        var requestUri = new UriBuilder("http", Const.AppBaseHost, 80, "/c/u/user/getuserinfo")
        {
            Query = $"cmd={Cmd}"
        }.Uri;
        var responseMessage = await httpCore.PackProtoRequest(requestUri, data);
        var result = await responseMessage.Content.ReadAsByteArrayAsync();
        return ParseBody(result);
    }

    public override UserInfoGuInfoApp ParseBody(byte[] body)
    {
        var resProto = GetUserInfoResIdl.Parser.ParseFrom(body);
        var code = resProto.Error.Errorno;
        if (code != 0)
        {
            throw new TieBaServerException(code, resProto.Error.Errmsg ?? string.Empty);
        }

        var dataUser = resProto.Data.User;
        return UserInfoGuInfoApp.FromTbData(dataUser);
    }

    private static byte[] PackProto(int userId)
    {
        var reqProto = new GetUserInfoReqIdl
        {
            Data = new() { UserId = userId }
        };
        return reqProto.ToByteArray();
    }
}