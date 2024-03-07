using System.ComponentModel.DataAnnotations;

namespace Kalbe.Models
{
    public class m_study
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string StudyId { get; set; }
        public int VersionId { get; set; }
        public string ProtocolTitle { get; set; }
        public string ProtocolCode { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime  CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? State { get; set; }

        public Guid MoleculesId { get; set; }
        public int StudyStatusId {get; set;}

        public m_molecules Molecule {  get; set; }
        public m_study_status StudyStatus { get; set; }





    }
}
