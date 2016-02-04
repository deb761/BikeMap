using System;
using System.Xml.Serialization;

namespace GPX
{
    /// <summary>
    /// Two latitude/longitude pairs defining the extent of an element.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.topografix.com/GPX/1/1")]
    public class Bounds
    {
        #region Variables
        private decimal minlatField;

        private decimal minlonField;

        private decimal maxlatField;

        private decimal maxlonField;
        #endregion Variables

        /// <summary>
        /// The minimum latitude.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="minlat")]
        public decimal MinimumLatitude
        {
            get
            {
                return this.minlatField;
            }
            set
            {
                this.minlatField = value;
            }
        }

        /// <summary>
        /// The minimum longitude.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="minlon")]
        public decimal MinimumLongitude
        {
            get
            {
                return this.minlonField;
            }
            set
            {
                this.minlonField = value;
            }
        }

        /// <summary>
        /// The maximum latitude.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="maxlat")]
        public decimal MaximumLatitude
        {
            get
            {
                return this.maxlatField;
            }
            set
            {
                this.maxlatField = value;
            }
        }

        /// <summary>
        /// The maximum longitude.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName="maxlon")]
        public decimal MaximumLongitude
        {
            get
            {
                return this.maxlonField;
            }
            set
            {
                this.maxlonField = value;
            }
        }
    }
}
