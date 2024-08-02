using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain;

namespace TaskFlow.Application.SignIn_and_SignUp.Sign_Up
{
    public class SignUpCommand : IRequest<string>
    {
        public string EmpName { get; set; }
        public string EmpRole { get; set; }

        public string EmpPassowrd { get; set; }

        public string EmpEmailId { get; set; }
    }
}
