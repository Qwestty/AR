using SQLite4Unity3d;

namespace nsDB
{
    [Table("administrators")]
    public class Administrators
    {
        [PrimaryKey, AutoIncrement, Column("adm_id")]
        public int    adm_id   { get; set; }
        public string adm_login { get; set; }
        public string adm_password { get; set; }
        public string adm_name { get; set; }
    }
}