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
    public class KeyValueDatabase : NamedComponent
    {
        #region Constants
        const EnvironmentOpenFlags ENV_OPEN_FLAGS = EnvironmentOpenFlags.WriteMap | EnvironmentOpenFlags.MapAsync;
        static readonly long DB_INITIAL_SIZE = 1.Megabytes();
        const string DB_FILE_NAME = "data.mdb"; 
        #endregion

        #region Constructors
        public KeyValueDatabase(string name) : this(name, KeyValueDatabaseConfiguration.Default) { }
        public KeyValueDatabase(string name, KeyValueDatabaseConfiguration config)
            : base(name)
        {
            this.Configuration = config;
        }
        #endregion

        LightningEnvironment m_env;

        #region Properties
        public KeyValueDatabaseConfiguration Configuration { get; private set; }
        #endregion

        #region Load/Unload
        protected override void OnLoad()
        {
            // ** Create the storage file
            var DBPath = Path.Combine(Configuration.DataDirectory, Name, DB_FILE_NAME);
            var DBDirectory = Path.GetDirectoryName(DBPath);

            // ** Sparse File Support
            if (!File.Exists(DBPath)
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

        #region Delete Database
        public void Delete()
        {
            // ** Ensure the database is unloaded
            if (IsLoaded)
                throw new Exception("Database must be unloaded before it can be deleted.");

            // ** Delete the database by deleting it's containing directory
            var DBDirectory = Path.Combine(Configuration.DataDirectory, Name);
            if (Directory.Exists(DBDirectory))
            {
                Directory.Delete(DBDirectory, true);
            }
        }
        #endregion

        #region Collection Interface
        public void CreateCollection(string collectionName)
        {
            throw new NotImplementedException();
        }
        public void DeleteCollection(string collectionName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
