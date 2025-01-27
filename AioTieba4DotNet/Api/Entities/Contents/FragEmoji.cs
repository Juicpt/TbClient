namespace AioTieba4DotNet.Api.Entities.Contents;

public class FragEmoji : IFrag
{
    public string Id { get; set; } = "";
    public string Desc { get; set; } = "";

    public static FragEmoji FromTbData(PbContent dataProto)
    {
        var id = dataProto.Text;
        var desc = dataProto.C;
        return new FragEmoji { Id = id, Desc = desc };
    }

    public string GetFragType()
    {
        return "FragEmoji";
    }
}