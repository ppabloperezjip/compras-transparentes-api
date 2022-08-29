using System.ComponentModel.DataAnnotations;

namespace Compras.Repository.Eums;

public enum ProcedureType
{
        [Display(Name = "TODOS")]
        Todos=-1,
        [Display(Name = "ADQUISICIÓN")]
        Adquisicion = 0,
        [Display(Name = "SERVICIO")]
        Servicio = 1,
        [Display(Name = "ARRENDAMIENTO")]
        Arrendamiento = 2,
        [Display(Name = "OBRA PÚBLICA")]
        ObraPublica = 3,
        [Display(Name = "SERVICIOS RELACIONADOS CON OBRA PÚBLICA")]
        RelacionadosOP = 4,
        [Display(Name = "SERVICIOS PROFESIONALES, ASESORIA, CAPACITACIÓN Y OTROS")]
        ServProf = 5
}