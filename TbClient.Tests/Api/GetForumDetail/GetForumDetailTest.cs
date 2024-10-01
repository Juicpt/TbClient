using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TbClient.Api.GetForumDetail;
using TbClient.core;

namespace TbClient.Tests.Api.GetForumDetail;

[TestClass]
[TestSubject(typeof(TbClient.Api.GetForumDetail.GetForumDetail))]
public class GetForumDetailTest
{

    [TestMethod]
    public void TestRequest()
    {
        var httpCore = new HttpCore();
        var getForumDetail = new TbClient.Api.GetForumDetail.GetForumDetail(httpCore);
        var requestAsync = getForumDetail.RequestAsync(81570);
        requestAsync.Wait();
        Console.WriteLine(requestAsync.Result);
    }
}