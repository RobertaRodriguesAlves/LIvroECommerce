using System.Runtime.Serialization;

namespace LivrosECommerce.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }
}
