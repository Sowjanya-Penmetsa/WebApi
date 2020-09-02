﻿using System;
using System.Collections.Generic;

namespace WebApi_With_Entity_Framework.Models
{
    public partial class Orders
    {
        public Orders()
        {
           
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string OrderStatus { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        
    }
}
