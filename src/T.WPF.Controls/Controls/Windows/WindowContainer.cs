using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace T.Controls
{
    /// <summary>
    ///
    ///     <MyNamespace:WindowContainer/>
    ///
    /// </summary>
    public class CanvasWindow : WindowContainerBase
    {
        private static readonly string PART_WindowContainer = "PART_WindowContainer";

        static CanvasWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CanvasWindow), new FrameworkPropertyMetadata(typeof(CanvasWindow)));
        }

        private Canvas WindowsContainer;


        public override void OnApplyTemplate()
        {
            WindowsContainer = GetTemplateChild(PART_WindowContainer) as Canvas;
            if (WindowsContainer == null)
            {
                throw new NullReferenceException("找不到名称为PART_WindowContainer的Panel");
            }

            base.OnApplyTemplate();
        }
        protected override void OnAddWindow(UIElement windowControl)
        {
            WindowsContainer.Children.Add(windowControl);
        }

        protected override void OnRemoveWindow(UIElement windowControl)
        {
            WindowsContainer.Children.Remove(windowControl);
        }

        protected override void OnBringToFront(UIElement windowControl)
        {
            BringPanelChildToFront(windowControl);
        }

        private void BringPanelChildToFront(UIElement windowControl)//图片置于最顶层显示
        {
            if (windowControl == null || WindowsContainer == null) return;
            if(WindowsContainer.Children.Count> 1)
            {
                var maxZ = WindowsContainer.Children.OfType<UIElement>()//linq语句，取Zindex的最大值
              .Where(x => x != windowControl)
              .Select(x => Canvas.GetZIndex(x))
              .Max();
                Canvas.SetZIndex(windowControl, maxZ + 1);
            }
            
        }
    }
}
