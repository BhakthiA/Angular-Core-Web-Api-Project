using JWT.Helper;

namespace JWT.EmailService
{
    public interface IEmailService
    {
       Task SendEmailAsync(MailRequest mailRequest);
    }
}
