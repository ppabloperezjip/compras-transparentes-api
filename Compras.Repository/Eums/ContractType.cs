using System.ComponentModel.DataAnnotations;

namespace Compras.Repository.Eums;

public enum ContractType
{
    [Display(Name = "TODOS")]
    Todos=-1,
    [Display(Name = "LICITACIÓN PÚBLICA")]
    LicitacionPublica = 0,
    [Display(Name = "LICITACIÓN SIMPLIFICADA")]
    LicitacionSimplificada = 1,
    [Display(Name = "ADJUDICACIÓN DIRECTA")]
    AdjudicacionDirecta = 2
}