using System;
using System.Threading;
using NyanCatDisplay;
using System.Windows.Threading;
using System.Windows.Forms;

namespace NyanCatReporterDataCollector
{
    public class CatRenderer
    {
        private NyanCatWindow _nyanCat;
        private Thread _uiThread;

        public void Start()
        {
            try
            {
                SetUpUiThread();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        private void SetUpUiThread()
        {
            _uiThread = new Thread(() =>
            {
                _nyanCat = new NyanCatWindow(100);
                _nyanCat.Show();
                _nyanCat.Closed += (s, e) => _nyanCat.Dispatcher.InvokeShutdown();
                Dispatcher.Run();
            });
            _uiThread.SetApartmentState(ApartmentState.STA);
            _uiThread.Start();
        }

        public void Stop()
        {
            try
            {
                _nyanCat.Dispatcher.Invoke(() => _nyanCat.Close());
                _nyanCat.Dispatcher.InvokeShutdown();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }

        }

        public void UpdateStats(TestStats stats)
        {
            try
            {
                _nyanCat.Dispatcher.Invoke(() => 
                    {
                        _nyanCat.PassedCount = stats.Passed;
                        _nyanCat.FailedCount = stats.Failed;
                        _nyanCat.OtherCount = stats.Other;
                    });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }
    }
}
