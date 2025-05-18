using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomManagement.Data.Entities
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public int Floor { get; set; }

        [Required]
        public string Type { get; set; }

        public ICollection<Guest> Guests { get; set; }
    }
} 