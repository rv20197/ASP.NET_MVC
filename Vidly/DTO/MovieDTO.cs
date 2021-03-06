using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public byte? GenreId { get; set; }

        public GenreTypeDTO Genre { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Range(1, 20)]
        public byte? NumberInStock { get; set; }

        public byte? NumberAvailable { get; set; }

    }
}