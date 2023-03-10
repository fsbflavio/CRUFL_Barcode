using CRUFL_Barcode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CRUFL_Barcode.Tests
{
    [TestClass]
    public class BarCode2of5Test
    {
        [TestMethod]
        public void TestBarcode2of5()
        {
            var barCode = new Interleaved();

            var result = barCode.To2of5("00198909600001567600000003364815000046685817");

            Assert.AreEqual("(0Cç9Ê01ÆÚ0003T`?00^ÒÈA)", result);
        }
    }
}
