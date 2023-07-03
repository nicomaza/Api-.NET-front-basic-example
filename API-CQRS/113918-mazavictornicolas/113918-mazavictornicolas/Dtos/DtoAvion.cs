namespace _113918_mazavictornicolas.Dtos
{
    public class DtoAvion : RespuestaBase
    {
        public int Id { get; set; }

        public string NombreFabricante { get; set; } = null!;

        public int CantidadAsientos { get; set; }

        public string Modelo { get; set; } = null!;

        public int CantidadMotores { get; set; }

        public string? DatosVarios { get; set; }
    }
}
