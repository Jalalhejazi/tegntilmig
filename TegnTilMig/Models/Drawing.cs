using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TegnTilMig.Models
{
    public class Drawing
    {
        public int DrawingID { get; set; }
        public string DrawingString { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Deleted { get; set; }
    }
}