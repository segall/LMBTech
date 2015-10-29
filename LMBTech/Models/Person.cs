// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="LBM Tech">
//   
// </copyright>
// <summary>
//   The Person.cs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace LMBTech.Models
{
    #region includes

    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    #endregion

    /// <summary>The person.</summary>
    public class Person
    {
        #region Public Properties

        /// <summary>Gets or sets the id.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        [MaxLength(50)]
        [Required(ErrorMessage = "A Name is required")]
        public string Name { get; set; }

        /// <summary>Gets or sets the Surname.</summary>
        [MaxLength(50)]
        public string Surname { get; set; }

        /// <summary>Gets or sets the Age.</summary>
        [Required(ErrorMessage = "Age is required")]
        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]
        public int Age { get; set; }

        /// <summary>Gets or sets the country.</summary>
        public virtual Country Country { get; set; }

        /// <summary>Gets or sets the region.</summary>
        public virtual Region Region { get; set; }

        /// <summary>Gets or sets the region id.</summary>
        public int RegionId { get; set; }
        #endregion
    }
}