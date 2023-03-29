using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirstDemo
{
    public static class AutomapperConfig
    {
        // Lazy thread-safe auto initialised Mapper (instantiated on first .Value access)
        private static Lazy<Mapper> _mapper = new Lazy<Mapper>(() => new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<AmProfile>())));

        public static Mapper mapper => _mapper.Value;

        public static void ReloadMapper()
        {
            _mapper = new Lazy<Mapper>(() => new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<AmProfile>())));
        }

    }


    internal class AmProfile:Profile
    {
        public AmProfile()
        {
            CreateMap<Grade, GradeDto>();
            CreateMap<Student, StudentDto>();
        }
    }

    public class StudentDto
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        public byte[] RowVersion { get; set; }

        //fully defined relationship
        public int? GradeId { get; set; }

        public virtual GradeDto Grade { get; set; }

    }

    public class GradeDto
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }

    }
}
