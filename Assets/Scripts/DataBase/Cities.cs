using SQLite4Unity3d;

namespace nsDB
{
    [Table("cities")]
    public class Cities
    {
        [PrimaryKey, AutoIncrement, Column("city_id")]
        public int    city_id     { get; set; }
        public string city_name   { get; set; }
        public int city_space   { get; set; }
        public int country_id   { get; set; }
    }
}