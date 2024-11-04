using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TbClient.Api.GetUInfoUserJson;
using TbClient.Core;

namespace TbClient.Tests.Api.GetUInfoUserJson;

[TestClass]
[TestSubject(typeof(TbClient.Api.GetUInfoUserJson.GetUInfoUserJson))]
public class GetUInfoUserJsonTest
{

    [TestMethod]
    public void TestRequest()
    {
        var httpCore = new HttpCore();
        var getUInfoPanel=  new TbClient.Api.GetUInfoUserJson.GetUInfoUserJson(httpCore);
        var result = getUInfoPanel.RequestAsync("");
        result.Wait();
        Console.WriteLine(result.Result);
    }
}