namespace TbClient.Api.Entities.Contents;

public class FragText : IFrag
{
    public string Text { get; set; } = "";

    public static FragText FromTbData(PbContent dataProto)
    {
        string text = dataProto.Text;
        return new FragText { Text = text };
    }

    public string GetFragType()
    {
        return "FragText";
    }
}