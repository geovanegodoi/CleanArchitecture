using System.Collections.Generic;

namespace CleanIntegration.Core.ReclameAqui.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        public static List<Ticket> EmptyList()
            => new List<Ticket>();
    }

    public class NullTicket : Ticket
    {
    }
}
