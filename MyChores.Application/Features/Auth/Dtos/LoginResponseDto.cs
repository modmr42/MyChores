using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChores.Application.Features.Auth.Dtos
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string Expiration { get; set; }
    }
}
