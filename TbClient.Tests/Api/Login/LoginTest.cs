using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TbClient.Core;

namespace TbClient.Tests.Api.Login;

[TestClass]
[TestSubject(typeof(TbClient.Api.Login.Login))]
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
        var sync = new TbClient.Api.Login.Login(httpCore);
        var requestAsync = sync.RequestAsync();
        requestAsync.Wait();
        Console.WriteLine(requestAsync.Result);
    }
}