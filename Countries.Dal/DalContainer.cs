using System;
using Countries.Dal.DataManager;

namespace Countries.Dal
{
    /// <summary>
    /// Data access container
    /// </summary>
    public static class DalContainer
    {
        /// <summary>
        /// The data access manager
        /// </summary>
        private static IDataManager sDataManager;

        /// <summary>
        /// Get data access manager
        /// </summary>
        public static IDataManager GetDataManager
        {
            get
            {
                if (sDataManager == null)
                {
                    throw new ApplicationException("DataManager не зарегистрирован");
                }

                return sDataManager;
            }
        }

        /// <summary>
        /// Register data access manager in container
        /// </summary>
        /// <param name="dataManager">
        /// Data access manager
        /// </param>
        public static void RegisterDataManger(IDataManager dataManager)
        {
            if(dataManager == null)
                throw new ArgumentException(nameof(dataManager));

            sDataManager = dataManager;
        }
    }
}