using SQLite.CodeFirst;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBank.Model
{
    [Table("SalaryAccounts")]
    public class SalaryAccount
    {
        public SalaryAccount()
        {
        }

        public SalaryAccount(int total)
        {
            SalaryTotal = 0;
            DateSalaryOpen = DateTime.Now;
        }

        [Key,Autoincrement]
        [Unique]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SalaryAccountId")]
        public int SalaryAccountId { get; set; }

        [Column("PersonId")]
        //[ForeignKey("FK_SalaryAccount")]
        public int PersonId { get; set; }

        [Column("SalaryTotal")]
        public int SalaryTotal { get; set; } = 0;

        [Column("DateSalaryOpen")]
        public DateTime DateSalaryOpen { get; set; }

    }
}
