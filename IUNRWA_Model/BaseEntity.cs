using System;
using System.ComponentModel.DataAnnotations;

namespace IUNRWA_Model
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public bool IsVaild { get; set; } = true;
        public bool ForceDelete { get; set; } = false;
    }
}
