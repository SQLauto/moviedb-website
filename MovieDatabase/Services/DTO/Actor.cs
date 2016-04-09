using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    [DataContract]
    public class Actor
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public List<Movie> Movies { get; set; }

        public Actor()
        {
            Movies = new List<Movie>();
        }
    }
}
