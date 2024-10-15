using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TbClient;
using TbClient.Enums;

namespace TbClient.Tests;

[TestClass]
[TestSubject(typeof(Client))]
public class ClientTest
{
    [TestMethod]
    public void TestGetThreadsByFname()
    {
        var client = new Client();
        var threads = client.GetThreads("地下城与勇士", 200);
        threads.Wait();
        Console.WriteLine(threads.Result);
    }

    [TestMethod]
    public void TestGetThreadsByFid()
    {
        var client = new Client
        {
            ThreadIsGood = false,
            ThreadSortType = ThreadSortType.CREATE
        };
        var threads = client.GetThreads(81570, 50);
        threads.Wait();
        Console.WriteLine(threads.Result.Page);
        Console.WriteLine(threads.Result.Forum);
        Console.WriteLine(threads.Result.Objs.Count);
        Console.WriteLine(threads.Result.Objs[^1]);
    }

    [TestMethod]
    public void TestGetFname()
    {
        var client = new Client();
        var fname = client.GetFname(81570);
        fname.Wait();
        Console.WriteLine(fname.Result);
        Console.WriteLine(fname.Result);
    }
}