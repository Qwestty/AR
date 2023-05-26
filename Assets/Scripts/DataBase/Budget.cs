using SQLite4Unity3d;

namespace nsDB
{
    [Table("budget")]
    public class Budget
    {
        [PrimaryKey, AutoIncrement, Column("budget_id")]
        public int    budget_id        { get; set; }
        public int    usr_id    { get; set; }
        public int budget_min_amount   { get; set; }
        public int budget_max_amount   { get; set; }
    }
}