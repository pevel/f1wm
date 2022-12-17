using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace F1WM.DatabaseModel.Context
{
	public class EntryConfiguration : IEntityTypeConfiguration<Entry>
	{
		public void Configure(EntityTypeBuilder<Entry> builder)
		{
			builder.HasKey(e => e.Id);

			builder.ToTable("f1entries");

			builder.HasIndex(e => e.CarId)
				.HasDatabaseName("carid");

			builder.HasIndex(e => e.CarMakeId)
				.HasDatabaseName("carmakeid");

			builder.HasIndex(e => e.DriverId)
				.HasDatabaseName("driverid");

			builder.HasIndex(e => e.EngineId)
				.HasDatabaseName("engineid");

			builder.HasIndex(e => e.EngineMakeId)
				.HasDatabaseName("enginemakeid");

			builder.HasIndex(e => e.RaceId)
				.HasDatabaseName("raceid");

			builder.HasIndex(e => e.TeamId)
				.HasDatabaseName("teamid");

			builder.HasIndex(e => e.TyresId)
				.HasDatabaseName("tyresid");

			builder.Property(e => e.Id)
				.HasColumnName("entryid")
				.HasColumnType("mediumint unsigned");

			builder.Property(e => e.CarId)
				.HasColumnName("carid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.CarMakeId)
				.HasColumnName("carmakeid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.DriverId)
				.HasColumnName("driverid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.EngineId)
				.HasColumnName("engineid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.EngineMakeId)
				.HasColumnName("enginemakeid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.Number)
				.HasColumnName("number")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.RaceId)
				.HasColumnName("raceid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.TeamId)
				.HasColumnName("teamid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.TeamNameId)
				.HasColumnName("teamnameid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.Property(e => e.IsThirdDriver)
				.HasColumnName("thirddriver");

			builder.Property(e => e.TyresId)
				.HasColumnName("tyresid")
				.HasColumnType("mediumint unsigned")
				.HasDefaultValueSql("'0'");

			builder.HasOne(e => e.Driver)
				.WithMany(d => d.Entries)
				.HasForeignKey(e => e.DriverId)
				.HasPrincipalKey(d => d.Id);

			builder.HasOne(e => e.Race)
				.WithMany(r => r.Entries)
				.HasForeignKey(e => e.RaceId)
				.HasPrincipalKey(r => r.Id);

			builder.HasOne(e => e.Car)
				.WithMany(c => c.Entries)
				.HasForeignKey(e => e.CarId)
				.HasPrincipalKey(c => c.Id);

			builder.HasOne(e => e.Tyres)
				.WithMany(t => t.Entries)
				.HasForeignKey(e => e.TyresId)
				.HasPrincipalKey(t => t.Id);
		}
	}
}
