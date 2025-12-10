namespace SIMS.Data
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int SemesterId { get; set; }
        public Semester Semester { get; set; }

        public string LecturerId { get; set; }
        public ApplicationUser Lecturer { get; set; }
    }
}
