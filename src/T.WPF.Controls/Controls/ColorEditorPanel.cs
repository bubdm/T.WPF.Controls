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
