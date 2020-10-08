using TeachMeSkills.Common.Enums;

namespace TeachMeSkills.Common.Extensions
{
    /// <summary>
    /// Priority type extensions.
    /// </summary>
    public static class PriorityTypeExtension
    {
        /// <summary>
        /// Convert value to string.
        /// </summary>
        /// <param name="priorityType">Priority type (number).</param>
        /// <returns>String value.</returns>
        public static string ToLocal(int priorityType)
        {
            return priorityType switch
            {
                (int)PriorityType.Low => "Low",
                (int)PriorityType.Medium => "Medium",
                (int)PriorityType.High => "High",
                _ => "Unknown",
            };
        }
    }
}
