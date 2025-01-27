using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AioTieba4DotNet.Api.Profile.GetUInfoProfile;
using AioTieba4DotNet.Core;

namespace AioTieba4DotNet.Tests.Api.Profile.GetUInfoProfile;

[TestClass]
[TestSubject(typeof(GetUInfoProfile<string>))]
public class GetUInfoProfileTest
{

    [TestMethod]
    public void TestGetUInfoProfile()
    {
        var httpCore = new HttpCore();
        var getUInfoProfile = new GetUInfoProfile<int>(httpCore);
        var requestAsync = getUInfoProfile.RequestAsync(1);
        requestAsync.Wait();
        Console.WriteLine(requestAsync.Result);
    }
}