﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon.Api.Web.Models
{
    public sealed class SimonVersionModel
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }

        public string DisplayText { get; set; }
    }
}
