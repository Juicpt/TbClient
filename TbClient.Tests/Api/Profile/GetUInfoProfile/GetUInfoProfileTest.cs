using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TbClient.Api.Profile.GetUInfoProfile;
using TbClient.core;

namespace TbClient.Tests.Api.Profile.GetUInfoProfile;

[TestClass]
[TestSubject(typeof(GetUInfoProfile<string>))]
public class GetUInfoProfileTest
{

    [TestMethod]
    public void TestGetUInfoProfile()
    {
        var httpCore = new HttpCore();
        var getUInfoProfile = new GetUInfoProfile<int>(httpCore);
        var requestAsync = getUInfoProfile.RequestAsync(2075805759);
        requestAsync.Wait();
        Console.WriteLine(requestAsync.Result);
    }
}