using System.Collections;
using System.Collections.Generic;

namespace Raythos_Aerospace.Models.entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        public ICollection<OrderEntity> Orders { get; set; }
    }
}
