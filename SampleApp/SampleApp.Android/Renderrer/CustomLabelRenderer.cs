
using Android.Content;
using Android.Runtime;
using SampleApp.Droid.Renderers;
using System;

using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Label), typeof(CustomLabelRenderer))]
namespace SampleApp.Droid.Renderers
{

    public class CustomLabelRenderer : Xamarin.Forms.Platform.Android.FastRenderers.LabelRenderer
    {
        public CustomLabelRenderer(Context context) : base(context)
        {
        }
        [Obsolete]
        public CustomLabelRenderer(IntPtr handle, JniHandleOwnership transfer)
        {

        }
    }
}