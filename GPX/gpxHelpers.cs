namespace GPX {
    using System.Xml.Serialization;

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.topografix.com/GPX/1/1")]
    public enum Fix
    {

        /// <remarks/>
        none,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2d")]
        Item2d,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("3d")]
        Item3d,

        /// <remarks/>
        dgps,

        /// <remarks/>
        pps,
    }

    /// <summary>
    /// You can add extend GPX by adding your own elements from another schema here.
    /// </summary>
    /// <remarks>Allow any elements from a namespace other than this schema's namespace (lax validation).</remarks>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.topografix.com/GPX/1/1")]
    public class Extensions {
        
        private System.Xml.XmlElement[] anyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any {
            get {
                return this.anyField;
            }
            set {
                this.anyField = value;
            }
        }
    }
    
    

    /// <summary>
    /// Information about the copyright holder and any license governing use of this file.
    /// </summary>
    /// <remarks>By linking to an appropriate license, you may place your data into the public domain or grant additional usage rights.</remarks>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.topografix.com/GPX/1/1")]
    public class Copyright {
        
        private string yearField;
        
        private string licenseField;
        
        private string authorField;
        
        /// <summary>
        /// Year of copyright.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType="gYear", ElementName="year")]
        public string Year {
            get {
                return this.yearField;
            }
            set {
                this.yearField = value;
            }
        }
        
        /// <summary>
        /// Link to external file containing license text.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "anyURI", ElementName = "license")]
        public string License {
            get {
                return this.licenseField;
            }
            set {
                this.licenseField = value;
            }
        }
        
        /// <summary>
        /// Copyright holder.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute("author")]
        public string Author {
            get {
                return this.authorField;
            }
            set {
                this.authorField = value;
            }
        }
    }
}
