﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApplication1
{
    public interface IRender
    {
        void Render(DrawingContext dc);
    }
}
