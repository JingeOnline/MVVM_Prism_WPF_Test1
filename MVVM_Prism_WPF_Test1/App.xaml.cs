using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Prism.Ioc;
using MVVM_Prism_WPF_Test1.Views;

namespace MVVM_Prism_WPF_Test1
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //这两行代码意义不明，但如果注释掉，导航到ViewA和ViewB会失败，不显示内容，只显示一个Object
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();
        }

        protected override Window CreateShell()
        {
            var w = Container.Resolve<MainWindow>();
            return w;
        }

        //protected override void InitializeShell(Window shell)
        //{
        //    //base.InitializeShell(shell);
        //    Application.Current.MainWindow.Show();
        //}
    }
}
