﻿using System.Collections.Generic;

namespace AppQuest_Schrittzaehler.Model
{
    public class ReceiveObject
    {
        public string StartStation { get; set; }

        public IList<Steps> Input { get; set; }     
            
    }
}