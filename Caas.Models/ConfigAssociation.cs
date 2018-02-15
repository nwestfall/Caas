﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Caas.Models
{
    /// <summary>
    /// Model for the association between <see cref="Config"/> and <see cref="Client"/>
    /// </summary>
    public class ConfigAssociation
    {
        /// <summary>
        /// Get or set the <see cref="ConfigAssociation"/> id
        /// </summary>
        [Key]
        public int ConfigAssociationId { get; set; }
        private Config _config;
        /// <summary>
        /// Get or set the <see cref="Models.Config"/>
        /// </summary>
        public virtual Config Config
        {
            get => _config;
            set
            {
                _config = value;
                _configId = _config?.ConfigId ?? 0;
            }
        }
        private int _configId;
        /// <summary>
        /// Get or set the <see cref="Config.ConfigId"/>
        /// </summary>
        [Required]
        public int ConfigId
        {
            get => _configId;
            set
            {
                _configId = value;
                if (_configId != _config.ConfigId)
                    _config = null;
            }
        }
        private Client _client;
        /// <summary>
        /// Get or set the <see cref="Models.Client"/>
        /// </summary>
        public virtual Client Client
        {
            get => _client;
            set
            {
                _client = value;
                _clientId = _client?.ClientId ?? 0;
            }
        }
        private int _clientId;
        /// <summary>
        /// Get or set the <see cref="Config.ConfigId"/>
        /// </summary>
        [Required]
        public int ClientId
        {
            get => _clientId;
            set
            {
                _clientId = value;
                if (_clientId != _client.ClientId)
                    _client = null;
            }
        }
        /// <summary>
        /// Get or set when <see cref="ConfigAssociation"/> was created
        /// </summary>
        [Required]
        public DateTime Created { get; set; }
    }
}
