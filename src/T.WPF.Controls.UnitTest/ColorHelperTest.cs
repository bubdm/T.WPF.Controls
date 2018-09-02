using System;
using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using T.Controls.core;

namespace T.WPF.Controls.UnitTest
{
    [TestClass]
    public class ColorHelperTest
    {
        [TestMethod]
        public void TestColorConvert()
        {

            var hsv = ColorHelper.RGB2HSV(Colors.Red);
            Assert.AreEqual(new HSVColor(0,1,1), hsv);

            Assert.AreEqual(new HSVColor(0, 0, 0), ColorHelper.RGB2HSV(Colors.Black));
            Assert.AreEqual(new HSVColor(240, 1, 1), ColorHelper.RGB2HSV(Colors.Blue));
            Assert.AreEqual(new HSVColor(60, 1, 1), ColorHelper.RGB2HSV(Colors.Yellow));
            Assert.AreEqual(new HSVColor(180, 1, 1), ColorHelper.RGB2HSV(Colors.Cyan));
            Assert.AreEqual(new HSVColor(0, 0, 128/255f), ColorHelper.RGB2HSV(Colors.Gray));
            Assert.AreEqual(new HSVColor(300, 1, 128 / 255f), ColorHelper.RGB2HSV(Colors.Purple));


            Assert.AreEqual(Colors.Black, ColorHelper.HSV2RGB(new HSVColor(0f, 0f, 0f)));
            Assert.AreEqual(Colors.Blue, ColorHelper.HSV2RGB(new HSVColor(240, 1, 1)));
            Assert.AreEqual(Colors.Yellow, ColorHelper.HSV2RGB(new HSVColor(60, 1, 1)));
            Assert.AreEqual(Colors.Cyan, ColorHelper.HSV2RGB(new HSVColor(180, 1, 1)));
            Assert.AreEqual(Colors.Gray, ColorHelper.HSV2RGB(new HSVColor(0, 0, 128 / 255f)));
            Assert.AreEqual(Colors.Purple, ColorHelper.HSV2RGB(new HSVColor(300, 1, 128 / 255f)));

        }

    }
}
