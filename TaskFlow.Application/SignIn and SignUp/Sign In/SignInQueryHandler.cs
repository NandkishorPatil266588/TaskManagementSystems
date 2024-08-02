using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Infrastructure.Auth;
using TaskFlow.Persistence;

namespace TaskFlow.Application.SignIn_and_SignUp.Sign_In
{
    public class SignInQueryHandler : IRequestHandler<SignInQuery, string>
    {
        private readonly AppDbContext appDbContext;

        private readonly IConfiguration _config;

        public SignInQueryHandler(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this._config = configuration;
        }
        public async Task<string> Handle(SignInQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result =  appDbContext.Employees.FirstOrDefault(x => x.EmpEmailId == request.EmpEmailId && x.EmpPassowrd == request.EmpPassword);
                if (result == null)
                {
                    return "User Not Found";
                }else
                {
                    var data = new UserData
                    {
                        EmpEmailId = request.EmpEmailId,
                        EmpRole = result.EmpRole,
                    };

                    var token = JwtAuthenticationHelper.CreateToken(data, _config);

                    return token;
                }


            }catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
