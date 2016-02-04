using System;
using System.Xml.Serialization;

namespace GPX
{
    /// <summary>
    /// An email address. Broken into two parts (id and domain) to help prevent email harvesting.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.topografix.com/GPX/1/1")]
    public class Email
    {

        private string idField;

        private string domainField;

        /// <summary>
        /// id half of email address.
        /// </summary>
        /// <example>billgates2004</example>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="id")]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <summary>
        /// domain half of email address.
        /// </summary>
        /// <example>hotmail.com</example>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="domain")]
        public string Domain
        {
            get
            {
                return this.domainField;
            }
            set
            {
                this.domainField = value;
            }
        }
    }
}
