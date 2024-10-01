namespace CA241001
{
    internal class Event
    {
        public int Year { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public Dictionary<string, int> Medals { get; set; }

        public override string ToString()
        {
            return
                $"\tÉv:         {Year}\n" +
                $"\tOrszág:     {Country}\n" +
                $"\tVáros:      {City}\n" +
                $"\tEredmények: a:{Medals["gold"]} | e:{Medals["silver"]} | b:{Medals["bronze"]}\n";
        }

        public Event(string row)
        {
            var v = row.Split(";");
            Year = int.Parse(v[0]);
            Country = v[1];
            City = v[2];
            Medals = new()
            {
                { "gold",   int.Parse(v[3]) },
                { "silver", int.Parse(v[4]) },
                { "bronze", int.Parse(v[5]) },
            };
        }
    }
}
