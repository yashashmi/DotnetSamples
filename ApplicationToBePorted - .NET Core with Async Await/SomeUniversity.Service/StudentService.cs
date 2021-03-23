using SomeUniversity.Data;
using SomeUniversity.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SomeUniversity.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository schoolRepository)
        {
            this.studentRepository = schoolRepository;
        }

        public async Task AddStuddent(Student student)
        {
            if (string.IsNullOrEmpty(student.FirstMidName))
            {
                throw new ArgumentException("First Name can't be null or empty", "Student Name");
            }

            if (string.IsNullOrEmpty(student.LastName))
            {
                throw new ArgumentException("Last Name can't be null or empty", "Student Name");
            }
            await studentRepository.AddStudent(student);
        }


        public async Task<IList<Student>> GetAllStudents()
        {
            return await studentRepository.GetAllStudents();
        }

        public async Task<Student> GetStudent(int? id)
        {
            return await studentRepository.GetStudent(id);
        }

        public async Task RemoveStudent(int id)
        {
            Student student = await GetStudent(id);
            await studentRepository.RemoveStudent(student);
        }

        public async Task SaveChanges()
        {
            await studentRepository.SaveChanges();
        }

        public async Task Update(Student student)
        {
            await studentRepository.UpdateStudent(student);
        }

        public void Dispose()
        {
            studentRepository.Dispose();
        }
    }

    public interface IStudentService : IDisposable
    {
        Task<Student> GetStudent(int? id);
        Task<IList<Student>> GetAllStudents();
        Task AddStuddent(Student student);
        Task SaveChanges();
        Task RemoveStudent(int id);
        Task Update(Student student);
    }
}
