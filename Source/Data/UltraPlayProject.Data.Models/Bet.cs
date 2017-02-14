namespace UltraPlayProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Bet
    {
        private HashSet<Odd> odds;

        public Bet()
        {
            this.odds = new HashSet<Odd>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [XmlAttribute]
        public int ID { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public bool IsLive { get; set; }

        [ForeignKey("Match")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int MatchID { get; set; }

        public virtual Match Match { get; set; }

        [XmlElement("Odd")]
        public virtual HashSet<Odd> Odds
        {
            get { return this.odds; }
            set { this.odds = value; }
        }
    }
}
