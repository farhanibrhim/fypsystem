using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fyp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "77995c74-b83e-43dd-b22d-f5b6ec911d60", "00e943a8-6e13-448a-9a3d-8902025f80d7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f30bdb2-8589-4b7b-a01f-ca4ac8d2e4ca", "10895172-15a1-4493-a82d-47b4e148c669" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a43145a2-20ea-437c-b950-2e9ed5f697ba", "148b5b0d-e46c-469b-bd50-96e0cbad0734" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4ba614f4-4dce-4e01-bbbb-9c74818cd5aa", "2fca439c-3d44-40f8-b10c-f7dc29c97dcd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "77995c74-b83e-43dd-b22d-f5b6ec911d60", "44a5a4c2-d1bd-49ad-93b0-dad3cda6ed36" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a43145a2-20ea-437c-b950-2e9ed5f697ba", "59da83f6-11b4-4789-b727-40bd23e41de2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f30bdb2-8589-4b7b-a01f-ca4ac8d2e4ca", "65d3a093-e7a7-4771-b427-59d90ddcaa49" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a43145a2-20ea-437c-b950-2e9ed5f697ba", "97610b7d-e1fd-4f58-a326-81e71b20584f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4ba614f4-4dce-4e01-bbbb-9c74818cd5aa", "9fd7ed6c-04a5-4ab6-8383-267d18c175cb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e4f99058-9b5d-4d20-9463-358935bdf319", "a2245ee9-b54e-478c-89f0-4237c1f90b64" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e4f99058-9b5d-4d20-9463-358935bdf319", "d51d948e-7122-4f14-873a-39c18c816ad3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "77995c74-b83e-43dd-b22d-f5b6ec911d60", "de659213-174b-49ad-9768-a45b67acec8e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e4f99058-9b5d-4d20-9463-358935bdf319", "f40c6a83-aea4-4e82-b15c-23b46e1457d6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4ba614f4-4dce-4e01-bbbb-9c74818cd5aa", "f417ac54-fa17-46e5-a0a4-cea386f52bbe" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f30bdb2-8589-4b7b-a01f-ca4ac8d2e4ca", "f5c860b0-981a-4a1a-bb04-e8943489b50c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ba614f4-4dce-4e01-bbbb-9c74818cd5aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77995c74-b83e-43dd-b22d-f5b6ec911d60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f30bdb2-8589-4b7b-a01f-ca4ac8d2e4ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a43145a2-20ea-437c-b950-2e9ed5f697ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4f99058-9b5d-4d20-9463-358935bdf319");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00e943a8-6e13-448a-9a3d-8902025f80d7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10895172-15a1-4493-a82d-47b4e148c669");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "148b5b0d-e46c-469b-bd50-96e0cbad0734");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2fca439c-3d44-40f8-b10c-f7dc29c97dcd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44a5a4c2-d1bd-49ad-93b0-dad3cda6ed36");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59da83f6-11b4-4789-b727-40bd23e41de2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65d3a093-e7a7-4771-b427-59d90ddcaa49");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97610b7d-e1fd-4f58-a326-81e71b20584f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9fd7ed6c-04a5-4ab6-8383-267d18c175cb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2245ee9-b54e-478c-89f0-4237c1f90b64");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d51d948e-7122-4f14-873a-39c18c816ad3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "de659213-174b-49ad-9768-a45b67acec8e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f40c6a83-aea4-4e82-b15c-23b46e1457d6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f417ac54-fa17-46e5-a0a4-cea386f52bbe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5c860b0-981a-4a1a-bb04-e8943489b50c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3048ebcf-efa0-4d94-8c20-3b35e9dabcae", null, "Lecturer", "LECTURER" },
                    { "5f166561-895e-44fb-ae65-0534840a7533", null, "Student", "STUDENT" },
                    { "7b42cb50-a42c-43eb-96f0-89c18338838b", null, "Admin", "ADMIN" },
                    { "7b6e28e2-b51b-4684-9de1-1f9e16d5663e", null, "Evaluator", "EVALUATOR" },
                    { "b97be726-8b24-40d7-9314-a70bbb417b3b", null, "Supervisor", "SUPERVISOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "EvaluatorId", "Gender", "IcNumber", "LecturerId", "LockoutEnabled", "LockoutEnd", "Name", "Nationality", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "StudentId", "SupervisorId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0b41b16f-84d5-46c7-bf56-9db7c1e65798", 0, "364a6ace-e4e5-4b5e-aa0b-8bce76f44ad9", "ApplicationUser", "supervisor2@gmail.com", false, null, "Male", "567890123456", null, false, null, "Ts. Noah Taylor", "China", "SUPERVISOR2@GMAIL.COM", "SUPERVISOR2@GMAIL.COM", "AQAAAAIAAYagAAAAECQoPgHVFBxXIg2LIkAU95YybPSiakHloVIK/NmPE/6rjvzNjZlIjOtBucDXLKq3lg==", null, false, "2ffc38df-fb04-45cc-b442-d522c5257ea6", "951 Pinecrest St", null, 2, false, "supervisor2@gmail.com" },
                    { "0c05b7a1-7df5-4256-ac9d-b2da978e8135", 0, "845e0c16-1c03-4aa5-92f0-55aef6a48019", "ApplicationUser", "evaluator2@gmail.com", false, 2, "Female", "765432109876", null, false, null, "Prof. Emma Young", "Malaysia", "EVALUATOR2@GMAIL.COM", "EVALUATOR2@GMAIL.COM", "AQAAAAIAAYagAAAAEPKpxnNsFu6gbcDekrw4kD84eLC+zZ9VnVEud5ne+uEMDMx5FkkZ5QmswKmMf9kDvQ==", null, false, "99b34f17-dc60-465b-a6d4-fe2d89056047", "753 Pine Lane", null, null, false, "evaluator2@gmail.com" },
                    { "2b3f2307-24f6-43a5-af45-316add2fca61", 0, "e764bb3a-04fb-4eff-8989-05086b2a88ef", "ApplicationUser", "admin2@gmail.com", false, null, "Female", "000", null, false, null, "Admin Two", "Malaysia", "ADMIN2@GMAIL.COM", "ADMIN2@GMAIL.COM", "AQAAAAIAAYagAAAAEJ4diMq+ztHp8S71nSQCvscYevFk6fWUpHA5UsTqkufN7LMIoQoePRU9ka9DGX/+dQ==", null, false, "732dc31f-618e-4ccc-b15a-f2fcade52336", "124 Admin St", null, null, false, "admin2@gmail.com" },
                    { "39d251c6-cbc5-46b2-967b-f7a0869711d1", 0, "73823f1d-7bd4-456f-b515-374f417f19d6", "ApplicationUser", "admin3@gmail.com", false, null, "Male", "000", null, false, null, "Admin Three", "Malaysia", "ADMIN3@GMAIL.COM", "ADMIN3@GMAIL.COM", "AQAAAAIAAYagAAAAEIZUWspe9/H1KeQl3AAWCVgZTp1lmhzR6V/uDs8RJTQQaGWRu5aIzwVRePEidkVelQ==", null, false, "a7ad67db-21ea-4e46-9351-52de89f4f4f9", "125 Admin St", null, null, false, "admin3@gmail.com" },
                    { "4147f1c9-350e-4408-9c51-ee6356d03d57", 0, "a223546f-afd0-40d9-8f4a-d0350eb09fef", "ApplicationUser", "student2@gmail.com", false, null, "Female", "987654321012", null, false, null, "Jane Smith", "Malaysia", "STUDENT2@GMAIL.COM", "STUDENT2@GMAIL.COM", "AQAAAAIAAYagAAAAEG1Xtofza4Wq6By3EybS/Ump4i41CoS/zKSnDhqZkBmeVRnSD68m510FE5LixC5l6w==", null, false, "6a0780e0-e6c5-4169-a2d9-b6959e3033ab", "456 Elm St", 2, null, false, "student2@gmail.com" },
                    { "477f95ab-32cc-4d3f-8921-f31a79f89f28", 0, "a37d6e55-56e2-47b6-a9e0-8eeea8a16faa", "ApplicationUser", "supervisor3@gmail.com", false, null, "Female", "210987654321", null, false, null, "Dr. Sophia Rodriguez", "Malaysia", "SUPERVISOR3@GMAIL.COM", "SUPERVISOR3@GMAIL.COM", "AQAAAAIAAYagAAAAEG9pSYypb9QoEDASWNhmlgNKfIwAuGN/Fp2LrvwEsgd00tealyN9iH0U6DOY1ZdcQg==", null, false, "7f91fb0e-0de6-4817-832c-158dce18e6af", "753 Birchwood St", null, 3, false, "supervisor3@gmail.com" },
                    { "4ec56310-c888-4c47-a94e-975cf7f29828", 0, "5b5d6fff-d4b7-46cc-9d75-e99b5b0dfcbf", "ApplicationUser", "student1@gmail.com", false, null, "Male", "001234567890", null, false, null, "John Doe", "Malaysia", "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "AQAAAAIAAYagAAAAEDSj/APZIcpO36Z/dPjUaxnkbw+71cciV3PRI8t4sgJWBKcGkC5sYFmNMFtH87/9kg==", null, false, "cfcdc034-4ca5-4b45-85e3-a6feefe29b4c", "123 Main St", 1, null, false, "student1@gmail.com" },
                    { "652e8b6c-16b0-45ee-b82e-9f085eff94de", 0, "efe09ba2-79dd-42fa-9401-834b62af2ef8", "ApplicationUser", "lecturer3@gmail.com", false, null, "Female", "876543210987", 3, false, null, "Dr. Sophia Miller", "France", "LECTURER3@GMAIL.COM", "LECTURER3@GMAIL.COM", "AQAAAAIAAYagAAAAEKktLqhy3EGHbgWStfuyqIizBt5BPwnFGDOCF3e3vYZi2fHZA/xk8ZC7gPdQwexkuA==", null, false, "c1cd46db-1460-4b62-94e4-b050e51f97cd", "987 Birch St", null, null, false, "lecturer3@gmail.com" },
                    { "6705cc9b-67ec-4fff-bda4-8b6b2f4c2d25", 0, "0be753d9-1acb-418e-b768-9300b1e13025", "ApplicationUser", "lecturer1@gmail.com", false, null, "Female", "098765432101", 1, false, null, "Dr. Emily Brown", "Malaysia", "LECTURER1@GMAIL.COM", "LECTURER1@GMAIL.COM", "AQAAAAIAAYagAAAAEE0YHtgYWrq2IQnXO7ycZoCXbDqk2v7Ydgpa9F7DVCYcdQtSUpKNXqKbuJeSqZ+6Iw==", null, false, "320d4394-089c-414d-824c-ec1f61970ca1", "321 Pine St", null, null, false, "lecturer1@gmail.com" },
                    { "76238e7e-e275-4a4d-9b20-80b7f00fd48c", 0, "809fb5e9-0759-482e-a131-16d0d21cd723", "ApplicationUser", "student3@gmail.com", false, null, "Male", "123456789012", null, false, null, "Michael Johnson", "Malaysia", "STUDENT3@GMAIL.COM", "STUDENT3@GMAIL.COM", "AQAAAAIAAYagAAAAEC3XRyGJyw+Q0UFCk9eK3WC4AdpP2cfqpxqGpbvrmApGlJMlXa0n30AHB8N1nHXLKw==", null, false, "a885b0b9-f6fa-499c-9f53-85f38f3324a9", "789 Oak St", 3, null, false, "student3@gmail.com" },
                    { "8f4b7420-1680-410d-aeca-6b66e586b6b8", 0, "422626b3-6b42-4029-8d62-8b621014b69a", "ApplicationUser", "lecturer2@gmail.com", false, null, "Male", "456789012345", 2, false, null, "Dr. David Lee", "Malaysia", "LECTURER2@GMAIL.COM", "LECTURER2@GMAIL.COM", "AQAAAAIAAYagAAAAEDxNe1Y27sRsDn7VWqpms75af8FhkNyDgnSKxDnIsTtDhhuVTjYjYly8ltVfAR2qKg==", null, false, "91ae36dc-e177-4a1f-9097-d5022813411d", "654 Cedar St", null, null, false, "lecturer2@gmail.com" },
                    { "a8fb6ff3-c5ca-44b9-a758-ce253485738c", 0, "d3c5b476-b0e1-4b13-a9a2-2ce69f17c97b", "ApplicationUser", "evaluator3@gmail.com", false, 3, "Male", "345678901234", null, false, null, "Ts. Mason Green", "Malaysia", "EVALUATOR3@GMAIL.COM", "EVALUATOR3@GMAIL.COM", "AQAAAAIAAYagAAAAEKITF29lT7zMUsS8QXtrmJJXFiMflNy57t5bY5L9ZVDotiJvzT2Dnpgt6JbxYm8FWA==", null, false, "dd4ed535-648f-492b-8682-e929bd415274", "951 Oak Lane", null, null, false, "evaluator3@gmail.com" },
                    { "bcf21292-beba-45b6-9182-4f1184d041f9", 0, "4dc912a0-5242-4248-a3f3-3ebeca3ec13a", "ApplicationUser", "admin1@gmail.com", false, null, "Male", "000", null, false, null, "Admin One", "Malaysia", "ADMIN1@GMAIL.COM", "ADMIN1@GMAIL.COM", "AQAAAAIAAYagAAAAEPBDvlsiWN1vMlfosBsK7tDc5sNat5zB4CQBHxjA9EsKD1acPizGjVFbPQ0trKEw9w==", null, false, "fc1b0daa-ab39-43bc-b6dc-43c5ed73cd26", "123 Admin St", null, null, false, "admin1@gmail.com" },
                    { "e9338e92-59c1-4f33-9d25-bc994817a09b", 0, "ea200fe7-c342-44f2-a949-cc9cfcbf8fa1", "ApplicationUser", "evaluator1@gmail.com", false, 1, "Male", "234567890123", null, false, null, "Mr. Ethan Harris", "South Korea", "EVALUATOR1@GMAIL.COM", "EVALUATOR1@GMAIL.COM", "AQAAAAIAAYagAAAAEDZUXKuD0X7AfyaU0C1NKFnSJdpcUhenK977GLq+rXfVZtqMsRNagrTk5xWz7y5YcQ==", null, false, "b4d62bd0-6c58-4a09-8aeb-bb658130f051", "852 Cedarwood St", null, null, false, "evaluator1@gmail.com" },
                    { "eefbbf88-a11d-4ee2-9000-70b71f8246f8", 0, "db5d8852-a450-451b-815f-7e87a8fad257", "ApplicationUser", "supervisor1@gmail.com", false, null, "Female", "654321098765", null, false, null, "Prof. Isabella Brown", "India", "SUPERVISOR1@GMAIL.COM", "SUPERVISOR1@GMAIL.COM", "AQAAAAIAAYagAAAAEC3UZ2xWI62H4xbKx/2Y1zALRBe5IVpBfHHgG4LyKvfeKM+CA0jHHPcSHCO7vM9plg==", null, false, "ec242b0e-a2a5-45e0-9a52-840eb7060b35", "159 Elmwood St", null, 1, false, "supervisor1@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b97be726-8b24-40d7-9314-a70bbb417b3b", "0b41b16f-84d5-46c7-bf56-9db7c1e65798" },
                    { "7b6e28e2-b51b-4684-9de1-1f9e16d5663e", "0c05b7a1-7df5-4256-ac9d-b2da978e8135" },
                    { "7b42cb50-a42c-43eb-96f0-89c18338838b", "2b3f2307-24f6-43a5-af45-316add2fca61" },
                    { "7b42cb50-a42c-43eb-96f0-89c18338838b", "39d251c6-cbc5-46b2-967b-f7a0869711d1" },
                    { "5f166561-895e-44fb-ae65-0534840a7533", "4147f1c9-350e-4408-9c51-ee6356d03d57" },
                    { "b97be726-8b24-40d7-9314-a70bbb417b3b", "477f95ab-32cc-4d3f-8921-f31a79f89f28" },
                    { "5f166561-895e-44fb-ae65-0534840a7533", "4ec56310-c888-4c47-a94e-975cf7f29828" },
                    { "3048ebcf-efa0-4d94-8c20-3b35e9dabcae", "652e8b6c-16b0-45ee-b82e-9f085eff94de" },
                    { "3048ebcf-efa0-4d94-8c20-3b35e9dabcae", "6705cc9b-67ec-4fff-bda4-8b6b2f4c2d25" },
                    { "5f166561-895e-44fb-ae65-0534840a7533", "76238e7e-e275-4a4d-9b20-80b7f00fd48c" },
                    { "3048ebcf-efa0-4d94-8c20-3b35e9dabcae", "8f4b7420-1680-410d-aeca-6b66e586b6b8" },
                    { "7b6e28e2-b51b-4684-9de1-1f9e16d5663e", "a8fb6ff3-c5ca-44b9-a758-ce253485738c" },
                    { "7b42cb50-a42c-43eb-96f0-89c18338838b", "bcf21292-beba-45b6-9182-4f1184d041f9" },
                    { "7b6e28e2-b51b-4684-9de1-1f9e16d5663e", "e9338e92-59c1-4f33-9d25-bc994817a09b" },
                    { "b97be726-8b24-40d7-9314-a70bbb417b3b", "eefbbf88-a11d-4ee2-9000-70b71f8246f8" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b97be726-8b24-40d7-9314-a70bbb417b3b", "0b41b16f-84d5-46c7-bf56-9db7c1e65798" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7b6e28e2-b51b-4684-9de1-1f9e16d5663e", "0c05b7a1-7df5-4256-ac9d-b2da978e8135" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7b42cb50-a42c-43eb-96f0-89c18338838b", "2b3f2307-24f6-43a5-af45-316add2fca61" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7b42cb50-a42c-43eb-96f0-89c18338838b", "39d251c6-cbc5-46b2-967b-f7a0869711d1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5f166561-895e-44fb-ae65-0534840a7533", "4147f1c9-350e-4408-9c51-ee6356d03d57" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b97be726-8b24-40d7-9314-a70bbb417b3b", "477f95ab-32cc-4d3f-8921-f31a79f89f28" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5f166561-895e-44fb-ae65-0534840a7533", "4ec56310-c888-4c47-a94e-975cf7f29828" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3048ebcf-efa0-4d94-8c20-3b35e9dabcae", "652e8b6c-16b0-45ee-b82e-9f085eff94de" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3048ebcf-efa0-4d94-8c20-3b35e9dabcae", "6705cc9b-67ec-4fff-bda4-8b6b2f4c2d25" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5f166561-895e-44fb-ae65-0534840a7533", "76238e7e-e275-4a4d-9b20-80b7f00fd48c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3048ebcf-efa0-4d94-8c20-3b35e9dabcae", "8f4b7420-1680-410d-aeca-6b66e586b6b8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7b6e28e2-b51b-4684-9de1-1f9e16d5663e", "a8fb6ff3-c5ca-44b9-a758-ce253485738c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7b42cb50-a42c-43eb-96f0-89c18338838b", "bcf21292-beba-45b6-9182-4f1184d041f9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7b6e28e2-b51b-4684-9de1-1f9e16d5663e", "e9338e92-59c1-4f33-9d25-bc994817a09b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b97be726-8b24-40d7-9314-a70bbb417b3b", "eefbbf88-a11d-4ee2-9000-70b71f8246f8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3048ebcf-efa0-4d94-8c20-3b35e9dabcae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f166561-895e-44fb-ae65-0534840a7533");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b42cb50-a42c-43eb-96f0-89c18338838b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b6e28e2-b51b-4684-9de1-1f9e16d5663e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b97be726-8b24-40d7-9314-a70bbb417b3b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0b41b16f-84d5-46c7-bf56-9db7c1e65798");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c05b7a1-7df5-4256-ac9d-b2da978e8135");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b3f2307-24f6-43a5-af45-316add2fca61");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39d251c6-cbc5-46b2-967b-f7a0869711d1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4147f1c9-350e-4408-9c51-ee6356d03d57");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "477f95ab-32cc-4d3f-8921-f31a79f89f28");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ec56310-c888-4c47-a94e-975cf7f29828");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "652e8b6c-16b0-45ee-b82e-9f085eff94de");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6705cc9b-67ec-4fff-bda4-8b6b2f4c2d25");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76238e7e-e275-4a4d-9b20-80b7f00fd48c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f4b7420-1680-410d-aeca-6b66e586b6b8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8fb6ff3-c5ca-44b9-a758-ce253485738c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcf21292-beba-45b6-9182-4f1184d041f9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e9338e92-59c1-4f33-9d25-bc994817a09b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eefbbf88-a11d-4ee2-9000-70b71f8246f8");

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
                    { "00e943a8-6e13-448a-9a3d-8902025f80d7", 0, "59bc52ee-1720-4393-b168-f04a05b7dcc0", "ApplicationUser", "student3@gmail.com", false, null, "Male", "123456789012", null, false, null, "Michael Johnson", "Malaysia", "STUDENT3@GMAIL.COM", "STUDENT3@GMAIL.COM", "AQAAAAIAAYagAAAAEAIrxi0uMHrt4pX1CSDODR2Gsnq5usho8QkRR4749V49SiHmn4EabbAXVZyhH9RAfA==", null, false, "fd227025-85a4-4d30-b2b8-9aae2427f4d5", "789 Oak St", 3, null, false, "student3@gmail.com" },
                    { "10895172-15a1-4493-a82d-47b4e148c669", 0, "b7ab425a-2f02-4b90-99a3-c8fcc5e1efb1", "ApplicationUser", "evaluator1@gmail.com", false, 1, "Male", "234567890123", null, false, null, "Mr. Ethan Harris", "South Korea", "EVALUATOR1@GMAIL.COM", "EVALUATOR1@GMAIL.COM", "AQAAAAIAAYagAAAAEIbecBFmEkdiN96j4UwY8nCUEv98rzH0dl1bqIGHhGby+mmbdQrZjmhwWU17V5m+CA==", null, false, "75026ab4-1417-4be8-80b9-a2dbf986c77c", "852 Cedarwood St", null, null, false, "evaluator1@gmail.com" },
                    { "148b5b0d-e46c-469b-bd50-96e0cbad0734", 0, "d25605b4-34e4-4154-b480-c23ac4437c09", "ApplicationUser", "lecturer1@gmail.com", false, null, "Female", "098765432101", 1, false, null, "Dr. Emily Brown", "Malaysia", "LECTURER1@GMAIL.COM", "LECTURER1@GMAIL.COM", "AQAAAAIAAYagAAAAEJ6NNCiEBj2UqGDb9pFYMVJTlNRmziAdPhzjFFwdtgXS1B5G4V7KCdEJlnFGbib9Iw==", null, false, "273d35e4-dba6-4f17-97d9-7ddba6396813", "321 Pine St", null, null, false, "lecturer1@gmail.com" },
                    { "2fca439c-3d44-40f8-b10c-f7dc29c97dcd", 0, "8b441a84-a924-4457-be4f-5541df98cfcf", "ApplicationUser", "admin3@gmail.com", false, null, "Male", "000", null, false, null, "Admin Three", "Malaysia", "ADMIN3@GMAIL.COM", "ADMIN3@GMAIL.COM", "AQAAAAIAAYagAAAAEBq//U7idu/8ao09AOQqt+s3grJu5EloDmoBq4Rt/nqF0lo6Ls8EVvxK4Ee39pvdVQ==", null, false, "5265eb64-ec94-4cbd-9329-539e827f4ba2", "125 Admin St", null, null, false, "admin3@gmail.com" },
                    { "44a5a4c2-d1bd-49ad-93b0-dad3cda6ed36", 0, "5b4cb0de-fb9b-4e15-ad0e-024ea567a537", "ApplicationUser", "student1@gmail.com", false, null, "Male", "001234567890", null, false, null, "John Doe", "Malaysia", "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "AQAAAAIAAYagAAAAEFZVHJqTp1cgacbAZnyUqixpnbGJ0jo32uchBOHy6x6rdhf56/TIQYS4Sn0x39Fs0Q==", null, false, "da3c9430-afc4-425b-bb9e-151c629bb6c7", "123 Main St", 1, null, false, "student1@gmail.com" },
                    { "59da83f6-11b4-4789-b727-40bd23e41de2", 0, "65909e5d-d2af-441b-adf6-be9bed43860f", "ApplicationUser", "lecturer2@gmail.com", false, null, "Male", "456789012345", 2, false, null, "Dr. David Lee", "Malaysia", "LECTURER2@GMAIL.COM", "LECTURER2@GMAIL.COM", "AQAAAAIAAYagAAAAECEOWfVhY+hlaDqujGVSgqerZw8nRDaG6kPKbMdXYTy85yfKY0lT0oFilVv5SwLPOQ==", null, false, "e754b384-f917-4307-a8ac-028531b86930", "654 Cedar St", null, null, false, "lecturer2@gmail.com" },
                    { "65d3a093-e7a7-4771-b427-59d90ddcaa49", 0, "b32e263a-cba3-4a14-8534-a386ba826a3a", "ApplicationUser", "evaluator2@gmail.com", false, 2, "Female", "765432109876", null, false, null, "Prof. Emma Young", "Malaysia", "EVALUATOR2@GMAIL.COM", "EVALUATOR2@GMAIL.COM", "AQAAAAIAAYagAAAAEMSIQBOQPxoWaTL6/vyUuy/I7kkNZC9azp+pF91JZ8QpP3/yojChpHsnzqZm2bX2BA==", null, false, "5d424577-df3c-41dc-9ede-0405938b01f4", "753 Pine Lane", null, null, false, "evaluator2@gmail.com" },
                    { "97610b7d-e1fd-4f58-a326-81e71b20584f", 0, "4829e1e7-09b2-473f-b339-d6eded7813bf", "ApplicationUser", "lecturer3@gmail.com", false, null, "Female", "876543210987", 3, false, null, "Dr. Sophia Miller", "France", "LECTURER3@GMAIL.COM", "LECTURER3@GMAIL.COM", "AQAAAAIAAYagAAAAEOy0pKUxc+BZQSwsf/A8593/2o0+OemfEGn8xLz4dE19OFFusucLS5ElOhL/ZWLeag==", null, false, "7c115e7f-c5ee-465a-886b-3f32bee055e2", "987 Birch St", null, null, false, "lecturer3@gmail.com" },
                    { "9fd7ed6c-04a5-4ab6-8383-267d18c175cb", 0, "6d8d3faf-8b44-4271-aa08-a59d6363c17e", "ApplicationUser", "admin2@gmail.com", false, null, "Female", "000", null, false, null, "Admin Two", "Malaysia", "ADMIN2@GMAIL.COM", "ADMIN2@GMAIL.COM", "AQAAAAIAAYagAAAAELS06s5XcrKc5DsvVfuZbxqZvnLPUJYoJ4/9r6+Kx7/8JR0eJpss/Fa3+tMl4daOlA==", null, false, "001d4227-9d57-4bd2-a589-4957ece90c85", "124 Admin St", null, null, false, "admin2@gmail.com" },
                    { "a2245ee9-b54e-478c-89f0-4237c1f90b64", 0, "6a7b1017-1063-4429-be37-fbe851a944f9", "ApplicationUser", "supervisor1@gmail.com", false, null, "Female", "654321098765", null, false, null, "Prof. Isabella Brown", "India", "SUPERVISOR1@GMAIL.COM", "SUPERVISOR1@GMAIL.COM", "AQAAAAIAAYagAAAAEFsXKuHAbaq6CbHmDugv3HhzoOLVOLYJotQb/zl3NNeYcamNRu+spDPoT8n9pHplnw==", null, false, "35951c99-d0fe-4f4a-84aa-9bc6ccf4ab6d", "159 Elmwood St", null, 1, false, "supervisor1@gmail.com" },
                    { "d51d948e-7122-4f14-873a-39c18c816ad3", 0, "b46450a0-86a9-4dde-81c2-c83eb19fe5a5", "ApplicationUser", "supervisor3@gmail.com", false, null, "Female", "210987654321", null, false, null, "Dr. Sophia Rodriguez", "Malaysia", "SUPERVISOR3@GMAIL.COM", "SUPERVISOR3@GMAIL.COM", "AQAAAAIAAYagAAAAELlEjsQhxMt58/sd2UmgyLPhn0f+Ikv4lqmW3eTKtsnahufhmr0/IfsKJH7JqCRjQg==", null, false, "5c8bf42e-61b2-4298-856e-fb8876b4ee8e", "753 Birchwood St", null, 3, false, "supervisor3@gmail.com" },
                    { "de659213-174b-49ad-9768-a45b67acec8e", 0, "986365da-698a-4c00-a046-d0590bea966a", "ApplicationUser", "student2@gmail.com", false, null, "Female", "987654321012", null, false, null, "Jane Smith", "Malaysia", "STUDENT2@GMAIL.COM", "STUDENT2@GMAIL.COM", "AQAAAAIAAYagAAAAEAvKRu+CTl5ci82n3ZYavJzWQ2hCDHZy7YYCkMB3J8NY/7Lg2SF9nuITYLvRryqrgA==", null, false, "85e30bd7-3af3-4695-a4f8-8f7aa48da7e5", "456 Elm St", 2, null, false, "student2@gmail.com" },
                    { "f40c6a83-aea4-4e82-b15c-23b46e1457d6", 0, "2efee632-e193-4d35-891b-2e7ffe85ce1c", "ApplicationUser", "supervisor2@gmail.com", false, null, "Male", "567890123456", null, false, null, "Ts. Noah Taylor", "China", "SUPERVISOR2@GMAIL.COM", "SUPERVISOR2@GMAIL.COM", "AQAAAAIAAYagAAAAEGR0eAr18MsC6Re8eMDF1cKuLLOmOY3VAxdZOmx95E2rug1SS59VIu7+fchDymJaJA==", null, false, "1f456d87-1004-402a-904a-f543de663bd9", "951 Pinecrest St", null, 2, false, "supervisor2@gmail.com" },
                    { "f417ac54-fa17-46e5-a0a4-cea386f52bbe", 0, "cc4015ab-8b67-4269-b56a-c63d7ce5586c", "ApplicationUser", "admin1@gmail.com", false, null, "Male", "000", null, false, null, "Admin One", "Malaysia", "ADMIN1@GMAIL.COM", "ADMIN1@GMAIL.COM", "AQAAAAIAAYagAAAAEFGqsAykOwBTDqPLszcLvWA9M+7jbgg0QUN+fdFL2NhwRgwT42hZ1tybKDioIeQcrw==", null, false, "ea122f26-cb1a-4358-a4aa-bf0129c1659c", "123 Admin St", null, null, false, "admin1@gmail.com" },
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
                    { "4ba614f4-4dce-4e01-bbbb-9c74818cd5aa", "2fca439c-3d44-40f8-b10c-f7dc29c97dcd" },
                    { "77995c74-b83e-43dd-b22d-f5b6ec911d60", "44a5a4c2-d1bd-49ad-93b0-dad3cda6ed36" },
                    { "a43145a2-20ea-437c-b950-2e9ed5f697ba", "59da83f6-11b4-4789-b727-40bd23e41de2" },
                    { "9f30bdb2-8589-4b7b-a01f-ca4ac8d2e4ca", "65d3a093-e7a7-4771-b427-59d90ddcaa49" },
                    { "a43145a2-20ea-437c-b950-2e9ed5f697ba", "97610b7d-e1fd-4f58-a326-81e71b20584f" },
                    { "4ba614f4-4dce-4e01-bbbb-9c74818cd5aa", "9fd7ed6c-04a5-4ab6-8383-267d18c175cb" },
                    { "e4f99058-9b5d-4d20-9463-358935bdf319", "a2245ee9-b54e-478c-89f0-4237c1f90b64" },
                    { "e4f99058-9b5d-4d20-9463-358935bdf319", "d51d948e-7122-4f14-873a-39c18c816ad3" },
                    { "77995c74-b83e-43dd-b22d-f5b6ec911d60", "de659213-174b-49ad-9768-a45b67acec8e" },
                    { "e4f99058-9b5d-4d20-9463-358935bdf319", "f40c6a83-aea4-4e82-b15c-23b46e1457d6" },
                    { "4ba614f4-4dce-4e01-bbbb-9c74818cd5aa", "f417ac54-fa17-46e5-a0a4-cea386f52bbe" },
                    { "9f30bdb2-8589-4b7b-a01f-ca4ac8d2e4ca", "f5c860b0-981a-4a1a-bb04-e8943489b50c" }
                });
        }
    }
}
