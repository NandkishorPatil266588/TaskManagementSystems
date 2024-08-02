using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain;
using TaskFlow.Persistence;

namespace TaskFlow.Application.SignIn_and_SignUp.Sign_Up
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand , string>
    {
        private readonly AppDbContext appDbContext;

        public SignUpCommandHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task<string> Handle(SignUpCommand command , CancellationToken cancellationToken)
        {
            try
            {
                if (command != null)
                {
                    var task = new Employee
                    {
                          EmpId = Guid.NewGuid(),
                          EmpName = command.EmpName,
                          EmpRole = command.EmpRole,
                          EmpEmailId = command.EmpEmailId,
                          EmpPassowrd = command.EmpPassowrd,
                    };

                    appDbContext.Employees.Add(task);

                    await appDbContext.SaveChangesAsync(cancellationToken);

                    return "Emp Added";

                }
                else
                {
                    return "Enter valid Data";
                }
            }catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
