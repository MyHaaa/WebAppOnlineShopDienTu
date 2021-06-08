namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Image = "~/Data/add.png";
            
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(250)]
        public string Alias { get; set; }

        public int CategoryID { get; set; }

        public int? SupplierID { get; set; }

        [Range(1,500)]
        public int Quantity { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        public decimal? Price { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string MetaKeyword { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool Status { get; set; }

        public bool HomeFlag { get; set; }

        public bool HotFlag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public virtual Supplierss Supplierss { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
    }
}
