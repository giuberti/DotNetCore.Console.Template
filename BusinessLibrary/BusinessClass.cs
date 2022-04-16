using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace BusinessLibrary
{
    public class BusinessClass : IBusinessClass
    {
        private ILogger _logger;
        private IConfiguration _config;
        public BusinessClass(ILogger<BusinessClass> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public void RunBusiness()
        {
            int loopTimes = _config.GetValue<int>("loopTimes");

            for (int i = 0; i < loopTimes; i++)
            {
                _logger.LogInformation($"Doing businnes number #{i}");
                _logger.LogDebug("It also can be looger this way {num}", i);
            }
        }
    }
}
