using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class BroadcastedSessionTypeConfiguration : IEntityTypeConfiguration<BroadcastedSessionType>
	{
		public void Configure(EntityTypeBuilder<BroadcastedSessionType> builder)
		{
			builder
				.HasIndex(e => e.Name)
				.IsUnique();
		}
	}
}
