using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using URSpot.Core.Utils;
using Acr.UserDialogs;

namespace URSpot.Core.Services
{
    public interface IBusyService
    {
        IDisposable BeginBusy();
        bool IsBusy { get; }
    }

    public class BusyService : IBusyService
    {
        ScopedValue<bool> isBusy;
        public BusyService()
        {
            this.isBusy = new ScopedValue<bool>();
            this.isBusy.ValueStarted += OnBusyStarted;
            this.isBusy.ValueEnded += OnBusyEnded;
        }

        public bool IsBusy => this.isBusy.Value;

        public IDisposable BeginBusy()
        {
            return this.isBusy.BeginScope(true);
        }

        private void OnBusyEnded(bool oldValue, bool newValue)
        {
            if(!newValue)
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        private void OnBusyStarted(bool oldValue, bool newValue)
        {
            if(newValue)
            {
                UserDialogs.Instance.ShowLoading("Loading", MaskType.Black);
            }
        }
    }
}
