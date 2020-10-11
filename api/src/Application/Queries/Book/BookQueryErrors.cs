using System.ComponentModel;

namespace Application.Queries.Book
{
    public enum BookQueryErrors
    {
        [Description("Book with id '{0}' does not exist")]
        BookDoesNotExist
    }
}
