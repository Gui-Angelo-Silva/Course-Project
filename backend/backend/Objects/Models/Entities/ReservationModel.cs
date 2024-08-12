using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Objects.Models.Entities
{
    [Table("reservation")]
    public class ReservationModel
    {
        [Column("idreservation")]
        public int Id { get; set; }

        [Column("datereservation")]
        public string DateReservation { get; set; }

        [Column("hourbegin")]
        public string HourBegin { get; set; }

        [Column("hourfinish")]
        public string HourFinish { get; set; }

        [Column("timeduration")]
        public string TimeDuration { get; set; }

        [Column("valuereservation")]
        public decimal ValueReservation { get; set; }

        [ForeignKey("iduser")]
        public int IdUser { get; set; }

        [ForeignKey("idtable")]
        public int IdTable { get; set; }

        [Column("createat")]
        public DateTime CreateAt { get; set; }

        [Column("updateat")]
        public DateTime UpdateAt { get; set; }


        public UserModel? UserModel { get; set; }
        public TableModel? TableModel { get; set; }
    }
}
