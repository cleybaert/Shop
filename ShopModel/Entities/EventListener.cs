using log4net;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DaycareModel.Entities
{
    public class EventListener : IEventLogger
    {
        private readonly ILog _logger;

        public List<LogEvent> Events { get; set; }

        public EventListener(ILog logger)
        {
            this._logger = logger;
            _logger.Debug("New event listener created");
            Events = new List<LogEvent>();
        }

        public void Log(LogEvent logEvent)
        {
            _logger.Debug(logEvent);
            Events.Add(logEvent);
        }
    }
}
