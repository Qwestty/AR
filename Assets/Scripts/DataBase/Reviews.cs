using SQLite4Unity3d;

namespace nsDB
{
    [Table("reviews")]
    class Reviews
    {
        [PrimaryKey, AutoIncrement, Column("reviews_id")]
        public int reviews_id   { get; set; }
        public int usr_id { get; set; }
        public int city_id { get; set; }
        public string reviews_desc { get; set; }
        public int reviews_mark { get; set; }
    }
}