using TeachMeSkills.Common.Enums;

namespace TeachMeSkills.Common.Extensions
{
    /// <summary>
    /// Priority type extensions.
    /// </summary>
    public static class PriorityTypeExtension
    {
        /// <summary>
        /// Convert enum to string.
        /// </summary>
        /// <param name="priorityType">Priority type (enum).</param>
        /// <returns>String value.</returns>
        public static string ToLocal(this PriorityType priorityType)
        {
            return priorityType switch
            {
                PriorityType.Low => "Low",
                PriorityType.Medium => "Medium",
                PriorityType.High => "High",
                _ => "Unknown",
            };
        }
    }
}
