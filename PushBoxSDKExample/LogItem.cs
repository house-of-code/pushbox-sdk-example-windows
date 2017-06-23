using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushBoxSDKExample
{
    class LogItem
    {
        public LogItem(string title)
        {
            Title = title;
        }

        public string Title {
            get;
            set;
        }
    }
}
