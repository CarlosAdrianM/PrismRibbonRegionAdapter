using Prism.Modularity;
using Prism.Regions;
using CommonServiceLocator;
using Prism.Ioc;

namespace TestApplication.Module1
{
	[Module(ModuleName = "Module1", OnDemand = true)]
	class Module1 : IModule
	{

    private readonly IRegionManager _regionManager;

		public Module1(IRegionManager regionManager)
    {
      _regionManager = regionManager;
    }

        public void OnInitialized(IContainerProvider containerProvider)
        {
			_regionManager.RegisterViewWithRegion(ShellRegions.EditorContextMenu, GetContextMenu);
		}

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        private object GetContextMenu()
		{
			var cmv = ServiceLocator.Current.GetInstance<EditorContextMenuView>();
			return cmv.ContextMenu;
		}
	}
}
