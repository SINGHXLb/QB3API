using System.Net;
using System.Text.Json.Serialization;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Serialization.SystemTextJson;
using QB3API.Model;
using System.Text.Json;
using QB3API.Model.Security;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
//[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
[assembly:LambdaSerializer(typeof(SourceGeneratorLambdaJsonSerializer<QB3API.HttpApiJsonSerializerContext>))]
namespace QB3API;

[JsonSerializable(typeof(APIGatewayProxyResponse))]
[JsonSerializable(typeof(APIGatewayProxyRequest))]
public partial class HttpApiJsonSerializerContext : JsonSerializerContext
{

}

public class Functions
{
    /// <summary>
    /// Default constructor that Lambda will invoke.
    /// </summary>
    public Functions()
    {
    }


    /// <summary>
    /// A Lambda function to respond to HTTP Get methods from API Gateway
    /// </summary>
    /// <param name="request"></param>
    /// <returns>The API Gateway response.</returns>
  
    public APIGatewayProxyResponse token(APIGatewayProxyRequest request, ILambdaContext context)
    {
        context.Logger.LogInformation("Get Request\n");
        var userLogin = new User
        {
            Email = request.Headers.Where(x=>x.Key=="user").First().Value
        };
         

        var user = Authenticate(userLogin);
        var response = new APIGatewayProxyResponse();
             
        if (user != null)
        {



            var _token = new UserTokens();
            _token.RefreshToken = Guid.NewGuid().ToString();
            _token.Token = Guid.NewGuid().ToString();

             response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonSerializer.Serialize(_token), //; "Hello AWS Serverless",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
        }
        else
        {
             response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = "Not allowed ",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };
        }
        return response;
    }


    private User? Authenticate(User userLogin)
    {
        var currentUser = userLogin;
        if (currentUser.Email == "p@g.com")
        {
            return currentUser;
        }
        else
        {
            return null;
        }
     }

    private string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("QB"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
                new Claim(ClaimTypes.NameIdentifier,user.Email),
                new Claim(ClaimTypes.Role,"user")
            };

        var token = new JwtSecurityToken("QBAPI","QBAPI",
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);


        return new JwtSecurityTokenHandler().WriteToken(token);

    }


}