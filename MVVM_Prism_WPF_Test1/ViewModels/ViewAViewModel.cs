using MVVM_Prism_WPF_Test1.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Prism_WPF_Test1.ViewModels
{
    class ViewAViewModel : BindableBase
    {
        private string _firstName="first name";

        public string FirstName
        {
            get { return _firstName; }
            set 
            {
                SetProperty(ref _firstName, value);

                //可以通过该方法通知Command刷新状态，重新执行CanSubmitExecute()
                //SubmitCommand.RaiseCanExecuteChanged();

                //触发FullName属性的PropertyChanged事件
                RaisePropertyChanged("FullName");
            }
        }

        private string _lastName="last name";

        public string LastName
        {
            get { return _lastName; }
            set 
            { 
                SetProperty(ref _lastName, value);
                RaisePropertyChanged("FullName");
            }
        }

        public string FullName { get { return FirstName + " " + LastName; } }

        //可空类型，没有赋值的时候会返回null，而不是默认的初始值1970年
        private DateTime? _submitTime;

        public DateTime? SubmitTime
        {
            get { return _submitTime; }
            set { SetProperty(ref _submitTime, value); }
        }

        private IEventAggregator _eventAggregator;

        public ViewAViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            //通过让Command监听属性值的变化，来自动更新CanSubmitExecute属性
            SubmitCommand = new DelegateCommand(SubmitExecute, CanSubmitExecute).
                ObservesProperty(() => FirstName).ObservesProperty(() => LastName);
        }

        public DelegateCommand SubmitCommand { get; set; }

        private void SubmitExecute()
        {
            SubmitTime = DateTime.Now;
            //传递该条消息给其他页面
            _eventAggregator.GetEvent<MessagePassEvent>().Publish(SubmitTime.ToString());
        }
        private bool CanSubmitExecute()
        {
            return !String.IsNullOrEmpty(FirstName) && !String.IsNullOrEmpty(LastName);
        }
    }
}
