using FlightDocSys.Authentication;
using FlightDocSys.ErrorThrow;
using FlightDocSys.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlightDocSys.Authorize
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager,
            IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        public async Task<List<AccountInfo>> SignInAsync(SignIn model)
        {
            var accountInfo = new AccountInfo();
            var user = await _userManager.FindByEmailAsync(model.Email);
            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!model.Email!.EndsWith("vietjetair.com"))
            {
                //Response.StatusCode = 401;
                //return new Exception {  code: 401 ,Value = "Lỗi rồi nè"};
                throw new ExceptionThrow(4012, "Email phải bắt đầu bằng @vietjetair.com");
            }
            if (user == null || !passwordValid)
            {
                throw new ExceptionThrow(402, "Sai mật khẩu hoặc email không chính xác");
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
            );
            accountInfo.UserName = model.Email;
            accountInfo.UserId = user.Id;
            accountInfo.JWT_Token = new JwtSecurityTokenHandler().WriteToken(token);
            accountInfo.Role = userRoles[0].ToString();

            return new List<AccountInfo> { accountInfo };
        }
        public async Task<IdentityResult> SignUpAsync(SignUp model)
        {
            if (!model.Email!.EndsWith("@vietjetair.com"))
            {
                throw new ExceptionThrow(4012, "Email phải bắt đầu bằng @vietjetair.com");
            }
            var user = new User
            {
                Name = model.Name,
                PhoneNumber = model.NumberPhone,
                Email = model.Email,
                UserName = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(RoleBase.BackOffice))
                {
                    await _roleManager.CreateAsync(new IdentityRole(RoleBase.BackOffice));
                }
                if (!await _roleManager.RoleExistsAsync(RoleBase.Pilot))
                {
                    await _roleManager.CreateAsync(new IdentityRole(RoleBase.Pilot));
                }
                if (!await _roleManager.RoleExistsAsync(RoleBase.Crew))
                {
                    await _roleManager.CreateAsync(new IdentityRole(RoleBase.Crew));
                }
                if (!await _roleManager.RoleExistsAsync(RoleBase.Admin))
                {
                    await _roleManager.CreateAsync(new IdentityRole(RoleBase.Admin));
                }
                switch (model.Role)
                {
                    case 1:
                        {
                            await _userManager.AddToRoleAsync(user, RoleBase.Pilot);
                            break;
                        }
                    case 2:
                        {
                            await _userManager.AddToRoleAsync(user, RoleBase.Crew);
                            break;
                        }
                    case 3:
                        {
                            await _userManager.AddToRoleAsync(user, RoleBase.BackOffice);
                            break;
                        }
                    case 4:
                        {
                            user.IsAdmin = true;
                            await _userManager.AddToRoleAsync(user, RoleBase.Admin);
                            break;
                        }
                }
            }
            return result;
        }
    }
}
