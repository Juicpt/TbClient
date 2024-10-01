using TbClient.core;

namespace TbClient.Api.GetUInfoPanel;

public class GetUInfoPanel<T>(HttpCore httpCore) : BaseApiRequest<T, string, byte[]>
{
    public override string ParseBody(byte[] body)
    {
        throw new NotImplementedException();
    }

    public override Task<string> RequestAsync(T requestParams)
    {
        throw new NotImplementedException();
    }
}