using System.Net;

namespace TbClient.core;

public record HttpContainer(Dictionary<string, string> Headers, CookieContainer Cookies);
