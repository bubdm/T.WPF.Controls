using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace T.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class ColorEditorPanel : Control
    {
        static ColorEditorPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorEditorPanel), new FrameworkPropertyMetadata(typeof(ColorEditorPanel)));
        }




        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Color), typeof(ColorEditorPanel), new PropertyMetadata(Colors.Red));


    }
}
