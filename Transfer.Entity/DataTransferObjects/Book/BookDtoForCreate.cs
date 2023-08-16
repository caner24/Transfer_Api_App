using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Entity.DataTransferObjects.Book
{
    public record class BookDtoForCreate:BookDtoValidation
    {
        public Guid BookId { get; init; }
    }
}
