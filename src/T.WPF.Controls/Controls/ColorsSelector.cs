using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using T.Controls.core;

namespace T.Controls
{
    /// <summary>
    /// 颜色画布，显示和选择所有颜色
    /// </summary>
    [TemplatePart(Name = "PART_SelctorThumb", Type =typeof(Thumb))]
    [TemplatePart(Name = "PART_Container", Type =typeof(Control))]
    public class ColorsSelector : Control
    {
        private static readonly Vector3i[][] ColorArray = new Vector3i[][]
        {
            new Vector3i[]{ new Vector3i(255, 0, 0), new Vector3i(0, 1,0)},
            new Vector3i[]{ new Vector3i(255, 255, 0), new Vector3i(-1,0,0)},
            new Vector3i[]{ new Vector3i(0, 255, 0), new Vector3i(0,0,1)},
            new Vector3i[]{ new Vector3i(0, 255, 255), new Vector3i(0,-1,0)},
            new Vector3i[]{ new Vector3i(0, 0, 255), new Vector3i(1,0,0)},
            new Vector3i[]{ new Vector3i(255, 0, 255), new Vector3i(0,0,-1)},
        };
        private static readonly string PART_SelctorThumb = "PART_SelctorThumb";
        private static readonly string PART_Container = "PART_Container";
        

        private Thumb selctorThumb;
        private Panel container;
        static ColorsSelector()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorsSelector), new FrameworkPropertyMetadata(typeof(ColorsSelector)));
        }
        
        /// <summary>
        /// get or set color selector thumb style
        /// </summary>
        public Style SelectorThumbStyle
        {
            get { return (Style)GetValue(SelectorThumbStyleProperty); }
            set { SetValue(SelectorThumbStyleProperty, value); }
        }
        /// <summary>
        /// SelectorThumbStyle DependencyProperty
        /// </summary>
        public static readonly DependencyProperty SelectorThumbStyleProperty =
            DependencyProperty.Register("SelectorThumbStyle", typeof(Style), typeof(ColorsSelector), new PropertyMetadata(null));

        /// <summary>
        /// currently selected color's value
        /// </summary>
        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        /// <summary>
        /// SelectedColor DependencyProperty
        /// </summary>
        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register("SelectedColor", typeof(Color), typeof(ColorsSelector), new PropertyMetadata(Colors.Transparent));
        
        public override void OnApplyTemplate()
        {
            if(selctorThumb != null)
            {
                selctorThumb.DragDelta -= SelectorThumb_DragDelta;
            }
            if(container != null)
            {
                container.MouseLeftButtonDown -= ColorsCanvas_MouseLeftButtonDown;
            }

            selctorThumb = (Thumb)GetTemplateChild(PART_SelctorThumb);
            if(selctorThumb != null)
            {
                selctorThumb.DragDelta += SelectorThumb_DragDelta;
            }

            container = (Panel)GetTemplateChild(PART_Container);
            if(container != null)
            {
                container.MouseLeftButtonDown += ColorsCanvas_MouseLeftButtonDown;
            }
            base.OnApplyTemplate();
        }

        private void ColorsCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(container);
            var x = point.Y / container.ActualHeight;
            var color = CalculateColor(x);
            if (SelectedColor != color)
            {
                SelectedColor = color;
            }
            Canvas.SetTop(selctorThumb, point.Y - selctorThumb.ActualHeight / 2);
        }

        private void SelectorThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var delta = selctorThumb.ActualHeight / 2;
            var top = Canvas.GetTop(selctorThumb) + e.VerticalChange;
            if (top < -delta)
                top = -delta;
            else if (top >= container.ActualHeight - delta)
                top = container.ActualHeight - delta;
            Canvas.SetTop(selctorThumb, top);
            var x = (top + delta) / container.ActualHeight;
            var color = CalculateColor(x);
            if (SelectedColor != color)
            {
                SelectedColor = color;
            }
        }
        
        private Color CalculateColor(double x)
        {
            if (x >= 1)
            {
                return ColorArray[0][0].ToColor();
            }
            var num = x * 6;
            var i = (int)Math.Truncate(num);
            var d = num - i;
            var color = ColorArray[i][0] + ColorArray[i][1] * (int)(255 * d);
            return color.ToColor();
        }
    }
}
