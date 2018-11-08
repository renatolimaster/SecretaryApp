using System.Collections.Generic;

namespace Secretary.API.Helpers
{
    public class EmailMessage
    {
        public EmailMessage()
	{
		ToAddresses = new List<EmailAddress>();
		FromAddresses = new List<EmailAddress>();
		Cc = new List<EmailAddress>();
	}
 
	public List<EmailAddress> ToAddresses { get; set; }
	public List<EmailAddress> FromAddresses { get; set; }
	public List<EmailAddress> Cc { get; set; }
	public string Subject { get; set; }
	public string Content { get; set; }
    }
}