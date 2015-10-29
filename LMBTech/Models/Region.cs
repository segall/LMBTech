// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Region.cs" company="LBM Tech">
//   
// </copyright>
// <summary>
//   The Region.cs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace LMBTech.Models
{
    #region includes

    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    #endregion

    /// <summary>The region.</summary>
    public class Region
    {
        #region Public Properties

        /// <summary>Gets or sets the country.</summary>
        [JsonIgnore]
        public virtual Country Country { get; set; }

        /// <summary>Gets or sets the country id.</summary>
        public int CountryId { get; set; }

        /// <summary>Gets or sets the id.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        [MaxLength(50)]
        public string Name { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>The to string.</summary>
        /// <returns>The <see cref="string" />.</returns>
        public override string ToString()
        {
            return this.Name;
        }

        #endregion
    }
}