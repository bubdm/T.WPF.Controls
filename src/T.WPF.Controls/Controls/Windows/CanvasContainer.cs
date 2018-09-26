using System.Windows;
using System.Windows.Controls;

namespace T.Controls
{
    public class CanvasContainer : DependencyObject
    {
        public static double GetLeft(DependencyObject obj)
        {
            return (double)obj.GetValue(LeftProperty);
        }

        public static void SetLeft(DependencyObject obj, double value)
        {
            obj.SetValue(LeftProperty, value);
        }

        public static readonly DependencyProperty LeftProperty =
            DependencyProperty.RegisterAttached("Left", typeof(double), typeof(CanvasContainer), new PropertyMetadata(0.0, LeftChangedCallback));

        private static void LeftChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Canvas.SetLeft((UIElement)d, (double)e.NewValue);
        }

        public static double GetTop(DependencyObject obj)
        {
            return (double)obj.GetValue(TopProperty);
        }

        public static void SetTop(DependencyObject obj, double value)
        {
            obj.SetValue(TopProperty, value);
        }
        
        public static readonly DependencyProperty TopProperty =
            DependencyProperty.RegisterAttached("Top", typeof(double), typeof(CanvasContainer), new PropertyMetadata(0.0, TopChangedCallback));

        private static void TopChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Canvas.SetTop((UIElement)d, (double)e.NewValue);
        }
    }
}
