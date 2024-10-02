using System.Collections.Generic; 
using contactApi.Models; 

namespace contactApi.DTOs
{
    public class PaginatedContactsResponse
    {
        public List<Contact> Contacts { get; set; }
        public int TotalCount { get; set; }    
    }
}