namespace AioTieba4DotNet.Enums;

[Flags]
public enum ReqUInfo
{
    UserId = 1,
    Portrait = 2,
    UserName = 3,
    NickName = 4,
    TiebaUid = 5,
    Other = 6,
    Basic = UserId | Portrait | UserName,
    All = Basic | NickName | TiebaUid | Other
}