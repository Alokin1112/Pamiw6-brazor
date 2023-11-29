using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pamiw6.Shared.Models;

namespace Pamiw6.Shared.Models
{

  public class AuthenticationRequest
  {
    [Required]
    public string username { get; set; }
    [Required]
    public string password { get; set; }
  }

  public class AuthenticationResponse
  {
    public string token { get; set; }
  }

}
