
namespace frontendED
{
    public class edAdicional
    {
        public int adicionalid { get; set; }
        public int vendedorid { get; set; }
        public string snombre { get; set; }
        public string sdescripcion { get; set; }
        public decimal dprecio { get; set; }
        public int iadicionaltipo { get; set; }
        public string sfecharegistro { get; set; }
        public int iactivo { get; set; }

        public int subproductoid { get; set; }
        public int productoid { get; set; }

        public int ventaadicionalid { get; set; }
        public int ventaid { get; set; }
    }
}
