using SQLite4Unity3d;

namespace nsDB
{
    [Table("attraction")]
    public class Attraction
    {
        [PrimaryKey, AutoIncrement, Column("attraction_id")]
        public int attraction_id     { get; set; }
        public int city_id { get; set; }
        public string attraction_name { get; set; }
        public int attraction_price { get; set; }
        public int attraction_working_hours { get; set; }
        public string attraction_description { get; set; }
    }
}