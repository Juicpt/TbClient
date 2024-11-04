using System.Net;

namespace TbClient.Core;

public record NetCore(string ProxyUrl, NetworkCredential ProxyCredential);
