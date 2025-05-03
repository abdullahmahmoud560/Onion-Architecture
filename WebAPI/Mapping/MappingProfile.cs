using AutoMapper;
using Domain.Entities;
using static Shared.DataTransferObjects; // تأكد من استيراد الـ DTOs

namespace WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDTO>(); // يقوم AutoMapper بتكوين كل شيء تلقائيًا هنا
        }
    }
}
