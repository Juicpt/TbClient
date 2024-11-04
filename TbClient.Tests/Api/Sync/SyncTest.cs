using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TbClient.Core;

namespace TbClient.Tests.Api.Sync;

[TestClass]
[TestSubject(typeof(TbClient.Api.Sync.Sync))]
public class SyncTest
{
    [TestMethod]
    public void TestRequestAsync()
    {
        var account =
            new Account(
                "",
                "");
        var httpCore = new HttpCore();
        httpCore.SetAccount(account);
        var sync = new TbClient.Api.Sync.Sync(httpCore);
        var requestAsync = sync.RequestAsync();
        requestAsync.Wait();
        Console.WriteLine(requestAsync.Result);
    }
}