using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_web_api.Dtos.Fight
{
    public class AttackerResultDto
    {
        public string AttackerName { get; set; }
        public string OpponentName { get; set; }
        public int AttackerHitPoint { get; set; }
        public int OpponentHitPoint { get; set; }
        public int Damage { get; set; }


    }
}
