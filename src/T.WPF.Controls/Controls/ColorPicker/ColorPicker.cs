using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using T.Controls.core;

namespace T.Controls
{
    /// <summary>
    ///
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

        public static readonly DependencyProperty SingleColorSelecterStyleProperty =
            DependencyProperty.Register("SingleColorSelecterStyle", typeof(Style), typeof(ColorPicker), new PropertyMetadata(null));
        
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Color), typeof(ColorPicker), new PropertyMetadata(Colors.Transparent));



        public Color OriginalColor
        {
            get { return (Color)GetValue(OriginalColorProperty); }
            set { SetValue(OriginalColorProperty, value); }
        }

        public static readonly DependencyProperty OriginalColorProperty =
            DependencyProperty.Register("OriginalColor", typeof(Color), typeof(ColorPicker), new PropertyMetadata(Colors.Red));

        public ICommand ResoreColorCommand { get; set; }

        public ColorPicker()
        {
            ResoreColorCommand = new Command(RestoeColor);
        }

        private void RestoeColor()
        {
            if(Color != OriginalColor)
            {
                Color = OriginalColor;
            }
        }
        
    }
}
