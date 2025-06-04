using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrganistsSchedule.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COUNTRIES",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUNTRIES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CITIES",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(90)", maxLength: 90, nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITIES", x => x.Id);
                    table.UniqueConstraint("AK_CITIES_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_CITIES_COUNTRIES_CountryId",
                        column: x => x.CountryId,
                        principalTable: "COUNTRIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CEPS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ZipCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    District = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    State = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEPS", x => x.Id);
                    table.UniqueConstraint("AK_CEPS_ZipCode", x => x.ZipCode);
                    table.ForeignKey(
                        name: "FK_CEPS_CITIES_CityId",
                        column: x => x.CityId,
                        principalTable: "CITIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ADDRESS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CepId = table.Column<long>(type: "bigint", nullable: false),
                    StreetNumber = table.Column<long>(type: "bigint", nullable: false),
                    Complement = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ADDRESS_CEPS_CepId",
                        column: x => x.CepId,
                        principalTable: "CEPS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CONGREGATIONS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    RelatorioBrasCode = table.Column<string>(type: "text", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    DaysOfService = table.Column<int[]>(type: "integer[]", nullable: false),
                    HasYouthMeetings = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONGREGATIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CONGREGATIONS_ADDRESS_AddressId",
                        column: x => x.AddressId,
                        principalTable: "ADDRESS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORGANISTS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    PhoneId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORGANISTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORGANISTS_ADDRESS_AddressId",
                        column: x => x.AddressId,
                        principalTable: "ADDRESS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PARAMETERS_SCHEDULE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CongregationId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARAMETERS_SCHEDULE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PARAMETERS_SCHEDULE_CONGREGATIONS_CongregationId",
                        column: x => x.CongregationId,
                        principalTable: "CONGREGATIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CONGREGATION_ORGANISTS",
                columns: table => new
                {
                    CongregationId = table.Column<long>(type: "bigint", nullable: false),
                    OrganistId = table.Column<long>(type: "bigint", nullable: false),
                    OrganistServiceDaysOfWeek = table.Column<int[]>(type: "integer[]", nullable: false),
                    Sequence = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONGREGATION_ORGANISTS", x => new { x.CongregationId, x.OrganistId });
                    table.ForeignKey(
                        name: "FK_CONGREGATION_ORGANISTS_CONGREGATIONS_CongregationId",
                        column: x => x.CongregationId,
                        principalTable: "CONGREGATIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CONGREGATION_ORGANISTS_ORGANISTS_OrganistId",
                        column: x => x.OrganistId,
                        principalTable: "ORGANISTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EMAILS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmailAddress = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IsPrimary = table.Column<bool>(type: "boolean", nullable: false),
                    OrganistId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMAILS", x => x.Id);
                    table.UniqueConstraint("AK_EMAILS_EmailAddress", x => x.EmailAddress);
                    table.ForeignKey(
                        name: "FK_EMAILS_ORGANISTS_OrganistId",
                        column: x => x.OrganistId,
                        principalTable: "ORGANISTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HOLY_SERVICES",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CongregationId = table.Column<long>(type: "bigint", nullable: false),
                    OrganistId = table.Column<long>(type: "bigint", nullable: false),
                    IsYouthMeeting = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOLY_SERVICES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HOLY_SERVICES_CONGREGATIONS_CongregationId",
                        column: x => x.CongregationId,
                        principalTable: "CONGREGATIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HOLY_SERVICES_ORGANISTS_OrganistId",
                        column: x => x.OrganistId,
                        principalTable: "ORGANISTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PHONES",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: false),
                    IsPrimary = table.Column<bool>(type: "boolean", nullable: false),
                    OrganistId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHONES", x => x.Id);
                    table.UniqueConstraint("AK_PHONES_Number", x => x.Number);
                    table.ForeignKey(
                        name: "FK_PHONES_ORGANISTS_OrganistId",
                        column: x => x.OrganistId,
                        principalTable: "ORGANISTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "COUNTRIES",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Brasil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L });

            migrationBuilder.InsertData(
                table: "ORGANISTS",
                columns: new[] { "Id", "AddressId", "CreatedAt", "CreatedBy", "FullName", "Level", "PhoneId", "ShortName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Alzenir da Silva Souza", 2, null, "Alzenir", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 2L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Jemima Oliveira Costa", 2, null, "Jemima", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 3L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Valdete Pereira Lima", 2, null, "Valdete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 4L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Joana Martins Souza", 2, null, "Joana", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 5L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Rosemari Alves Pinto", 2, null, "Rosemari", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 6L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Camila Souza Lima", 2, null, "Camila", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 7L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Priscila Andrade Melo", 2, null, "Priscila", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 8L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Joanita Silva Costa", 2, null, "Joanita", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 9L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Vanderleia Souza Lima", 2, null, "Vanderleia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 10L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Ana Paula Fernandes", 3, null, "Ana Paula", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 11L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Amanda Ribeiro Costa", 2, null, "Amanda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 12L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Hallen Martins Souza", 2, null, "Hallen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 13L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Solange Pereira Lima", 2, null, "Solange", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 14L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Dinorá Souza Pinto", 2, null, "Dinorá", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 15L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Rosangela Lima Costa", 2, null, "Rosangela", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 16L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Sarah Martins Souza", 2, null, "Sarah", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 17L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Luciana Pereira Lima", 2, null, "Luciana", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 18L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Manoela Souza Pinto", 1, null, "Manoela", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 19L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Kauany Martins Souza", 1, null, "Kauany", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 20L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Mônica Pereira Lima", 1, null, "Mônica", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L }
                });

            migrationBuilder.InsertData(
                table: "CITIES",
                columns: new[] { "Id", "CountryId", "CreatedAt", "CreatedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Joinville", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L });

            migrationBuilder.InsertData(
                table: "CEPS",
                columns: new[] { "Id", "CityId", "CreatedAt", "CreatedBy", "District", "State", "Street", "UpdatedAt", "UpdatedBy", "ZipCode" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Adhemar Garcia", "SC", "Rua Barra Santa Salete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89230792" },
                    { 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Fátima", "SC", "Rua Anêmonas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89229040" },
                    { 3L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Boa Vista", "SC", "Rua Erhard Wetzel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89205306" },
                    { 4L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Bom Retiro", "SC", "Rua Piratuba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89222365" },
                    { 5L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Canto do Rio", "SC", "Rua Volans", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89226730" },
                    { 6L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Comasa", "SC", "Servidão São Jerônimo Emiliane", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89224405" },
                    { 7L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Costa e Silva", "SC", "Rua Helena Degelmann", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89218580" },
                    { 8L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Cubatão", "SC", "Rua Nossa Senhora dos Anjos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89226820" },
                    { 9L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Distrito Pirabeiraba - Canela", "SC", "Rua Emílio Hardt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89239560" },
                    { 10L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Distrito Pirabeiraba - Centro", "SC", "Rua Joinville", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89239220" },
                    { 11L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Distrito Pirabeiraba - Rio Bonito", "SC", "Rua Theodoro Brietzig", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89239740" },
                    { 12L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Escolinha", "SC", "Rua Boehmerwald", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89232485" },
                    { 13L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Espinheiros", "SC", "Rua Bertoldo Berkembrock", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89228760" },
                    { 14L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Fátima", "SC", "Rua Fátima", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89210681" },
                    { 15L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Floresta", "SC", "Rua São Lourenço do Oeste", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89212115" },
                    { 16L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Iririú", "SC", "Rua Deputado Lauro Carneiro de Loyola", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89227250" },
                    { 17L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Jardim das Oliveiras", "SC", "Rua Paula Mayerle Wulf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89209268" },
                    { 18L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Jardim Edilene", "SC", "Avenida Aulo Abrahão Francisco", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89234173" },
                    { 19L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Jardim Iririú", "SC", "Avenida Odilon Rocha Ferreira", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89224424" },
                    { 20L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Jardim Paraíso", "SC", "Rua Canis Major", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89226618" },
                    { 21L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Jardim Sofia", "SC", "Rua Professor Eunaldo Verdi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89223620" },
                    { 22L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Jativoca", "SC", "Rua Santa Marta", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89214720" },
                    { 23L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Loteamento São Francisco II", "SC", "Rua Delphinus", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89226666" },
                    { 24L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Loteamento Tahiti", "SC", "Rua Adele Hille", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89233780" },
                    { 25L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Morro do Meio", "SC", "Estrada Lagoinha", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89215200" },
                    { 26L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Nova Brasília", "SC", "Rua Minas Gerais", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89213300" },
                    { 27L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Paranaguamirim", "SC", "Rua Esmirna", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89231740" },
                    { 28L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Parque Joinville", "SC", "Avenida Miguel Alves Castanha", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89225795" },
                    { 29L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Petrópolis", "SC", "Rua Bauru", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89208870" },
                    { 30L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Pinotti", "SC", "Rua Paranaguamirim", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89234100" },
                    { 31L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Pitaguaras", "SC", "Rua do Campo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89215110" },
                    { 32L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Profipo", "SC", "Rua Cidade de Sumidouro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89233240" },
                    { 33L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Santa Barbara", "SC", "Rua Dezoito de Janeiro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89225884" },
                    { 34L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Ulysses Guimarães", "SC", "Rua Professor Avelino Marcante", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89230650" },
                    { 35L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Vila Nova", "SC", "Rua Joaquim Girardi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89237110" },
                    { 36L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Vila Paraná", "SC", "Rua Carmem Miranda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89228250" },
                    { 37L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "Zona Industrial Norte", "SC", "Rua Ricardo Alberto Mebs", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, "89219655" }
                });

            migrationBuilder.InsertData(
                table: "ADDRESS",
                columns: new[] { "Id", "CepId", "Complement", "CreatedAt", "CreatedBy", "StreetNumber", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, 1L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 284L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 2L, 2L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 583L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 3L, 3L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 400L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 4L, 4L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 1549L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 5L, 5L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 44L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 6L, 6L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 76L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 7L, 7L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 340L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 8L, 8L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 97L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 9L, 9L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 75L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 10L, 10L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 13491L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 11L, 11L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 52L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 12L, 12L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 1123L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 13L, 13L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 14L, 14L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 678L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 15L, 15L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 112L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 16L, 16L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 806L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 17L, 17L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 352L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 18L, 18L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 201L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 19L, 19L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 452L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 20L, 20L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 70L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 21L, 21L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 337L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 22L, 22L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 140L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 23L, 23L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 1188L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 24L, 24L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 228L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 25L, 25L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 1445L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 26L, 26L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 1415L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 27L, 27L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 235L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 28L, 28L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 699L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 29L, 29L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 252L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 30L, 30L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 63L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 31L, 31L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 690L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 32L, 32L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 177L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 33L, 33L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 55L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 34L, 34L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 42L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 35L, 35L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 415L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 36L, 36L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 599L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 37L, 37L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, 74L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L }
                });

            migrationBuilder.InsertData(
                table: "CONGREGATIONS",
                columns: new[] { "Id", "AddressId", "CreatedAt", "CreatedBy", "DaysOfService", "HasYouthMeetings", "Name", "RelatorioBrasCode", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 5 }, true, "Adhemar Garcia", "BR200577", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 2L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 2 }, true, "Areião do Fátima", "BR200553", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 3L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 3, 2, 6 }, true, "Central - Boa Vista", "BR200029", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 4L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 5 }, true, "Bom Retiro", "BR200384", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 5L, 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 3, 6 }, true, "Canto do Rio", "BR200613", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 6L, 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 2, 6 }, true, "Comasa", "BR200669", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 7L, 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 3 }, true, "Costa e Silva", "BR200070", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 8L, 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 3, 6 }, true, "Cubatão", "BR200219", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 9L, 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 5 }, true, "Distrito Pirabeiraba - Canela", "BR200149", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 10L, 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 4 }, true, "Distrito Pirabeiraba - Centro", "BR200535", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 11L, 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 3, 6 }, true, "Distrito Pirabeiraba - Rio Bonito", "BR200583", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 12L, 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 3, 6 }, true, "Escolinha", "BR200109", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 13L, 13L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 3 }, true, "Espinheiros", "BR200274", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 14L, 14L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 3, 6 }, true, "Fátima", "BR200073", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 15L, 15L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 5 }, true, "Floresta", "BR200343", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 16L, 16L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 3, 6 }, true, "Iririú", "BR200058", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 17L, 17L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 3 }, true, "Jardim das Oliveiras", "BR200546", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 18L, 18L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 2, 6 }, true, "Jardim Edilene", "BR200547", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 19L, 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 3 }, true, "Jardim Iririú", "BR200554", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 20L, 20L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 5 }, true, "Jardim Paraíso", "BR200137", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 21L, 21L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 4 }, true, "Jardim Sofia", "BR200582", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 22L, 22L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 4 }, true, "Jativoca", "BR200242", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 23L, 23L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 3, 6 }, true, "Loteamento São Francisco II", "BR200587", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 24L, 24L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 2 }, true, "Loteamento Tahiti", "BR200575", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 25L, 25L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 3 }, true, "Morro do Meio", "BR200110", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 26L, 26L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 1, 2, 6 }, true, "Nova Brasília", "BR200195", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 27L, 27L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 3, 5 }, true, "Paranaguamirim", "BR200184", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 28L, 28L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 3 }, true, "Parque Joinville", "BR200220", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 29L, 29L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 3 }, true, "Petrópolis", "BR200555", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 30L, 30L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 4 }, true, "Pinotti", "BR200584", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 31L, 31L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 3, 6 }, true, "Pitaguaras", "BR200610", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 32L, 32L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 4 }, true, "Profipo", "BR200221", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 33L, 33L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 2, 6 }, true, "Santa Barbara", "BR200590", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 34L, 34L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 3 }, true, "Ulysses Guimarães", "BR200544", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 35L, 35L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 3, 6 }, true, "Vila Nova", "BR200222", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L },
                    { 36L, 36L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 5 }, true, "Vila Paraná", "BR200306", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L }
                });

            migrationBuilder.InsertData(
                table: "CONGREGATIONS",
                columns: new[] { "Id", "AddressId", "CreatedAt", "CreatedBy", "DaysOfService", "Name", "RelatorioBrasCode", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 37L, 37L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L, new[] { 0, 5 }, "Anaburgo", "BR200687", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0L });

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_CepId",
                table: "ADDRESS",
                column: "CepId");

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_Id",
                table: "ADDRESS",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CEP_UNIQUE",
                table: "CEPS",
                column: "ZipCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CEPS_CityId",
                table: "CEPS",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CEPS_Id",
                table: "CEPS",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CITIES_CountryId",
                table: "CITIES",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CITIES_Id",
                table: "CITIES",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CITY_NAME_UNIQUE",
                table: "CITIES",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CONGREGATION_ORGANISTS_OrganistId",
                table: "CONGREGATION_ORGANISTS",
                column: "OrganistId");

            migrationBuilder.CreateIndex(
                name: "IX_CONGREGATION_NAME",
                table: "CONGREGATIONS",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_CONGREGATIONS_AddressId",
                table: "CONGREGATIONS",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CONGREGATIONS_RelatorioBrasCode",
                table: "CONGREGATIONS",
                column: "RelatorioBrasCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COUNTRIES_Id",
                table: "COUNTRIES",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COUNTRY_NAME_UNIQUE",
                table: "COUNTRIES",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMAIL_ADDRESS",
                table: "EMAILS",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMAILS_Id",
                table: "EMAILS",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMAILS_OrganistId",
                table: "EMAILS",
                column: "OrganistId");

            migrationBuilder.CreateIndex(
                name: "IX_DATE_OF_HOLY_SERVICE",
                table: "HOLY_SERVICES",
                columns: new[] { "Date", "CongregationId", "OrganistId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HOLY_SERVICES_CongregationId",
                table: "HOLY_SERVICES",
                column: "CongregationId");

            migrationBuilder.CreateIndex(
                name: "IX_HOLY_SERVICES_Id",
                table: "HOLY_SERVICES",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HOLY_SERVICES_OrganistId",
                table: "HOLY_SERVICES",
                column: "OrganistId");

            migrationBuilder.CreateIndex(
                name: "IX_ORGANISTS_AddressId",
                table: "ORGANISTS",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ORGANISTS_Id",
                table: "ORGANISTS",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ORGANISTS_NAMES",
                table: "ORGANISTS",
                columns: new[] { "ShortName", "FullName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CONGREGATION_RANGE_DATE",
                table: "PARAMETERS_SCHEDULE",
                columns: new[] { "StartDate", "EndDate", "CongregationId" });

            migrationBuilder.CreateIndex(
                name: "IX_PARAMETERS_SCHEDULE_CongregationId",
                table: "PARAMETERS_SCHEDULE",
                column: "CongregationId");

            migrationBuilder.CreateIndex(
                name: "IX_PARAMETERS_SCHEDULE_Id",
                table: "PARAMETERS_SCHEDULE",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PHONE_NUMBER",
                table: "PHONES",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PHONES_Id",
                table: "PHONES",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PHONES_OrganistId",
                table: "PHONES",
                column: "OrganistId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CONGREGATION_ORGANISTS");

            migrationBuilder.DropTable(
                name: "EMAILS");

            migrationBuilder.DropTable(
                name: "HOLY_SERVICES");

            migrationBuilder.DropTable(
                name: "PARAMETERS_SCHEDULE");

            migrationBuilder.DropTable(
                name: "PHONES");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CONGREGATIONS");

            migrationBuilder.DropTable(
                name: "ORGANISTS");

            migrationBuilder.DropTable(
                name: "ADDRESS");

            migrationBuilder.DropTable(
                name: "CEPS");

            migrationBuilder.DropTable(
                name: "CITIES");

            migrationBuilder.DropTable(
                name: "COUNTRIES");
        }
    }
}
