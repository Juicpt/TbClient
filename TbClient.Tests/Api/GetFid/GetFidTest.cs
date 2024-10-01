﻿using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TbClient.Api.GetFid;
using TbClient.core;

namespace TbClient.Tests.Api.GetFid;

[TestClass]
[TestSubject(typeof(TbClient.Api.GetFid.GetFid))]
public class GetFidTest
{
    [TestMethod]
    public void TestRequest()
    {
        var httpCore = new HttpCore();
        var getFid = new TbClient.Api.GetFid.GetFid(httpCore);
        var requestAsync = getFid.RequestAsync("地下城与勇士");
        requestAsync.Wait();
        Console.WriteLine(requestAsync.Result);
    }
}