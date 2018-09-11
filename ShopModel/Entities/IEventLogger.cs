using System;
using System.Collections.Generic;
using System.Text;

namespace DaycareModel.Entities
{
    public interface IEventLogger
    {
        void Log(LogEvent logEvent);
    }
}
