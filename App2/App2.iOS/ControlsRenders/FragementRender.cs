using System;
using System.Collections.Generic;
using System.Text;
using App2.Controls;
using App2.iOS.ControlsRenders;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Fragement), typeof(FragementRender))]

namespace App2.iOS.ControlsRenders
{
    public class FragementRender: ViewRenderer<Fragement, UISegmentedControl>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Fragement> e)
        {
            base.OnElementChanged(e);
       
          SetNativeControl(new UISegmentedControl(new object[] {"aaaa", "bbbbb"}));
        }
    }
}
