using TbClient.Api.Block;
using TbClient.Api.GetFid;
using TbClient.Api.GetForumDetail;
using TbClient.Api.GetForumDetail.Entities;
using TbClient.Api.GetThreads;
using TbClient.Api.GetThreads.Entities;
using TbClient.Api.GetUInfoGetUserInfoApp;
using TbClient.Api.GetUInfoGetUserInfoApp.Entities;
using TbClient.Api.GetUInfoPanel;
using TbClient.Api.GetUInfoPanel.Entities;
using TbClient.Api.GetUInfoUserJson;
using TbClient.Api.GetUInfoUserJson.Entities;
using TbClient.Api.Login;
using TbClient.Api.Login.Entities;
using TbClient.Api.Profile.GetUInfoProfile;
using TbClient.Api.Profile.GetUInfoProfile.Entities;
using TbClient.core;
using TbClient.Core;
using TbClient.Entities;
using TbClient.Enums;

namespace TbClient;

public class Client
{
    private Account? Account { get; set; }
    private string? Bduss { get; set; }
    private UserInfoLogin? User { get; set; }
    private string? Stoken { get; set; }
    private readonly HttpCore _httpCore;

    private readonly ForumInfoCache _forumInfoCache = new ForumInfoCache();

    /// <summary>
    /// 设置贴子获取时排序方法
    /// </summary>
    public ThreadSortType ThreadSortType { get; set; } = ThreadSortType.REPLY;

    /// <summary>
    /// 设置获取贴子时，是否获取精品贴
    /// </summary>
    public bool ThreadIsGood { get; set; }

    /// <summary>
    /// 设置获取贴子时，默认获取数量
    /// </summary>
    public int ThreadRn { get; set; } = 30;

    public Client()
    {
        _httpCore = new HttpCore();
    }

    public Client(string bduss, string stoken)
    {
        Bduss = bduss;
        Stoken = stoken;
        _httpCore = new HttpCore();
        if (Bduss == null || Stoken == null) return;
        Account = new Account(Bduss, Stoken);
        _httpCore.SetAccount(Account);
    }

    /// <summary>
    /// 根据贴吧名获取Fid
    /// </summary>
    /// <param name="fname">贴吧名</param>
    /// <returns>fid</returns>
    public async Task<ulong> GetFid(string fname)
    {
        var forumId = _forumInfoCache.GetForumId(fname);
        if (forumId != 0)
        {
            return forumId;
        }

        var getFid = new GetFid(_httpCore);
        forumId = await getFid.RequestAsync(fname);
        _forumInfoCache.SetForumName(forumId, fname);

        return forumId;
    }

    public async Task<string> GetFname(ulong fid)
    {
        var forumName = _forumInfoCache.GetForumName(fid);
        if (!string.IsNullOrEmpty(forumName))
        {
            return forumName;
        }

        var forumDetail = await GetForumDetail(fid);
        forumName = forumDetail.Fname;
        _forumInfoCache.SetForumName(fid, forumName);

        return forumName;
    }

    /// <summary>
    /// 获取贴吧详细信息
    /// </summary>
    /// <param name="fid">fid</param>
    /// <returns></returns>
    public async Task<ForumDetail> GetForumDetail(ulong fid)
    {
        var getForumDetail = new GetForumDetail(_httpCore);
        var forumDetail = await getForumDetail.RequestAsync((long)fid);
        return forumDetail;
    }

    /// <summary>
    /// 获取贴吧详细信息
    /// </summary>
    /// <param name="fname"></param>
    /// <returns></returns>
    public async Task<ForumDetail> GetForumDetail(string fname)
    {
        var fid = await GetFid(fname);
        return await GetForumDetail(fid);
    }

