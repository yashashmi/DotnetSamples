using SomeUniversity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SomeUniversity.Data
{
    public class StudentRepository: IStudentRepository
    {
        private readonly SchoolContext db;
        public StudentRepository(SchoolContext db)
        {
            this.db = db;
        }

        public void AddStudent(Student student)
        {
            db.Students.Add(student);
            SaveChanges();
        }

        
        public IList<Student> GetAllStudents()
        {
            return db.Students.ToList();
        }

        public Student GetStudent(int? id)
        {
            return db.Students.Find(id);
        }

        public void RemoveStudent(Student student)
        {
            db.Students.Remove(student);
            SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            db.Students.Attach(student);
            db.Entry(student).State = EntityState.Modified;
            SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }

    public interface IStudentRepository:IDisposable
    {
        Student GetStudent(int? id);
        IList<Student> GetAllStudents();
        void AddStudent(Student student);
        void SaveChanges();
        void RemoveStudent(Student student);
        void UpdateStudent(Student student);
    }
}
