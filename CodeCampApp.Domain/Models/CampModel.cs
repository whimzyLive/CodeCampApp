﻿using System;

namespace CodeCampApp.Domain
{
    public class CampModel
    {
        public int CampId { get; set; }
        public string Name { get; set; }
        public string Moniker { get; set; }
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        public string Venue { get; set; }
    }
}
