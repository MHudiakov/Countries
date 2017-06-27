namespace Countries.Dal.Models.Currency
{
    /// <summary>
    /// Currency model interface
    /// </summary>
    public interface ICurrency
    {
        string Name { get; set; }

        void Update(ICurrency currency);
    }
}