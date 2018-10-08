using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<TimeSpan> HasTimeConversions(this PropertyBuilder<TimeSpan> builder)
    {
        return builder.HasConversion(
            v => v.TotalMilliseconds,
            v => TimeSpan.FromMilliseconds(v * 1000)
        );
    }
}