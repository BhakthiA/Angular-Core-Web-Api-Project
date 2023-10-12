using JWT.Common;   // for JWT
using JWT.Model;   // for JWT
using JWT.Model.CustomModel;
using JWT.Service.Login;
using JWT.Service.Register;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using System.Net.Mail;
using JWT.Helper;
using JWT.EmailService;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Configuration;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace JWT.Controllers
{

    [ApiController]
    [Route("api/SignIn")]
    public class SignInController : ControllerBase
    {
        private IConfiguration configuration;
        private readonly IRegisterServices registerService;
        private readonly ILoginService loginService;
        private readonly AppSetting appSetting;    //for jwt
        private readonly IEmailService emailService;   //for send email in mail

        public SignInController(IRegisterServices _registerService, ILoginService _loginService, IOptions<AppSetting> applications, IEmailService _emailService, IConfiguration _configuration)
        {
            registerService = _registerService;
            loginService = _loginService;
            appSetting = applications.Value;
            emailService = _emailService;
            configuration = _configuration;
        }



        [HttpPost("Login")]
        public async Task<ApiPostResponse<LoginResponseModel>> Login(LoginModel loginData)
        {
            ApiPostResponse<LoginResponseModel> response = new ApiPostResponse<LoginResponseModel>();
            try
            {
                var result = await loginService.Login(loginData);
                if (result != 0)
                {
                    response.Data = new LoginResponseModel();
                    string _jwtToken = JWT_Token.GenerateJSONWebToken(loginData.Email, appSetting.JWT_Secret);  //for jwt
                    response.Data.JWT_Token = _jwtToken;  //for jwt
                    response.Data.Email = loginData.Email;
                    response.Data.Password = loginData.Password;
                    response.Data.Id = result;
                    response.Success = true;
                    response.Message = "Success";

                    //var email = new MimeMessage();
                    //email.From.Add(MailboxAddress.Parse("bhakthipatel07@gmail.com"));
                    //email.To.Add(MailboxAddress.Parse("bhakthipatel07@gmail.com"));
                    //email.Subject = "Test Email Subject";
                    //email.Body = new TextPart(TextFormat.Html) { Text = "<h1>Example HTML Message Body</h1>" };

                    //using var smtp = new MailKit.Net.Smtp.SmtpClient();
                    //// gmail
                    //smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    //smtp.Authenticate("bhakthipatel07@gmail.com", "pasohobovjqxnldw");
                    //smtp.Send(email);
                    //smtp.Disconnect(true);

                }
                else
                {
                    response.Success = false;
                    response.Message = "Not Found";
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost("Register")]
        public async Task<ApiPostResponse<int>> Register([FromForm] RegisterRequestModel registerData)
        {
            try
            {
                ApiPostResponse<int> response = new ApiPostResponse<int>();

                var img = registerData.Image;

                string imgpath = Path.Combine(Directory.GetCurrentDirectory(), "Asset/Images");
                string destinationPath = Path.Combine(imgpath, img.FileName);
                registerData.ProfilePic = img.FileName;

                using (var stream = new FileStream(destinationPath, FileMode.Create))

                {
                    await img.CopyToAsync(stream);
                }
                Encryption.CreatePasswordHash(registerData.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
                var VerificationToken = Encryption.CreateRandomToken(registerData.Password);
                RegisterModel EncryptedData = new RegisterModel()
                {
                    FirstName = registerData.FirstName,
                    LastName = registerData.LastName,
                    Email = registerData.Email,
                    Password = registerData.Password,
                    Gender = registerData.Gender,
                    DateOfBirth = registerData.DateOfBirth,
                    Contact = registerData.Contact,
                    Address = registerData.Address,
                    DepartmentId = registerData.DepartmentId,
                    CountryId = registerData.CountryId,
                    StateId = registerData.StateId,
                    CityId = registerData.CityId,
                    ProfilePic = registerData.ProfilePic,
                    PasswordHash= PasswordHash,
                    PasswordSalt = PasswordSalt,
                    VerificationToken = VerificationToken,
                };

                var result = await registerService.Register(EncryptedData);
                if (result == 1)
                {
                    //var callbackUrl = Url.ActionLink("VerifyEmail", "SignIn", values: new { registerData.Email }, protocol: Request.Scheme);

                    var callbackUrl = $"{Request.Scheme}://{Request.Host}/api/SignIn/VerifyEmail?email={registerData.Email}";


                    await SendEmail(
                        registerData.Email,"BHAKTHI PATEL", $"Click verify to verify your email <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Verify Email!</a>");
                    
                    response.Data = result;
                    response.Success = true;
                    response.Message = "Success";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Failure";
                }
                return response;

            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost("SendEmail")]
        public async Task SendEmail(string email, string subject, string body)
        {

            var emailSettings = configuration.GetSection("EmailSettings");
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Shaligram Infotech", emailSettings["Email"]));
            message.To.Add(new MailboxAddress(email, email));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = body;
            message.Body = bodyBuilder.ToMessageBody();

            using var client = new MailKit.Net.Smtp.SmtpClient();
            await client.ConnectAsync(emailSettings["Host"], int.Parse(emailSettings["Port"]), SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(emailSettings["Email"], emailSettings["Password"]);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }


        //[HttpPost("SendMail")]
        //public async Task<IActionResult> SendMail()
        //{
        //    try
        //    {
        //        MailRequest mailrequest = new MailRequest();

        //        mailrequest.ToEmail = "bhakthipatel07@gmail.com";
        //        mailrequest.Subject = "Hello ABC msg send by Api Core";
        //        mailrequest.Body = GetHtmlContent();
        //        await emailService.SendEmailAsync(mailrequest);
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //private string GetHtmlContent()
        //{

        //    string result = "<h2>\"Thanks you !!!\" </h1>";
        //    return result;
        //}

        [HttpPost("VerifyEmail")]
        public async Task<ApiPostResponse<int>> EmailConfirmation(string email)
        {

            ApiPostResponse<int> response = new ApiPostResponse<int>();
            var result = await registerService.CheckEmail(email);
            if (result == 1)
            {

                response.Success = true;
                response.Message = "User Email Verified successfully";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong, please reverify your mail!";
            }
            return response;
           
        }
    }
}
