namespace TbClient.Exceptions;

public class TieBaServerException(int code, string msg) : Exception;