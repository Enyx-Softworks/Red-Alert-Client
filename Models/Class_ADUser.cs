using System.DirectoryServices;

namespace RA_Client.Models
{
    public class ADUser
    {
        public string? UserPrincipalName { get; set; }
        public string? Name { get; set; }
        public ResultPropertyCollection? Properties { get; set; }
    }
}
