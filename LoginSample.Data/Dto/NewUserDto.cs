using LoginSample.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSample.Data.Dto
{
    public class NewUserDto
    {
        [Required]
        [MaxLength(30)]
        public string Mail { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        [MaxLength(128)]
    
        public string DisplayName { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }
      

    }
}
