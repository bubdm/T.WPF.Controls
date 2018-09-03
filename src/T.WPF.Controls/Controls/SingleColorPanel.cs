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
    /// single color selector Panel
    /// </summary>
    [TemplatePart(Name = "PART_Selector", Type =typeof(Thumb))]
    [TemplatePart(Name = "PART_Container", Type =typeof(Panel))]
    public class SingleColorPanel : Control
    {
        private static readonly string PART_Selctor = "PART_Selector";
        private static readonly string PART_Container = "PART_Container";

        static SingleColorPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SingleColorPanel), new FrameworkPropertyMetadata(typeof(SingleColorPanel)));
        }
       
        public double Hub
        {
            get { return (double)GetValue(HubProperty); }
            set { SetValue(HubProperty, value); }
        }

        public static readonly DependencyProperty HubProperty =
            DependencyProperty.Register("Hub", typeof(double), typeof(SingleColorPanel), new PropertyMetadata(1.0));
        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register("SelectedColor", typeof(Color), typeof(SingleColorPanel), new PropertyMetadata(Colors.Red, OnSelectedColorChanged));

        private static void OnSelectedColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (SingleColorPanel)d;
            var color = (Color)e.NewValue;
            var hsv = ColorHelper.RGB2HSV(color);
            if (hsv.H != control.Hub)
            {
                control.Hub = hsv.H;
                if (control.container != null)
                {
                    control.SetSelectorPositionByScale(hsv.S,1- hsv.V);
                }
            }
        }




        private Thumb selectorThumb;
        private Panel container;

        public Style SelectorStyle
        {
            get { return (Style)GetValue(SelectorStyleProperty); }
            set { SetValue(SelectorStyleProperty, value); }
        }

        public static readonly DependencyProperty SelectorStyleProperty =
            DependencyProperty.Register("SelectorStyle", typeof(Style), typeof(SingleColorPanel), new PropertyMetadata(null));

        public override void OnApplyTemplate()
        {

            if (selectorThumb != null)
            {
                selectorThumb.DragDelta -= SelectorThumb_DragDelta;
            }
            if (container != null)
            {
                container.MouseLeftButtonDown -= Conainter_MouseLeftButtonDown;
            }

            selectorThumb = (Thumb)GetTemplateChild(PART_Selctor);
            if (selectorThumb != null)
            {
                selectorThumb.DragDelta += SelectorThumb_DragDelta;
                selectorThumb.MouseLeftButtonDown += SelctorThumb_MouseLeftButtonDown;
            }

            container = (Panel)GetTemplateChild(PART_Container);
            if (container != null)
            {
                container.MouseLeftButtonDown += Conainter_MouseLeftButtonDown;
            }

            base.OnApplyTemplate();
        }

        private void SelctorThumb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(selectorThumb);
            Console.WriteLine(point);
        }

        /// <summary>
        /// TODO: 单击后能进行拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Conainter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(container);
            SetSelectorPosition(point.X -selectorThumb.ActualWidth / 2, point.Y - selectorThumb.ActualHeight / 2);
            SetColor(point);
        }

        private void SelectorThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var left = Canvas.GetLeft(selectorThumb) + e.HorizontalChange;
            var top = Canvas.GetTop(selectorThumb) + e.VerticalChange;
            var point = SetSelectorPosition(left, top);
            SetColor(point);
        }

        /// <summary>
        /// set selector thumb position
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <returns>return the selector thumb center position relatived to container</returns>
        private Point SetSelectorPosition(double left, double top)
        {
            double w = container.ActualWidth;
            var x = left + selectorThumb.ActualWidth/2;
            x = x > w ? w : x;
            x = x < 0 ? 0 : x;

            double h = container.ActualHeight;
            double y = top + selectorThumb.ActualHeight/2;
            y = y > h ? h : y;
            y = y < 0 ? 0 : y;
            Canvas.SetLeft(selectorThumb, x - selectorThumb.ActualWidth / 2);
            Canvas.SetTop(selectorThumb, y - selectorThumb.ActualHeight / 2);
            return new Point(x, y);
        }

        /// <summary>
        /// set selector thumb position
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <returns>return the selector thumb center position relatived to container</returns>
        private void SetSelectorPositionByScale(double pleft, double ptop)
        {
            SetSelectorPosition(container.ActualWidth * pleft - selectorThumb.ActualWidth / 2,
                container.ActualHeight * ptop - selectorThumb.ActualHeight / 2);
        }

        /// <summary>
        /// get selector thumb current position relatived to container
        /// </summary>
        /// <returns></returns>
        private Point GetSelectorCenter()
        {
            var left = Canvas.GetLeft(selectorThumb);
            var top = Canvas.GetTop(selectorThumb);
            return new Point(left + selectorThumb.ActualWidth / 2, top + selectorThumb.ActualHeight / 2);
        }
        
        private void SetColor(Point point)
        {
            var color = CalcluteColor(point);
            if (color != SelectedColor)
            {
                SelectedColor = color;
            }
        }

        /// <summary>
        /// calculate color accord postion
        /// </summary>
        /// <param name="point">postion relative to container</param>
        /// <returns></returns>
        private Color CalcluteColor(Point point)
        {
            var px = point.X / container.ActualWidth;
            var py = point.Y / container.ActualHeight;
            var color= ColorHelper.HSV2RGB(new HSVColor(Hub, px, 1 - py));
            return color;
        }
    }
}
