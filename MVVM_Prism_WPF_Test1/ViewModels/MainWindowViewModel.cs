using MVVM_Prism_WPF_Test1.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_Prism_WPF_Test1.ViewModels
{
    public class MainWindowViewModel:BindableBase
    {

        //声明一个接口对象
        private readonly IRegionManager _regionManager;
        //声明一个Command代理对象
        public DelegateCommand<string> NavigateCommand { get; set; }

        //构造函数
        public MainWindowViewModel(IRegionManager regionManager)
        {
            //为接口对象赋值
            _regionManager = regionManager;
            //为Command代理对象赋值一个方法
            NavigateCommand = new DelegateCommand<string>(NavigateExecute);
            
            //设置MainWindow启动后默认的ContentRegion内容
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        }

        //导航按钮所执行的方法，传入ViewA或ViewB，导航至对应的视图。
        private void NavigateExecute(string uri)
        {
            _regionManager.RequestNavigate("ContentRegion", uri);
        }
    }
}
