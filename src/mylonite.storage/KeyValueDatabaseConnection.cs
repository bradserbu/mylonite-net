using LightningDB;
using mylonite.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylonite.storage
{
    public class KeyValueDatabaseConnection : Connection
    {
        internal enum ConnectionType
        {
            ReadWrite,
            ReadOnly
        }

        internal KeyValueDatabaseConnection(KeyValueDatabase database, ConnectionType connectionType)
        {
            Id = Guid.NewGuid();
            m_database = database;
            m_connectionType = connectionType;
        }

        KeyValueDatabase m_database;
        ConnectionType m_connectionType;
        LightningTransaction m_transaction;

        #region Properties
        public Guid Id { get; private set; }
        public bool IsWritable
        {
            get { return m_connectionType == ConnectionType.ReadWrite; }
        }
        #endregion

        #region Open/Close
        protected override void OnOpen()
        {
            var flags = m_connectionType == ConnectionType.ReadOnly
                      ? TransactionBeginFlags.ReadOnly
                      : TransactionBeginFlags.None;

            m_transaction = m_database.BeginTransaction(flags);
        }
        protected override void OnClose()
        {
            m_transaction.Commit();
            m_transaction.Dispose();
        }
        #endregion

        #region Save/Cancel
        public void Save()
        {
            // ** Commit the transaction
            m_transaction.Commit();

            // ** Close and dispose
            m_transaction.Dispose();

            // ** Open a new transaction
            var flags = m_connectionType == ConnectionType.ReadOnly
                      ? TransactionBeginFlags.ReadOnly
                      : TransactionBeginFlags.None;

            m_transaction = m_database.BeginTransaction(flags);
        }
        public void Cancel()
        {
            // ** Cancel the current transaction
            m_transaction.Abort();
            Close();
        }
        #endregion
        
        #region Get/Set/Remove
        public void Set(string key, string value)
        {
            m_transaction.Put(key, value);
        }
        public bool Get(string key, out string value)
        {
            value = null;
            var result = m_transaction.GetBy(key);
            if (!result.HasValue)
                return false;

            value = result.Value<string>();
            return true;
        }
        public void Remove(string key)
        {
            m_transaction.Delete(key);
        }
        #endregion
    }
}
