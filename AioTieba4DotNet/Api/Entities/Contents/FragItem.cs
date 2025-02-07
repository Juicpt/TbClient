﻿namespace AioTieba4DotNet.Api.Entities.Contents;

/// <summary>
/// item碎片
/// </summary>
public class FragItem : IFrag
{
    /// <summary>
    /// item名称
    /// </summary>
    public string Text { get; init; } = "";

    /// <summary>
    /// 从贴吧原始数据转换
    /// </summary>
    /// <param name="dataProto"></param>
    /// <returns>FragItem</returns>
    public static FragItem FromTbData(PbContent dataProto)
    {
        var text = dataProto.Item.ItemName;
        return new FragItem { Text = text };
    }

    /// <summary>
    /// 碎片类型
    /// </summary>
    /// <returns>string</returns>
    public string GetFragType()
    {
        return "FragItem";
    }

    /// <summary>
    /// 格式设置成员
    /// </summary>
    /// <returns>string</returns>
    public override string ToString()
    {
        return $"{GetFragType()} {nameof(Text)}: {Text}";
    }
}