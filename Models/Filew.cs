using System.ComponentModel.DataAnnotations;

namespace DriveAPI.Models
{
    public class Filew
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public string extension { get; set; }
        public string folderPath { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime modificationDate { get; set; }
    }
    //public Owner owner {get; set;}(Agregar?)
}