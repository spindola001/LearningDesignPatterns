using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AbstractFactory_ImplementatioExample
{
    public interface IGUIFactory
    {
        IButton CreateButton();

        IDialog CreateDialog();
    }

    class WindowsGUIFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public IDialog CreateDialog()
        {
            return new WindowsDialog();
        }
    }

    class MacOSGUIFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new MacOSButton();
        }

        public IDialog CreateDialog()
        {
            return new MacOSDialog();
        }
    }

    public interface IButton
    {
        string Render();
    }

    class WindowsButton : IButton
    {
        public string Render()
        {
            return "Renderizando um botão no Sistema Windows";
        }


    }

    class MacOSButton : IButton
    {
        public string Render()
        {
            return "Renderizando um botão no Sistema MAC";
        }
    }

    public interface IDialog
    {
        string Open();

        string RenderButton(IButton button);
    }

    class WindowsDialog : IDialog
    {
        public string Open()
        {
            return "Abrindo uma caixa de diálogo no Sistema Windows";
        }

        public string RenderButton(IButton button)
        {
            var result = button.Render();

            return $"{result}";
        }
    }

    class MacOSDialog : IDialog
    {
        public string Open()
        {
            return "Abrindo uma caixa de diálogo no Sistema MAC";
        }

        public string RenderButton(IButton button)
        {
            var result = button.Render();

            return $"{result}";
        }
    }

    class Application
    {
        private readonly IButton _button;
        private readonly IDialog _dialog;

        public Application(IGUIFactory factory)
        {
            _button = factory.CreateButton();
            _dialog = factory.CreateDialog();
        }

        public void Initialize()
        {
            Console.WriteLine(_button.Render());
            Console.WriteLine(_dialog.Open());
        }
    }

    public static class FactoryProvider
    {
        private static readonly Dictionary<OSPlatform, Func<IGUIFactory>> _factories = new()
        {
            {OSPlatform.Windows, () => new WindowsGUIFactory()},
            {OSPlatform.OSX, () => new MacOSGUIFactory()},
        };

        public static IGUIFactory GetFactory()
        {
            return _factories.FirstOrDefault(entry => RuntimeInformation.IsOSPlatform(entry.Key)).Value.Invoke() ?? new WindowsGUIFactory();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IGUIFactory factory = FactoryProvider.GetFactory();
            Application app = new Application(factory);
            app.Initialize();
        }
    }
}
