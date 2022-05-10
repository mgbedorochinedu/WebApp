﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_web_api.Dtos.Fight
{
    public class HighScoreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
    }
}
