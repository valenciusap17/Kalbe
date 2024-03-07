using Kalbe.Models;

namespace Kalbe.DTO
{
    public class PostStudyDto
    {
        public string StudyId { get; set; }
        public int VersionId { get; set; }
        public string ProtocolTitle { get; set; }
        public string ProtocolCode { get; set; }
        public string CreatedBy { get; set; }
        public Guid MoleculesId { get; set; }
        public int StudyStatusId { get; set; }
    }
}
