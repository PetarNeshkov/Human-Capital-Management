using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanCapitalManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEmployeeProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "Employees",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Employees",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Employees",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Employees");
        }
    }
}
