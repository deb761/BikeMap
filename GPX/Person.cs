using System;
using System.Xml.Serialization;

namespace GPX
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.topografix.com/GPX/1/1")]
    public class Person
    {

        private string nameField;

        private Email emailField;

        private Link linkField;

        /// <summary>
        /// Name of person or organization.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("name")]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <summary>
        /// Email address.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("email")]
        public Email Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        /// <summary>
        /// Link to Web site or other external information about person.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("link")]
        public Link Link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }
    }
}
