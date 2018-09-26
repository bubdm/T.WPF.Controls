using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace T.Controls
{
    public class WindowCommands
    {
        /// <summary>
        /// gets Close WindowControl Cammand
        /// </summary>
        public static RoutedCommand CloseWindowControlCommand { get; } = new RoutedCommand();
        /// <summary>
        /// gets Maximize WindowControl Cammand
        /// </summary>
        public static RoutedCommand MaximizeWindowControlCommand { get; } = new RoutedCommand();
        /// <summary>
        /// gets Minimize WindowControl Cammand
        /// </summary>
        public static RoutedCommand MinimizeWindowControlCommand { get; } = new RoutedCommand();
        /// <summary>
        /// gets Restore WindowControl Cammand
        /// </summary>
        public static RoutedCommand RestoreWindowControlCommand { get; } = new RoutedCommand();

        //public static void CloseWindowControl(WindowControl windowControl)
        //{
        //    if(windowControl != null)
        //    {
        //        //windowControl.Visibility = Visibility.Collapsed;
        //        windowControl.Container?.RemoveWindow(windowControl);
        //    }
        //}

        //public static void MaximizeWindowControl(WindowControl windowControl)
        //{
        //    if (windowControl != null)
        //    {
        //        windowControl.Container?.SetChildMax(windowControl);
        //    }
        //}

        //public static void MinimizeWindowControl(WindowControl windowControl)
        //{
        //    if(windowControl != null)
        //    {
        //        windowControl.Container?.SetChildMin(windowControl);
        //    }
        //}
    }
}
