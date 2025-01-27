using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AioTieba4DotNet.Core;

namespace AioTieba4DotNet.Tests.Api.Sync;

[TestClass]
[TestSubject(typeof(AioTieba4DotNet.Api.Sync.Sync))]
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
        var sync = new AioTieba4DotNet.Api.Sync.Sync(httpCore);
        var requestAsync = sync.RequestAsync();
        requestAsync.Wait();
        Console.WriteLine(requestAsync.Result);
    }
}