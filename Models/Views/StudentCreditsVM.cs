using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GAMF.Models.Views
{
    public class StudentCreditsVM
    {
        [DisplayName("Hallgató neve")]
        public string StudentName { get; set; }
        [DisplayName("Teljesített kreditek száma")]
        public int Credits { get; set; }
        [DisplayName("Felvett kreditek száma")]
        public int FullCredits { get; set; }
    }
}
