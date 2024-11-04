using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TbClient.Core;

namespace TbClient.Tests.Api.GetFid;

[TestClass]
[TestSubject(typeof(TbClient.Api.GetFid.GetFid))]
public class GetFidTest
{
    [TestMethod]
    public void TestRequest()
    {
        var httpCore = new HttpCore();
        var getFid = new TbClient.Api.GetFid.GetFid(httpCore);
        var requestAsync = getFid.RequestAsync("");
        requestAsync.Wait();
        Console.WriteLine(requestAsync.Result);
    }
}