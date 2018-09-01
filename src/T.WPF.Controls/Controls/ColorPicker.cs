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
    ///     <MyNamespace:ColorPicker/>
    ///
    /// </summary>
    public class ColorPicker : Control
    {
        static ColorPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPicker), new FrameworkPropertyMetadata(typeof(ColorPicker)));
        }



        public Style ExpanderStyle
        {
            get { return (Style)GetValue(ExpanderStyleProperty); }
            set { SetValue(ExpanderStyleProperty, value); }
        }
        public static readonly DependencyProperty ExpanderStyleProperty =
            DependencyProperty.Register("ExpanderStyle", typeof(Style), typeof(ColorPicker), new PropertyMetadata(null));

        public Style ColorsSelectorStyle
        {
            get { return (Style)GetValue(ColorsSelectorStyleProperty); }
            set { SetValue(ColorsSelectorStyleProperty, value); }
        }
        public static readonly DependencyProperty ColorsSelectorStyleProperty =
            DependencyProperty.Register("ColorsSelectorStyle", typeof(Style), typeof(ColorPicker), new PropertyMetadata(null));



        public Style SingleColorSelecterStyle
        {
            get { return (Style)GetValue(SingleColorSelecterStyleProperty); }
            set { SetValue(SingleColorSelecterStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SingleColorSelecterStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SingleColorSelecterStyleProperty =
            DependencyProperty.Register("SingleColorSelecterStyle", typeof(Style), typeof(ColorPicker), new PropertyMetadata(null));




        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Color), typeof(ColorPicker), new PropertyMetadata(Colors.Transparent));


    }
}
