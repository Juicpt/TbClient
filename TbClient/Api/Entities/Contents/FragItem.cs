namespace TbClient.Api.Entities.Contents;

public class FragItem : IFrag
{
    public string Text { get; set; } = "";

    public static FragItem FromTbData(PbContent dataProto)
    {
        var text = dataProto.Item.ItemName;
        return new FragItem { Text = text };
    }

    public string GetFragType()
    {
        return "FragItem";
    }
}