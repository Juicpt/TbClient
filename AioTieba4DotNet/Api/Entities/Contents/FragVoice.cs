﻿namespace AioTieba4DotNet.Api.Entities.Contents;

/// <summary>
/// 音频碎片
/// </summary>
public class FragVoice : IFrag
{
    /// <summary>
    /// 音频md5
    /// </summary>
    public string Md5 { get; init; } = "";

    /// <summary>
    /// 音频长度 以秒为单位
    /// </summary>
    public int Duration { get; init; }

    /// <summary>
    /// 从贴吧原始数据转换
    /// </summary>
    /// <param name="dataProto"></param>
    /// <returns>FragVoice</returns>
    public static FragVoice FromTbData(Voice dataProto)
    {
        var md5 = dataProto.VoiceMd5;
        var duration = dataProto.DuringTime / 1000;
        return new FragVoice { Md5 = md5, Duration = duration };
    }

    /// <summary>
    /// 是否存在音频
    /// </summary>
    /// <returns>bool</returns>
    public bool IsValid()
    {
        return !string.IsNullOrEmpty(Md5);
    }

    /// <summary>
    /// 碎片类型
    /// </summary>
    /// <returns>string</returns>
    public string GetFragType()
    {
        return "FragVoice";
    }

    /// <summary>
    /// 格式设置成员
    /// </summary>
    /// <returns>string</returns>
    public override string ToString()
    {
        return $"{nameof(Md5)}: {Md5}, {nameof(Duration)}: {Duration}";
    }
}