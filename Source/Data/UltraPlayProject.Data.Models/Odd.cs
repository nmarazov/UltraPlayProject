namespace UltraPlayProject.Data.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Odd
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [XmlAttribute]
        public int ID { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public decimal Value { get; set; }

        [XmlAttribute]
        public decimal SpecialBetValue { get; set; }

        [XmlIgnore]
        public bool SpecialBetValueSpecified { get; set; }

        [ForeignKey("Bet")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int BetID { get; set; }

        public virtual Bet Bet { get; set; }
    }
}
