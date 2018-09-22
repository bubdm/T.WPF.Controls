using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace T.Controls
{
    public class TileThumbPanel : Thumb
    {
        static TileThumbPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TileThumbPanel), new FrameworkPropertyMetadata(typeof(TileThumbPanel)));
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(TileThumbPanel), new PropertyMetadata(""));



        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(TileThumbPanel), new PropertyMetadata(null));


    }
}
