using System.Windows;
using Prism.Ioc;
using Prism.Unity;
using HCHLView.Views;
using Data;
using Model;
using HCHLView.Views.CalculoNomina;

namespace HCHLView
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var w = Container.Resolve<AccesoBD>();
            return w;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<RepositorioTablasBD>();
            containerRegistry.Register<IRepositorioBase<Usuario>, RepositorioBase<Usuario>>();
        }

    }
}
