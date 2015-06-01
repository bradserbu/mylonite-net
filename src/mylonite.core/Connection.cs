using mylonite.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.core
{
    public abstract class Connection : IConnection
    {
        #region Properties
        public bool IsOpened { get; private set; }
        #endregion

        #region Public Interface
        public void Open()
        {
            OnOpen();
            IsOpened = true;
        }
        public void Close()
        {
            if (IsOpened == false)
            {
                return;
            }

            IsOpened = false;
            OnClose();
        }
        #endregion

        #region Abstract Interface
        protected abstract void OnOpen();
        protected abstract void OnClose();
        #endregion
    }
}
