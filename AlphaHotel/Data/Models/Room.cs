namespace AlphaHotel.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            Orders = new HashSet<Order>();
        }

        [StringLength(50)]
        public string Floor { get; set; }

        [StringLength(10)]
        public string RoomNumber { get; set; }

        [StringLength(255)]
        public string RoomCategory { get; set; }

        [StringLength(50)]
        public string RoomStatus { get; set; }

        public int? Price { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
