namespace AioTieba4DotNet.Api.Entities.Contents;

public class FragVoice : IFrag
{
    public string Md5 { get; set; } = "";
    public int Duration { get; set; } = 0;

    public static FragVoice? FromTbData(Voice dataProto)
    {
        var md5 = dataProto.VoiceMd5;
        var duration = dataProto.DuringTime / 1000;
        return new FragVoice { Md5 = md5, Duration = duration };
    }

    public bool IsValid()
    {
        return !string.IsNullOrEmpty(Md5);
    }

    public string GetFragType()
    {
        return "FragVoice";
    }
}