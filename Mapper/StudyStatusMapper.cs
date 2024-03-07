using AutoMapper;
using Kalbe.DTO;
using Kalbe.Models;

namespace Kalbe.Mapper

{
    public class StudyStatusMapper : Profile
    {
        public StudyStatusMapper()
        {
            CreateMap<PostStudyStatusDto, m_study_status>();
            CreateMap<PostMoleculesDto, m_molecules>();
            CreateMap<PostStudyDto, m_study>();
            CreateMap<EditStudyDto, m_study>();
        }
    }
}
