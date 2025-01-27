namespace AioTieba4DotNet.Api.Entities.Contents;

public class FragAt : IFrag
{
    public string Text { get; set; } = "";
    public long UserId { get; set; } = 0;

    public static FragAt FromTbData(PbContent dataProto)
    {
        var text = dataProto.Text;
        var userId = dataProto.Uid;
        return new FragAt { Text = text, UserId = userId };
    }

    public string GetFragType()
    {
        return "FragAt";
    }
}