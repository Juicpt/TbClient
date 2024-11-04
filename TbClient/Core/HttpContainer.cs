using System.Net;

namespace TbClient.Core;

public record HttpContainer(Dictionary<string, string> Headers, CookieContainer Cookies);
