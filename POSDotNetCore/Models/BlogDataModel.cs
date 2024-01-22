using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSDotNetCore.Models
{
    [Table("Tbl_Blog")] ////USE THIS FOR MAPPING TABLE NAME 
    public class BlogDataModel
    {
        [Key]
        [Column("Blog_Id")] //USE THIS FOR MAPPING COLUMN NAME 
        public int BlogId { get; set; }
        [Column("Blog_Author")]
        public string BlogAuthor { get; set; }
        [Column("Blog_Title")]
        public string BlogTitle { get; set; }
        [Column("Blog_Content")]
        public string BlogContent { get; set; }

    }                                   
}                                       
                                        