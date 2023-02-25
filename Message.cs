using ApiMap.Repository.Models;

namespace ApiMap
{
    public class Message
    {
        public bool Success { get; set; }
        public string Reason { get; set; }
        public Mapaddress Data { get; set; }
    }
}
