using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TbClient;

namespace TbClient.Tests;

[TestClass]
[TestSubject(typeof(Client))]
public class ClientTest
{

    [TestMethod]
    public void TestGetThreadsByFname()
    {
        var client = new Client();
        var threads = client.GetThreads("地下城与勇士", 1, 30, 1, 1);
        threads.Wait();
        Console.WriteLine(threads.Result);
    }
    
    [TestMethod]
    public void TestGetThreadsByFid()
    {
        var client = new Client();
        var threads = client.GetThreads(81570, 1, 30, 1, 1);
        threads.Wait();
        Console.WriteLine(threads.Result);
    }

    [TestMethod]
    public void TestGetFname()
    {
        var client = new Client();
        var fname = client.GetFname(81570);
        fname.Wait();
        Console.WriteLine(fname.Result);
    }
}