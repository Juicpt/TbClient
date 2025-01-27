using System.Text.RegularExpressions;

namespace AioTieba4DotNet.Api.Entities.Contents;

public partial class FragImage : IFrag
{
    [GeneratedRegex("/([a-z0-9]{32,})\\.")]
    private static partial Regex MyRegex();

    private static readonly Regex ImageHashExp = MyRegex();

    public string Src { get; set; } = "";
    public string BigSrc { get; set; } = "";
    public string OriginSrc { get; set; } = "";
    public uint OriginSize { get; set; } = 0;
    public int ShowWidth { get; set; } = 0;
    public int ShowHeight { get; set; } = 0;
    public string Hash { get; set; } = "";

    public static FragImage FromTbData(PbContent dataProto)
    {
        var src = dataProto.CdnSrc;
        var bigSrc = dataProto.BigCdnSrc;
        var originSrc = dataProto.OriginSrc;
        var originSize = dataProto.OriginSize;

        var bSize = dataProto.Bsize.Split(',');
        var showWidth = int.Parse(bSize[0]);
        var showHeight = int.Parse(bSize[1]);

        var hash = ImageHashExp.Match(src).Groups[1].Value;

        return new FragImage
        {
            Src = src,
            BigSrc = bigSrc,
            OriginSrc = originSrc,
            OriginSize = originSize,
            ShowWidth = showWidth,
            ShowHeight = showHeight,
            Hash = hash
        };
    }

    public string GetFragType()
    {
        return "FragImage";
    }
}