using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AioTieba4DotNet.Core;

namespace AioTieba4DotNet.Tests.Api.GetUInfoGetUserInfoApp;

[TestClass]
[TestSubject(typeof(AioTieba4DotNet.Api.GetUInfoGetUserInfoApp.GetUInfoGetUserInfoApp))]
public class GetUInfoGetUserInfoAppTest
{
    [TestMethod]
    public void TestRequest()
    {
        var httpCore = new HttpCore();
        var getUInfoGetUserInfoApp = new AioTieba4DotNet.Api.GetUInfoGetUserInfoApp.GetUInfoGetUserInfoApp(httpCore);
        var requestAsync = getUInfoGetUserInfoApp.RequestAsync(1);
        requestAsync.Wait();
        Console.WriteLine(requestAsync.Result);
    }
}