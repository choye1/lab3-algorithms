using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcessorApp
{
    public class TextAction
    {
        public string ActionType { get; set; }
        public string Text { get; set; }
        public int Position { get; set; }

        public TextAction(string actionType, string text, int position)
        {
            ActionType = actionType;
            Text = text;
            Position = position;
        }
    }


}
