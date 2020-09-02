
namespace frontendED
{
    public class edConfiguracion
    {
        public int configuracionid { get; set; }
        public int vendedorid { get; set; }
        public string snombre { get; set; }
        public string sdescripcion { get; set; }
        public string svalor { get; set; }
        public int itipoConfiguracion { get; set; }
        public string stipoConfiguracion { get; set; }
        public string sfecharegistro { get; set; }
        public int iactivo { get; set; }

        public int especificacionid { get; set; }
        public int productoid { get; set; }

        public int configuracionventaid { get; set; }
        public int ventaid { get; set; }
    }
}
