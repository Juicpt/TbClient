using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AioTieba4DotNet.Api.GetThreads;
using AioTieba4DotNet.Core;

namespace AioTieba4DotNet.Tests.Api.GetThreads;

[TestClass]
[TestSubject(typeof(AioTieba4DotNet.Api.GetThreads.GetThreads))]
public class GetThreadsTest
{

    [TestMethod]
    public void TestRequest()
    {
        var httpCore = new HttpCore();
        var getThreads = new AioTieba4DotNet.Api.GetThreads.GetThreads(httpCore);
        var requestAsync = getThreads.RequestAsync("",1,30,1,1);
        requestAsync.Wait();
        Console.WriteLine(requestAsync.Result);
    }
}