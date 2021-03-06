﻿using System;
#if NETCOREAPP2_0
using System.ComponentModel.DataAnnotations;
#endif

namespace Caas.Models
{
    /// <summary>
    /// Model for client configurations
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Get or set the Id
        /// </summary>
#if NETCOREAPP2_0
        [Key]
#endif
        public int ClientId { get; set; }
        /// <summary>
        /// Get or set the <see cref="Client"/> identifier
        /// </summary>
#if NETCOREAPP2_0
        [Required]
#endif
        public string Identifier { get; set; }
        private ClientType _clientType;
        /// <summary>
        /// Get or set the <see cref="ClientType" />
        /// </summary>
        public virtual ClientType ClientType
        {
            get => _clientType;
            set
            {
                _clientType = value;
                _clientTypeId = _clientType?.ClientTypeId ?? 0;
            }
        }
        private int _clientTypeId;
        /// <summary>
        /// Get or set the <see cref="ClientType.ClientTypeId"/>
        /// </summary>
        public int ClientTypeId
        {
            get => _clientTypeId;
            set
            {
                _clientTypeId = value;
                if (_clientType != null && _clientTypeId != _clientType.ClientTypeId)
                    _clientType = null;
            }
        }
        /// <summary>
        /// Get or set when the <see cref="Client"/> was created
        /// </summary>
#if NETCOREAPP2_0
        [Required]
#endif
        public DateTime Created { get; set; }
        /// <summary>
        /// Get or set when the <see cref="Client"/> was updated
        /// </summary>
        public DateTime? Updated { get; set; }
        private Client _parent;
        /// <summary>
        /// Get or set the parent <see cref="Client"/> if applicable
        /// </summary>
        public virtual Client Parent
        {
            get => _parent;
            set
            {
                _parent = value;
                _parentClientId = _parent?.ClientId;
            }
        }
        private int? _parentClientId;
        /// <summary>
        /// Get or set the parent <see cref="Client.ClientId"/> if applicable
        /// </summary>
        public int? ParentClientId
        {
            get => _parentClientId;
            set
            {
                _parentClientId = value;
                if (_parent != null && _parentClientId != _parent.ClientId)
                    _parent = null;
            }
        }
        /// <summary>
        /// Get or set if this top level <see cref="Client"/>
        /// </summary>
        public bool HasParent => _parentClientId.HasValue;
    }
}
