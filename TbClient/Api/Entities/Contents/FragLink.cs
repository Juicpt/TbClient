namespace TbClient.Api.Entities.Contents;

public class FragLink :IFrag
{
    public string Text { get; set; } = "";
    public string Title { get; set; } = "";
    public Uri RawUrl { get; set; }
    public Uri? Url => IsExternal ? new Uri(RawUrl.Query.Substring(RawUrl.Query.IndexOf("url=") + 4)) : RawUrl;
    public bool IsExternal => RawUrl.AbsolutePath == "/mo/q/checkurl";

    public static FragLink FromTbData(PbContent dataProto)
    {
        var text = dataProto.Link;
        var title = dataProto.Text;
        var rawUrl = new Uri(text);
        return new FragLink { Text = text, Title = title, RawUrl = rawUrl };
    }

    public string GetFragType()
    {
        return "FragLink";
    }
}