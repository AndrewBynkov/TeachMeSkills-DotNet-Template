using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using TeachMeSkills.Common.Constants;
using TeachMeSkills.Common.Enums;
using TeachMeSkills.DataAccessLayer.Entities;

namespace TeachMeSkills.DataAccessLayer.Configurations
{
    /// <summary>
    /// EF Configuration for Todo entity.
    /// </summary>
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(TableConstants.Todos, SchemaConstants.Todo)
                .HasKey(todo => todo.Id);

            builder.Property(todo => todo.Title)
                .IsRequired()
                .HasMaxLength(ConfigurationContants.SqlMaxLengthMedium);

            builder.Property(todo => todo.Description)
                .HasMaxLength(ConfigurationContants.SqlMaxLengthLong);

            builder.Property(todo => todo.PriorityType)
                .HasConversion(new EnumToNumberConverter<PriorityType, int>());

            builder.HasOne(todo => todo.User)
                .WithMany(user => user.Todos)
                .HasForeignKey(todo => todo.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
