using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Objects.Models.Entities
{
    [Table("restaurant")]
    public class RestaurantModel
    {
        [Column("idrestaurant")]
        public int Id { get; set; }

        [Column("namefranchise")]
        public string NameFranchise { get; set; }

        [Column("namerestaurant")]
        public string NameRestaurant { get; set; }

        [Column("emailrestaurant")]
        public string EmailRestaurant { get; set; }

        [Column("phonerestaurant")]
        public string PhoneRestaurant { get; set; }


        public ICollection<TableModel>? TablesModel { get; set; }
    }
}