using System.Windows;
using Prism.Ioc;
using Prism.Unity;
using Data;
using Model;

namespace HCHLView
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var w = Container.Resolve<MainWindow>();
            return w;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.Register<IRepositorioBase<Usuario>>(provider => new RepositorioBase<Usuario>("connectionString"));
        }

    }
}
