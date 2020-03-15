using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task1
{
    [Serializable]
    public class Question
    {
        private string _text;
        private bool _trueFalse;

        public string Text { get => _text; set { _text = value; } }
        public bool TrueFalse { get => _trueFalse; set { _trueFalse = value; } }

        public Question()
        {
        }
        public Question(string text, bool trueFalse)
        {
            this._text = text;
            this._trueFalse = trueFalse;
        }

    }

    class TrueFalse
    {
        private string fileName;
        private List<Question> list;

        public string FileName
        {
            set { fileName = value; }
        }

        public TrueFalse(string fileName)
        {
            this.fileName = fileName;
            list = new List<Question>();
        }

        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }

        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }

        public Question this[int index]
        {
            get { return list[index]; }
        }

        public void Save(string localfilename = null)
        {
            if (localfilename == null)
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
                Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                xmlFormat.Serialize(fStream, list);
                fStream.Close();
            }
            else
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
                Stream fStream = new FileStream(localfilename, FileMode.Create, FileAccess.Write);
                xmlFormat.Serialize(fStream, list);
                fStream.Close();
            }
            
        }

        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Question>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }

        public int Count
        {
            get { return list.Count; }
        }

    }
}
