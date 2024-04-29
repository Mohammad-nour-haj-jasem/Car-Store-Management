using DominC.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarstoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public AuthenticationController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // تعريف نقطة الوصول لعملية المصادقة باستخدام HTTP POST
        [HttpPost("authentocate")]
        public async Task<ActionResult<string>> Authentocate(AuthRequest authRequest)
        {
            // التحقق من صحة بيانات المستخدم باستخدام دالة ValidateUserCredentials

            var isAuthenticated = ValidateUserCredentials(authRequest.Username, authRequest.Password);

            if (!isAuthenticated)
                return Unauthorized();
            // إعداد السجلات (Claims) لتضمينها في الرمز البرمجي
            var claims = new List<Claim>();
            claims.Add(new Claim("birth_date", "2000"));
            claims.Add(new Claim("given_name", "Ali"));
            claims.Add(new Claim("family_name", "abo ahmad"));
            claims.Add(new Claim(ClaimTypes.Role, "User"));
            // إعداد مفتاح الأمان والتوقيع باستخدام معلومات التكوين
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // إنشاء رمز برمجي باستخدام معلومات التكوين والسجلات ومفتاح الأمان والتوقيع
            var token =new JwtSecurityToken(
               configuration["Authentication:Issuer"],
               configuration["Authentication:Audience"],
                 claims,
                 DateTime.UtcNow,
                 DateTime.UtcNow.AddDays(100),
                 signingCredentials
                );
            var serilaizedToken = new JwtSecurityTokenHandler().WriteToken(token);
            // إرجاع اجابة ناجحة تتضمن token
                        return Ok(serilaizedToken);
        }

        //التحقق من صحة البيانات المدخلة
        private bool ValidateUserCredentials(string username, string password)
        {
           // if(username == "Ali" && password == "12345")
            return true;
            //return false;
        }
    }
}
