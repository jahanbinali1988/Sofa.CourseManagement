using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sofa.CourseManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class rename_priority_to_order_in_session : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Session",
                newName: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Session",
                newName: "Priority");
        }
    }
}
