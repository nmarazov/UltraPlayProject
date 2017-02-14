namespace UltraPlayProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Xml.Serialization;

    [System.SerializableAttribute]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class XmlSports
    {
        private HashSet<Sport> sports;

        public XmlSports()
        {
            this.sports = new HashSet<Sport>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [XmlAttribute]
        public DateTime CreateDate { get; set; }

        [XmlElement("Sport")]
        public virtual HashSet<Sport> Sports
        {
            get { return this.sports; }
            set { this.sports = value; }
        }
    }
}
