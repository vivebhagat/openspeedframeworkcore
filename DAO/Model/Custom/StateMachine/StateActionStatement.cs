﻿using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Model.Custom.Communication;
using SpeedFramework.DAO.Model.Custom.Entity;
using System;

namespace SpeedFramework.DAO.Model.Custom.StateMachine
{
    public class StateActionStatement : IActivableEntity
    {
        public int Id { get; set; }
        public virtual StateAction StateAction { get; set; }
        public int? StateActionId { get; set; }
        public bool Inactive { get; set; }

        public virtual ApplicationEntityProperty ApplicationEntityProperty { get; set; }
        public int ApplicationEntityPropertyId { get; set; }

        public string currentValue { get; set; }
        public string nextValue { get; set; }

        public virtual UserDefinedRole UserDefinedRole { get; set; }
        public int? UserDefinedRoleId { get; set; }

        public virtual CommunicationTemplate CommunicationTemplate { get; set; }
        public int? CommunicationTemplateId { get; set; }
        public string ApplicationNumber { get; set; }
        public string LegacyNumber { get; set; }
        public virtual IntUser CreatedBy { get; set; }
        public int? CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual  IntUser ModifiedBy { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual IntUser ArchieveBy { get; set; }
        public int? ArchieveById { get; set; }
        public DateTime? ArchieveDate { get; set; }
    }

}
