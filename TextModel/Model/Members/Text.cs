using System;
using System.Collections.Generic;
using TextModel.Interfaces;

namespace TextModel.Model.Members
{
    public class Text: IText,ICloneable
    {
        public List<ISentence> Sentences { get; }

        public Text()
        {
            Sentences = new List<ISentence>();
        }
        public Text CloneText()
        {
            return (Text)this.MemberwiseClone();
        }

        public object Clone()
        {
            return this.CloneText();
        }
    }
}