using Avalonia;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls;
using Avalonia.Themes.Fluent;
using Avalonia.Markup.Declarative;

namespace ExampleMarkupDeclarative
{
    internal class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
            // THIS FROM OLD APP
            //SingletonApp();
            //BuildAvaloniaApp()
            //.StartWithClassicDesktopLifetime(args);


            // THIS FROM MARKUP EXAMPLE
            // see https://github.com/AvaloniaUI/Avalonia.Markup.Declarative/blob/master/src/Samples/AvaloniaMarkupSample/App.cs
            var lifetime = new ClassicDesktopStyleApplicationLifetime { Args = args, ShutdownMode = ShutdownMode.OnLastWindowClose };

            AppBuilder.Configure<Application>()
            .UsePlatformDetect()
            .AfterSetup(b => b.Instance?.Styles.Add(new FluentTheme()))
            .SetupWithLifetime(lifetime);


            lifetime.MainWindow = new Window()
            .Title("Avalonia markup samples")
            .Content(new MainView());

#if DEBUG
            lifetime.MainWindow.AttachDevTools();
#endif

            lifetime.Start(args);
        }
    }
}