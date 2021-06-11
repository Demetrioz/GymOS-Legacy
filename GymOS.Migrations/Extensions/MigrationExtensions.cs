using FluentMigrator.Builders.Create.Table;

namespace GymOS.Migrations.Extensions
{
    public static class MigrationExtensions
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax WithId(
            this ICreateTableWithColumnSyntax table,
            string columnName
        )
        {
            return table
                .WithColumn(columnName)
                .AsInt32()
                .NotNullable()
                .PrimaryKey()
                .Identity();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithBaseModel(
            this ICreateTableWithColumnSyntax table
        )
        {
            return table
                .WithColumn("Created").AsDateTimeOffset().NotNullable()
                .WithColumn("Modified").AsDateTimeOffset().Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable();
        }
    }
}
