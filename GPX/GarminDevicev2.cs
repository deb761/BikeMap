﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.832
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=2.0.50727.42.
// 
namespace GPX {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2")]
    [System.Xml.Serialization.XmlRootAttribute("Device", Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2", IsNullable=false)]
    public partial class Device_t {
        
        private Model_t modelField;
        
        private uint idField;
        
        private string registrationCodeField;
        
        private UnlockCode_t[] unlockField;
        
        private string displayNameField;
        
        private MassStorageMode_t massStorageModeField;
        
        private GarminMode_t garminModeField;
        
        private Extensions_t extensionsField;
        
        /// <remarks/>
        public Model_t Model {
            get {
                return this.modelField;
            }
            set {
                this.modelField = value;
            }
        }
        
        /// <remarks/>
        public uint Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="token")]
        public string RegistrationCode {
            get {
                return this.registrationCodeField;
            }
            set {
                this.registrationCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Unlock")]
        public UnlockCode_t[] Unlock {
            get {
                return this.unlockField;
            }
            set {
                this.unlockField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="token")]
        public string DisplayName {
            get {
                return this.displayNameField;
            }
            set {
                this.displayNameField = value;
            }
        }
        
        /// <remarks/>
        public MassStorageMode_t MassStorageMode {
            get {
                return this.massStorageModeField;
            }
            set {
                this.massStorageModeField = value;
            }
        }
        
        /// <remarks/>
        public GarminMode_t GarminMode {
            get {
                return this.garminModeField;
            }
            set {
                this.garminModeField = value;
            }
        }
        
        /// <remarks/>
        public Extensions_t Extensions {
            get {
                return this.extensionsField;
            }
            set {
                this.extensionsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2")]
    public partial class Model_t {
        
        private string partNumberField;
        
        private ushort softwareVersionField;
        
        private string descriptionField;
        
        private Extensions_t extensionsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="token")]
        public string PartNumber {
            get {
                return this.partNumberField;
            }
            set {
                this.partNumberField = value;
            }
        }
        
        /// <remarks/>
        public ushort SoftwareVersion {
            get {
                return this.softwareVersionField;
            }
            set {
                this.softwareVersionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="token")]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public Extensions_t Extensions {
            get {
                return this.extensionsField;
            }
            set {
                this.extensionsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2")]
    public partial class Extensions_t {
        
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2")]
    public partial class MemoryRegion_t {
        
        private byte idField;
        
        private Version_t versionField;
        
        private string descriptionField;
        
        private string partNumberField;
        
        private bool isErasedField;
        
        private bool isErasedFieldSpecified;
        
        private bool isRemovedField;
        
        private bool isRemovedFieldSpecified;
        
        private bool isUserUpdateableField;
        
        private bool isUserUpdateableFieldSpecified;
        
        private Extensions_t extensionsField;
        
        /// <remarks/>
        public byte Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public Version_t Version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="token")]
        public string PartNumber {
            get {
                return this.partNumberField;
            }
            set {
                this.partNumberField = value;
            }
        }
        
        /// <remarks/>
        public bool IsErased {
            get {
                return this.isErasedField;
            }
            set {
                this.isErasedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsErasedSpecified {
            get {
                return this.isErasedFieldSpecified;
            }
            set {
                this.isErasedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public bool IsRemoved {
            get {
                return this.isRemovedField;
            }
            set {
                this.isRemovedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsRemovedSpecified {
            get {
                return this.isRemovedFieldSpecified;
            }
            set {
                this.isRemovedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public bool IsUserUpdateable {
            get {
                return this.isUserUpdateableField;
            }
            set {
                this.isUserUpdateableField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsUserUpdateableSpecified {
            get {
                return this.isUserUpdateableFieldSpecified;
            }
            set {
                this.isUserUpdateableFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public Extensions_t Extensions {
            get {
                return this.extensionsField;
            }
            set {
                this.extensionsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2")]
    public partial class Version_t {
        
        private ushort majorField;
        
        private ushort minorField;
        
        /// <remarks/>
        public ushort Major {
            get {
                return this.majorField;
            }
            set {
                this.majorField = value;
            }
        }
        
        /// <remarks/>
        public ushort Minor {
            get {
                return this.minorField;
            }
            set {
                this.minorField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2")]
    public partial class AppProtocol_t {
        
        private ushort[] dataTypeField;
        
        private ushort idField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DataType")]
        public ushort[] DataType {
            get {
                return this.dataTypeField;
            }
            set {
                this.dataTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2")]
    public partial class Protocol_t {
        
        private ushort idField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2")]
    public partial class Protocols_t {
        
        private Protocol_t linkField;
        
        private AppProtocol_t[] applicationField;
        
        private Protocol_t transportField;
        
        /// <remarks/>
        public Protocol_t Link {
            get {
                return this.linkField;
            }
            set {
                this.linkField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Application")]
        public AppProtocol_t[] Application {
            get {
                return this.applicationField;
            }
            set {
                this.applicationField = value;
            }
        }
        
        /// <remarks/>
        public Protocol_t Transport {
            get {
                return this.transportField;
            }
            set {
                this.transportField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2")]
    public partial class GarminMode_t {
        
        private Protocols_t protocolsField;
        
        private MemoryRegion_t[] memoryRegionField;
        
        private Extensions_t extensionsField;
        
        /// <remarks/>
        public Protocols_t Protocols {
            get {
                return this.protocolsField;
            }
            set {
                this.protocolsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MemoryRegion")]
        public MemoryRegion_t[] MemoryRegion {
            get {
                return this.memoryRegionField;
            }
            set {
                this.memoryRegionField = value;
            }
        }
        
        /// <remarks/>
        public Extensions_t Extensions {
            get {
                return this.extensionsField;
            }
            set {
                this.extensionsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2")]
    public partial class UpdateFile_t {
        
        private string partNumberField;
        
        private Version_t versionField;
        
        private string descriptionField;
        
        private string pathField;
        
        private string fileNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="token")]
        public string PartNumber {
            get {
                return this.partNumberField;
            }
            set {
                this.partNumberField = value;
            }
        }
        
        /// <remarks/>
        public Version_t Version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
        public string Path {
            get {
                return this.pathField;
            }
            set {
                this.pathField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="token")]
        public string FileName {
            get {
                return this.fileNameField;
            }
            set {
                this.fileNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2")]
    public partial class Location_t {
        
        private string pathField;
        
        private string baseNameField;
        
        private string fileExtensionField;
        
        private Extensions_t extensionsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
        public string Path {
            get {
                return this.pathField;
            }
            set {
                this.pathField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="token")]
        public string BaseName {
            get {
                return this.baseNameField;
            }
            set {
                this.baseNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="token")]
        public string FileExtension {
            get {
                return this.fileExtensionField;
            }
            set {
                this.fileExtensionField = value;
            }
        }
        
        /// <remarks/>
        public Extensions_t Extensions {
            get {
                return this.extensionsField;
            }
            set {
                this.extensionsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2")]
    public partial class Specification_t {
        
        private string identifierField;
        
        private string documentationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="token")]
        public string Identifier {
            get {
                return this.identifierField;
            }
            set {
                this.identifierField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
        public string Documentation {
            get {
                return this.documentationField;
            }
            set {
                this.documentationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2")]
    public partial class File_t {
        
        private Specification_t specificationField;
        
        private Location_t locationField;
        
        private TransferDirection_t transferDirectionField;
        
        /// <remarks/>
        public Specification_t Specification {
            get {
                return this.specificationField;
            }
            set {
                this.specificationField = value;
            }
        }
        
        /// <remarks/>
        public Location_t Location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
            }
        }
        
        /// <remarks/>
        public TransferDirection_t TransferDirection {
            get {
                return this.transferDirectionField;
            }
            set {
                this.transferDirectionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2")]
    public enum TransferDirection_t {
        
        /// <remarks/>
        InputOutput,
        
        /// <remarks/>
        InputToUnit,
        
        /// <remarks/>
        OutputFromUnit,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2")]
    public partial class DataType_t {
        
        private string nameField;
        
        private File_t[] fileField;
        
        private Extensions_t extensionsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="token")]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("File")]
        public File_t[] File {
            get {
                return this.fileField;
            }
            set {
                this.fileField = value;
            }
        }
        
        /// <remarks/>
        public Extensions_t Extensions {
            get {
                return this.extensionsField;
            }
            set {
                this.extensionsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2")]
    public partial class MassStorageMode_t {
        
        private DataType_t[] dataTypeField;
        
        private UpdateFile_t[] updateFileField;
        
        private Extensions_t extensionsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DataType")]
        public DataType_t[] DataType {
            get {
                return this.dataTypeField;
            }
            set {
                this.dataTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UpdateFile")]
        public UpdateFile_t[] UpdateFile {
            get {
                return this.updateFileField;
            }
            set {
                this.updateFileField = value;
            }
        }
        
        /// <remarks/>
        public Extensions_t Extensions {
            get {
                return this.extensionsField;
            }
            set {
                this.extensionsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.garmin.com/xmlschemas/GarminDevice/v2")]
    public partial class UnlockCode_t {
        
        private string codeField;
        
        private string commentField;
        
        /// <remarks/>
        public string Code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }
        
        /// <remarks/>
        public string Comment {
            get {
                return this.commentField;
            }
            set {
                this.commentField = value;
            }
        }
    }
}
