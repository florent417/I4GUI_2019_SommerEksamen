using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BlackboardDatabase.Models;
using Microsoft.EntityFrameworkCore;
using BlackBoard.Models;

namespace BlackboardDatabase.Data
{
    public class BlackboardDbContext : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentStudent> AssignmentStudents { get; set; }
        public DbSet<ContentArea> ContentAreas { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseContent> CourseContents { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        public BlackboardDbContext() { }

        public BlackboardDbContext(DbContextOptions<BlackboardDbContext> options)
            :base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=DAB2--BlackBoard;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            OnModelCreatingTeacherCourse(modelBuilder);
            OnModelCreatingCourseStudent(modelBuilder);
            OnModelCreatingCourseContent(modelBuilder);
            OnModelCreatingAssignmentStudent(modelBuilder);
            OnModelCreatingStudent(modelBuilder);
            OnModelCreatingSeedingData(modelBuilder);
        }

        private void OnModelCreatingStudent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasAlternateKey(s => s.AUID);


        }

        private void OnModelCreatingCourseContent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasOne(c => c.CourseContent)
                .WithOne(cc => cc.Course)
                .HasForeignKey<CourseContent>(c => c.CourseName);
        }

        private void OnModelCreatingCourseStudent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudent>()
                .HasKey(cs => new {cs.CourseName, cs.StudentAUID});

            modelBuilder.Entity<CourseStudent>()
                .HasOne<Course>(cs => cs.Course)
                .WithMany(c => c.CourseStudents)
                .HasForeignKey(cs => cs.CourseName);

            modelBuilder.Entity<CourseStudent>()
                .HasOne<Student>(cs => cs.Student)
                .WithMany(s => s.CourseStudents)
                .HasForeignKey(cs => cs.StudentAUID);
        }

        protected void OnModelCreatingTeacherCourse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherCourse>()
                .HasKey(tc => new { tc.CourseName, tc.TeacherAUID });

            modelBuilder.Entity<TeacherCourse>()
                .HasOne<Teacher>(tc => tc.Teacher)
                .WithMany(t => t.TeacherCourses)
                .HasForeignKey(tc => tc.TeacherAUID);

            modelBuilder.Entity<TeacherCourse>()
                .HasOne<Course>(tc => tc.Course)
                .WithMany(c => c.TeacherCourses)
                .HasForeignKey(sc => sc.CourseName);
        }

        private void OnModelCreatingAssignmentStudent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignmentStudent>()
                .HasKey(as_ => new { as_.StudentAUID, as_.AssignmentId });

            modelBuilder.Entity<AssignmentStudent>()
                .HasOne<Student>(as_ => as_.Student)
                .WithMany(s => s.AssignmentStudents)
                .HasForeignKey(as_ => as_.StudentAUID);

            modelBuilder.Entity<AssignmentStudent>()
                .HasOne<Assignment>(as_ => as_.Assignment)
                .WithMany(a => a.AssignmentStudents)
                .HasForeignKey(as_ => as_.AssignmentId);
        }

        private void OnModelCreatingSeedingData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    AUID = 111111,
                    Name = "Morten",
                    BirthDate = new DateTime(1995, 5, 10),
                    EnrollmentDate = new DateTime(2019, 1, 1),
                    GraduationDate = new DateTime(2019, 7, 1)
                },
                new Student
                {
                    AUID = 222222,
                    Name = "Andreas",
                    BirthDate = new DateTime(1995, 1, 9),
                    EnrollmentDate = new DateTime(2019, 1, 1),
                    GraduationDate = new DateTime(2019, 7, 1)
                },
                new Student
                {
                    AUID = 333333,
                    Name = "Troels",
                    BirthDate = new DateTime(1996, 1, 2),
                    EnrollmentDate = new DateTime(2019, 1, 1),
                    GraduationDate = new DateTime(2019, 7, 1)
                },
                new Student
                {
                    AUID = 444444,
                    Name = "Frederik",
                    BirthDate = new DateTime(1997, 6, 2),
                    EnrollmentDate = new DateTime(2019, 1, 1),
                    GraduationDate = new DateTime(2019, 7, 1)
                }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseName = "F19-I4DAB" },
                new Course { CourseName = "F19-I4GUI" },
                new Course { CourseName = "F19-I4SWD" }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { AUID = 999999, Name = "Henrik" },
                new Teacher { AUID = 888888, Name = "Poul" },
                new Teacher { AUID = 777777, Name = "Michael" }
            );

            modelBuilder.Entity<TeacherCourse>().HasData(
                new TeacherCourse { CourseName = "F19-I4DAB", TeacherAUID = 999999, Role = "Primær" },
                new TeacherCourse { CourseName = "F19-I4GUI", TeacherAUID = 888888, Role = "Primær" },
                new TeacherCourse { CourseName = "F19-I4SWD", TeacherAUID = 999999, Role = "Primær" },
                new TeacherCourse { CourseName = "F19-I4SWD", TeacherAUID = 777777, Role = "Primær" }
            );

            modelBuilder.Entity<CourseStudent>().HasData(
                new CourseStudent { CourseName = "F19-I4DAB", StudentAUID = 111111, Status = "Aktiv"},
                new CourseStudent { CourseName = "F19-I4GUI", StudentAUID = 111111, Status = "Aktiv" },
                new CourseStudent { CourseName = "F19-I4SWD", StudentAUID = 111111, Status = "Aktiv" },

                new CourseStudent { CourseName = "F19-I4DAB", StudentAUID = 222222, Status = "Aktiv" },
                new CourseStudent { CourseName = "F19-I4GUI", StudentAUID = 222222, Status = "Aktiv" },
                new CourseStudent { CourseName = "F19-I4SWD", StudentAUID = 222222, Status = "Aktiv" },

                new CourseStudent { CourseName = "F19-I4DAB", StudentAUID = 333333, Status = "Aktiv" },
                new CourseStudent { CourseName = "F19-I4GUI", StudentAUID = 333333, Status = "Aktiv" },
                new CourseStudent { CourseName = "F19-I4SWD", StudentAUID = 333333, Status = "Aktiv" },

                new CourseStudent { CourseName = "F19-I4DAB", StudentAUID = 444444, Status = "Aktiv" },
                new CourseStudent { CourseName = "F19-I4GUI", StudentAUID = 444444, Status = "Aktiv" },
                new CourseStudent { CourseName = "F19-I4SWD", StudentAUID = 444444, Status = "Aktiv" }
            );

            modelBuilder.Entity<CourseContent>().HasData(
                new CourseContent { CourseContentId = 1, CourseName = "F19-I4DAB" },
                new CourseContent { CourseContentId = 2, CourseName = "F19-I4GUI" },
                new CourseContent { CourseContentId = 3, CourseName = "F19-I4SWD" }
            );

            modelBuilder.Entity<Folder>().HasData(
                new Folder { FolderId = 1, CourseContentId = 1, FolderName = "Assignments" },
                new Folder { FolderId = 2, CourseContentId = 1, FolderName = "0 Pre-Course" },
                new Folder { FolderId = 3, CourseContentId = 1, FolderName = "1.1 Introduction" },

                new Folder { FolderId = 4, CourseContentId = 2, FolderName = "Introduktion" },
                new Folder { FolderId = 5, CourseContentId = 2, FolderName = "Lektionsplan" },
                new Folder { FolderId = 6, CourseContentId = 2, FolderName = "01 Intro and .Net architecture" },

                new Folder { FolderId = 7, CourseContentId = 3, FolderName = "Week -1   : Optional: Self study of C#" },
                new Folder { FolderId = 8, CourseContentId = 3, FolderName = "Week 0    : Interfaces(Self-study)" },
                new Folder { FolderId = 9, CourseContentId = 3, FolderName = "Week 01.1 : Introduction to the course and agile software development" }
            );

            modelBuilder.Entity<ContentArea>().HasData(
                new ContentArea { ContentAreaId = 1, CourseContentId = 1, FolderId = 1, TextBlock = $"1Random content text (1,1)" },
                new ContentArea { ContentAreaId = 2, CourseContentId = 1, FolderId = 1, TextBlock = $"2Random content text (1,1)" },
                new ContentArea { ContentAreaId = 3, CourseContentId = 1, FolderId = 1, TextBlock = $"3Random content text (1,1)" },

                new ContentArea { ContentAreaId = 4, CourseContentId = 1, FolderId = 2, TextBlock = $"Random content text (1,2)" },
                new ContentArea { ContentAreaId = 5, CourseContentId = 1, FolderId = 3, TextBlock = $"1Random content text (1,3)" },
                new ContentArea { ContentAreaId = 6, CourseContentId = 1, FolderId = 3, TextBlock = $"2Random content text (1,3)" },

                new ContentArea { ContentAreaId = 7, CourseContentId = 2, FolderId = 4, TextBlock = $"Random content text (2,4)" },
                new ContentArea { ContentAreaId = 8, CourseContentId = 2, FolderId = 5, TextBlock = $"1Random content text (2,5)" },
                new ContentArea { ContentAreaId = 9, CourseContentId = 2, FolderId = 6, TextBlock = $"2Random content text (2,6)" },

                new ContentArea { ContentAreaId = 10, CourseContentId = 3, FolderId = 7, TextBlock = $"Random content text (3,7)" },
                new ContentArea { ContentAreaId = 11, CourseContentId = 3, FolderId = 8, TextBlock = $"1Random content text (3,8)" },
                new ContentArea { ContentAreaId = 12, CourseContentId = 3, FolderId = 9, TextBlock = $"2Random content text (3,9)" }

            );

            modelBuilder.Entity<Assignment>().HasData(
                new Assignment 
                {
                    AssignmentId = 111,
                    HandinDeadline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    Attempt = 2,
                    Grade = 7,
                    ParticipantsAllowed = 5,
                    TeacherAUID = 777777,
                    CourseName = "F19-I4SWD"
                },
                new Assignment
                {
                    AssignmentId = 222,
                    HandinDeadline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    Attempt = 2,
                    Grade = 4,
                    ParticipantsAllowed = 5,
                    TeacherAUID = 999999,
                    CourseName = "F19-I4DAB"
                },
                new Assignment
                {
                    AssignmentId = 333,
                    HandinDeadline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    Attempt = 5,
                    Grade = 10,
                    ParticipantsAllowed = 10,
                    TeacherAUID = 999999,
                    CourseName = "F19-I4DAB"
                });

            modelBuilder.Entity<AssignmentStudent>().HasData(
                new AssignmentStudent { StudentAUID = 111111, AssignmentId = 111 },
                new AssignmentStudent { StudentAUID = 111111, AssignmentId = 222 },
                new AssignmentStudent { StudentAUID = 111111, AssignmentId = 333 },
                new AssignmentStudent { StudentAUID = 222222, AssignmentId = 111 },
                new AssignmentStudent { StudentAUID = 222222, AssignmentId = 222 },
                new AssignmentStudent { StudentAUID = 333333, AssignmentId = 333 },
                new AssignmentStudent { StudentAUID = 444444, AssignmentId = 333 },
                new AssignmentStudent { StudentAUID = 444444, AssignmentId = 111 }
            );


        }

        public DbSet<BlackBoard.Models.ContentLink> ContentLink { get; set; }
    }
}
