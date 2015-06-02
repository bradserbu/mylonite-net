using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mylonite.core.interfaces;
using mylonite.logging.interfaces;
using mylonite.logging;

namespace mylonite.core
{
    public abstract class Component : IComponent, IDisposable
    {
        protected Component()
        {
            Log = Logger.GetLog(this.GetType());
            IsLoaded = false;
        }

        protected ILog Log { get; private set; }
        public bool IsLoaded { get; private set; }
        
        #region Public Interface
        public void Load()
        {
            // ** If we are already loadded, issue a NOOP
            if (IsLoaded)
                return;

            Log.Debug("Loading component: {0}...", this);
            OnLoad();
            IsLoaded = true;
            Log.Status("LOADED", "Loaded component: {0}", this);
        }
        public void Unload()
        {
            if (IsLoaded == false)
            {
                return;
            }

            Log.Debug("Unloading component: {0}...", this);
            IsLoaded = false;
            OnUnload();
            Log.Status("UNLOADED", "Unloaded component: {0}", this);
        }
        #endregion

        #region Abstract Interface
        protected virtual void OnLoad() { }
        protected virtual void OnUnload() { }
        #endregion

        #region Explicit IDisposable Interface
        void IDisposable.Dispose()
        {
            if (IsLoaded)
                Unload();
        }
        #endregion
    }
}
