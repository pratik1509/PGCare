namespace PGCare.Models {
    public class BaseModel {
         public string Id { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }        
    }
}