using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Prism_WPF_Test1.Events
{
    //泛型中填入你要传递的消息类型，可以是任何对象
    public class MessagePassEvent:PubSubEvent<string>
    {
    }
}
