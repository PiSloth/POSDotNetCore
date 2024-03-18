using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSDotNetCore.MvcApp.Models
{
    [Table("Tbl_Blog")]
    public class BlogDataModelOnMac
	{
            [Key]
             //USE THIS FOR MAPPING COLUMN NAME 
            public int BlogId { get; set; }
           
            public string BlogAuthor { get; set; }
            
            public string BlogTitle { get; set; }
            
            public string BlogContent { get; set; }
        
	}
}

