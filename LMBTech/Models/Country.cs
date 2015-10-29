// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Country.cs" company="LBM Tech">
//   
// </copyright>
// <summary>
//   The Country.cs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace LMBTech.Models
{
    #region includes

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    #endregion

    /// <summary>The country.</summary>
    public class Country
    {
        #region Public Properties

        /// <summary>Gets or sets the id.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>Gets or sets the regions.</summary>
        public virtual ICollection<Region> Regions { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>The to string.</summary>
        /// <returns>The <see cref="string" />.</returns>
        public override string ToString()
        {
            return string.Format("{0}: {1}", this.Name, string.Join(", ", this.Regions));
        }

        #endregion
    }
}