using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compras.Repository.Dtos
{
    public class ContractDetailsDto
    {
        public int contratacionId { get; set; }
        public string numeroLicitacion { get; set; }
        public string conceptoContrato { get; set; }
        public string estatus { get; set; }
        public decimal? montoContrato { get; set; }
        public string anticipoContrato { get; set; }
        public string tipoContratacion { get; set; }
        public string tipoProcedimiento { get; set; }
        public string unidadCompradora { get; set; }
        public string oficioAutorizacion { get; set; }
        public string licitacionTecnologia { get; set; }
        public List<Participante> participantes { get; set; }
        public decimal? costoBases { get; set; }
        public string publicacionConvocatoria { get; set; }
        public string juntaAclaraciones { get; set; }
        public string horaJuntaAclaraciones { get; set; }
        public string limiteInscripcion { get; set; }
        public string aperturaPropuestas { get; set; }
        public string horaAperturaPropuestas { get; set; }
        public string fechaFallo { get; set; }
        public string horaFallo { get; set; }
        public string firmaContrato { get; set; }
        public string inicioContrato { get; set; }
        public string finContrato { get; set; }
        public string lugarVisita { get; set; }
        public string fechaVisitaLugar { get; set; }
        public string horaVisitaLugar { get; set; }
        public string conveniosModificatorios { get; set; }
        public string clasificacion { get; set; }
        public string urlAnexos { get; set; }
        public string organismoId { get; set; }
    }
    
    public class Participante
    {
        public int proveedorId { get; set; }
        public string participanteNombre { get; set; }
        public bool esGanador { get; set; }
        public string montoContrato { get; set; }
        
        
    }

}
