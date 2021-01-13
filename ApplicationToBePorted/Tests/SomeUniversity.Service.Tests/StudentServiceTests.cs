using Moq;
using NUnit.Framework;
using SomeUniversity.Data;
using SomeUniversity.Model;
using System;

namespace SomeUniversity.Service.Tests
{
    [TestFixture]
    public class StudentServiceTests
    {
        [Test]
        public void ShouldThrowExceptionWhenStudentFirstNameIsNull()
        {
            var student = new Student();
            var studentRepo = new Mock<IStudentRepository>();
            var studentService = new StudentService(studentRepo.Object);

            Assert.Throws<ArgumentException>(() => studentService.AddStuddent(student));
        }
        [Test]
        public void ShouldThrowExceptionWhenStudentFirstNameIsEmpty()
        {
            var student = new Student { FirstMidName = "" };
            var studentRepo = new Mock<IStudentRepository>();
            var studentService = new StudentService(studentRepo.Object);

            Assert.Throws<ArgumentException>(() => studentService.AddStuddent(student));
        }

        [Test]
        public void ShouldThrowExceptionWhenStudentLasttNameIsNull()
        {
            var student = new Student { FirstMidName = "John" };
            var studentRepo = new Mock<IStudentRepository>();
            var studentService = new StudentService(studentRepo.Object);

            Assert.Throws<ArgumentException>(() => studentService.AddStuddent(student));
        }

        [Test]
        public void ShouldThrowExceptionWhenStudentLasttNameIsEmpty()
        {
            var student = new Student { FirstMidName = "John", LastName = "" };
            var studentRepo = new Mock<IStudentRepository>();
            var studentService = new StudentService(studentRepo.Object);

            Assert.Throws<ArgumentException>(() => studentService.AddStuddent(student));
        }

        [Test]
        public void ShouldSaveTheChangesInDBWhenValidStudentRecords()
        {
            var student = new Student { FirstMidName = "John", LastName = "Mathew" };
            var studentRepo = new Mock<IStudentRepository>();
            var studentService = new StudentService(studentRepo.Object);
            studentService.AddStuddent(student);
            studentRepo.Verify(s => s.AddStudent(student), Times.Once);
        }

    }
}
