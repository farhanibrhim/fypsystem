using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fyp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicPrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evaluators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supervisors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Lecturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCommitteeMember = table.Column<bool>(type: "bit", nullable: false),
                    DomainId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lecturers_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupervisorId = table.Column<int>(type: "int", nullable: true),
                    ProposalId = table.Column<int>(type: "int", nullable: true),
                    Semester = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicSession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorApprovalStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Supervisors_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Supervisors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LecturerPrograms",
                columns: table => new
                {
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    AcademicProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerPrograms", x => new { x.LecturerId, x.AcademicProgramId });
                    table.ForeignKey(
                        name: "FK_LecturerPrograms_AcademicPrograms_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalTable: "AcademicPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerPrograms_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IcNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LecturerId = table.Column<int>(type: "int", nullable: true),
                    EvaluatorId = table.Column<int>(type: "int", nullable: true),
                    SupervisorId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Evaluators_EvaluatorId",
                        column: x => x.EvaluatorId,
                        principalTable: "Evaluators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Supervisors_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Supervisors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectTypeId = table.Column<int>(type: "int", nullable: true),
                    ProposalDocumentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Evaluator1Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Evaluator2Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result1 = table.Column<int>(type: "int", nullable: true),
                    Result2 = table.Column<int>(type: "int", nullable: true),
                    MuridId = table.Column<int>(type: "int", nullable: false),
                    Evaluator1Id = table.Column<int>(type: "int", nullable: true),
                    Evaluator2Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Evaluators_Evaluator1Id",
                        column: x => x.Evaluator1Id,
                        principalTable: "Evaluators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proposals_Evaluators_Evaluator2Id",
                        column: x => x.Evaluator2Id,
                        principalTable: "Evaluators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proposals_ProjectTypes_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "ProjectTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proposals_Students_MuridId",
                        column: x => x.MuridId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.InsertData(
                table: "AcademicPrograms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Software Engineering" },
                    { 2, "Data Engineering" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ba614f4-4dce-4e01-bbbb-9c74818cd5aa", null, "Admin", "ADMIN" },
                    { "77995c74-b83e-43dd-b22d-f5b6ec911d60", null, "Student", "STUDENT" },
                    { "9f30bdb2-8589-4b7b-a01f-ca4ac8d2e4ca", null, "Evaluator", "EVALUATOR" },
                    { "a43145a2-20ea-437c-b950-2e9ed5f697ba", null, "Lecturer", "LECTURER" },
                    { "e4f99058-9b5d-4d20-9463-358935bdf319", null, "Supervisor", "SUPERVISOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "EvaluatorId", "Gender", "IcNumber", "LecturerId", "LockoutEnabled", "LockoutEnd", "Name", "Nationality", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "StudentId", "SupervisorId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2fca439c-3d44-40f8-b10c-f7dc29c97dcd", 0, "8b441a84-a924-4457-be4f-5541df98cfcf", "ApplicationUser", "admin3@gmail.com", false, null, "Male", "000", null, false, null, "Admin Three", "Malaysia", "ADMIN3@GMAIL.COM", "ADMIN3@GMAIL.COM", "AQAAAAIAAYagAAAAEBq//U7idu/8ao09AOQqt+s3grJu5EloDmoBq4Rt/nqF0lo6Ls8EVvxK4Ee39pvdVQ==", null, false, "5265eb64-ec94-4cbd-9329-539e827f4ba2", "125 Admin St", null, null, false, "admin3@gmail.com" },
                    { "9fd7ed6c-04a5-4ab6-8383-267d18c175cb", 0, "6d8d3faf-8b44-4271-aa08-a59d6363c17e", "ApplicationUser", "admin2@gmail.com", false, null, "Female", "000", null, false, null, "Admin Two", "Malaysia", "ADMIN2@GMAIL.COM", "ADMIN2@GMAIL.COM", "AQAAAAIAAYagAAAAELS06s5XcrKc5DsvVfuZbxqZvnLPUJYoJ4/9r6+Kx7/8JR0eJpss/Fa3+tMl4daOlA==", null, false, "001d4227-9d57-4bd2-a589-4957ece90c85", "124 Admin St", null, null, false, "admin2@gmail.com" },
                    { "f417ac54-fa17-46e5-a0a4-cea386f52bbe", 0, "cc4015ab-8b67-4269-b56a-c63d7ce5586c", "ApplicationUser", "admin1@gmail.com", false, null, "Male", "000", null, false, null, "Admin One", "Malaysia", "ADMIN1@GMAIL.COM", "ADMIN1@GMAIL.COM", "AQAAAAIAAYagAAAAEFGqsAykOwBTDqPLszcLvWA9M+7jbgg0QUN+fdFL2NhwRgwT42hZ1tybKDioIeQcrw==", null, false, "ea122f26-cb1a-4358-a4aa-bf0129c1659c", "123 Admin St", null, null, false, "admin1@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Domains",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Research" },
                    { 2, "Development" }
                });

            migrationBuilder.InsertData(
                table: "Evaluators",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3
                });

            migrationBuilder.InsertData(
                table: "Lecturers",
                columns: new[] { "Id", "DomainId", "IsCommitteeMember" },
                values: new object[,]
                {
                    { 1, null, false },
                    { 2, null, false },
                    { 3, null, false }
                });

            migrationBuilder.InsertData(
                table: "ProjectTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Research" },
                    { 2, "Development" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "AcademicSession", "ProposalId", "Semester", "SupervisorApprovalStatus", "SupervisorId" },
                values: new object[,]
                {
                    { 1, null, null, null, 0, null },
                    { 2, null, null, null, 0, null },
                    { 3, null, null, null, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Supervisors",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4ba614f4-4dce-4e01-bbbb-9c74818cd5aa", "2fca439c-3d44-40f8-b10c-f7dc29c97dcd" },
                    { "4ba614f4-4dce-4e01-bbbb-9c74818cd5aa", "9fd7ed6c-04a5-4ab6-8383-267d18c175cb" },
                    { "4ba614f4-4dce-4e01-bbbb-9c74818cd5aa", "f417ac54-fa17-46e5-a0a4-cea386f52bbe" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "EvaluatorId", "Gender", "IcNumber", "LecturerId", "LockoutEnabled", "LockoutEnd", "Name", "Nationality", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "StudentId", "SupervisorId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00e943a8-6e13-448a-9a3d-8902025f80d7", 0, "59bc52ee-1720-4393-b168-f04a05b7dcc0", "ApplicationUser", "student3@gmail.com", false, null, "Male", "123456789012", null, false, null, "Michael Johnson", "Malaysia", "STUDENT3@GMAIL.COM", "STUDENT3@GMAIL.COM", "AQAAAAIAAYagAAAAEAIrxi0uMHrt4pX1CSDODR2Gsnq5usho8QkRR4749V49SiHmn4EabbAXVZyhH9RAfA==", null, false, "fd227025-85a4-4d30-b2b8-9aae2427f4d5", "789 Oak St", 3, null, false, "student3@gmail.com" },
                    { "10895172-15a1-4493-a82d-47b4e148c669", 0, "b7ab425a-2f02-4b90-99a3-c8fcc5e1efb1", "ApplicationUser", "evaluator1@gmail.com", false, 1, "Male", "234567890123", null, false, null, "Mr. Ethan Harris", "South Korea", "EVALUATOR1@GMAIL.COM", "EVALUATOR1@GMAIL.COM", "AQAAAAIAAYagAAAAEIbecBFmEkdiN96j4UwY8nCUEv98rzH0dl1bqIGHhGby+mmbdQrZjmhwWU17V5m+CA==", null, false, "75026ab4-1417-4be8-80b9-a2dbf986c77c", "852 Cedarwood St", null, null, false, "evaluator1@gmail.com" },
                    { "148b5b0d-e46c-469b-bd50-96e0cbad0734", 0, "d25605b4-34e4-4154-b480-c23ac4437c09", "ApplicationUser", "lecturer1@gmail.com", false, null, "Female", "098765432101", 1, false, null, "Dr. Emily Brown", "Malaysia", "LECTURER1@GMAIL.COM", "LECTURER1@GMAIL.COM", "AQAAAAIAAYagAAAAEJ6NNCiEBj2UqGDb9pFYMVJTlNRmziAdPhzjFFwdtgXS1B5G4V7KCdEJlnFGbib9Iw==", null, false, "273d35e4-dba6-4f17-97d9-7ddba6396813", "321 Pine St", null, null, false, "lecturer1@gmail.com" },
                    { "44a5a4c2-d1bd-49ad-93b0-dad3cda6ed36", 0, "5b4cb0de-fb9b-4e15-ad0e-024ea567a537", "ApplicationUser", "student1@gmail.com", false, null, "Male", "001234567890", null, false, null, "John Doe", "Malaysia", "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "AQAAAAIAAYagAAAAEFZVHJqTp1cgacbAZnyUqixpnbGJ0jo32uchBOHy6x6rdhf56/TIQYS4Sn0x39Fs0Q==", null, false, "da3c9430-afc4-425b-bb9e-151c629bb6c7", "123 Main St", 1, null, false, "student1@gmail.com" },
                    { "59da83f6-11b4-4789-b727-40bd23e41de2", 0, "65909e5d-d2af-441b-adf6-be9bed43860f", "ApplicationUser", "lecturer2@gmail.com", false, null, "Male", "456789012345", 2, false, null, "Dr. David Lee", "Malaysia", "LECTURER2@GMAIL.COM", "LECTURER2@GMAIL.COM", "AQAAAAIAAYagAAAAECEOWfVhY+hlaDqujGVSgqerZw8nRDaG6kPKbMdXYTy85yfKY0lT0oFilVv5SwLPOQ==", null, false, "e754b384-f917-4307-a8ac-028531b86930", "654 Cedar St", null, null, false, "lecturer2@gmail.com" },
                    { "65d3a093-e7a7-4771-b427-59d90ddcaa49", 0, "b32e263a-cba3-4a14-8534-a386ba826a3a", "ApplicationUser", "evaluator2@gmail.com", false, 2, "Female", "765432109876", null, false, null, "Prof. Emma Young", "Malaysia", "EVALUATOR2@GMAIL.COM", "EVALUATOR2@GMAIL.COM", "AQAAAAIAAYagAAAAEMSIQBOQPxoWaTL6/vyUuy/I7kkNZC9azp+pF91JZ8QpP3/yojChpHsnzqZm2bX2BA==", null, false, "5d424577-df3c-41dc-9ede-0405938b01f4", "753 Pine Lane", null, null, false, "evaluator2@gmail.com" },
                    { "97610b7d-e1fd-4f58-a326-81e71b20584f", 0, "4829e1e7-09b2-473f-b339-d6eded7813bf", "ApplicationUser", "lecturer3@gmail.com", false, null, "Female", "876543210987", 3, false, null, "Dr. Sophia Miller", "France", "LECTURER3@GMAIL.COM", "LECTURER3@GMAIL.COM", "AQAAAAIAAYagAAAAEOy0pKUxc+BZQSwsf/A8593/2o0+OemfEGn8xLz4dE19OFFusucLS5ElOhL/ZWLeag==", null, false, "7c115e7f-c5ee-465a-886b-3f32bee055e2", "987 Birch St", null, null, false, "lecturer3@gmail.com" },
                    { "a2245ee9-b54e-478c-89f0-4237c1f90b64", 0, "6a7b1017-1063-4429-be37-fbe851a944f9", "ApplicationUser", "supervisor1@gmail.com", false, null, "Female", "654321098765", null, false, null, "Prof. Isabella Brown", "India", "SUPERVISOR1@GMAIL.COM", "SUPERVISOR1@GMAIL.COM", "AQAAAAIAAYagAAAAEFsXKuHAbaq6CbHmDugv3HhzoOLVOLYJotQb/zl3NNeYcamNRu+spDPoT8n9pHplnw==", null, false, "35951c99-d0fe-4f4a-84aa-9bc6ccf4ab6d", "159 Elmwood St", null, 1, false, "supervisor1@gmail.com" },
                    { "d51d948e-7122-4f14-873a-39c18c816ad3", 0, "b46450a0-86a9-4dde-81c2-c83eb19fe5a5", "ApplicationUser", "supervisor3@gmail.com", false, null, "Female", "210987654321", null, false, null, "Dr. Sophia Rodriguez", "Malaysia", "SUPERVISOR3@GMAIL.COM", "SUPERVISOR3@GMAIL.COM", "AQAAAAIAAYagAAAAELlEjsQhxMt58/sd2UmgyLPhn0f+Ikv4lqmW3eTKtsnahufhmr0/IfsKJH7JqCRjQg==", null, false, "5c8bf42e-61b2-4298-856e-fb8876b4ee8e", "753 Birchwood St", null, 3, false, "supervisor3@gmail.com" },
                    { "de659213-174b-49ad-9768-a45b67acec8e", 0, "986365da-698a-4c00-a046-d0590bea966a", "ApplicationUser", "student2@gmail.com", false, null, "Female", "987654321012", null, false, null, "Jane Smith", "Malaysia", "STUDENT2@GMAIL.COM", "STUDENT2@GMAIL.COM", "AQAAAAIAAYagAAAAEAvKRu+CTl5ci82n3ZYavJzWQ2hCDHZy7YYCkMB3J8NY/7Lg2SF9nuITYLvRryqrgA==", null, false, "85e30bd7-3af3-4695-a4f8-8f7aa48da7e5", "456 Elm St", 2, null, false, "student2@gmail.com" },
                    { "f40c6a83-aea4-4e82-b15c-23b46e1457d6", 0, "2efee632-e193-4d35-891b-2e7ffe85ce1c", "ApplicationUser", "supervisor2@gmail.com", false, null, "Male", "567890123456", null, false, null, "Ts. Noah Taylor", "China", "SUPERVISOR2@GMAIL.COM", "SUPERVISOR2@GMAIL.COM", "AQAAAAIAAYagAAAAEGR0eAr18MsC6Re8eMDF1cKuLLOmOY3VAxdZOmx95E2rug1SS59VIu7+fchDymJaJA==", null, false, "1f456d87-1004-402a-904a-f543de663bd9", "951 Pinecrest St", null, 2, false, "supervisor2@gmail.com" },
                    { "f5c860b0-981a-4a1a-bb04-e8943489b50c", 0, "dc53081b-0a26-4781-9535-8314abb212de", "ApplicationUser", "evaluator3@gmail.com", false, 3, "Male", "345678901234", null, false, null, "Ts. Mason Green", "Malaysia", "EVALUATOR3@GMAIL.COM", "EVALUATOR3@GMAIL.COM", "AQAAAAIAAYagAAAAEAOrmf6mB7dBgKStZNIQnGW+yZtIw5XOwQrRX6iBw0lr8Jn4Lcw+7ygPdgKIlnnKnA==", null, false, "25bd42df-6baa-4ff9-aa8c-135a7d989834", "951 Oak Lane", null, null, false, "evaluator3@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "77995c74-b83e-43dd-b22d-f5b6ec911d60", "00e943a8-6e13-448a-9a3d-8902025f80d7" },
                    { "9f30bdb2-8589-4b7b-a01f-ca4ac8d2e4ca", "10895172-15a1-4493-a82d-47b4e148c669" },
                    { "a43145a2-20ea-437c-b950-2e9ed5f697ba", "148b5b0d-e46c-469b-bd50-96e0cbad0734" },
                    { "77995c74-b83e-43dd-b22d-f5b6ec911d60", "44a5a4c2-d1bd-49ad-93b0-dad3cda6ed36" },
                    { "a43145a2-20ea-437c-b950-2e9ed5f697ba", "59da83f6-11b4-4789-b727-40bd23e41de2" },
                    { "9f30bdb2-8589-4b7b-a01f-ca4ac8d2e4ca", "65d3a093-e7a7-4771-b427-59d90ddcaa49" },
                    { "a43145a2-20ea-437c-b950-2e9ed5f697ba", "97610b7d-e1fd-4f58-a326-81e71b20584f" },
                    { "e4f99058-9b5d-4d20-9463-358935bdf319", "a2245ee9-b54e-478c-89f0-4237c1f90b64" },
                    { "e4f99058-9b5d-4d20-9463-358935bdf319", "d51d948e-7122-4f14-873a-39c18c816ad3" },
                    { "77995c74-b83e-43dd-b22d-f5b6ec911d60", "de659213-174b-49ad-9768-a45b67acec8e" },
                    { "e4f99058-9b5d-4d20-9463-358935bdf319", "f40c6a83-aea4-4e82-b15c-23b46e1457d6" },
                    { "9f30bdb2-8589-4b7b-a01f-ca4ac8d2e4ca", "f5c860b0-981a-4a1a-bb04-e8943489b50c" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "IX_AspNetUsers_EvaluatorId",
                table: "AspNetUsers",
                column: "EvaluatorId",
                unique: true,
                filter: "[EvaluatorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LecturerId",
                table: "AspNetUsers",
                column: "LecturerId",
                unique: true,
                filter: "[LecturerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudentId",
                table: "AspNetUsers",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SupervisorId",
                table: "AspNetUsers",
                column: "SupervisorId",
                unique: true,
                filter: "[SupervisorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerPrograms_AcademicProgramId",
                table: "LecturerPrograms",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_DomainId",
                table: "Lecturers",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_Evaluator1Id",
                table: "Proposals",
                column: "Evaluator1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_Evaluator2Id",
                table: "Proposals",
                column: "Evaluator2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_MuridId",
                table: "Proposals",
                column: "MuridId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_ProjectTypeId",
                table: "Proposals",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SupervisorId",
                table: "Students",
                column: "SupervisorId");
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
                name: "LecturerPrograms");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AcademicPrograms");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.DropTable(
                name: "Evaluators");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Domains");

            migrationBuilder.DropTable(
                name: "Supervisors");
        }
    }
}
