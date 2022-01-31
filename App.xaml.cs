using System.Windows;
using Prism.Ioc;
using Prism.Unity;
using HCHLView.Views;
using Data;
using Model;
using Data.Interfaces;
using Data.Repositorios;
using HCHLView.Views.BBDD;
using HCHLView.Views.BBII;
using HCHLView.Views.Aplicacion;

namespace HCHLView
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var w = Container.Resolve<MenuInicioView>();
            return w;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AccesoBDView>();
            containerRegistry.RegisterForNavigation<AccesoBIView>();
            containerRegistry.RegisterForNavigation<DMOfertasView>();

            containerRegistry.Register<IRepositorioRevisiones, RepositorioRevisiones>();
            containerRegistry.Register<IRepositorioCarpetas, RepositorioCarpetas>();
            containerRegistry.Register<IRepositorioContactos, RepositorioContactos>();
            containerRegistry.Register<IRepositorioEquiposLinkeados, RepositorioEquiposLinkeados>();
            containerRegistry.Register<IRepositorioItem, RepositorioItem>();
            containerRegistry.Register<RepositorioMarca>();
            containerRegistry.Register<RepositorioPais>();
            containerRegistry.Register<IRepositorioTablasBD, RepositorioTablasBD>();
            containerRegistry.Register<IRepositorioOferta, RepositorioOferta>();
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