﻿using System.ComponentModel.DataAnnotations;

namespace TarjetaDeCreditoMVC.Entidades.ViewModels.Provincia
{
    public class ProvinciaListViewModel
    {
        public int ProvinciaId { get; set; }

        [Display(Name="Nombre de la provincia")]
        public string NombreProvincia { get; set; }
    }
}
