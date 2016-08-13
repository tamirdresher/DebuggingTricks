using System;
using System.Collections.Generic;

namespace OzCodeDemo.ProjectManagment
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Projects
    {

        private Project[] _projectsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Project")]
        public Project[] Project
        {
            get
            {
                return this._projectsField;
            }
            set
            {
                this._projectsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class Project
    {

        private byte idField;

        private string departmentField;

        private byte managerField;

        private string statusField;

        private ushort remainingEffortField;

        /// <remarks/>
        public byte Id
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

        /// <remarks/>
        public string Department
        {
            get
            {
                return this.departmentField;
            }
            set
            {
                this.departmentField = value;
            }
        }

        /// <remarks/>
        public byte Manager
        {
            get
            {
                return this.managerField;
            }
            set
            {
                this.managerField = value;
            }
        }

        /// <remarks/>
        public string Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        public ushort RemainingEffort
        {
            get
            {
                return this.remainingEffortField;
            }
            set
            {
                this.remainingEffortField = value;
            }
        }
    }


}
