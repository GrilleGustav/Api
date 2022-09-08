
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PvSystemPlugin.Entities.Models.Pv;

namespace PvSystemPlugin.Entities.Configuration.Pv
{
  /// <summary>
  /// Class to configure pvComments entity.
  /// </summary>
  public class PvCommentsConfiguration : IEntityTypeConfiguration<PvComments>
  {
    public void Configure(EntityTypeBuilder<PvComments> builder)
    {
      builder.ToTable("Pv_" + nameof(PvComments));

      builder.HasKey(x => x.Id);

      builder.Property(x => x.ConcurrencyStamp).IsRowVersion().IsRowVersion().ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.UpdatedOn).ValueGeneratedOnAddOrUpdate();

      builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd();
    }
  }
}
