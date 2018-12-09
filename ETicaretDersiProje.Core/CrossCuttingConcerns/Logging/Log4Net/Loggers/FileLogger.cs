using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace ETicaretDersiProje.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
   public  class FileLogger:LoggerService
    {
        public FileLogger() : base(LogManager.GetLogger("JsonFileLogger"))
        {
        }
    }
}
