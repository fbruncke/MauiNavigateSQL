using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiNavigateSQL.Model
{
    [Table("item")]
    public class Item //: BindableObject , this gave me some issue, when serializing, use INotifyProperty changed
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        //Notice foreign key constrains must be handled manually !!
    }
}
