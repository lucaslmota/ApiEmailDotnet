namespace MailApi.Services.Interface
{
    public interface ISendEmail
    {
        Task SendEmailAsync(string email, string subject, string body);
    }
}