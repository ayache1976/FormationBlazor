using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Initiation.Shared.Dto
{
    public class DtoInstrument
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le champ <<{0}>> est obligatoire")]
        [StringLength(40, MinimumLength =2, ErrorMessage = "Le champ <<{0}>> doit faire plus de 2 caracteres et maximun 40 caracteres")]
        [DisplayName("Nom")]
        public string Name { get; set; }

        [DisplayName("Nombre de cordes")]
        public int Strings { get; set; }
        public int YearManufacture { get; set; }
    }
}
