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
    public class SportEvent
    {
        private HashSet<Match> matches;

        public SportEvent()
        {
            this.matches = new HashSet<Match>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [XmlAttribute]
        public int ID { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public bool IsLive { get; set; }

        [XmlAttribute]
        public int CategoryID { get; set; }

        [ForeignKey("Sport")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int SportID { get; set; }

        public virtual Sport Sport { get; set; }

        [XmlElement("Match")]
        public virtual HashSet<Match> Matches
        {
            get { return this.matches; }
            set { this.matches = value; }
        }
    }
}
