using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomManagement.Data.Entities
{
    public class Guest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(400)]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        [MaxLength(600)]
        public string Address { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        public int RoomId { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }
    }
} 