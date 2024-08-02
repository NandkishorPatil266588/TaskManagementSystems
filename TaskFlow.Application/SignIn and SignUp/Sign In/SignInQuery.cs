using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Application.SignIn_and_SignUp.Sign_In
{
    public class SignInQuery : IRequest<string>
    {
        public string EmpEmailId { get; set; }

        public string EmpPassword { get; set; }
    }
}
