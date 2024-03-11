using Kalbe.Models;

namespace Kalbe.DTO
{
    public class HomePageDto
    {
        public List<StudiesCardDto>? Studies {get; set;}
        public List<m_study_status>? StudyStatus {get; set;}
        public List<MoleculesSelectDto>? Molecules {get; set;}
    }
}
