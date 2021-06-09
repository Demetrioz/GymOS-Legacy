using FluentMigrator;

namespace GymOS.Migrations
{
    [Migration(0001)]
    public class Release0001 : Migration
    {
        public override void Up()
        {
            // ************************************
            //          Identity Tables
            // ************************************

            Create.Table("AspNetRoles")
                .WithColumn("Id").AsString(450).NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(256).Nullable()
                .WithColumn("NormalizedName").AsString(256).Nullable()
                .WithColumn("ConcurrencyStamp").AsString(int.MaxValue).Nullable();

            Create.Table("AspNetUsers")
                .WithColumn("Id").AsString(450).NotNullable().PrimaryKey()
                .WithColumn("UserName").AsString(256).Nullable()
                .WithColumn("NormalizedUserName").AsString(256).Nullable()
                .WithColumn("Email").AsString(256).Nullable()
                .WithColumn("NormalizedEmail").AsString(256).Nullable()
                .WithColumn("EmailConfirmed").AsBoolean().NotNullable()
                .WithColumn("PasswordHash").AsString(int.MaxValue).Nullable()
                .WithColumn("SecurityStamp").AsString(int.MaxValue).Nullable()
                .WithColumn("ConcurrencyStamp").AsString(int.MaxValue).Nullable()
                .WithColumn("PhoneNumber").AsString(int.MaxValue).Nullable()
                .WithColumn("PhoneNumberConfirmed").AsBoolean().NotNullable()
                .WithColumn("TwoFactorEnabled").AsBoolean().NotNullable()
                .WithColumn("LockoutEnd").AsDateTimeOffset().Nullable()
                .WithColumn("LockoutEnabled").AsBoolean().NotNullable()
                .WithColumn("AccessFailedCount").AsInt32().NotNullable()
                .WithColumn("Address").AsString(int.MaxValue).Nullable()
                .WithColumn("City").AsString(int.MaxValue).Nullable()
                .WithColumn("State").AsString(40).Nullable()
                .WithColumn("ZipCode").AsString(40).Nullable()
                .WithColumn("BirthDate").AsDateTimeOffset().Nullable();

            Create.Table("DeviceCodes")
                .WithColumn("UserCode").AsString(200).NotNullable().PrimaryKey()
                .WithColumn("DeviceCode").AsString(200).NotNullable()
                .WithColumn("SubjectId").AsString(200).Nullable()
                .WithColumn("SessionId").AsString(200).Nullable()
                .WithColumn("ClientId").AsString(200).NotNullable()
                .WithColumn("Description").AsString(200).Nullable()
                .WithColumn("CreationTime").AsDateTime2().NotNullable()
                .WithColumn("Expiration").AsDateTime2().NotNullable()
                .WithColumn("Data").AsString(int.MaxValue).NotNullable();

            Create.Table("PersistedGrants")
                .WithColumn("Key").AsString(200).NotNullable().PrimaryKey()
                .WithColumn("Type").AsString(50).NotNullable()
                .WithColumn("SubjectId").AsString(200).Nullable()
                .WithColumn("SessionId").AsString(100).Nullable()
                .WithColumn("ClientId").AsString(200).NotNullable()
                .WithColumn("Description").AsString(200).Nullable()
                .WithColumn("CreationTime").AsDateTime2().NotNullable()
                .WithColumn("Expiration").AsDateTime2().Nullable()
                .WithColumn("ConsumedTime").AsDateTime2().Nullable()
                .WithColumn("Data").AsString(int.MaxValue).NotNullable();

            Create.Table("AspNetRoleClaims")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("RoleId").AsString(450).NotNullable()
                .WithColumn("ClaimType").AsString(int.MaxValue).Nullable()
                .WithColumn("ClaimValue").AsString(int.MaxValue).Nullable();

            Create.ForeignKey()
                .FromTable("AspNetRoleClaims").ForeignColumn("RoleId")
                .ToTable("AspNetRoles").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);

            Create.Table("AspNetUserClaims")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserId").AsString(450).NotNullable()
                .WithColumn("ClaimType").AsString(int.MaxValue).Nullable()
                .WithColumn("ClaimValue").AsString(int.MaxValue).Nullable();

