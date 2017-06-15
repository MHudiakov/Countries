namespace Countries.Dal.Models.Currency
{
    /// <summary>
    /// Интерфейс модели валюты
    /// </summary>
    public interface ICurrency
    {
        string Name { get; set; }

        void Update(ICurrency currency);
    }
}
