﻿using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
        Task<StudentDto?> GetStudentByIdAsync(int id);
        Task AddStudentAsync(StudentDto studentDto);
        Task UpdateStudentAsync(int id, StudentDto studentDto);
        Task DeleteStudentAsync(int id);
    }
}