    /// <summary>
    /// 获取首页帖子
    /// </summary>
    /// <param name="fname">贴吧名</param>
    /// <param name="pn">页码. Defaults to 1.</param>
    /// <param name="rn">请求的条目数. Defaults to 30. Max to 100.</param>
    /// <param name="sort"> HOT热门排序</param>
    /// <param name="isGood">True则获取精品区帖子 False则获取普通区帖子. Defaults to False.</param>
    /// <returns></returns>
    public async Task<Threads> GetThreads(string fname, int pn, int rn, ThreadSortType sort, bool isGood)
    {
        var getThreads = new GetThreads(_httpCore);
        return await getThreads.RequestAsync(fname, pn, rn, (int)sort, isGood ? 1 : 0);
    }

    /// <summary>
    /// 获取首页帖子
    /// </summary>
    /// <param name="fid">fid</param>
    /// <param name="pn">页码. Defaults to 1.</param>
    /// <param name="rn">请求的条目数. Defaults to 30. Max to 100.</param>
    /// <param name="sort"> HOT热门排序</param>
    /// <param name="isGood">True则获取精品区帖子 False则获取普通区帖子. Defaults to False.</param>
    /// <returns></returns>
    public async Task<Threads> GetThreads(ulong fid, int pn, int rn, ThreadSortType sort, bool isGood)
    {
        var fname = await GetFname(fid);
        return await GetThreads(fname, pn, rn, sort, isGood);
    }

    /// <summary>
    /// 获取首页帖子
    /// </summary>
    /// <param name="fid">fid</param>
    /// <param name="pn">页码. Defaults to 1.</param>
    /// <returns></returns>
    public async Task<Threads> GetThreads(ulong fid, int pn)
    {
        var fname = await GetFname(fid);
        return await GetThreads(fname, pn, 30, ThreadSortType, ThreadIsGood);
    }

    /// <summary>
    /// 获取首页帖子
    /// </summary>
    /// <param name="fname">贴吧名</param>
    /// <param name="pn">页码. Defaults to 1.</param>
    /// <returns></returns>
    public async Task<Threads> GetThreads(string fname, int pn)
    {
        return await GetThreads(fname, pn, ThreadRn, ThreadSortType, ThreadIsGood);
    }

    private async Task<UserInfoGuInfoApp> _GetUInfoGetUserInfoApp(int userId)
    {
        var getUInfoGetUserInfoApp = new GetUInfoGetUserInfoApp(_httpCore);
        var user = await getUInfoGetUserInfoApp.RequestAsync(userId);
        return user;
    }

    private async Task<UserInfoPf> _GetUInfoProfile<T>(T userId)
    {
        var getUInfoProfile = new GetUInfoProfile<T>(_httpCore);
        return await getUInfoProfile.RequestAsync(userId);
    }

    private async Task<UserInfoJson> _GetUInfoUserJson(string userName)
    {
        var getUInfoUserJson = new GetUInfoUserJson(_httpCore);

        return await getUInfoUserJson.RequestAsync(userName);
    }

    private async Task<UserInfoPanel> _GetUInfoPanel(string userId)
    {
        var getUInfoPanel = new GetUInfoPanel(_httpCore);

        return await getUInfoPanel.RequestAsync(userId);
    }

    public async Task<string> GetUserInfo(string userId, ReqUInfo require)
    {
        return "";
    }

    /// <summary>
    ///  获取用户信息
    /// </summary>
    /// <param name="userId">用户id user_id</param>
    /// <param name="require">请求数据类型</param>
    /// <returns>UserInfoGuInfoApp</returns>
    public async Task<UserInfoGuInfoApp> GetUserInfo(int userId, ReqUInfo require)
    {
        if ((require & ReqUInfo.Basic) == require)
        {
            return await _GetUInfoGetUserInfoApp(userId);
        }

        return await _GetUInfoProfile(userId);
    }

    /// <summary>
    ///  获取用户信息
    /// </summary>
    /// <param name="userId">用户id user_id</param>
    /// <returns>UserInfoGuInfoApp</returns>
    public async Task<UserInfoPf> GetUserInfo(int userId)
    {
        return await _GetUInfoProfile(userId);
    }

    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <param name="userNameOrPortrait">用户名 or portrait</param>
    /// <returns></returns>
    public async Task<UserInfoPf> GetUserInfo(string userNameOrPortrait)
    {
        if (Utils.IsPortrait(userNameOrPortrait))
        {
            return await _GetUInfoProfile(userNameOrPortrait);
        }

        var user = await _GetUInfoUserJson(userNameOrPortrait);
        return await _GetUInfoProfile(user.Portrait);
    }

