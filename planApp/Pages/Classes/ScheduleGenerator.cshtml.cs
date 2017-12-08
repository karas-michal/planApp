using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using planApp.Models;

namespace planApp.Pages.Classes
{
    public class ScheduleGeneratorModel : PageModel
    { 
        public class Exception : System.Exception
        {
            public Exception(string msg) : base(msg) { }
        }

        private readonly planApp.Data.ApplicationDbContext _context;
        [BindProperty]
        public Class Class { get; set; }
        public IQueryable<Teacher> Teachers; 
        public IQueryable<Lesson> Lessons;
        [BindProperty]
        public List<Lesson> Schedule { get; set; } 

        public ScheduleGeneratorModel(planApp.Data.ApplicationDbContext context)
        {
            _context = context;
            Schedule = new List<Lesson>();
        }

        public async Task<IActionResult> OnGetAsync(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            } 

            Class = await _context.Class
                .Include("Students")
                .Include("Requirements") 
                .Include("Requirements.Subject")
                .SingleOrDefaultAsync(m => m.ID == id);

            if (Class == null)
            {
                return NotFound();
            }

			Teachers = _context.Teacher
				.Include("Availability")
				.Include("Subjects")
				.Include("Subjects.Subject")
				.Include("Subjects.Teacher").ToList().AsQueryable();

            if (Teachers == null)
            {
                return NotFound();
            }

			Lessons = _context.Lesson
				.Include("Class")
				.Include("Teacher")
				.Include("Subject")
				.Include("Classroom").ToList().AsQueryable();

            if (Lessons == null)
            {
                return NotFound();
            }

            try
            {
                GenerateSchedule();
            }
            catch (Exception)
            {
                return RedirectToPage("./ScheduleFailure", new { id = Class.ID });
            }
            Schedule = Schedule
                .OrderBy(l => l.Day)
                .ThenBy(l => l.Hour)
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Lesson.RemoveRange(_context.Lesson.Include("Class").Where(l => l.Class.ID == Class.ID));
            foreach (var lesson in Schedule)
            {
                lesson.Class = _context.Class.Where(c => c.ID == lesson.Class.ID).First();
                lesson.Classroom = _context.Classroom.Where(c => c.ID == lesson.Classroom.ID).First();
                lesson.Subject = _context.Subject.Where(c => c.ID == lesson.Subject.ID).First();
                lesson.Teacher = _context.Teacher.Where(c => c.ID == lesson.Teacher.ID).First();
            }
            _context.Lesson.AddRange(Schedule);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Edit", new { id = Class.ID });
        }

        private void GenerateSchedule()
        {
            foreach (var requirement in Class.Requirements)
            {
                CreateLessons(requirement.Subject, requirement.Hours);
            }
        }


        private void CreateLessons(Subject subject, int hours)
        {
            var subjectTeachers = GetTeachers(subject);
            for (int hour = 8; hour <= 16; hour++)
            {
                for (Day day = Day.MONDAY; day <= Day.FRIDAY; day++)
                {
                    if (Schedule.Any(l => l.Day == day && l.Hour == hour))
                    {
                        continue;
                    }
                    var availableClassrooms = GetAvailable(_context.Classroom, day, hour);
                    var availableTeachers = GetAvailable(subjectTeachers, day, hour);
                    if (availableClassrooms.Any() && availableTeachers.Any())
                    {
                        var lesson = new Lesson
                        {
                            Day = day,
                            Hour = hour,
                            Subject = subject,
                            Teacher = availableTeachers[0],
                            Class = Class,
                            Classroom = availableClassrooms[0]
                        };
                        Schedule.Add(lesson);
                        hours--;
                    }
                    if (hours == 0)
                    {
                        return;
                    }
                }
            }
            if (hours > 0)
            {
                throw new Exception("Failed to generate schedule!");
            }
        }

        private IQueryable<Teacher> GetTeachers(Subject subject)
        {
            return Teachers.Where(t => t.Subjects.Any(ts => ts.Subject == subject));
        }

        private List<Classroom> GetAvailable(IQueryable<Classroom> classrooms, Day day, int hour)
        {
            var lessons = GetLessons(day, hour);
            return classrooms
                .Where(c => !lessons.Any(l => l.Classroom == c))
                .ToList();
        }
        private List<Teacher> GetAvailable(IQueryable<Teacher> teachers, Day day, int hour)
        {
            var lessons = GetLessons(day, hour);
            return teachers
                .Where(t => t.Availability.Any(a => a.Day == day
                && a.Start.Hours <= hour && hour <= a.End.Hours)
                && !lessons.Any(l => l.Teacher == t))
                .ToList();
        }

        private IQueryable<Lesson> GetLessons(Day day, int hour)
        {
            var lessons = Lessons.Where(l => l.Day == day && l.Hour == hour).ToList();
            lessons.AddRange(Schedule.Where(l => l.Day == day && l.Hour == hour));
            return lessons.AsQueryable();
        }
    }
}
