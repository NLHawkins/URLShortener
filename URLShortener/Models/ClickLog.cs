using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace URLShortener.Models
{
    public class ClickLog
    {
        public int Id { get; set; }
        public DateTime TimeLog { get; set; }
        public int BookMarkId { get; set; }

        [ForeignKey("BookMarkId")]
        public virtual BookMark BookMark { get; set; }
    }
}