using Microsoft.EntityFrameworkCore;
using SIMS.Data;

namespace SIMS.Data
{
    public static class EnrollmentSeeder
    {
        public static async Task SeedEnrollments(ApplicationDbContext context)
        {
            if (await context.Enrollments.AnyAsync())
            {
                return;
            }

            var students = await context.ApplicationUsers
                .Where(u => u.Email != null && u.Email.Contains("student"))
                .Take(5)
                .ToListAsync();

            var courses = await context.Course
                .Take(3)
                .ToListAsync();

            if (!students.Any() || !courses.Any())
            {
                return;
            }

            var enrollments = new List<Enrollment>();

            foreach (var student in students)
            {
                foreach (var course in courses)
                {
                    enrollments.Add(new Enrollment
                    {
                        StudentId = student.Id,
                        CourseId = course.Id,
                        EnrollmentDate = DateTime.Now.AddDays(-30),
                        Status = "Active"
                    });
                }
            }

            context.Enrollments.AddRange(enrollments);
            await context.SaveChangesAsync();
        }
    }
}

