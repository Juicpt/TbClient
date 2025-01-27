using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AioTieba4DotNet.Api.GetUInfoUserJson;
using AioTieba4DotNet.Core;

namespace AioTieba4DotNet.Tests.Api.GetUInfoUserJson;

[TestClass]
[TestSubject(typeof(AioTieba4DotNet.Api.GetUInfoUserJson.GetUInfoUserJson))]
public class GetUInfoUserJsonTest
{

    [TestMethod]
    public void TestRequest()
    {
        var httpCore = new HttpCore();
        var getUInfoPanel=  new AioTieba4DotNet.Api.GetUInfoUserJson.GetUInfoUserJson(httpCore);
        var result = getUInfoPanel.RequestAsync("");
        result.Wait();
        Console.WriteLine(result.Result);
    }
}