using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School
{
    public class Student_schema
    {
        private int _register_no;
        private string _st_name;
        private int _st_age;
        private string _st_phone;
        private int _st_class;
        private string _st_profile_photo;
        private string _st_email;
        private string _st_password;
        
        public int RegisterNo
        {
            get { return _register_no; }
            set { _register_no = value; }
        }

        public string StName
        {
            get { return _st_name; }
            set { _st_name = value; }
        }

        public int StAge
        {
            get { return _st_age; }
            set { _st_age = value; }
        }

        public string StPhone
        {
            get { return _st_phone; }
            set { _st_phone = value; }
        }

        public int StClass
        {
            get { return _st_class; }
            set { _st_class = value; }
        }

        public string StProfilePhoto
        {
            get { return _st_profile_photo; }
            set { _st_profile_photo = value; }
        }

        public string StEmail
        {
            get { return _st_email; }
            set { _st_email = value; }
        }

        public string StPassword
        {
            get { return _st_password; }
            set { _st_password = value; }
        }

    }
}