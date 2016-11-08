using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class EightBallAnswers : Dictionary<int, string>
    {

        private void AddValue(string value)
        {
            this.Add(this.Count, value);
        }
        public EightBallAnswers()
        {
            this.AddValue("It is certain");
            this.AddValue("It is decidedly so");
            this.AddValue("Without a doubt");
            this.AddValue("Yes, definitely");
            this.AddValue("You may rely on it");
            this.AddValue("As I see it, yes");
            this.AddValue("Most likely");
            this.AddValue("Outlook good");
            this.AddValue("Yes");
            this.AddValue("Signs point to yes");
            this.AddValue("Reply hazy try again");
            this.AddValue("Ask again later");
            this.AddValue("Better not tell you now");
            this.AddValue("Cannot predict now");
            this.AddValue("Concentrate and ask again");
            this.AddValue("Don't count on it");
            this.AddValue("My reply is no");
            this.AddValue("My sources say no");
            this.AddValue("Outlook not so good");
            this.AddValue("Very doubtful");
        }
    }
}
