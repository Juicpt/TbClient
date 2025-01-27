using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AioTieba4DotNet.Core;

namespace AioTieba4DotNet.Tests.Api.Login;

[TestClass]
[TestSubject(typeof(AioTieba4DotNet.Api.Login.Login))]
public class LoginTest
{

    [TestMethod]
    public void TestLogin()
    {
        var account =
            new Account(
                "",
                "");
        var httpCore = new HttpCore();
        httpCore.SetAccount(account);
        var sync = new AioTieba4DotNet.Api.Login.Login(httpCore);
        var requestAsync = sync.RequestAsync();
        requestAsync.Wait();
        Console.WriteLine(requestAsync.Result);
    }
}