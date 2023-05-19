//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;

//namespace ApiRoles.Extensions
//{
//    public static class ServiceCollectionExtensions
//    {
//        public static IServiceCollection AddAuthetication(this IServiceCollection Services, IConfiguration configuration)
//        {
//            // Adding Authentication
//            Services.AddAuthentication(options =>
//            {
//                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//            })

//            // Adding Jwt Bearer
//            .AddJwtBearer(options =>
//            {
//                options.SaveToken = true;
//                options.RequireHttpsMetadata = false;
//                options.TokenValidationParameters = new TokenValidationParameters()
//                {
//                    ValidateIssuer = true,
//                    ValidateAudience = true,
//                    ValidAudience = configuration["JWT:ValidAudience"],
//                    ValidIssuer = configuration["JWT:ValidIssuer"],
//                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
//                };
//            });

//            return Services;
//        }
//    }
//}
