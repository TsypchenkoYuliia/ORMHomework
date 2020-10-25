using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ORM.Homework.Context;
using ORM.Homework.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Homework.Service
{
    public class AppService
    {
        private readonly HomeworkAppContext _context;
      
        public AppService(HomeworkAppContext context)
        {
            _context = context;
        }

        public async Task<string> CreateFaculty()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var faculty = new Faculty() { Number = "Faculty of Economics" };

                    await _context.Faculties.AddAsync(faculty);

                    await _context.SaveChangesAsync();

                    var group_1 = new Group { FacultyId = faculty.Id, Number = "Gr-098-Ec" };
                    var group_2 = new Group { FacultyId = faculty.Id, Number = "GrT-0548-Ec" };
                    var group_3 = new Group { FacultyId = faculty.Id, Number = "GrP-67-Ec" };

                    await _context.Groups.AddRangeAsync(group_1, group_2, group_3);

                    await _context.SaveChangesAsync();

                    await _context.Students.AddAsync(new Student
                    {
                        FirstName = "Makarov",
                        LastName = "Ivan",
                        MiddleName = "Ivanovish",
                        DateOfBirth = new DateTime(1990, 12, 4).Date,
                        GroupId = group_1.Id
                    });

                    await _context.Students.AddAsync(new Student
                    {
                        FirstName = "Turov",
                        LastName = "Egor",
                        MiddleName = "Ivanovish",
                        DateOfBirth = new DateTime(1985, 03, 04).Date,
                        GroupId = group_1.Id
                    });

                    await _context.Students.AddAsync(new Student
                    {
                        FirstName = "Sidorov",
                        LastName = "Taras",
                        MiddleName = "Ivanovish",
                        DateOfBirth = new DateTime(1992, 01, 08).Date,
                        GroupId = group_2.Id
                    });

                    await _context.Students.AddAsync(new Student
                    {
                        FirstName = "Below",
                        LastName = "Lev",
                        MiddleName = "Ivanovish",
                        DateOfBirth = new DateTime(1997, 05, 27).Date,
                        GroupId = group_2.Id
                    });

                    await _context.Students.AddAsync(new Student
                    {
                        FirstName = "Lotkina",
                        LastName = "Inna",
                        MiddleName = "Ivanovna",
                        DateOfBirth = new DateTime(1993, 09, 10).Date,
                        GroupId = group_3.Id
                    });

                    await _context.Students.AddAsync(new Student
                    {
                        FirstName = "Belkina",
                        LastName = "Anna",
                        MiddleName = "Ivanovna",
                        DateOfBirth = new DateTime(1998, 11, 02).Date,
                        GroupId = group_3.Id
                    });

                    await _context.SaveChangesAsync();

                    transaction.Commit();
                } 
                catch(Exception ex)
                {
                    transaction.Rollback();
                    return ex.Message;
                }
            }

            return "Data added to database";
        }

        public async Task<ICollection<Student>> GetAllAsync()
        {
            return await _context.Students
                .Include(g => g.Group)
                .ThenInclude(f => f.Faculty)
                .ToListAsync();
        }
    }
}
