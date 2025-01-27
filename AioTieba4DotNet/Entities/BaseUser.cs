namespace AioTieba4DotNet.Entities;

public class BaseUser
{
    /// <summary>
    /// portrait
    /// </summary>
    public string Portrait { get; init; } = "";

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; init; } = "";


    public override string ToString()
    {
        return $"{nameof(Portrait)}: {Portrait}, {nameof(UserName)}: {UserName}";
    }

    protected bool Equals(BaseUser other)
    {
        return Portrait == other.Portrait;
    }
}