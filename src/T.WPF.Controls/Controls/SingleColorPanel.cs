using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using T.Controls.core;

namespace T.Controls
{
    /// <summary>
    /// skjjkjjkingle color selector Panel
    /// </summary>
    public class SingleColorPanel : Control
    {
        private static readonly string PART_Selctor = "PART_Selector";
        private static readonly string PART_Container = "PART_Container";
        private static Vector3i white = new Vector3i(255,255,255);

        static SingleColorPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SingleColorPanel), new FrameworkPropertyMetadata(typeof(SingleColorPanel)));
        }
        
        public Color SourceColor
        {
            get { return (Color)GetValue(SourceColorProperty); }
            set { SetValue(SourceColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SourceColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceColorProperty =
            DependencyProperty.Register("SourceColor", typeof(Color), typeof(SingleColorPanel), new PropertyMetadata(Colors.Transparent));

        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register("SelectedColor", typeof(Color), typeof(SingleColorPanel), new PropertyMetadata(Colors.Red));


        private Thumb selctorThumb;
        private Panel container;

        public Style SelectorStyle
        {
            get { return (Style)GetValue(SelectorStyleProperty); }
            set { SetValue(SelectorStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectorStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectorStyleProperty =
            DependencyProperty.Register("SelectorStyle", typeof(Style), typeof(SingleColorPanel), new PropertyMetadata(null));

        public override void OnApplyTemplate()
        {

            if (selctorThumb != null)
            {
                selctorThumb.DragDelta -= SelectorThumb_DragDelta;
            }
            if (container != null)
            {
                container.MouseLeftButtonDown -= Conainter_MouseLeftButtonDown;
            }

            selctorThumb = (Thumb)GetTemplateChild(PART_Selctor);
            if (selctorThumb != null)
            {
                selctorThumb.DragDelta += SelectorThumb_DragDelta;
            }

            container = (Panel)GetTemplateChild(PART_Container);
            if (container != null)
            {
                container.MouseLeftButtonDown += Conainter_MouseLeftButtonDown;
            }

            base.OnApplyTemplate();
        }

        private void Conainter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(container);
            SetColor(point);
        }

        private void SelectorThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var left = Canvas.GetLeft(selctorThumb) + e.HorizontalChange;
            var top = Canvas.GetTop(selctorThumb) + e.VerticalChange;
            var point = CalculteLocation(left, top);
            SetColor(point);
        }

        private Point CalculteLocation(double left, double top)
        {
            double w = container.ActualWidth;
            var x = left + selctorThumb.ActualWidth/2;
            x = x > w ? w : x;
            x = x < 0 ? 0 : x;

            double h = container.ActualHeight;
            double y = top + selctorThumb.ActualHeight/2;
            y = y > h ? h : y;
            y = y < 0 ? 0 : y;
            return new Point(x, y);
        }
        
        private void SetColor(Point point)
        {
            Canvas.SetLeft(selctorThumb, point.X - selctorThumb.ActualWidth/2);
            Canvas.SetTop(selctorThumb, point.Y - selctorThumb.ActualHeight / 2);
            var color = CalcluteColor(point);
            if (color != SelectedColor)
            {
                SelectedColor = color;
            }
        }

        /// <summary>
        /// 计算对应的颜色
        /// </summary>
        /// <param name="point">先对于container的位置</param>
        /// <returns></returns>
        private Color CalcluteColor(Point point)
        {
            var c = new Vector3i(SourceColor);
            var px = point.X / container.ActualWidth;
            var py = point.Y / container.ActualHeight;
            var ccolor = (white * (1 - px) + c * px) * (1 - py);
            return ccolor.ToColor();
        }
    }
}
