namespace Countries.Dal.Models.Currency
{
    /// <summary>
    /// Модель валюты
    /// </summary>
    public class Currency : ICurrency
    {
        public string Name { get; set; }
        public void Update(ICurrency currency)
        {
            Name = currency.Name;
        }
    }
}
