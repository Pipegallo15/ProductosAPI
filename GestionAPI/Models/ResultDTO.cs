namespace GestionAPI.Models
{
    public class RespuestaDTO
    {
        public RespuestaDTO()
        {
            Message = "";
        }
        public string IsOk { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
