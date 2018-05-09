using _01从头编写API基础框架;
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
        //这里是通过在  Startup 构造函数中，new IConfigration对象

        //然后这里通过对比appSetting.json文件的格式，来取值
        private string _mailTo = Startup._configuration["mailSettings:mailToAddress"];
        private string _mailFrom = Startup._configuration["mailsSettings:mailFromAddress"];

        public void Send()
        {
            Debug.WriteLine("{0}给{1}发送了文件", _mailTo, _mailFrom);
        }
    }
}
