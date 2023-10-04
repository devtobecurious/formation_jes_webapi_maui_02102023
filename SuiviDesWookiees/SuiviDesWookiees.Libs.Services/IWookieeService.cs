namespace SuiviDesWookiees.Libs.Services
{
    public interface IWookieeService
    {
        IEnumerable<Wookiee> GetAll();

        Wookiee GetOne()
        {
            return new Wookiee(1, new(0, 2));
        }
    }
}