using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WinUI3UWP
{
    /// <summary>
    /// The custom entry point for this app. We override it to allow WinUI 3 in the UWP env BEFORE the app launches.
    /// </summary>
    /// <remarks>A little quirk about this way of interacting with WinUI 3: We can't use <see cref="Microsoft.UI.Xaml.Window"/>s because they cause a crash.</remarks>
    public static class Program
    {
        [DllImport("Microsoft.ui.xaml.dll")]
        private static extern void XamlCheckProcessRequirements();

        [DllImport("API-MS-WIN-CORE-LIBRARYLOADER-L2-1-0.DLL", SetLastError = true)]
        private static extern IntPtr LoadPackagedLibrary([MarshalAs(UnmanagedType.LPWStr)] string libraryName, int reserved = 0);

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2309")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.MTAThread]
        static void Main(string[] args)
        {
            // Library by driver1998: https://github.com/driver1998/HookCoreAppWinUI
            // used here to enable WinUI 3 in UWP by hooking certain registry calls.
            Debug.WriteLine(LoadPackagedLibrary("HookCoreAppWinUI.dll"));

            // Boring MUX app init
            XamlCheckProcessRequirements();

            WinRT.ComWrappersSupport.InitializeComWrappers();
            Microsoft.UI.Xaml.Application.Start((param) =>
            {
                var context = new global::Microsoft.UI.Dispatching.DispatcherQueueSynchronizationContext(global::Microsoft.UI.Dispatching.DispatcherQueue.GetForCurrentThread());
                global::System.Threading.SynchronizationContext.SetSynchronizationContext(context);
                new App();
            });
        }
    }
}