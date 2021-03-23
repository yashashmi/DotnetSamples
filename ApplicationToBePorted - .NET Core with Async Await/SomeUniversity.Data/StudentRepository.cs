using SomeUniversity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SomeUniversity.Data
{
    public class StudentRepository: IStudentRepository
    {
        private readonly SchoolContext db;
        public StudentRepository(SchoolContext db)
        {
            this.db = db;
        }

        public async Task AddStudent(Student student)
        {
            db.Students.Add(student);
            await SaveChanges();
        }

        
        public async Task<IList<Student>> GetAllStudents()
        {
            return await db.Students.ToListAsync();
        }

        public async Task<Student> GetStudent(int? id)
        {
            return await db.Students.FindAsync(id);
        }

        public async Task RemoveStudent(Student student)
        {
            db.Students.Remove(student);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await db.SaveChangesAsync();
        }

        public async Task UpdateStudent(Student student)
        {
            db.Students.Attach(student);
            db.Entry(student).State = EntityState.Modified;
            await SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }

    public interface IStudentRepository:IDisposable
    {
        Task<Student> GetStudent(int? id);
        Task<IList<Student>> GetAllStudents();
        Task AddStudent(Student student);
        Task SaveChanges();
        Task RemoveStudent(Student student);
        Task UpdateStudent(Student student);
    }
}
