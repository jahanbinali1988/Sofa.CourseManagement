using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sofa.CourseManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class replace_priority_with_occurreddate_in_session : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OccurredDate",
                table: "Session");

            migrationBuilder.AddColumn<byte>(
                name: "Priority",
                table: "Session",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Session");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "OccurredDate",
                table: "Session",
                type: "datetimeoffset",
                maxLength: 34,
                nullable: true);
        }
    }
}
