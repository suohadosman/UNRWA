using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IUNRWARepository.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Salary = table.Column<double>(type: "double", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Doses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoseOrder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FamilyRegestrationCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CardNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyRegestrationCards", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IllnessTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IllnessTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "labTestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labTestTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LateComplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LateComplications", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OriginPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Place = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OriginPlaces", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Relatioship = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SideEffects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SideEffects", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudyLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Level = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyLevels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TheMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheMeasurements", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TimeSlotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Time = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlotes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AreaPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Place = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaPlaces_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Illnesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IllnessTypeId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illnesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Illnesses_IllnessTypes_IllnessTypeId",
                        column: x => x.IllnessTypeId,
                        principalTable: "IllnessTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LabTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalResultValue = table.Column<double>(type: "double", nullable: true),
                    MaxNormalResult = table.Column<double>(type: "double", nullable: true),
                    MinNormalResult = table.Column<double>(type: "double", nullable: true),
                    PNNormalResult = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsAvaliable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Unit = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LabTestResultType = table.Column<int>(type: "int", nullable: false),
                    LabTestTypeId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabTests_labTestTypes_LabTestTypeId",
                        column: x => x.LabTestTypeId,
                        principalTable: "labTestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    MedicineTypeId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicines_MedicineTypes_MedicineTypeId",
                        column: x => x.MedicineTypeId,
                        principalTable: "MedicineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ImmunizationProgrammes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AgeOfChild = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VaccineId = table.Column<int>(type: "int", nullable: false),
                    DoseId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmunizationProgrammes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImmunizationProgrammes_Doses_DoseId",
                        column: x => x.DoseId,
                        principalTable: "Doses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImmunizationProgrammes_Vaccines_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HealthCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AreaPlaceId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthCenters_AreaPlaces_AreaPlaceId",
                        column: x => x.AreaPlaceId,
                        principalTable: "AreaPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArabicName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaritalStatus = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Gender = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateOfBirthday = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FatherId = table.Column<int>(type: "int", nullable: true),
                    ClerickId = table.Column<int>(type: "int", nullable: true),
                    RelationshipId = table.Column<int>(type: "int", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    OriginAdressId = table.Column<int>(type: "int", nullable: false),
                    CurrentAddressId = table.Column<int>(type: "int", nullable: false),
                    FamilyCardId = table.Column<int>(type: "int", nullable: false),
                    CildCardId = table.Column<int>(type: "int", nullable: true),
                    StudyLevelId = table.Column<int>(type: "int", nullable: false),
                    OriginPlaceId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_AreaPlaces_CurrentAddressId",
                        column: x => x.CurrentAddressId,
                        principalTable: "AreaPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_AreaPlaces_OriginAdressId",
                        column: x => x.OriginAdressId,
                        principalTable: "AreaPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_FamilyRegestrationCards_FamilyCardId",
                        column: x => x.FamilyCardId,
                        principalTable: "FamilyRegestrationCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_OriginPlaces_OriginPlaceId",
                        column: x => x.OriginPlaceId,
                        principalTable: "OriginPlaces",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_People_People_FatherId",
                        column: x => x.FatherId,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_People_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_StudyLevels_StudyLevelId",
                        column: x => x.StudyLevelId,
                        principalTable: "StudyLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChildCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CardNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildCards_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clericks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    HealthCenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clericks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clericks_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clericks_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clericks_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clericks_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    HealthCenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MeasurementNurses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    HealthCenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementNurses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasurementNurses_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeasurementNurses_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeasurementNurses_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeasurementNurses_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NCDCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CardNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Diabetes = table.Column<int>(type: "int", nullable: false),
                    Pressure = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Sensitive = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCDCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NCDCards_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NCDNurse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    HealthCenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCDNurse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NCDNurse_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NCDNurse_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NCDNurse_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NCDNurse_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pharmacists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    HealthCenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pharmacists_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pharmacists_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pharmacists_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pharmacists_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Testers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    HealthCenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Testers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Testers_HealthCenters_HealthCenterId",
                        column: x => x.HealthCenterId,
                        principalTable: "HealthCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Testers_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Testers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChildCardMeasurementResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Result = table.Column<float>(type: "float", nullable: false),
                    DateOfMeasurement = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ChildCardId = table.Column<int>(type: "int", nullable: false),
                    MeasurementId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildCardMeasurementResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildCardMeasurementResults_ChildCards_ChildCardId",
                        column: x => x.ChildCardId,
                        principalTable: "ChildCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildCardMeasurementResults_TheMeasurements_MeasurementId",
                        column: x => x.MeasurementId,
                        principalTable: "TheMeasurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ImmunizationDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ChildCardId = table.Column<int>(type: "int", nullable: false),
                    ImmunizationProgrammeId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmunizationDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImmunizationDates_ChildCards_ChildCardId",
                        column: x => x.ChildCardId,
                        principalTable: "ChildCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImmunizationDates_ImmunizationProgrammes_ImmunizationProgram~",
                        column: x => x.ImmunizationProgrammeId,
                        principalTable: "ImmunizationProgrammes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FollwUpVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfVisit = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TypeOfFollwUp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NCDCardId = table.Column<int>(type: "int", nullable: false),
                    NCDNurseId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollwUpVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollwUpVisits_NCDCards_NCDCardId",
                        column: x => x.NCDCardId,
                        principalTable: "NCDCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FollwUpVisits_NCDNurse_NCDNurseId",
                        column: x => x.NCDNurseId,
                        principalTable: "NCDNurse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ClerickId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    IsDone = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NCDNurseId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Clericks_ClerickId",
                        column: x => x.ClerickId,
                        principalTable: "Clericks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_NCDNurse_NCDNurseId",
                        column: x => x.NCDNurseId,
                        principalTable: "NCDNurse",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ImmunizationDateSideEffects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImmunizationDateId = table.Column<int>(type: "int", nullable: false),
                    SideEffectId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmunizationDateSideEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImmunizationDateSideEffects_ImmunizationDates_ImmunizationDa~",
                        column: x => x.ImmunizationDateId,
                        principalTable: "ImmunizationDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImmunizationDateSideEffects_SideEffects_SideEffectId",
                        column: x => x.SideEffectId,
                        principalTable: "SideEffects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "followUpLabTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FollwUpVisitId = table.Column<int>(type: "int", nullable: false),
                    LabTestId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateOfDone = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDone = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PNResult = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Result = table.Column<float>(type: "float", nullable: true),
                    FollowUpLabTestType = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_followUpLabTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_followUpLabTests_FollwUpVisits_FollwUpVisitId",
                        column: x => x.FollwUpVisitId,
                        principalTable: "FollwUpVisits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_followUpLabTests_LabTests_LabTestId",
                        column: x => x.LabTestId,
                        principalTable: "LabTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FollowUpLateComplication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FollwUpVisitId = table.Column<int>(type: "int", nullable: false),
                    LateComplicationId = table.Column<int>(type: "int", nullable: false),
                    NCDCardId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUpLateComplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowUpLateComplication_FollwUpVisits_FollwUpVisitId",
                        column: x => x.FollwUpVisitId,
                        principalTable: "FollwUpVisits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FollowUpLateComplication_LateComplications_LateComplicationId",
                        column: x => x.LateComplicationId,
                        principalTable: "LateComplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FollowUpLateComplication_NCDCards_NCDCardId",
                        column: x => x.NCDCardId,
                        principalTable: "NCDCards",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Previews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Previews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Previews_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Previews_People_PatientId",
                        column: x => x.PatientId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Previews_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicinPreviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IsTaken = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    PreviewId = table.Column<int>(type: "int", nullable: false),
                    NCDCardId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinPreviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicinPreviews_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicinPreviews_NCDCards_NCDCardId",
                        column: x => x.NCDCardId,
                        principalTable: "NCDCards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicinPreviews_Previews_PreviewId",
                        column: x => x.PreviewId,
                        principalTable: "Previews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonMeasurementResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Result = table.Column<float>(type: "float", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    MeasurementId = table.Column<int>(type: "int", nullable: false),
                    DateOfMeasurement = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PreviewId = table.Column<int>(type: "int", nullable: true),
                    FollwUpVisitId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonMeasurementResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonMeasurementResults_FollwUpVisits_FollwUpVisitId",
                        column: x => x.FollwUpVisitId,
                        principalTable: "FollwUpVisits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonMeasurementResults_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonMeasurementResults_Previews_PreviewId",
                        column: x => x.PreviewId,
                        principalTable: "Previews",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonMeasurementResults_TheMeasurements_MeasurementId",
                        column: x => x.MeasurementId,
                        principalTable: "TheMeasurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PreviewComplaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PreviewId = table.Column<int>(type: "int", nullable: false),
                    ComplaintId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviewComplaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreviewComplaints_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreviewComplaints_Previews_PreviewId",
                        column: x => x.PreviewId,
                        principalTable: "Previews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PreviewIllnesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PreviewId = table.Column<int>(type: "int", nullable: false),
                    IllnessId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviewIllnesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreviewIllnesses_Illnesses_IllnessId",
                        column: x => x.IllnessId,
                        principalTable: "Illnesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreviewIllnesses_Previews_PreviewId",
                        column: x => x.PreviewId,
                        principalTable: "Previews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PreviewLabTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PreviewId = table.Column<int>(type: "int", nullable: false),
                    LabTestId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateOfDone = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDone = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PNResult = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Result = table.Column<float>(type: "float", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsVaild = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForceDelete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviewLabTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreviewLabTests_LabTests_LabTestId",
                        column: x => x.LabTestId,
                        principalTable: "LabTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreviewLabTests_Previews_PreviewId",
                        column: x => x.PreviewId,
                        principalTable: "Previews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AreaPlaces_AreaId",
                table: "AreaPlaces",
                column: "AreaId");

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
                name: "IX_ChildCardMeasurementResults_ChildCardId",
                table: "ChildCardMeasurementResults",
                column: "ChildCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildCardMeasurementResults_MeasurementId",
                table: "ChildCardMeasurementResults",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildCards_PersonId",
                table: "ChildCards",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clericks_HealthCenterId",
                table: "Clericks",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Clericks_PersonId",
                table: "Clericks",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clericks_TeamId",
                table: "Clericks",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_HealthCenterId",
                table: "Doctors",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PersonId",
                table: "Doctors",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_TeamId",
                table: "Doctors",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_followUpLabTests_FollwUpVisitId",
                table: "followUpLabTests",
                column: "FollwUpVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_followUpLabTests_LabTestId",
                table: "followUpLabTests",
                column: "LabTestId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpLateComplication_FollwUpVisitId",
                table: "FollowUpLateComplication",
                column: "FollwUpVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpLateComplication_LateComplicationId",
                table: "FollowUpLateComplication",
                column: "LateComplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpLateComplication_NCDCardId",
                table: "FollowUpLateComplication",
                column: "NCDCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FollwUpVisits_NCDCardId",
                table: "FollwUpVisits",
                column: "NCDCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FollwUpVisits_NCDNurseId",
                table: "FollwUpVisits",
                column: "NCDNurseId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCenters_AreaPlaceId",
                table: "HealthCenters",
                column: "AreaPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Illnesses_IllnessTypeId",
                table: "Illnesses",
                column: "IllnessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ImmunizationDates_ChildCardId",
                table: "ImmunizationDates",
                column: "ChildCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ImmunizationDates_ImmunizationProgrammeId",
                table: "ImmunizationDates",
                column: "ImmunizationProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_ImmunizationDateSideEffects_ImmunizationDateId",
                table: "ImmunizationDateSideEffects",
                column: "ImmunizationDateId");

            migrationBuilder.CreateIndex(
                name: "IX_ImmunizationDateSideEffects_SideEffectId",
                table: "ImmunizationDateSideEffects",
                column: "SideEffectId");

            migrationBuilder.CreateIndex(
                name: "IX_ImmunizationProgrammes_DoseId",
                table: "ImmunizationProgrammes",
                column: "DoseId");

            migrationBuilder.CreateIndex(
                name: "IX_ImmunizationProgrammes_VaccineId",
                table: "ImmunizationProgrammes",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTests_LabTestTypeId",
                table: "LabTests",
                column: "LabTestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementNurses_HealthCenterId",
                table: "MeasurementNurses",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementNurses_PersonId",
                table: "MeasurementNurses",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementNurses_TeamId",
                table: "MeasurementNurses",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicineTypeId",
                table: "Medicines",
                column: "MedicineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinPreviews_MedicineId",
                table: "MedicinPreviews",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinPreviews_NCDCardId",
                table: "MedicinPreviews",
                column: "NCDCardId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinPreviews_PreviewId",
                table: "MedicinPreviews",
                column: "PreviewId");

            migrationBuilder.CreateIndex(
                name: "IX_NCDCards_PersonId",
                table: "NCDCards",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NCDNurse_HealthCenterId",
                table: "NCDNurse",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_NCDNurse_PersonId",
                table: "NCDNurse",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_NCDNurse_TeamId",
                table: "NCDNurse",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_People_CurrentAddressId",
                table: "People",
                column: "CurrentAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_People_FamilyCardId",
                table: "People",
                column: "FamilyCardId");

            migrationBuilder.CreateIndex(
                name: "IX_People_FatherId",
                table: "People",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_People_NationalityId",
                table: "People",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_People_OriginAdressId",
                table: "People",
                column: "OriginAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_People_OriginPlaceId",
                table: "People",
                column: "OriginPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_People_RelationshipId",
                table: "People",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_People_StudyLevelId",
                table: "People",
                column: "StudyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonMeasurementResults_FollwUpVisitId",
                table: "PersonMeasurementResults",
                column: "FollwUpVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonMeasurementResults_MeasurementId",
                table: "PersonMeasurementResults",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonMeasurementResults_PersonId",
                table: "PersonMeasurementResults",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonMeasurementResults_PreviewId",
                table: "PersonMeasurementResults",
                column: "PreviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacists_HealthCenterId",
                table: "Pharmacists",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacists_PersonId",
                table: "Pharmacists",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacists_TeamId",
                table: "Pharmacists",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PreviewComplaints_ComplaintId",
                table: "PreviewComplaints",
                column: "ComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_PreviewComplaints_PreviewId",
                table: "PreviewComplaints",
                column: "PreviewId");

            migrationBuilder.CreateIndex(
                name: "IX_PreviewIllnesses_IllnessId",
                table: "PreviewIllnesses",
                column: "IllnessId");

            migrationBuilder.CreateIndex(
                name: "IX_PreviewIllnesses_PreviewId",
                table: "PreviewIllnesses",
                column: "PreviewId");

            migrationBuilder.CreateIndex(
                name: "IX_PreviewLabTests_LabTestId",
                table: "PreviewLabTests",
                column: "LabTestId");

            migrationBuilder.CreateIndex(
                name: "IX_PreviewLabTests_PreviewId",
                table: "PreviewLabTests",
                column: "PreviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Previews_DoctorId",
                table: "Previews",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Previews_PatientId",
                table: "Previews",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Previews_ReservationId",
                table: "Previews",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClerickId",
                table: "Reservations",
                column: "ClerickId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DoctorId",
                table: "Reservations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_NCDNurseId",
                table: "Reservations",
                column: "NCDNurseId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PersonId",
                table: "Reservations",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ServiceId",
                table: "Reservations",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Testers_HealthCenterId",
                table: "Testers",
                column: "HealthCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Testers_PersonId",
                table: "Testers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Testers_TeamId",
                table: "Testers",
                column: "TeamId");
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
                name: "ChildCardMeasurementResults");

            migrationBuilder.DropTable(
                name: "followUpLabTests");

            migrationBuilder.DropTable(
                name: "FollowUpLateComplication");

            migrationBuilder.DropTable(
                name: "ImmunizationDateSideEffects");

            migrationBuilder.DropTable(
                name: "MeasurementNurses");

            migrationBuilder.DropTable(
                name: "MedicinPreviews");

            migrationBuilder.DropTable(
                name: "PersonMeasurementResults");

            migrationBuilder.DropTable(
                name: "Pharmacists");

            migrationBuilder.DropTable(
                name: "PreviewComplaints");

            migrationBuilder.DropTable(
                name: "PreviewIllnesses");

            migrationBuilder.DropTable(
                name: "PreviewLabTests");

            migrationBuilder.DropTable(
                name: "Testers");

            migrationBuilder.DropTable(
                name: "TimeSlotes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "LateComplications");

            migrationBuilder.DropTable(
                name: "ImmunizationDates");

            migrationBuilder.DropTable(
                name: "SideEffects");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "FollwUpVisits");

            migrationBuilder.DropTable(
                name: "TheMeasurements");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "Illnesses");

            migrationBuilder.DropTable(
                name: "LabTests");

            migrationBuilder.DropTable(
                name: "Previews");

            migrationBuilder.DropTable(
                name: "ChildCards");

            migrationBuilder.DropTable(
                name: "ImmunizationProgrammes");

            migrationBuilder.DropTable(
                name: "MedicineTypes");

            migrationBuilder.DropTable(
                name: "NCDCards");

            migrationBuilder.DropTable(
                name: "IllnessTypes");

            migrationBuilder.DropTable(
                name: "labTestTypes");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Doses");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "Clericks");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "NCDNurse");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "HealthCenters");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "AreaPlaces");

            migrationBuilder.DropTable(
                name: "FamilyRegestrationCards");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "OriginPlaces");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "StudyLevels");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
