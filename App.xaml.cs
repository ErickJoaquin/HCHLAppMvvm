using System.Windows;
using Prism.Ioc;
using Prism.Unity;
using HCHLView.Views;
using Data;
using Model;
using Data.Interfaces;
using HCHLView.Views.BBDD;

namespace HCHLView
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var w = Container.Resolve<MenuInicio>();
            return w;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AccesoBD>();

            containerRegistry.Register<RepositorioCarpetas>();
            containerRegistry.Register<RepositorioContactos>();
            containerRegistry.Register<RepositorioEquiposLinkeados>();
            containerRegistry.Register<RepositorioItem>();
            containerRegistry.Register<RepositorioMarca>();
            containerRegistry.Register<RepositorioPais>();
            containerRegistry.Register<RepositorioTablasBD>();
            containerRegistry.Register<IRepositorioBase<Usuario>, RepositorioBase<Usuario>>();
            containerRegistry.Register<IRepositorioBase<BaseInstalada>, RepositorioBase<BaseInstalada>>();
            containerRegistry.Register<IRepositorioBase<BU>, RepositorioBase<BU>>();
            containerRegistry.Register<IRepositorioBase<ContactoCliente>, RepositorioBase<ContactoCliente>>();
            containerRegistry.Register<IRepositorioBase<ContactoBU>, RepositorioBase<ContactoBU>>();
            containerRegistry.Register<IRepositorioBase<EndUser>, RepositorioBase<EndUser>>();
            containerRegistry.Register<IRepositorioBase<Pago>, RepositorioBase<Pago>>();
            containerRegistry.Register<IRepositorioBase<Vendor>, RepositorioBase<Vendor>>();

            //containerRegistry.Register<RepositorioPorOferta<>>();        
        }
    }
}