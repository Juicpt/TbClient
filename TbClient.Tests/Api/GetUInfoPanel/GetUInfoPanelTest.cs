using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TbClient.Core;

namespace TbClient.Tests.Api.GetUInfoPanel;

[TestClass]
[TestSubject(typeof(TbClient.Api.GetUInfoPanel.GetUInfoPanel))]
public class GetUInfoPanelTest
{

    [TestMethod]
    public void TestRequest()
    {
        var httpCore = new HttpCore();
        var getUInfoPanel=  new TbClient.Api.GetUInfoPanel.GetUInfoPanel(httpCore);
        var result = getUInfoPanel.RequestAsync("");
        result.Wait();
        Console.WriteLine(result.Result);
    }
}