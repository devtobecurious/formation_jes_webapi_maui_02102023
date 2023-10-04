namespace DiscoverDotnetEight.AppCode
{
    public class Service
    {
        public void Call() { }
    }

    public class Planet(int id, string name, Service service)
    {
        public Planet() : this(1, "", null)
        {

        }

        public void Tourner()
        {
            service.Call();
        }

        public int ID => id;

        public string Name { get; set; } = name;

        public Position Position { get; set; } = new Position(0, 0);
    }

    public record Position(int X, int Y);

    public class ChildPlanet : Planet
    {
        public ChildPlanet() : base(0, "", null)
        {

        }
    }
}
