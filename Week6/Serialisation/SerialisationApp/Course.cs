using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationApp
{
    public class Course
    {
        public string Subject { get; set; }
        public string Title { get; set; }
        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public List<Trainee> Trainees { get; } = new List<Trainee>();

        [field: NonSerialized]
        private readonly DateTime _lastRead;

        public Course()
        {
            _lastRead = DateTime.Now;
        }

        public void AddTrainee(Trainee trainee)
        {
            Trainees.Add(trainee);
        }
    }
}
