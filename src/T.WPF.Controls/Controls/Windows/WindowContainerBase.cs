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
    ///     <MyNamespace:WindowContainer/>
    ///
    /// </summary>
    ///
    public abstract class WindowContainerBase : Window
    {


        private HashSet<UIElement> windows = new HashSet<UIElement>();


        static WindowContainerBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowContainerBase), new FrameworkPropertyMetadata(typeof(WindowContainerBase)));
        }


        /// <summary>
        /// default child window style
        /// </summary>
        public Style DefaultWindowStyle
        {
            get { return (Style)GetValue(DefaultWindowStyleProperty); }
            set { SetValue(DefaultWindowStyleProperty, value); }
        }

        public static readonly DependencyProperty DefaultWindowStyleProperty =
            DependencyProperty.Register("DefaultWindowStyle", typeof(Style), typeof(WindowContainerBase), new PropertyMetadata(null));
        
        
        public void AddWindow(UIElement windowControl)
        {
            if (!windows.Contains(windowControl))
            {
                windows.Add(windowControl);
                OnAddWindow(windowControl);
            }
        }

        public void RemoveWindow(UIElement windowControl)
        {
            if (windows.Remove(windowControl))
            {
                OnRemoveWindow(windowControl);
            }
        }

        protected virtual void OnAddWindow(UIElement windowControl)
        {

        }
        protected virtual void OnRemoveWindow(UIElement windowControl)
        {

        }

    }
}
