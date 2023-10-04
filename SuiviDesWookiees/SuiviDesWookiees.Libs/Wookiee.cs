using System.Diagnostics.CodeAnalysis;

namespace SuiviDesWookiees.Libs
{
    public class Wookiee
    {
        public Wookiee()
        {

        }

        public Wookiee(int id, Position position)
        {
            this.Id = id;
            Position = position;

        }

        public int Id { get; init; }

        [AllowNull]
        public string Surname { get; set; }

        public string? NickName { get; set; }

        public Position Position { get; set; }
    }
}
