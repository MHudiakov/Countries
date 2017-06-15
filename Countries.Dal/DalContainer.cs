using System;
using Countries.Dal.DataManager;

namespace Countries.Dal
{
    /// <summary>
    /// Контейнер доступа к данным
    /// </summary>
    public static class DalContainer
    {
        /// <summary>
        /// Менеджер доступа к данным
        /// </summary>
        private static IDataManager sDataManager;

        /// <summary>
        /// Получить менеджер доступа к данным
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
        /// Зарегистрировать менеджер доступа к данным в контейнере
        /// </summary>
        /// <param name="dataManager">
        /// Менеджер доступа к данным в контейнере
        /// </param>
        public static void RegisterDataManger(IDataManager dataManager)
        {
            if(dataManager == null)
                throw new ArgumentException(nameof(dataManager));

            sDataManager = dataManager;
        }
    }
}