using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TbClient.Core;

namespace TbClient.Tests.Api.GetUInfoGetUserInfoApp;

[TestClass]
[TestSubject(typeof(TbClient.Api.GetUInfoGetUserInfoApp.GetUInfoGetUserInfoApp))]
public class GetUInfoGetUserInfoAppTest
{
    [TestMethod]
    public void TestRequest()
    {
        var httpCore = new HttpCore();
        var getUInfoGetUserInfoApp = new TbClient.Api.GetUInfoGetUserInfoApp.GetUInfoGetUserInfoApp(httpCore);
        var requestAsync = getUInfoGetUserInfoApp.RequestAsync(1);
        requestAsync.Wait();
        Console.WriteLine(requestAsync.Result);
    }
}