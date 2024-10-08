﻿using System.Text;
using TbClient.Api.Profile.GetUInfoProfile;

namespace TbClient.Api.GetThreads.Entities;

public class Threads
{
    public required PageT Page { get; set; }
    public required ForumT Forum { get; set; }
    public required List<Thread> Objs { get; set; }
    public required Dictionary<string, int> TabDictionary { get; set; }

    public bool HasMore
    {
        get => Page.HasMore;
    }

    public static Threads FromTbData(FrsPageResIdl.Types.DataRes dataRes)
    {
        var forum = ForumT.FromTbData(dataRes);
        var threads = dataRes.ThreadList.Select(p => Thread.FromTbData(p)).ToList();
        var users = dataRes.UserList.ToDictionary(u => u.Id, u => UserInfoT.FromTbData(u));
        foreach (var thread in threads)
        {
            thread.Fname = forum.Fname;
            thread.Fid = forum.Fid;
            thread.User = users[thread.AuthorId];
        }

        return new Threads()
        {
            Page = PageT.FromTbData(dataRes.Page),
            Forum = forum,
            TabDictionary = dataRes.NavTabInfo.Tab.ToDictionary(p => p.TabName, p => p.TabId),
            Objs = threads,
        };
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(
            $"{nameof(Page)}: {Page}, {nameof(Forum)}: {Forum}, {nameof(TabDictionary)}: {TabDictionary}, {nameof(HasMore)}: {HasMore}");
        sb.AppendLine($"{nameof(Objs)}:");
        foreach (var obj in Objs)
        {
            sb.AppendLine(obj.ToString());
        }

        return sb.ToString();
    }
}