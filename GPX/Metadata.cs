using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GPX
{
    /// <summary>
    /// Information about the GPX file, author, and copyright restrictions goes in the metadata section.
    /// </summary>
    /// <remarks>Providing rich, meaningful information about your GPX files allows others to search for and use your GPS data.</remarks>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.topografix.com/GPX/1/1")]
    public class Metadata
    {
        #region Variables
        private string nameField;

        private string descField;

        private Person authorField;

        private Copyright copyrightField;

        //private linkType[] linkField;
        private List<Link> linkField;

        private System.DateTime timeField;

        private bool timeFieldSpecified;

        private string keywordsField;

        private Bounds boundsField;

        private Extensions extensionsField;
        #endregion Variables

        /// <summary>
        /// The name of the GPX file.
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
        /// A description of the contents of the GPX file.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("desc")]
        public string Description
        {
            get
            {
                return this.descField;
            }
            set
            {
                this.descField = value;
            }
        }

        /// <summary>
        /// The person or organization who created the GPX file.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("author")]
        public Person Author
        {
            get
            {
                return this.authorField;
            }
            set
            {
                this.authorField = value;
            }
        }

        /// <summary>
        /// Copyright and license information governing use of the file.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("copyright")]
        public Copyright Copyright
        {
            get
            {
                return this.copyrightField;
            }
            set
            {
                this.copyrightField = value;
            }
        }

        /// <summary>
        /// URLs associated with the location described in the file.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("link")]
        public List<Link> Link
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

        /// <summary>
        /// The creation date of the file.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("time")]
        public System.DateTime Time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool timeSpecified
        {
            get
            {
                return this.timeFieldSpecified;
            }
            set
            {
                this.timeFieldSpecified = value;
            }
        }

        /// <summary>
        /// Keywords associated with the file.
        /// </summary>
        /// <remarks>Search engines or databases can use this information to classify the data.</remarks>
        [System.Xml.Serialization.XmlElementAttribute("keywords")]
        public string Keywords
        {
            get
            {
                return this.keywordsField;
            }
            set
            {
                this.keywordsField = value;
            }
        }

        /// <summary>
        /// Minimum and maximum coordinates which describe the extent of the coordinates in the file.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("bounds")]
        public Bounds Bounds
        {
            get
            {
                return this.boundsField;
            }
            set
            {
                this.boundsField = value;
            }
        }

        /// <summary>
        /// You can extend GPX by adding your own elements from another schema here.
        /// </summary>
        public Extensions extensions
        {
            get
            {
                return this.extensionsField;
            }
            set
            {
                this.extensionsField = value;
            }
        }
    }
}
