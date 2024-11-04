using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TbClient.Api.GetThreads;
using TbClient.Core;

namespace TbClient.Tests.Api.GetThreads;

[TestClass]
[TestSubject(typeof(TbClient.Api.GetThreads.GetThreads))]
public class GetThreadsTest
{

    [TestMethod]
    public void TestRequest()
    {
        var httpCore = new HttpCore();
        var getThreads = new TbClient.Api.GetThreads.GetThreads(httpCore);
        var requestAsync = getThreads.RequestAsync("",1,30,1,1);
        requestAsync.Wait();
        Console.WriteLine(requestAsync.Result);
    }
}