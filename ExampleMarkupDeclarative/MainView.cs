using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Markup.Declarative;
using Avalonia.Media;
using Avalonia.Styling;
using AvaloniaEdit;
using AvaloniaEdit.Document;
using AvaloniaEdit.Rendering;
using AvaloniaEdit.TextMate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMateSharp.Grammars;

namespace ExampleMarkupDeclarative;

public class MainView : ViewBase
{
    TextEditor _textEditor;
    RegistryOptions _registryOptions;
    TextMate.Installation _textMateInstallation;
    protected override object Build()
    {
        // copied some from the dedicated sample
        _textEditor = new TextEditor()
               .Width(400)
               .Height(400);

        _textEditor.FontFamily = new FontFamily("Cascadia Code,Consolas,Menlo,Monospace");
        _textEditor.FontWeight = FontWeight.Light;
        _textEditor.FontSize = 14;
        _textEditor.ShowLineNumbers = true;
        _textEditor.HorizontalScrollBarVisibility = Avalonia.Controls.Primitives.ScrollBarVisibility.Visible;
        _textEditor.Background = Brushes.BlueViolet;
        _textEditor.TextArea.Background = Brushes.AliceBlue;
        _textEditor.Options.ShowBoxForControlCharacters = true;
        _textEditor.Options.ColumnRulerPositions = new List<int>() { 80, 100 };
        _textEditor.TextArea.IndentationStrategy = new AvaloniaEdit.Indentation.CSharp.CSharpIndentationStrategy(_textEditor.Options);
        _textEditor.TextArea.RightClickMovesCaret = true;
        _textEditor.Options.HighlightCurrentLine = true;
        _textEditor.IsVisible = true;
        _textEditor.TextArea.Width = 400;
        _textEditor.TextArea.Height = 400;

        if (false)
        {
            // events added just to try and debug why not working
            _textEditor.Initialized += _textEditor_Initialized;
            _textEditor.Loaded += _textEditor_Loaded;
            _textEditor.SizeChanged += _textEditor_SizeChanged;
            _textEditor.ActualThemeVariantChanged += _textEditor_ActualThemeVariantChanged;
            _textEditor.DetachedFromVisualTree += _textEditor_DetachedFromVisualTree;
            _textEditor.PointerWheelChanged += _textEditor_PointerWheelChanged;
            _textEditor.EffectiveViewportChanged += _textEditor_EffectiveViewportChanged;
            _textEditor.PointerPressed += _textEditor_PointerPressed;
            _textEditor.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch;
            _textEditor.VerticalAlignment = Avalonia.Layout.VerticalAlignment.Stretch;
        }

        // looks like next is also must
        _registryOptions = new RegistryOptions(ThemeName.Dark);

        _textMateInstallation = _textEditor.InstallTextMate(_registryOptions);

        Language csharpLanguage = _registryOptions.GetLanguageByExtension(".cs");

        string scopeName = _registryOptions.GetScopeByLanguageId(csharpLanguage.Id);

        _textEditor.Document = new TextDocument(
            "// AvaloniaEdit supports displaying control chars: \a or \b or \v" + Environment.NewLine +
            "// AvaloniaEdit supports displaying underline and strikethrough" + Environment.NewLine);
        _textMateInstallation.SetGrammar(_registryOptions.GetScopeByLanguageId(csharpLanguage.Id));
        //_textEditor.TextArea.TextView.LineTransformers.Add(new UnderlineAndStrikeThroughTransformer());
        _textEditor.ScrollTo(1, 1);

        var b3 = new TextBlock();
        b3.Text = "TextBlock 3";
        b3.Background = Brushes.GreenYellow;
        var panel = new StackPanel();
        panel.Children(
                    new TextBlock()
                    .Text("TextBlock 1, before edit")
                    .Background(Brushes.LightCoral),
                    _textEditor,
                     new TextBlock()
                    .Text("TextBlock 2, after edit")
                    .Background(Brushes.LightBlue),
                     b3);
        return panel;
    }

    private void TextBlock_EffectiveViewportChanged(object? sender, Avalonia.Layout.EffectiveViewportChangedEventArgs e)
    {
        //  throw new NotImplementedException();
    }

    private void TextBlock_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        //throw new NotImplementedException();
    }

    private void _textEditor_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        //throw new NotImplementedException();
    }

    private void _textEditor_EffectiveViewportChanged(object? sender, Avalonia.Layout.EffectiveViewportChangedEventArgs e)
    {
        // throw new NotImplementedException();
    }

    private void _textEditor_PointerWheelChanged(object? sender, Avalonia.Input.PointerWheelEventArgs e)
    {
        // throw new NotImplementedException();
    }

    private void _textEditor_DetachedFromVisualTree(object? sender, Avalonia.VisualTreeAttachmentEventArgs e)
    {
        //  throw new NotImplementedException();
    }

    private void _textEditor_ActualThemeVariantChanged(object? sender, EventArgs e)
    {
        // throw new NotImplementedException();
    }

    private void _textEditor_SizeChanged(object? sender, SizeChangedEventArgs e)
    {
        //throw new NotImplementedException();
    }

    private void _textEditor_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //throw new NotImplementedException();
    }

    private void _textEditor_Initialized(object? sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }
}
