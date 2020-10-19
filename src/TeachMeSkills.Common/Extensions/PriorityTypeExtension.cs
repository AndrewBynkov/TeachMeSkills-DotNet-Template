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

        /// <summary>
        /// Convert int to PriorityType.
        /// </summary>
        /// <param name="priorityType">Priority type (int).</param>
        /// <returns>PriorityType value.</returns>
        public static PriorityType ToPriorityType(int priorityType)
        {
            return priorityType switch
            {
                (int)PriorityType.Low => PriorityType.Low,
                (int)PriorityType.Medium => PriorityType.Medium,
                (int)PriorityType.High => PriorityType.High,
                _ => PriorityType.Unknown,
            };
        }

        /// <summary>
        /// Validate PriorityType to CSS style.
        /// </summary>
        /// <param name="priorityType">Priority type (enum).</param>
        /// <returns>CSS style.</returns>
        public static string ValidatePriorityType(this PriorityType priorityType)
        {
            return priorityType switch
            {
                PriorityType.Low => string.Empty,
                PriorityType.Medium => "todo__medium",
                PriorityType.High => "todo__high",
                _ => string.Empty,
            };
        }
    }
}
