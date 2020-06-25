using MVVM_Prism_WPF_Test1.Events;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Prism_WPF_Test1.ViewModels
{
    class ViewBViewModel:BindableBase
    {
        private string _text="View B";

        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public ViewBViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<MessagePassEvent>().Subscribe(updateText);
        }

        private void updateText(string s)
        {
            Text = s;
        }
    }
}
