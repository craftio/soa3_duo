﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiosTicketSystem
{
    public class PlainTextState : ExportState
    {
        public override void Export()
        {
            Console.WriteLine("PLAIN TEXT EXPORT");
        }
    }
}