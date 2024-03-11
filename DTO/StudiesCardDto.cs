namespace Kalbe.DTO
{
    public class StudiesCardDto
    {
        public Guid Id {get; set;}
        public string ProtocolTitle { get; set; }
        public string MoleculesName { get; set; }
        public string MolDescription { get; set; }
        public string StatusName {get; set;}
        public string CreatedBy {get; set;}
        public string? UpdatedBy {get; set;}
        public DateTime? CreatedDate {get; set;}
        public DateTime? UpdatedDate {get; set;}

        

    }
}
