using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace NotesCore.Models.Context.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Notes")
                .HasKey(x => x.Id);

            builder.Property(x => x.Author)
                .HasColumnName("Author")
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            builder.Property(x => x.Text)
                .HasColumnName("Text")
                .HasColumnType("nvarchar")
                .HasMaxLength(1000);

            builder.Property(x => x.CreatedDate)
                .HasColumnName("CreatedDate");

            builder.OwnsOne(x => x.LifeTime)
                .Property(x => x.Count)
                .HasColumnName("Count")
                .HasColumnType("int");

            builder.OwnsOne(x => x.LifeTime)
                .Property(x => x.DeletingDate)
                .HasColumnName("DeletingDate");           
        }
    }
}
