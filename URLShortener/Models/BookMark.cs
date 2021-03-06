﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace URLShortener.Models
{
    public class BookMark
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string HashLink { get; set; }
        public string OwnerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ClickLog> ClickLogs { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public DateTime Created { get; set; }
        public string UserName { get; set; }

        [ForeignKey("OwnerId")]
        public virtual ApplicationUser Owner { get; set; }




    }
}