            Create.ForeignKey()
                .FromTable("AspNetUserClaims").ForeignColumn("UserId")
                .ToTable("AspNetUsers").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);

            Create.Table("AspNetUserLogins")
                .WithColumn("LoginProvider").AsString(128).NotNullable().PrimaryKey()
                .WithColumn("ProviderKey").AsString(128).NotNullable().PrimaryKey()
                .WithColumn("ProviderDisplayName").AsString(int.MaxValue).Nullable()
                .WithColumn("UserId").AsString(450).NotNullable();

            Create.ForeignKey()
                .FromTable("AspNetUserLogins").ForeignColumn("UserId")
                .ToTable("AspNetUsers").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);

            Create.Table("AspNetUserRoles")
                .WithColumn("UserId").AsString(450).NotNullable().PrimaryKey()
                .WithColumn("RoleId").AsString(450).NotNullable().PrimaryKey();

            Create.ForeignKey()
                .FromTable("AspNetUserRoles").ForeignColumn("RoleId")
                .ToTable("AspNetRoles").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);

            Create.ForeignKey()
                .FromTable("AspNetUserRoles").ForeignColumn("UserId")
                .ToTable("AspNetUsers").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);

            Create.Table("AspNetUserTokens")
                .WithColumn("UserId").AsString(450).NotNullable().PrimaryKey()
                .WithColumn("LoginProvider").AsString(128).NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(128).NotNullable().PrimaryKey()
                .WithColumn("Value").AsString(int.MaxValue).Nullable();

            Create.ForeignKey()
                .FromTable("AspNetUserTokens").ForeignColumn("UserId")
                .ToTable("AspNetUsers").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);

            Create.Index("IX_AspNetRoleClaims_RoleId")
                .OnTable("AspNetRoleClaims")
                .OnColumn("RoleId");

            Create.Index("RoleNameIndex")
                .OnTable("AspNetRoles")
                .OnColumn("NormalizedName")
                .Unique();

            Create.Index("IX_AspNetUserClaims_UserId")
                .OnTable("AspNetUserClaims")
                .OnColumn("UserId");

            Create.Index("IX_AspNetUserLogins_UserId")
                .OnTable("AspNetUserLogins")
                .OnColumn("UserId");

            Create.Index("IX_AspNetUserRoles_RoleId")
                .OnTable("AspNetUserRoles")
                .OnColumn("RoleId");

            Create.Index("EmailIndex")
                .OnTable("AspNetUsers")
                .OnColumn("NormalizedEmail");

            Create.Index("UserNameIndex")
                .OnTable("AspNetUsers")
                .OnColumn("NormalizedUserName")
                .Unique();

            Create.Index("IX_DeviceCodes_DeviceCode")
                .OnTable("DeviceCodes")
                .OnColumn("DeviceCode")
                .Unique();

            Create.Index("IX_DeviceCodes_Expiration")
                .OnTable("DeviceCodes")
                .OnColumn("Expiration");

            Create.Index("IX_PersistedGrants_Expiration")
                .OnTable("PersistedGrants")
                .OnColumn("Expiration");

            Create.Index("IX_PersistedGrants_SubjectId_ClientId_Type")
                .OnTable("PersistedGrants")
                .OnColumn("SubjectId").Ascending()
                .OnColumn("ClientId").Ascending()
                .OnColumn("Type");

            Create.Index("IX_PersistedGrants_SubjectId_SessionId_Type")
                .OnTable("PersistedGrants")
                .OnColumn("SubjectId").Ascending()
                .OnColumn("SessionId").Ascending()
                .OnColumn("Type");
        }

        public override void Down()
        {
            // ************************************
            //          Identity Tables
            // ************************************

            Delete.Table("AspNetRoleClaims");
            Delete.Table("AspNetUserClaims");
            Delete.Table("AspNetUserLogins");
            Delete.Table("AspNetUserRoles");
            Delete.Table("AspNetUserTokens");
            Delete.Table("AspNetRoles");
            Delete.Table("AspNetUsers");
            Delete.Table("DeviceCodes");
            Delete.Table("PersistedGrants");
        }
    }
}
