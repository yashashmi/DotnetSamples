using SomeUniversity.Data;
using SomeUniversity.Model;
using System;
using System.Collections.Generic;

namespace SomeUniversity.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository schoolRepository)
        {
            this.studentRepository = schoolRepository;
        }

        public void AddStuddent(Student student)
        {
            if (string.IsNullOrEmpty(student.FirstMidName))
            {
                throw new ArgumentException("First Name can't be null or empty", "Student Name");
            }

            if (string.IsNullOrEmpty(student.LastName))
            {
                throw new ArgumentException("Last Name can't be null or empty", "Student Name");
            }
            studentRepository.AddStudent(student);
        }


        public IList<Student> GetAllStudents()
        {
            return studentRepository.GetAllStudents();
        }

        public Student GetStudent(int? id)
        {
            return studentRepository.GetStudent(id);
        }

        public void RemoveStudent(int id)
        {
            Student student = GetStudent(id);
            studentRepository.RemoveStudent(student);
        }

        public void SaveChanges()
        {
            studentRepository.SaveChanges();
        }

        public void Update(Student student)
        {
            studentRepository.UpdateStudent(student);
        }

        public void Dispose()
        {
            studentRepository.Dispose();
        }
    }

    public interface IStudentService : IDisposable
    {
        Student GetStudent(int? id);
        IList<Student> GetAllStudents();
        void AddStuddent(Student student);
        void SaveChanges();
        void RemoveStudent(int id);
        void Update(Student student);
    }
}
