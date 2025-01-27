using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AioTieba4DotNet.Api.GetForum;
using AioTieba4DotNet.Core;

namespace AioTieba4DotNet.Tests.Api.GetForum;

[TestClass]
[TestSubject(typeof(AioTieba4DotNet.Api.GetForum.GetForum))]
public class GetForumTest
{
    [TestMethod]
    public void TestRequest()
    {
        var httpCore = new HttpCore();
        var getForum = new AioTieba4DotNet.Api.GetForum.GetForum(httpCore);
        var result = getForum.RequestAsync(new GetFormParams(""));
        result.Wait();
        Assert.AreEqual(result.Result.Fname,"");
    }
}