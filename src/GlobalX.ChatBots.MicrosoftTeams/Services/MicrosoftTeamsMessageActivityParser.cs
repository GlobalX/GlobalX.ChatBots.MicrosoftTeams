using System;
using System.Collections.Generic;
using System.Text;
using GlobalX.ChatBots.Core.Messages;
using GlobalX.ChatBots.Core.People;
using GlobalX.ChatBots.Core.Rooms;
using Microsoft.Bot.Schema;

namespace GlobalX.ChatBots.MicrosoftTeams.Services
{
    internal class MicrosoftTeamsMessageActivityParser : IMicrosoftTeamsMessageActivityParser
    {
        public Message ParseMessageActivity(IMessageActivity messageActivity)
        {
            var mappedMessage = new Message
            {
                Id = messageActivity.Id,
                Created = messageActivity.Timestamp?.Date ?? DateTime.Now,
                Sender = new Person
                {
                    Username = messageActivity.From.Name,
                    UserId = messageActivity.From.Id,
                    Type = messageActivity.From.Role == "bot" ? PersonType.Bot : PersonType.Person
                },
                RoomId = messageActivity.ChannelId,
                ParentId = messageActivity.ReplyToId,
                RoomType = messageActivity.Conversation.IsGroup ?? false ? RoomType.Group : RoomType.Direct
            };

            var mentions = messageActivity.GetMentions();
            if (mentions.Length == 0)
            {
                mappedMessage.MessageParts = new[]
                    {new MessagePart {MessageType = MessageType.Text, Text = messageActivity.Text}};
                mappedMessage.Text = messageActivity.Text;
            }
            else
            {
                var messageParts = new List<MessagePart>();
                var messageText = messageActivity.Text;
                StringBuilder textBuilder = new StringBuilder();
                foreach (var mention in mentions)
                {
                    var mentionText = GetMentionText(mention);
                    if (!messageText.StartsWith(mentionText))
                    {
                        var index = messageText.IndexOf(mentionText, StringComparison.Ordinal);
                        var partText = messageText.Substring(0, index);
                        messageParts.Add(new MessagePart{Text = partText });
                        messageText = messageText.Substring(index);
                        textBuilder.Append(partText);
                    }

                    messageParts.Add(new MessagePart
                    {
                        Text = mention.Mentioned.Name, MessageType = MessageType.PersonMention,
                        UserId = mention.Mentioned.Id
                    });
                    textBuilder.Append(mention.Mentioned.Name);
                    messageText = messageText.Substring(mentionText.Length);
                }

                if (!String.IsNullOrEmpty(messageText))
                {
                    messageParts.Add(new MessagePart{ MessageType = MessageType.Text, Text = messageText});
                }

                mappedMessage.MessageParts = messageParts.ToArray();
                mappedMessage.Text = textBuilder.ToString();
            }

            return mappedMessage;
        }

        private string GetMentionText(Mention mention)
        {
            if (mention.Text == null)
            {
                return "<at>" + mention.Mentioned.Name + "</at>";
            }

            return mention.Text;
        }
    }
}
