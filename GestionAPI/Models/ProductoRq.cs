using Newtonsoft.Json;

namespace GestionAPI.Models
{
    public class ProductoRq
    {


        [JsonProperty("CodigoProducto")]
        public string CodigoProducto { get; set; }

        [JsonProperty("DescripcionProducto")]
        public string DescripcionProducto { get; set; }

        [JsonProperty("EstadoProducto")]

        public string EstadoProducto { get; set; }

        [JsonProperty("FechaFabricacionProducto")]

        public string FechaFabricacionProducto { get; set; }


        [JsonProperty("FechaValidezProducto")]

        public string FechaValidezProducto { get; set; }


        [JsonProperty("CodigoProveedor")]

        public string CodigoProveedor { get; set; }


        [JsonProperty("DescripcionProveedor")]

        public string DescripcionProveedor { get; set; }

        [JsonProperty("TelefonoProveedor")]

        public string TelefonoProveedor { get; set; }




    }
}
