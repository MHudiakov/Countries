
namespace Countries.Dal.Models.Currency
{
    /// <summary>
    /// Currency model
    /// </summary>
    public sealed class Currency : ICurrency
    {
        public string Name { get; set; }
        public void Update(ICurrency currency)
        {
            Name = currency.Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
