using System.Net;

namespace _113918_mazavictornicolas.Dtos
{
    public class RespuestaBase
    {
        public string mensage { get; set; }
        public bool exito { get; set; }
        public HttpStatusCode code { get; set; }

    }
}
