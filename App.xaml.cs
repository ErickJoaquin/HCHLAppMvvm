using Data;
using Data.Interfaces;
using Data.Repositorios;
using HCHLView.Views;
using HCHLView.Views.Aplicacion;
using HCHLView.Views.BBDD;
using HCHLView.Views.BBII;
using Model;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;

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
            #region Navegacion
            containerRegistry.RegisterForNavigation<AccesoBDView>();
            containerRegistry.RegisterForNavigation<DMOfertasView>();
            containerRegistry.RegisterForNavigation<AccesoBIView>(nameof(AccesoBIView));
            #endregion

            #region Cachés
            containerRegistry.Register<RepositorioBase<Proceso>>();
            containerRegistry.Register<IRepositorioBase<Proceso>>(provider =>
            {
                var procesoRepository = provider.Resolve<RepositorioBase<Proceso>>();
                return new CacheRepositoryDecorator<Proceso>(procesoRepository);
            });

            containerRegistry.Register<RepositorioBase<BU>>();
            containerRegistry.Register<IRepositorioBase<BU>>(provider =>
            {
                var buRepository = provider.Resolve<RepositorioBase<BU>>();
                return new CacheRepositoryDecorator<BU>(buRepository);
            });

            containerRegistry.Register<RepositorioBase<Usuario>>();
            containerRegistry.Register<IRepositorioBase<Usuario>>(provider =>
            {
                var userRepository = provider.Resolve<RepositorioBase<Usuario>>();
                return new CacheRepositoryDecorator<Usuario>(userRepository);
            });

            containerRegistry.Register<RepositorioBase<BaseInstalada>>();
            containerRegistry.Register<IRepositorioBase<BaseInstalada>>(provider =>
            {
                var biRepository = provider.Resolve<RepositorioBase<BaseInstalada>>();
                return new CacheRepositoryDecorator<BaseInstalada>(biRepository);
            });

            containerRegistry.Register<RepositorioBase<Pago>>();
            containerRegistry.Register<IRepositorioBase<Pago>>(provider =>
            {
                var payRepository = provider.Resolve<RepositorioBase<Pago>>();
                return new CacheRepositoryDecorator<Pago>(payRepository);
            });

            containerRegistry.Register<RepositorioBase<Mercado>>();
            containerRegistry.Register<IRepositorioBase<Mercado>>(provider =>
            {
                var marketRepository = provider.Resolve<RepositorioBase<Mercado>>();
                return new CacheRepositoryDecorator<Mercado>(marketRepository);
            });

            containerRegistry.Register<RepositorioBase<EquiposCRM>>();
            containerRegistry.Register<IRepositorioBase<EquiposCRM>>(provider =>
            {
                var crmRepository = provider.Resolve<RepositorioBase<EquiposCRM>>();
                return new CacheRepositoryDecorator<EquiposCRM>(crmRepository);
            });
            #endregion

            #region Repositorios
            containerRegistry.Register<IRepositorioRevisiones, RepositorioRevisiones>();
            containerRegistry.Register<IRepositorioCarpetas, RepositorioCarpetas>();
            containerRegistry.Register<IRepositorioContactos, RepositorioContactos>();
            containerRegistry.Register<IRepositorioEquipos, RepositorioEquipos>();
            containerRegistry.Register<IRepositorioItem, RepositorioItem>();
            containerRegistry.Register<RepositorioMarca>();
            containerRegistry.Register<RepositorioPais>();
            containerRegistry.Register<IRepositorioTablasBD, RepositorioTablasBD>();
            containerRegistry.Register<IRepositorioOferta, RepositorioOferta>();

            containerRegistry.Register<IRepositorioBase<ContactoCliente>, RepositorioBase<ContactoCliente>>();
            containerRegistry.Register<IRepositorioBase<ContactoBU>, RepositorioBase<ContactoBU>>();
            containerRegistry.Register<IRepositorioBase<EndUser>, RepositorioBase<EndUser>>();
            containerRegistry.Register<IRepositorioBase<Vendor>, RepositorioBase<Vendor>>();
            #endregion 
        }
    }
}