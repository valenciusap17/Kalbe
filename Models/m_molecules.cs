using System.ComponentModel.DataAnnotations;

namespace Kalbe.Models
{
    public class m_molecules
    {
        [Key]
        public Guid IdMolecules { get; set; } = Guid.NewGuid();
        public string MoleculesName { get; set; }
        public string MolDescription { get; set; }
        public bool IsActive { get; set; } = true;
        public string State { get; set; } = "-";
        public ICollection<m_study> Studies { get; set; }
    }
}
