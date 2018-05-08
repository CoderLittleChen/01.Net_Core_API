using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Core_API.Services
{
    public interface ILocalMailService
    {
        void Send();
    }

    public class LocalMailService : ILocalMailService
    {
        private string _mailTo = "cm@qq.com";
        private string _mailFrom = "cm@alibaba.com";

        public void Send()
        {
            Debug.WriteLine("张三给李四发送了文件");
        }
    }
}
