using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UltraPlayProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Sport
    {
        private HashSet<SportEvent> sportEvents;

        public Sport()
        {
            this.sportEvents = new HashSet<SportEvent>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [XmlAttribute]
        public int ID { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [ForeignKey("XmlSports")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int XmlSportsID { get; set; }

        public virtual XmlSports XmlSports { get; set; }

        [XmlElement("Event")]
        public virtual HashSet<SportEvent> SportEvents
        {
            get { return this.sportEvents; }
            set { this.sportEvents = value; }
        }
    }
}
