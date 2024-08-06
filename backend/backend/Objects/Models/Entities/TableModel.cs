using System.ComponentModel.DataAnnotations.Schema;

namespace SGED.Objects.Models.Entities
{
    [Table("table")]
    public class TableModel
    {
        [Column("idtable")]
        public int Id { get; set; }

        [Column("numbertable")]
        public int NumberTable { get; set; }

        [Column("capacitypersons")]
        public int CapacityPersons { get; set; }

        [Column("locationtable")]
        public string LocationTable { get; set; }

        [Column("valuetable", TypeName = "decimal(18, 2)")]
        public decimal ValueTable
        {
            get => _valueTable;
            set => _valueTable = Math.Round(value, 2);
        }
        private decimal _valueTable;

        [ForeignKey("idrestaurant")]
        public int IdRestaurant { get; set; }


        public RestaurantModel? RestaurantModel { get; set; }
        public ICollection<ReservationModel>? ReservationsModel { get; set; }
    }
}