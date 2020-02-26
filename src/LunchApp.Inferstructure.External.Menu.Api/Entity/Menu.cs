using LunchApp.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LunchApp.Inferstructure.External.Menu.Api.Entity
{
    [XmlRoot("Menu")]
    public class ExternalMenu : IMenu
    {
        [XmlAttribute("Date")]
        public DateTime Date { get; set; }
        [XmlElement("Course")]
        public string[] Course { get; set; }
    }
}
