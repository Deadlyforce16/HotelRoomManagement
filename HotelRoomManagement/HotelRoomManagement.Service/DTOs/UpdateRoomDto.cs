using System.ComponentModel.DataAnnotations;

namespace HotelRoomManagement.Service.DTOs
{
    public class UpdateRoomDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public int Floor { get; set; }

        [Required]
        public string Type { get; set; }
    }
}