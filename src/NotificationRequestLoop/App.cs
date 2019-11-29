using System.Threading;
using System.Threading.Tasks;

namespace QueueExample.NotificationRequestLoop
{
    public class App
    {
        private CancellationTokenSource _cts;
        private NotificationService _serivice;
        private Task _runningTask;

        public App()
        {
            _serivice = new NotificationService();
        }

        public Task Start()
        {
            _cts = new CancellationTokenSource();
            var window = new NotificationWindow();
            _runningTask = _serivice.RunAsync(window, _cts.Token);

            // show window

            return Task.CompletedTask;
        }

        public async Task Stop()
        {
            if (_cts == null)
            {
                return;
            }

            if (_runningTask == null || _runningTask.IsCompleted)
            {
                _cts.Dispose();
            }

            try
            {
                _cts.Cancel();
            }
            finally
            {
                await _runningTask;
                _cts.Dispose();
            }
        }
    }
}
