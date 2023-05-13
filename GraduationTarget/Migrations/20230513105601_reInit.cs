using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationTarget.Migrations
{
    public partial class reInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "86539f96-572f-4e33-8291-a4ef290cf687", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "51a1c460-8290-44ef-a27a-3a95884cd159", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "c54dcce6-7263-40f8-947f-1e21f7b32b07", "PROJECTOWNER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "ee387cfa-39b4-4643-be11-777a51f6a26b", "CURATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "32cb141e-26da-4ab4-bc5c-5876bfeb2465", "AQAAAAEAACcQAAAAEH5PBBB4bcq/MJuowNHtfvgxIqFMthEDX2Qkhcila8SS58aVRypU+oJDMdbUCwLpNQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "fb74ec71-9560-4e27-97fd-ee9e40468b14", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "7e872e68-604a-4ad6-9572-cfba26553771", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "8c4f0bb2-3a9d-4c6d-81ae-2ea8b7ac6169", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "ed26eff0-4f6a-4288-b178-abbf3b990623", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "607267ed-8d02-4ea6-9b29-d929ec5274ed", "AQAAAAEAACcQAAAAEEwcGYdUaDdDZitd664SbWDTE9CaTnnC8Ox/+mpLgwG+hB43+8SNt5qN9DO/4bTJrQ==" });
        }
    }
}
