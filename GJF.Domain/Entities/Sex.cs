﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJF.Domain.Entities
{
    public class Sex
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
