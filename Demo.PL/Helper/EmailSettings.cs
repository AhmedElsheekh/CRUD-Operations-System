using System.Net;
using System.Net.Mail;

namespace Demo.PL.Helper
{
	public static class EmailSettings
	{
		public static void SendEmail(Email email)
		{
			var client = new SmtpClient("smtp.gmail.com", 587);

			client.EnableSsl = true;

			client.Credentials = new NetworkCredential("ahmed.elsheekh8620@gmail.com", "xrmvsurtrhnvigqp");

			client.Send("ahmed.elsheekh8620@gmail.com", email.To, email.Title, email.Body);
		}
	}
}
