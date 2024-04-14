using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Required at least 5 students");
            }

            var percentageOfTop = (int)Math.Ceiling(Students.Count * 0.2);
            var percentageOfTop2 = (int)Math.Ceiling(Students.Count * 0.4);
            var percentageOfTop3 = (int)Math.Ceiling(Students.Count * 0.6);
            var percentageOfTop4 = (int)Math.Ceiling(Students.Count * 0.8);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (averageGrade >= grades[percentageOfTop - 1])
                return 'A';
            else if (averageGrade >= grades[percentageOfTop2 - 1])
                return 'B';
            else if (averageGrade >= grades[percentageOfTop3 - 1])
                return 'C';
            else if (averageGrade >= grades[percentageOfTop4 - 1])
                return 'D';
            else
                return 'F';

        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
            }
            else
                base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
            }
            else
                base.CalculateStudentStatistics(name);
        }
    }
}
