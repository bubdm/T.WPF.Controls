using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace T.Controls
{
    /// <summary>
    /// selector of hue channel for HSV color model
    /// </summary>
    [TemplatePart(Name = "PART_SelctorThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_Container", Type = typeof(Control))]
    public class ColorHueSelector : Control
    {
        private static readonly string PART_SelctorThumb = "PART_SelctorThumb";
        private static readonly string PART_Container = "PART_Container";


        private Thumb selectorThumb;
        private Panel container;
        static ColorHueSelector()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorHueSelector), new FrameworkPropertyMetadata(typeof(ColorHueSelector)));
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
            DependencyProperty.Register("SelectorThumbStyle", typeof(Style), typeof(ColorHueSelector), new PropertyMetadata(null));


        public double Hue
        {
            get { return (double)GetValue(HueProperty); }
            set { SetValue(HueProperty, value); }
        }

        public static readonly DependencyProperty HueProperty =
            DependencyProperty.Register("Hue", typeof(double), typeof(ColorHueSelector), new PropertyMetadata(1.0, OnHueChangedCallback));

        private static void OnHueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (ColorHueSelector)d;
            control.SetSlectorPositon((double)e.NewValue);
        }

        public override void OnApplyTemplate()
        {
            if (selectorThumb != null)
            {
                selectorThumb.DragDelta -= SelectorThumb_DragDelta;
            }
            if (container != null)
            {
                container.MouseLeftButtonDown -= ColorsCanvas_MouseLeftButtonDown;
            }

            selectorThumb = (Thumb)GetTemplateChild(PART_SelctorThumb);
            if (selectorThumb != null)
            {
                selectorThumb.DragDelta += SelectorThumb_DragDelta;
            }

            container = (Panel)GetTemplateChild(PART_Container);
            if (container != null)
            {
                container.MouseLeftButtonDown += ColorsCanvas_MouseLeftButtonDown;
            }
            base.OnApplyTemplate();
        }

        protected void SetSlectorPositon(double x)
        {
            if (selectorThumb != null)
            {
                Canvas.SetTop(selectorThumb, container.ActualHeight * x - selectorThumb.ActualHeight / 2);
            }
        }

        private void ColorsCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(container);
            var x = point.Y / container.ActualHeight;
            Canvas.SetTop(selectorThumb, point.Y - selectorThumb.ActualHeight / 2);
            if (Hue != x)
            {
                Hue = x;
            }
        }

        private void SelectorThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var delta = selectorThumb.ActualHeight / 2;
            var top = Canvas.GetTop(selectorThumb) + e.VerticalChange;
            if (top < -delta)
                top = -delta;
            else if (top >= container.ActualHeight - delta)
                top = container.ActualHeight - delta;
            Canvas.SetTop(selectorThumb, top);
            var x = (top + delta) / container.ActualHeight;
            if (Hue != x)
            {
                Hue = x;
            }
        }
    }
}
