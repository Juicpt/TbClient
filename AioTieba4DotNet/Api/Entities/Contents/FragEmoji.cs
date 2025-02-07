﻿namespace AioTieba4DotNet.Api.Entities.Contents;

/// <summary>
/// 表情碎片
/// </summary>
public class FragEmoji : IFrag
{
    /// <summary>
    /// 表情图片id
    /// </summary>
    public string Id { get; init; } = "";

    /// <summary>
    /// 表情描述
    /// </summary>
    public string Desc { get; init; } = "";

    /// <summary>
    /// 从贴吧原始数据转换
    /// </summary>
    /// <param name="dataProto"></param>
    /// <returns>FragEmoji</returns>
    public static FragEmoji FromTbData(PbContent dataProto)
    {
        var id = dataProto.Text;
        var desc = dataProto.C;
        return new FragEmoji { Id = id, Desc = desc };
    }

    /// <summary>
    /// 碎片类型
    /// </summary>
    /// <returns>string</returns>
    public string GetFragType()
    {
        return "FragEmoji";
    }

    /// <summary>
    /// 格式设置成员
    /// </summary>
    /// <returns>string</returns>
    public override string ToString()
    {
        return $"{GetFragType()} {nameof(Id)}: {Id}, {nameof(Desc)}: {Desc}";
    }
}