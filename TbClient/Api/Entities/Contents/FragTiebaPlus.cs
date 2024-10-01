﻿namespace TbClient.Api.Entities.Contents;

public class FragTiebaPlus : IFrag
{
    public string Text { get; set; } = "";
    public Uri Url { get; set; }

    public static FragTiebaPlus FromTbData(PbContent dataProto)
    {
        var text = dataProto.TiebaplusInfo.Desc;
        var url = new Uri(dataProto.TiebaplusInfo.JumpUrl);
        return new FragTiebaPlus { Text = text, Url = url };
    }

    public string GetFragType()
    {
        return "FragTiebaPlus";
    }
}