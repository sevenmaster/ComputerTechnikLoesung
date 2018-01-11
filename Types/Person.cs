namespace Perso.Types
{
    public class Person
    {
        public Person(string name, string vorname, int alter)
        {
            Name = name;
            Vorname = vorname;
            Alter = alter;
        }

        public string Name { get; set; }
        public string Vorname { get; set; }
        public int Alter { get; set; }
    }
}