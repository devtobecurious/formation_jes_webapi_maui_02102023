namespace SuiviDesWookiees.Libs.Services
{
    public interface IStringToUpperService
    {
        string ToUpper(string value);
    }

    public class StringToUpperService : IStringToUpperService
    {
        public string ToUpper(string value)
        {
            return value.ToUpper();
        }
    }
}
