using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SwaggerDemo.Model
{
    public class acl
    {
        [IgnoreDataMember]
        public int Id { get; set; }
        public List<string> readUsers { get; set; }
        public List<string> readGroups { get; set; }
    }
}
