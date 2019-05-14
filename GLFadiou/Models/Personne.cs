﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GLFadiou.Models
{
    public class Personne
    {
        [Key]
        public int idPers { get; set; }

        [MaxLength(80, ErrorMessage ="taille maximale 80"),
            Required(ErrorMessage ="*")]
        [Display(Name ="Nom")]
        public string nomPers { get; set; }

        [MaxLength(80, ErrorMessage = "taille maximale 80"),
            Required(ErrorMessage = "*")]
        [Display(Name = "Prénom")]
        public string prenomPers { get; set; }

        [MaxLength(150, ErrorMessage = "taille maximale 150")]
        [Display(Name = "Adresse")]
        public string adressePers { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Date de naissance")]
        public DateTime dateNaissancePers { get; set; }

        [MaxLength(10, ErrorMessage = "taille maximale 10"),
            Required(ErrorMessage = "*")]
        [Display(Name = "Sexe")]
        public string sexePers { get; set; }

        [MaxLength(30, ErrorMessage = "taille maximale 30"),
            Required(ErrorMessage = "*")]
        [Display(Name = "CNI")]
        public string cniPers { get; set; }

        [MaxLength(40, ErrorMessage = "taille maximale 40"),
            Required(ErrorMessage = "*")]
        [Display(Name = "Situation Matrimoniale")]
        public string situationMatPers { get; set; }

        [MaxLength(80, ErrorMessage = "taille maximale 80"),
            Required(ErrorMessage = "*")]
        [Display(Name = "Email"), DataType(DataType.EmailAddress)]
        public string emailPers { get; set; }

        [MaxLength(15, ErrorMessage = "taille maximale 15"),
            Required(ErrorMessage = "*")]
        [Display(Name = "Téléphone")]
        public string telPers { get; set; }
    }
}