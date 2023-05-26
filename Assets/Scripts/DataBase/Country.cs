using SQLite4Unity3d;

namespace nsDB
{
    [Table("country")]
    public class Country
    {
        [PrimaryKey, AutoIncrement, Column("country_id")]
        public int country_id            { get; set; }
        public string country_name        { get; set; }
        public string country_continent { get; set; }
        public int country_population { get; set; }
        public string country_language          { get; set; }
        public string country_religion    { get; set; }
    }
}