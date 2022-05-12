using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_web_api.Migrations
{
    public partial class SeedEntitiesWithRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, new byte[] { 94, 137, 197, 194, 130, 5, 232, 175, 200, 220, 108, 177, 75, 50, 74, 46, 91, 159, 191, 220, 66, 131, 194, 125, 233, 193, 6, 19, 205, 75, 17, 194, 117, 82, 131, 15, 181, 244, 167, 101, 85, 183, 232, 105, 86, 134, 199, 144, 251, 12, 129, 188, 37, 152, 170, 125, 152, 70, 2, 169, 220, 221, 207, 128 }, new byte[] { 3, 51, 160, 150, 228, 53, 237, 187, 93, 195, 10, 151, 21, 50, 151, 112, 182, 208, 76, 227, 105, 227, 2, 238, 130, 140, 162, 234, 143, 227, 127, 80, 93, 7, 239, 116, 230, 176, 25, 37, 50, 197, 6, 49, 134, 133, 30, 117, 219, 150, 58, 70, 204, 99, 45, 142, 64, 66, 197, 40, 249, 135, 2, 30, 117, 211, 37, 3, 22, 97, 33, 91, 240, 15, 132, 192, 104, 38, 64, 210, 212, 205, 59, 23, 197, 168, 43, 72, 163, 61, 116, 251, 114, 127, 232, 10, 17, 126, 77, 11, 26, 56, 110, 183, 164, 39, 15, 89, 9, 40, 232, 33, 197, 204, 8, 119, 198, 126, 238, 195, 133, 119, 62, 234, 239, 239, 210, 209 }, "User1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 2, new byte[] { 94, 137, 197, 194, 130, 5, 232, 175, 200, 220, 108, 177, 75, 50, 74, 46, 91, 159, 191, 220, 66, 131, 194, 125, 233, 193, 6, 19, 205, 75, 17, 194, 117, 82, 131, 15, 181, 244, 167, 101, 85, 183, 232, 105, 86, 134, 199, 144, 251, 12, 129, 188, 37, 152, 170, 125, 152, 70, 2, 169, 220, 221, 207, 128 }, new byte[] { 3, 51, 160, 150, 228, 53, 237, 187, 93, 195, 10, 151, 21, 50, 151, 112, 182, 208, 76, 227, 105, 227, 2, 238, 130, 140, 162, 234, 143, 227, 127, 80, 93, 7, 239, 116, 230, 176, 25, 37, 50, 197, 6, 49, 134, 133, 30, 117, 219, 150, 58, 70, 204, 99, 45, 142, 64, 66, 197, 40, 249, 135, 2, 30, 117, 211, 37, 3, 22, 97, 33, 91, 240, 15, 132, 192, 104, 38, 64, 210, 212, 205, 59, 23, 197, 168, 43, 72, 163, 61, 116, 251, 114, 127, 232, 10, 17, 126, 77, 11, 26, 56, 110, 183, 164, 39, 15, 89, 9, 40, 232, 33, 197, 204, 8, 119, 198, 126, 238, 195, 133, 119, 62, 234, 239, 239, 210, 209 }, "User2" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defeats", "Defense", "Fights", "HitPoints", "Intelligence", "Name", "Strength", "UserId", "Victories" },
                values: new object[] { 1, 1, 0, 10, 0, 100, 10, "Frodo", 15, 1, 0 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defeats", "Defense", "Fights", "HitPoints", "Intelligence", "Name", "Strength", "UserId", "Victories" },
                values: new object[] { 2, 3, 0, 11, 0, 100, 20, "Raistlin", 9, 2, 0 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[] { 1, 1, 20, "The Master Sword" });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[] { 2, 2, 5, "Crystal Wand" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterSkills",
                keyColumns: new[] { "CharacterId", "SkillId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterSkills",
                keyColumns: new[] { "CharacterId", "SkillId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterSkills",
                keyColumns: new[] { "CharacterId", "SkillId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
