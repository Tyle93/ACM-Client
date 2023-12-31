﻿using System;
using System.Collections.Generic;

namespace ACM.Models
{
    public partial class ScreenEdit
    {
        public Guid ScreenEditId { get; set; }
        public Guid ScreenId { get; set; }
        public int ScreenEditIndex { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }

        public virtual Screen Screen { get; set; } = null!;
    }
}
