using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace School
{
    public class student_BAL
    {
        public DataTable Login(Student_schema student)
        {
            student_DAL studentDal = new student_DAL();
            return studentDal.login(student);
        }

        public int registerStudent(Student_schema student)
        {
            student_DAL studentDal = new student_DAL();
            return studentDal.registerStudent(student);
        }

        public DataTable ViewRegisteredStudents()
        {
            student_DAL studentDal = new student_DAL();
            return studentDal.ViewRegisteredStudents();
        }

        public DataTable viewAllStudentsResult()
        {
            student_DAL studentDal = new student_DAL();
            return studentDal.viewAllStudentsResult();
        }

        public DataTable GetStudentDetailsByID(int studentID)
        {
            student_DAL studentDal = new student_DAL();
            return studentDal.GetStudentDetailsByID(studentID);
        }

        public int updateStudentDetails(Student_schema student)
        {
            student_DAL studentDal = new student_DAL();
            return studentDal.UpdateStudentDetails(student);
        }

        public DataTable viewResultByID(int stdID)
        {
            student_DAL studentDal = new student_DAL();
            return studentDal.viewResultByID(stdID);
        }
    }
}