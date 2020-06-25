using MVVM_Prism_WPF_Test1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM_Prism_WPF_Test1.Views
{
    /// <summary>
    /// ViewA.xaml 的交互逻辑
    /// </summary>
    public partial class ViewA : UserControl
    {
        public ViewA()
        {
            InitializeComponent();

            //在View中添加了如下的代码就能让View自动定位ViewModel,不需要再手动设置DataContext了。
            //xmlns: prism = "http://prismlibrary.com/"
            //prism: ViewModelLocator.AutoWireViewModel = "True"

            //this.DataContext = new ViewAViewModel();
        }
    }
}
