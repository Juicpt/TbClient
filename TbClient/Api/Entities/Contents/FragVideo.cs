namespace TbClient.Api.Entities.Contents;

public class FragVideo : IFrag
{
    public string Src { get; set; } = "";
    public string CoverSrc { get; set; } = "";
    public uint Duration { get; set; } = 0;
    public uint Width { get; set; } = 0;
    public uint Height { get; set; } = 0;
    public int ViewNum { get; set; } = 0;

    public static FragVideo FromTbData(VideoInfo dataProto)
    {
        var src = dataProto.VideoUrl;
        var coverSrc = dataProto.ThumbnailUrl;
        var duration = dataProto.VideoDuration;
        var width = dataProto.VideoWidth;
        var height = dataProto.VideoHeight;
        var viewNum = dataProto.PlayCount;
        return new FragVideo
        {
            Src = src,
            CoverSrc = coverSrc,
            Duration = duration,
            Width = width,
            Height = height,
            ViewNum = viewNum
        };
    }

    public bool IsValid()
    {
        return Width > 0;
    }

    public string GetFragType()
    {
        return "FragVideo";
    }
}