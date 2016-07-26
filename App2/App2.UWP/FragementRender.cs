using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using App2.Controls;
using App2.UWP;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Fragement), typeof(FragementRender))]
namespace App2.UWP
{
    public class FragementRender : ViewRenderer<Fragement, StackPanel>
    {
        private StackPanel _stackPanel;
        protected override void OnElementChanged(ElementChangedEventArgs<Fragement> e)
        {
            base.OnElementChanged(e);

            _stackPanel = new  StackPanel();
            _stackPanel.Orientation = Orientation.Horizontal;;
            _stackPanel.Children.Add(new Button() {Content = "a"});
            _stackPanel.Children.Add(new Button() { Content = "b"});
            
            foreach (var button in _stackPanel.Children)
            {
                ((Button)button).Click += FragementRender_Click;
            }
            SetNativeControl(_stackPanel);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

        private void FragementRender_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            foreach (var button in _stackPanel.Children)
            {
                if(button != sender)
                ((Button)button).Background = new SolidColorBrush(Colors.DarkSalmon);
            }
        }
    }
}
