﻿using NJsonSchema.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.DTO_s
{
    public class TaskDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [NotNull]
        public string Description { get; set; }
        public bool Checked { get; set; }
     }
}