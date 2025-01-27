using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AioTieba4DotNet.Core;

namespace AioTieba4DotNet.Tests.Api.GetFid;

[TestClass]
[TestSubject(typeof(AioTieba4DotNet.Api.GetFid.GetFid))]
public class GetFidTest
{
    [TestMethod]
    public void TestRequest()
    {
        var httpCore = new HttpCore();
        var getFid = new AioTieba4DotNet.Api.GetFid.GetFid(httpCore);
        var requestAsync = getFid.RequestAsync("");
        requestAsync.Wait();
        Console.WriteLine(requestAsync.Result);
    }
}