using System.Collections.Generic;

namespace Vidly.DTO
{
    public class NewRentalDTO
    {
        public int CustomerId { get; set; }
        public List<int> MoviesIds { get; set; }
    }
}