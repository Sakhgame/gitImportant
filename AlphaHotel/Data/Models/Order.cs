namespace AlphaHotel.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int OrderID { get; set; }

        public int? ClientID { get; set; }

        public int? RoomID { get; set; }

        public int? CardID { get; set; }

        public DateTime? CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        public int? UserID { get; set; }

        public virtual Card Card { get; set; }

        public virtual Client Client { get; set; }

        public virtual Room Room { get; set; }

        public virtual User User { get; set; }
    }
}
