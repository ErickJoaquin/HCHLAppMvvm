using HCHLView.Views.Aplicacion;
using HCHLView.Views.BBII;
using HCHLView.Views.BBDD;
using Prism.Ioc;
using Prism.Modularity;

namespace HCHLView
{
    public class HCHLViewModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AccesoBIView>();
            containerRegistry.RegisterForNavigation<AccesoBDView>();
            containerRegistry.RegisterForNavigation<DMOfertasView>();
        }
    }
}
