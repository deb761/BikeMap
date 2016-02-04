using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GPX
{
    /// <summary>
    /// This represents a route - an ordered list of waypoints representing a series of turn points leading to a destination.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.topografix.com/GPX/1/1")]
    public class Route
    {
        #region Variables
        private string nameField;

        private string cmtField;

        private string descField;

        private string srcField;

        //private linkType[] linkField;
        private List<Link> linkField;

        private string numberField;

        private string typeField;

        private Extensions extensionsField;

        //private WayPoint[] rteptField;
        private List<WayPoint> rteptField;
        #endregion Variables

        /// <summary>
        /// GPS name of route.
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
        /// GPS comment for route.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("cmt")]
        public string Comment
        {
            get
            {
                return this.cmtField;
            }
            set
            {
                this.cmtField = value;
            }
        }

        /// <summary>
        /// Text description of route for user. Not sent to GPS.
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
        /// Source of data. Included to give user some idea of reliability and accuracy of data.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("src")]
        public string src
        {
            get
            {
                return this.srcField;
            }
            set
            {
                this.srcField = value;
            }
        }

        /// <summary>
        /// Links to external information about the route.
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
        /// GPS route number.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "number", DataType = "nonNegativeInteger")]
        public string Number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <summary>
        /// Type (classification) of route.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("type")]
        public string Classification
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

        /// <summary>
        /// A list of route points.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("rtept")]
        public List<WayPoint> rtept
        {
            get
            {
                return this.rteptField;
            }
            set
            {
                this.rteptField = value;
            }
        }

    }
}
