using System;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    [Serializable]
    public class Student
    {
        private string _firstName;
        private string _secondName;
        private string _univercity;
        private string _faculty;
        private string _department;
        private int _age;
        private int _course;
        private int _group;
        private string _city;

        public string FirstName { get => _firstName; set { _firstName = value; } }
        public string SecondName { get => _secondName; set { _secondName = value; } }
        public string Univercity { get => _univercity; set { _univercity = value; } }
        public string Faculty { get => _faculty; set { _faculty = value; } }
        public string Department { get => _department; set { _department = value; } }
        public int Age { get => _age; set { _age = value; } }
        public int Course { get => _course; set { _course = value; } }
        public int Group { get => _group; set { _group = value; } }
        public string City { get => _city; set { _city = value; } }

        public Student(string line)
        {
            string[] values = line.Split(';');
            _firstName = values[0];
            _secondName = values[1];
            _univercity = values[2];
            _faculty = values[3];
            _department = values[4];
            _age = Int32.Parse(values[5]);
            _course = Int32.Parse(values[6]);
            _group = Int32.Parse(values[7]);
            _city = values[8];
        }

        public Student() { }

    }

    class Students
    {
        private List<Student> _list;

        private string _file;

        public Students(string filename)
        {
            _list = new List<Student>();

            StreamReader sr = new StreamReader(filename);

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                _list.Add(new Student(line));

            }

            sr.Close();

            _file = filename;
        }

        public void Save(string fName)
        {
            
             XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));

             Stream fStream = new FileStream(fName, FileMode.Create, FileAccess.Write);

             xmlFormat.Serialize(fStream, _list);

             fStream.Close();
            
        }

        public Student this[int index]
        {
            get 
            { 
                return _list[index];
            }
        }

        public int Count
        {
            get { return _list.Count; }
        }

    }
}
