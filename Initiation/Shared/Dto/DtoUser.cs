using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Initiation.Shared.Dto
{
    public class DtoUser
    {
        string _userName;
        [Required(ErrorMessage = "Le champ <<{0}>> est obligatoire")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Vous devez spécifier un nom d'utilisateur")]
        [DisplayName("Nom d'utilisateur")]
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnValueChanged(null);
            }
        }

        [Required(ErrorMessage = "Le champ <<{0}>> est obligatoire")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Vous devez spécifier un mot de passe")]
        [DisplayName("Mot de passe")]
        public string Password { get; set; }

        public event EventHandler ValueChanged;
        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

    }
}
