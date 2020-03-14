using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cwiczenia2.Models
{
    public class Student
    {
        [XmlElement(ElementName = "fname")]
        private String _fname;
        [XmlElement(ElementName = "lname")]
        private String _lname;
        [XmlElement(ElementName = "studies")]
        private Studies _studies;
        [XmlAttribute(AttributeName = "indexNumber")]
        private String _id;
        [XmlAttribute(AttributeName = "birthdate")]
        private String _birthdate;
        [XmlAttribute(AttributeName = "email")]
        private String _email;
        [XmlAttribute(AttributeName = "mothersName")]
        private String _mothersName;
        [XmlAttribute(AttributeName = "fathersName")]
        private String _fathersName;

        public String FName
        {
            get { return _fname; }
            set { _fname = value; }
        }
        public String LName
        {
            get { return _fname; }
            set { _fname = value; }
        }
        public Studies Studies
        {
            get { return _studies; }
            set { _studies = value; }
        }
        [XmlAttribute]
        public String Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public String BirthDate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }
        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public String MothersName
        {
            get { return _mothersName; }
            set { _mothersName = value; }
        }
        public String FathersName
        {
            get { return _fathersName; }
            set { _fathersName = value; }
        }

        public Student(String fName, String lName, Studies studies, String id, String birthDate, String email, String mothersName, String fathersName)
        {
            FName = fName;
            LName = lName;
            Studies = studies;
            Id = id;
            BirthDate = birthDate;
            Email = email;
            MothersName = mothersName;
            FathersName = fathersName;
        }

        public Student(String fName, String lName, String studiesName, String mode, String id, String birthDate, String email, String mothersName, String fathersName)
           : this(fName, lName, new Studies(studiesName, mode), id, birthDate, email, mothersName, fathersName)
        { }

        override public bool Equals(Object s)
        {
            if (s is Student)
            {
                Student tmp = (Student)s;
                return FName == tmp.FName && LName == tmp.LName
                    && Studies == tmp.Studies && Id == tmp.Id
                    && BirthDate == tmp.BirthDate && Email == tmp.Email
                    && MothersName == tmp.MothersName && FathersName == tmp.FathersName;
            }

            return false;
        }

        public static bool operator ==(Student s1, Student s2) { return s1.Equals(s2); }

        public static bool operator !=(Student s1, Student s2) { return !s1.Equals(s2); }
    }
}
