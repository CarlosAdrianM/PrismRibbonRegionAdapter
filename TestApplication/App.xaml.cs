using CommonServiceLocator;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.RibbonRegionAdapter;
using Prism.Unity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;

namespace TestApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //var builder = containerRegistry.GetBuilder();
            //builder.RegisterAssemblyTypes(typeof(RibbonRegionAdapter).Assembly)
            //    .InNamespaceOf<RibbonRegionAdapter>()
            //    .AsSelf()
            //    .SingleInstance();

            containerRegistry.RegisterSingleton(typeof(RibbonRegionAdapter));

            //builder.RegisterAssemblyTypes(typeof(UIBootstrapper).Assembly)
            //    .InNamespaceOf<MainWindowViewModel>()
            //    .AsSelf()
            //    .SingleInstance();

            //builder.RegisterAssemblyTypes(typeof(UIBootstrapper).Assembly)
            //    .InNamespaceOf<Module1.Module1HelloCommand>()
            //    .AsSelf()
            //    .InstancePerDependency();

        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(Ribbon), ServiceLocator.Current.GetInstance<RibbonRegionAdapter>());
            regionAdapterMappings.RegisterMapping(typeof(ContextMenu), ServiceLocator.Current.GetInstance<MergingItemsControlRegionAdapter>());
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var catalog = base.CreateModuleCatalog();
            catalog.AddModule<Module1.Module1>();
            return catalog;
        }
    }
}