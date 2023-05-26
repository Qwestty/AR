using SQLite4Unity3d;

namespace nsDB
{
    [Table("featuredTickets")]
    public class FeaturedTickets
    {
        [PrimaryKey, AutoIncrement, Column("featuredTickets_id")]
        public int    featuredTickets_id   { get; set; }
        public int    usr_id               { get; set; }
    }
}