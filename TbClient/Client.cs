using TbClient.Api.GetFid;
using TbClient.Api.GetForumDetail;
using TbClient.Api.GetForumDetail.Entities;
using TbClient.Api.GetThreads;
using TbClient.Api.GetThreads.Entities;
using TbClient.core;
using TbClient.Core;

namespace TbClient;

public class Client
{
    public Account? Account { get; set; }
    public string? Bduss { get; set; }
    public string? Stoken { get; set; }
    private HttpCore _httpCore;

    private ForumInfoCache _forumInfoCache = new ForumInfoCache();

    public Client()
    {
        _httpCore = new HttpCore();
    }

    public Client(string bduss, string stoken)
    {
        Bduss = bduss;
        Stoken = stoken;
        _httpCore = new HttpCore();
        if (Bduss != null && Stoken != null)
        {
            Account = new Account(Bduss, Stoken);
            _httpCore.SetAccount(Account);
        }
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
    public async Task<Threads> GetThreads(string fname, int pn, int rn, int sort, int isGood)
    {
        var getThreads = new GetThreads(_httpCore);
        return await getThreads.RequestAsync(fname, pn, rn, sort, isGood);
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
    public async Task<Threads> GetThreads(ulong fid, int pn, int rn, int sort, int isGood)
    {
        var fname = await GetFname(fid);
        return await GetThreads(fname, pn, rn, sort, isGood);
    }
}