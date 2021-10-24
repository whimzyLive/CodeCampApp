using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeCampApp.Domain
{
    public class CampModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Moniker { get; set; }
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        public string Venue { get; set; }
        public ICollection<TalkModel> Talks { get; set; }
    }
}
