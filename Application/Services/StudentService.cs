using Application.DTOs;
using Application.Interfaces;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return students.Select(s => new StudentDto { Name = s.Name, Email = s.Email });
        }

        public async Task<StudentDto?> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return student == null ? null : new StudentDto { Name = student.Name, Email = student.Email };
        }

        public async Task AddStudentAsync(StudentDto studentDto)
        {
            var student = new Student { Name = studentDto.Name, Email = studentDto.Email };
            await _studentRepository.AddAsync(student);
        }

        public async Task UpdateStudentAsync(int id, StudentDto studentDto)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return;

            student.Name = studentDto.Name;
            student.Email = studentDto.Email;
            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _studentRepository.DeleteAsync(id);
        }
    }
}
