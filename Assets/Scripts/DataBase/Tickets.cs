using SQLite4Unity3d;

namespace nsDB
{
    [Table("tickets")]
    public class Tickets
    {
        [PrimaryKey, AutoIncrement, Column("tickets_id")]
        public int       tickets_id              { get; set; }
        public string    tickets_price           { get; set; }
        public string    tickets_departure_time  { get; set; }
        public string    tickets_data            { get; set; }
        public string    city_id_departure       { get; set; }
        public string    city_id_arrival         { get; set; }
        public string    tickets_place           { get; set; }
        public string    tickets_voyage          { get; set; }
        public string    tickets_landing_up      { get; set; }
    }
}