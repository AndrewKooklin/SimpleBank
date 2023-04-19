using SQLite.CodeFirst;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBank.Model
{
    [Table("DepositAccounts")]
    public class DepositAccount
    {
        public DepositAccount()
        {
        }

        public DepositAccount(int total)
        {
            DepositTotal = 0;
            DateDepositOpen = DateTime.Now;
        }

        [Key,Autoincrement]
        [Unique]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DepositAccountId")]
        public int DepositAccountId { get; set; }

        
        [Column("PersonId")]
        //[ForeignKey("FK_DepositAccount")]
        public int PersonId { get; set; }

        [Column("DepositTotal")]
        public int DepositTotal { get; set; } = 0;

        [Column("DateDepositOpen")]
        public DateTime DateDepositOpen { get; set; }
    }
}
