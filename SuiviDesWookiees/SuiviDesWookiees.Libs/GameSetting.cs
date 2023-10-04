namespace SuiviDesWookiees.Libs
{
    public class GameSetting
    {
        public int NbWookiees { get; set; } = 10;

        public PositionSetting? Position { get; set; }
    }

    public record PositionSetting(int X, int Y);
}
