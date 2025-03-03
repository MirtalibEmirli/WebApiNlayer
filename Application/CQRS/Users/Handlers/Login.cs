using Application.Services.TokenService;
using Common.Exceptions;
using Common.GlobalResponses.Generics;
using Common.Security;
using MediatR;
using Microsoft.Extensions.Configuration;
using Repository.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.CQRS.Users.Handlers;

public class Login
{

    public class LoginRequest : IRequest<ResponseModel<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public sealed class Handler(IUnitOfWork unitOfWork,IConfiguration configuration) : IRequestHandler<LoginRequest, ResponseModel<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration = configuration;

        public async Task<ResponseModel<string>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _unitOfWork.UserRepository.GetByEmailAsync(request.Email) ?? throw new BadRequestException("User does not exist with provided email ");
           
            var hashedPassword = PasswordHasher.ComputeStringToSha256Hash(request.Password);
            
            if (hashedPassword!=currentUser.PasswordHash)
            {
                throw new BadRequestException("Wrong Password");
            }

            List<Claim> authClaim = [
                new Claim(ClaimTypes.NameIdentifier,currentUser.Id.ToString()),
                new Claim(ClaimTypes.Name,currentUser.Name),
                new Claim (ClaimTypes.Email,currentUser.Email),
                new Claim(ClaimTypes.MobilePhone,currentUser.Phone)
                ];

            JwtSecurityToken token = TokenService.CreateToken(authClaim, _configuration);
            
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new ResponseModel<string> { Data = tokenString, IsSuccess = true };

        }
    }



}
