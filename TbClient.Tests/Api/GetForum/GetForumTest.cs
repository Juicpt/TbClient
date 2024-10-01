using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TbClient.Api.GetForum;
using TbClient.core;

namespace TbClient.Tests.Api.GetForum;

[TestClass]
[TestSubject(typeof(TbClient.Api.GetForum.GetForum))]
public class GetForumTest
{
    [TestMethod]
    public void TestRequest()
    {
        var httpCore = new HttpCore();
        var getForum = new TbClient.Api.GetForum.GetForum(httpCore);
        var result = getForum.RequestAsync(new GetFormParams("DNF"));
        result.Wait();
        Assert.AreEqual(result.Result.Fname,"地下城与勇士");
    }
}