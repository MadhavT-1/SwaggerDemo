using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SwaggerDemo.Model
{
    public class BUnit
    {

        [IgnoreDataMember]
        public int Id { get; set; }
       
        public string businessUnit { get; set; }
        public acl acls { get; set; }
        public List<attributes> attr { get; set; }
        public DateTime expiryDate { get; set; }
        public List<files> file { get; set; }

    }
}
