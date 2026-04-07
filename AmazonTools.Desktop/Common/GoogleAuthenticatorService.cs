using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace AmazonTools.Desktop.Common
{
    public class GoogleAuthenticatorService
    {
        private TOTPGenerator _generator;
        private DispatcherTimer _refreshTimer;
        private string _currentSecret;

        public event Action<string, int> OnCodeUpdated; // 验证码和剩余秒数

        public GoogleAuthenticatorService()
        {
            _generator = new TOTPGenerator();
            _refreshTimer = new DispatcherTimer();
            _refreshTimer.Interval = TimeSpan.FromSeconds(1);
            _refreshTimer.Tick += OnTimerTick;
        }

        public void Start(string secret)
        {
            _currentSecret = secret;
            _refreshTimer.Start();
            UpdateCode(); // 立即更新一次
        }

        public void Stop()
        {
            _refreshTimer.Stop();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            UpdateCode();
        }

        private void UpdateCode()
        {
            if (string.IsNullOrEmpty(_currentSecret)) return;

            string code = _generator.GenerateCode(_currentSecret);
            int remainingSeconds = _generator.GetRemainingSeconds();

            OnCodeUpdated?.Invoke(code, remainingSeconds);
        }
    }
}
