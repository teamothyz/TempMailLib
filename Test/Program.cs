using TempMailLib;

var email = TempMailClient.GetNewEmail().Result;
var messages = TempMailClient.GetMessages(email.Token).Result;
if (messages.Messages?.Any() == true)
{
    var messageDetails = TempMailClient.ReadMessage(messages.Messages[0].Id, email.Token).Result;
}