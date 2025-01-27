namespace AioTieba4DotNet.Exceptions;

public class TieBaServerException(int code, string msg) : Exception;