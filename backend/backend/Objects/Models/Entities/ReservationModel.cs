using System.ComponentModel.DataAnnotations.Schema;

namespace SGED.Objects.Models.Entities
{
    [Table("reservation")]
    public class ReservationModel
    {
        [Column("idreservation")]
        public int Id { get; set; }

        [Column("datereservation")]
        public DateTime DateReservation { get; set; }

        [Column("valuereservation", TypeName = "decimal(18, 2)")]
        public decimal ValueReservation
        {
            get => _valueReservation;
            set => _valueReservation = Math.Round(value, 2);
        }
        private decimal _valueReservation;

        [Column("createat")]
        public DateTime CreateAt { get; set; }

        [Column("updateat")]
        public DateTime UpdateAt { get; set; }

        [ForeignKey("iduser")]
        public int IdUser { get; set; }

        [ForeignKey("idtable")]
        public int IdTable { get; set; }


        public UserModel? UserModel { get; set; }
        public TableModel? TableModel { get; set; }
    }
}
