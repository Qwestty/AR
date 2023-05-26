using SQLite4Unity3d;

namespace nsDB
{
    [Table("purchasedTickets")]
    public class PurchasedTickets
    {
        [PrimaryKey, AutoIncrement, Column("purchasedTickets_id")]
        public int    purchasedTickets_id        { get; set; }
        public int    usr_id                     { get; set; }
    }
}