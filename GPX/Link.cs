using System;
using System.Xml.Serialization;

namespace GPX
{
    /// <summary>
    /// A link to an external resource (Web page, digital photo, video clip, etc) with additional information.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.topografix.com/GPX/1/1")]
    public class Link
    {

        private string textField;

        private string typeField;

        private string hrefField;

        /// <summary>
        /// Text of hyperlink.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("text")]
        public string Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <summary>
        /// Mime type of content.
        /// </summary>
        /// <example>image/jpeg</example>
        [System.Xml.Serialization.XmlElementAttribute("type")]
        public string MIMEType
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <summary>
        /// URL of hyperlink.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "href", DataType = "anyURI")]
        public string href
        {
            get
            {
                return this.hrefField;
            }
            set
            {
                this.hrefField = value;
            }
        }
    }
}