    private async Task<BaseUser> _GetUserInfoByPortrait(string portrait, ReqUInfo require)
    {
        if ((require & ReqUInfo.All) == ReqUInfo.All)
        {
            return await _GetUInfoProfile(portrait);
        }

        if ((require & ReqUInfo.UserId) == ReqUInfo.UserId)
        {
            return await _GetUInfoPanel(portrait);
        }

        return new UserInfoGuInfoApp();
    }

    /// <summary>
    /// 封禁用户
    /// </summary>
    /// <param name="fid">所在贴吧的fid</param>
    /// <param name="userId">用户id user_name / portrait 优先portrait</param>
    /// <param name="day">封禁天数. Defaults to 1.</param>
    /// <param name="reason">封禁理由. Defaults to ''.</param>
    /// <returns></returns>
    public async Task<bool> Block(ulong fid, string userId, int day = 1, string reason = "")
    {
        var portrait = userId;
        var isPortrait = Utils.IsPortrait(portrait);
        if (!isPortrait)
        {
            var user = await GetUserInfo(userId);
            portrait = user.Portrait;
        }

        await _initTbs();
        var block = new Block(_httpCore);
        return await block.RequestAsync(fid, portrait, day, reason);
    }
    /// <summary>
    /// 封禁用户
    /// </summary>
    /// <param name="fid">所在贴吧的fid</param>
    /// <param name="userId">用户id user_id</param>
    /// <param name="day">封禁天数. Defaults to 1.</param>
    /// <param name="reason">封禁理由. Defaults to ''.</param>
    /// <returns></returns>
    public async Task<bool> Block(ulong fid, int userId, int day = 1, string reason = "")
    {
        var user = await GetUserInfo(userId);
        await _initTbs();
        var block = new Block(_httpCore);
        return await block.RequestAsync(fid, user.Portrait, day, reason);
    }
    
    /// <summary>
    /// 封禁用户
    /// </summary>
    /// <param name="fname">所在贴吧的贴吧名</param>
    /// <param name="userId">用户id user_id</param>
    /// <param name="day">封禁天数. Defaults to 1.</param>
    /// <param name="reason">封禁理由. Defaults to ''.</param>
    /// <returns></returns>
    public async Task<bool> Block(string fname, int userId, int day = 1, string reason = "")
    {
        var fid = await GetFid(fname);
        var user = await GetUserInfo(userId);
        await _initTbs();
        var block = new Block(_httpCore);
        return await block.RequestAsync(fid, user.Portrait, day, reason);
    }
    
    /// <summary>
    /// 封禁用户
    /// </summary>
    /// <param name="fname">所在贴吧的贴吧名</param>
    /// <param name="userId">用户id user_name / portrait</param>
    /// <param name="day">封禁天数. Defaults to 1.</param>
    /// <param name="reason">封禁理由. Defaults to ''.</param>
    /// <returns></returns>
    public async Task<bool> Block(string fname, string userId, int day = 1, string reason = "")
    {
        var fid = await GetFid(fname);
        var portrait = userId;
        var isPortrait = Utils.IsPortrait(portrait);
        if (!isPortrait)
        {
            var user = await GetUserInfo(userId);
            portrait = user.Portrait;
        }
        await _initTbs();
        var block = new Block(_httpCore);
        return await block.RequestAsync(fid, portrait, day, reason);
    }

    private async Task _initTbs()
    {
        if (Account is { Tbs: not null })
        {
            return;
        }

        await _login();
    }

    private async Task _login()
    {
        var login = new Login(_httpCore);
        var (userInfoLogin, tbs) = await login.RequestAsync();
        User = userInfoLogin;
        Account!.Tbs = tbs;
    }
}