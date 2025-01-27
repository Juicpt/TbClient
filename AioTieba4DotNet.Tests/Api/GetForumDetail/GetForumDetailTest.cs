using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AioTieba4DotNet.Core;

namespace AioTieba4DotNet.Tests.Api.GetForumDetail;

[TestClass]
[TestSubject(typeof(AioTieba4DotNet.Api.GetForumDetail.GetForumDetail))]
public class GetForumDetailTest
{

    [TestMethod]
    public void TestRequest()
    {
        var httpCore = new HttpCore();
        var getForumDetail = new AioTieba4DotNet.Api.GetForumDetail.GetForumDetail(httpCore);
        var requestAsync = getForumDetail.RequestAsync(1);
        requestAsync.Wait();
        Console.WriteLine(requestAsync.Result);
    }
}