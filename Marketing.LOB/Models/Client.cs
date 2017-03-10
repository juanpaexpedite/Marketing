using Marketing.LOB.Validation;
using Prism.Mvvm;
using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Marketing.LOB.Models
{
    public class Client : ValidatableBindable
    {
        #region Properties
        public int ClientId { get; set; }

        private string name;
        [Required(AllowEmptyStrings = false, ErrorMessage = "NotEmpty")]
        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }

        private string job;
        [Required(AllowEmptyStrings = false, ErrorMessage = "NotEmpty")]
        public string Job
        {
            get { return job; }
            set
            {
                SetProperty(ref job, value);
            }
        }


        private string details;
        [NotMapped]
        public string Details
        {
            get { return details; }
            set { SetProperty(ref details, value); }
        }
        #endregion
    }
}
