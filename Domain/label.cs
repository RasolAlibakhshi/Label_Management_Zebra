using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class label:Base
    {
        public string Interwoven { set; get; }

        public label()
        {
            
        }

        public label(long machineId, string interwoven, string filament, string den, string colorCode, string emptyfield1, string emptyfield2, string emptyfield3, string emptyfield4, string emptyfield5, string description, string mingel, string yarnType,string ply,string direction)
        {
            MachineID = machineId;
            Interwoven = interwoven;
            Filament = filament;
            Den = den;
            ColorCode = colorCode;
            Emptyfield1 = emptyfield1;
            Emptyfield2 = emptyfield2;
            Emptyfield3 = emptyfield3;
            Emptyfield4 = emptyfield4;
            Emptyfield5 = emptyfield5;
            Description = description;
            CreaationDateTime= DateTime.Now;
            IsDeleted=false;
            Mingel = mingel;
            YarnType=yarnType;
            Ply = ply;
            this.direction = direction;
        }

        public void Edit(long machineId, string interwoven, string filament, string den, string colorCode, string emptyfield1, string emptyfield2, string emptyfield3, string emptyfield4, string emptyfield5, string description,string mingel,string yarnType, string ply, string direction)
        {
            MachineID = machineId;
            Interwoven = interwoven;
            Filament = filament;
            Den = den;
            ColorCode = colorCode;
            Emptyfield1 = emptyfield1;
            Emptyfield2 = emptyfield2;
            Emptyfield3 = emptyfield3;
            Emptyfield4 = emptyfield4;
            Emptyfield5 = emptyfield5;
            Description = description;
            Mingel = mingel;
            YarnType=yarnType;
            Ply = ply;
            this.direction = direction;
        }

        public void Remove()
        {
            IsDeleted=true;
        }

        public void Restore()
        {
            IsDeleted=false;
        }


        public long MachineID { set; get; }
        
        public  Machine Machine { set; get; }


        public string? Filament { set; get; }
        public string? Den { set; get; }
        public string? Ply { set; get; }
        public string? Mingel { set; get; }
        public string? ColorCode { set; get; }
        public string? direction { set; get; }
        public string? Emptyfield1 { set; get; }
        public string? Emptyfield2 { set; get; }
        public string? Emptyfield3 { set; get; }
        public string? Emptyfield4 { set; get; }
        public string? Emptyfield5 { set; get; }
        public string? YarnType { set; get; }
        public string? Description { set; get; }

    }

    

    
    
}
