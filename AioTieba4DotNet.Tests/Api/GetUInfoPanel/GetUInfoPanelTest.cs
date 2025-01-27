using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AioTieba4DotNet.Core;

namespace AioTieba4DotNet.Tests.Api.GetUInfoPanel;

[TestClass]
[TestSubject(typeof(AioTieba4DotNet.Api.GetUInfoPanel.GetUInfoPanel))]
public class GetUInfoPanelTest
{

    [TestMethod]
    public void TestRequest()
    {
        var httpCore = new HttpCore();
        var getUInfoPanel=  new AioTieba4DotNet.Api.GetUInfoPanel.GetUInfoPanel(httpCore);
        var result = getUInfoPanel.RequestAsync("");
        result.Wait();
        Console.WriteLine(result.Result);
    }
}