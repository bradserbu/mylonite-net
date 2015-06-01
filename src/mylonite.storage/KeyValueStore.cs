using LightningDB;
using mylonite.extensions;
using mylonite.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using mylonite.extensions;

namespace mylonite.storage
{
    public class KeyValueStore : NamedComponent
    {
        #region Constants
        const EnvironmentOpenFlags ENV_OPEN_FLAGS = EnvironmentOpenFlags.WriteMap | EnvironmentOpenFlags.MapAsync;
        static readonly long DB_INITIAL_SIZE = 1.Megabytes();
        const string DB_FILE_NAME = "data.mdb"; 
        #endregion

        #region Constructors
        public KeyValueStore(string name) : this(name, KeyValueStoreConfiguration.Default) { }
        public KeyValueStore(string name, KeyValueStoreConfiguration config)
            : base(name)
        {
            this.Configuration = config;
        }
        #endregion

        LightningEnvironment m_env;

        #region Properties
        public KeyValueStoreConfiguration Configuration { get; private set; }
        #endregion

        #region Open/Close
        protected override void OnLoad()
        {
            // ** Create the storage file
            var DBPath = Path.Combine(Configuration.DataDirectory, Name, DB_FILE_NAME);
            var DBDirectory = Path.GetDirectoryName(DBPath);

            // ** Sparse File Support
            if (File.Exists(DBPath) == false 
                && Configuration.SparseFileSupportEnabled)
            {
                // If the database didn't already exist,
                // then open the file with a small size initially,
                // then close it so we can mark it as sparse
                var temp_env = new LightningEnvironment(DBDirectory, ENV_OPEN_FLAGS);
                temp_env.MapSize = Configuration.DatabaseFileSize;
                temp_env.Open();
                temp_env.Close();

                FileExtensions.MarkAsSparseFile(DBPath);
            }

            // ** Load the storage environment
            m_env = new LightningEnvironment(DBDirectory, ENV_OPEN_FLAGS);
            m_env.MaxDatabases = Configuration.MaxCollections;
            m_env.MapSize = Configuration.DatabaseFileSize;

            // ** Open the storage environment
            m_env.Open();

            base.OnLoad();
        }
        protected override void OnUnload()
        {
            m_env.Flush(true);
            m_env.Close();

            base.OnUnload();
        }
        #endregion

        #region Collection Interface

        #endregion
    }
}
