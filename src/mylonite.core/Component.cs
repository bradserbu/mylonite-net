using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mylonite.core.interfaces;

namespace mylonite.core
{
    public abstract class Component : IComponent, IDisposable
    {
        protected Component()
        {

        }

        public bool IsLoaded { get; private set; }

        #region Public Interface
        public void Load()
        {
            OnLoad();
            IsLoaded = true;
        }
        public void Unload()
        {
            if (IsLoaded == false)
            {
                return;
            }

            IsLoaded = false;
            OnUnload();
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
