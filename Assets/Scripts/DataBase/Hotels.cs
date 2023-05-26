using SQLite4Unity3d;

namespace nsDB
{
    [Table("hotels")]
    public class Hotels
    {
        [PrimaryKey, AutoIncrement, Column("hotel_id")]
        public int    hotel_id                          { get; set; }
        public int    city_id                      { get; set; }
        public string hotel_name                        { get; set; }
        public int hotel_price                   { get; set; }
        public int hotel_working_hours                 { get; set; }
    }
}