using Serilog;
using TopShelfDemo.SampleDependency;

namespace TopShelfDemo
{
    internal class DemoService
    {
        private readonly ILogger _logger;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private readonly ISample _sample;

        public DemoService(ILogger logger, ISample sample)
        {
            this._logger = logger;
            this._sample = sample;
        }



        public void Start()
        {
            _logger.Information("Starting the service");

            Task.Run(() => { 
            while(true)
            {
                _logger.Information("The service is running with sample {0}",_sample.GetDependentColour());
                System.Threading.Thread.Sleep(3000);
            }
            }, _cts.Token);


        } 

        public void Stop()
        {
            _logger.Warning("Stopping the service");
            _cts.Cancel();
        }

    }
}
