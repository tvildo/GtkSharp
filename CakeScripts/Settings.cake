
class Settings
{
    public static ICakeContext Cake { get; set; }
    public static string Version { get; set; }
    public static string BuildTarget { get; set; }
    public static string Assembly { get; set; }
    public static List<GAssembly> AssemblyList { get; set; }
    
    public static void Init()
    {
        AssemblyList = new List<GAssembly>()
        {
            new GAssembly("GLibSharp"),
            new GAssembly("GioSharp")
            {
                Deps = new[] { "GLibSharp" },
            },
            new GAssembly("AtkSharp")
            {
                Deps = new[] { "GLibSharp" },
                ExtraArgs = "--abi-cs-usings=Atk,GLib"
            },
            new GAssembly("CairoSharp"),
            new GAssembly("PangoSharp")
            {
                Deps = new[] { "GLibSharp", "CairoSharp" }
            },
            new GAssembly("GdkSharp")
            {
                Deps = new[] { "GLibSharp", "GioSharp", "CairoSharp", "PangoSharp" }
            },
            new GAssembly("GtkSharp")
            {
                Deps = new[] { "GLibSharp", "GioSharp", "AtkSharp", "CairoSharp", "PangoSharp", "GdkSharp" },
                ExtraArgs = "--abi-cs-usings=Gtk,GLib"
            },
            new GAssembly("GtkSourceSharp")
            {
                Deps = new[] { "GLibSharp", "GtkSharp", "GioSharp", "CairoSharp", "PangoSharp", "GdkSharp" },
            },
            new GAssembly("WebkitGtkSharp")
            {
                Deps = new[] { "GtkSharp","GLibSharp", "GioSharp", "AtkSharp", "CairoSharp", "PangoSharp", "GdkSharp" },
                ExtraArgs = "--abi-cs-usings=Webkit,Gtk,GLib,Gdk,Atk,Pango,Cairo"
            },
            new GAssembly("GstSharp")
            {
                Deps = new[] {"GLibSharp", "GioSharp"},
                ExtraArgs = $"--abi-cs-usings=Gst,Gst.Video,Gst.Sdp,Gst.Tags,Gst.Rtsp,Gst.PbUtils,Gst.Net,Gst.Controller,Gst.Base,Gst.Audio,Gst.App --glue-includes=glib.h,gst/gst.h,gst/video/video.h,gst/audio/audio.h,gst/rtsp/rtsp.h,gst/app/app.h,gst/audio/audio.h,gst/base/base.h,gst/controller/controller.h,gst/fft/fft.h,gst/net/net.h,gst/pbutils/gstaudiovisualizer.h,gst/pbutils/pbutils.h,gst/rtp/rtp.h,gst/rtsp/rtsp.h,gst/sdp/sdp.h,gst/tag/tag.h,gst/video/video.h,gst/video/gstvideoaffinetransformationmeta.h,gst/net/gstnetcontrolmessagemeta.h,gst/webrtc/webrtc.h --abi-c-filename=Source/Libs/GstSharp/Generated/GstSharp-abi.c --abi-cs-filename=Source/Libs/GstSharp/Generated/GstSharp-abi.cs"
            }
        };
    }
}
