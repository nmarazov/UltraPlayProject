namespace UltraPlayProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Match
    {
        private HashSet<Bet> bets;

        public Match()
        {
            this.bets = new HashSet<Bet>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [XmlAttribute]
        public int ID { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public DateTime StartDate { get; set; }

        [XmlAttribute]
        public string MatchType { get; set; }

        [ForeignKey("SportEvent")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int SportEventID { get; set; }

        public virtual SportEvent SportEvent { get; set; }

        [XmlElement("Bet")]
        public virtual HashSet<Bet> Bets
        {
            get { return this.bets; }
            set { this.bets = value; }
        }
    }
}
