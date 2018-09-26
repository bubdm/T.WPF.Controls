using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace T.Controls
{
    /// <summary>
    ///
    ///
    /// </summary>
    public class WindowControl : ContentControl
    {
        private const string PART_TilePanel = "PART_TilePanel";
        static WindowControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowControl), new FrameworkPropertyMetadata(typeof(WindowControl)));
        }

        #region dependcy properties
        public ControlTemplate WindowTemplate
        {
            get { return (ControlTemplate)GetValue(WindowTemplateProperty); }
            set { SetValue(WindowTemplateProperty, value); }
        }

        public static readonly DependencyProperty WindowTemplateProperty =
            DependencyProperty.Register("WindowTemplate", typeof(ControlTemplate), typeof(WindowControl), new PropertyMetadata(null));

        public bool UserWindowTemplate
        {
            get { return (bool)GetValue(UserWindowTemplateProperty); }
            set { SetValue(UserWindowTemplateProperty, value); }
        }

        public static readonly DependencyProperty UserWindowTemplateProperty =
            DependencyProperty.Register("UserWindowTemplate", typeof(bool), typeof(WindowControl), new PropertyMetadata(false));


        public WindowContainerBase Container
        {
            get { return (WindowContainerBase)GetValue(ContainerProperty); }
            set { SetValue(ContainerProperty, value); }
        }

        public static readonly DependencyProperty ContainerProperty =
            DependencyProperty.Register("Container", typeof(WindowContainerBase), typeof(WindowControl), new PropertyMetadata(null));



        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(WindowControl), new PropertyMetadata(""));
        
        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(WindowControl), new PropertyMetadata(null));


        #endregion


        private Thumb tilePanel;

        public WindowControl()
        {
            this.PreviewMouseLeftButtonDown += WindowControl_PreviewMouseLeftButtonDown;
            CommandBindings.Add(new CommandBinding(WindowCommands.CloseWindowControlCommand,
                (s, e) => Close()));
            CommandBindings.Add(new CommandBinding(WindowCommands.MaximizeWindowControlCommand,
                (s, e) => Maximize()));
            CommandBindings.Add(new CommandBinding(WindowCommands.MinimizeWindowControlCommand,
                (s, e) => Minimize()));
        }

        private void WindowControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Container.BringToFront(this);
        }

        public void Show()
        {
            Visibility = Visibility.Visible;
            Container.AddWindow(this);
        }

        public void Close()
        {
            Container.RemoveWindow(this);
        }

        public void Maximize()
        {
            Container.SetChildMax(this);
        }

        public void Minimize()
        {
            Container.SetChildMin(this);
        }

        public override void OnApplyTemplate()
        {
            tilePanel = GetTemplateChild(PART_TilePanel) as Thumb;
            if(tilePanel != null)
            {
                tilePanel.DragDelta += TilePanel_DragDelta;
            }
            base.OnApplyTemplate();
        }

        private void TilePanel_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var x = (double)GetValue(CanvasContainer.LeftProperty) + e.HorizontalChange;
            var y = (double)GetValue(CanvasContainer.TopProperty) + e.VerticalChange;
            if(x < 0)
            {
                x = 0;
            }
            if(x > Container.ActualWidth - ActualWidth)
            {
                x = Container.ActualWidth - ActualWidth;
            }

            if (y < 0)
            {
                y = 0;
            }
            if (y > Container.ActualHeight - ActualHeight)
            {
                y = Container.ActualHeight - ActualHeight;
            }
            SetValue(CanvasContainer.LeftProperty, x);
            SetValue(CanvasContainer.TopProperty, y);
        }
    }
}
