using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Core_API.Services
{
    public class CloudMailService : ILocalMailService
    {
        //private readonly _mailTo=

        public void Send()
        {
            Debug.WriteLine("王五给赵六发送了邮件");
        }
    }
}
