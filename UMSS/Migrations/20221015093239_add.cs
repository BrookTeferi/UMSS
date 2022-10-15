﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace UMSS.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ef2e91f-3a30-455d-82e8-dabc58d20526", "a6a6b076-6e2d-4f25-95e9-aa71c59d41a1", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "8ef2e91f-3a30-455d-82e8-dabc58d20526");
        }
    }
}
