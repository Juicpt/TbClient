﻿using Google.Protobuf;
using TbClient.Api.Profile.GetUInfoProfile.Entities;
using TbClient.Core;
using TbClient.Exceptions;

namespace TbClient.Api.Profile.GetUInfoProfile;

public class GetUInfoProfile<T>(HttpCore httpCore) : BaseApiRequest<T, UserInfoPf, byte[]>
{
    private const int Cmd = 303012;

    private static byte[] PackProto<TP>(TP uidOrPortrait)
    {
        if (!(typeof(TP) == typeof(string) || typeof(TP) == typeof(int)))
        {
            throw new InvalidOperationException($"TP's type is {typeof(TP)} now.TP must be either string or int.");
        }

        var reqProto = new ProfileReqIdl()
        {
            Data = new()
            {
                Common = new()
                {
                    ClientType = 2,
                    ClientVersion = Const.MainVersion,
                },
                NeedPostCount = 1,
                Page = 1
            }
        };

        if (typeof(T) == typeof(int))
        {
            reqProto.Data.Uid = Convert.ToInt32(uidOrPortrait);
        }

        if (typeof(T) == typeof(string))
        {
            reqProto.Data.FriendUidPortrait = Convert.ToString(uidOrPortrait);
        }

        return reqProto.ToByteArray();
    }
    

    public override UserInfoPf ParseBody(byte[] body)
    {
        var resProto = ProfileResIdl.Parser.ParseFrom(body);
        var code = resProto.Error.Errorno;
        if (code != 0)
        {
            throw new TieBaServerException(code, resProto.Error.Errmsg ?? string.Empty);
        }

        var resProtoData = resProto.Data;
        return UserInfoPf.FromTbData(resProtoData);
    }

    public override async Task<UserInfoPf> RequestAsync(T requestParams)
    {
        var data = PackProto(requestParams);
        var requestUri = new UriBuilder("http", Const.AppBaseHost, 80, "/c/u/user/profile")
        {
            Query = $"cmd={Cmd}"
        }.Uri;
        var responseMessage = await httpCore.PackProtoRequest(requestUri, data);
        var result = await responseMessage.Content.ReadAsByteArrayAsync();
        return ParseBody(result);
    }
}