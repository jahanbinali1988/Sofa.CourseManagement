using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sofa.CourseManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remove_post_types : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagePost");

            migrationBuilder.DropTable(
                name: "SoundPost");

            migrationBuilder.DropTable(
                name: "TextPost");

            migrationBuilder.DropTable(
                name: "VideoPost");

            migrationBuilder.DropTable(
                name: "PostBase");

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Order = table.Column<short>(type: "smallint", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ContentType = table.Column<int>(type: "int", nullable: true),
                    ContentTypeTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LessonPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_LessonPlan_LessonPlanId",
                        column: x => x.LessonPlanId,
                        principalTable: "LessonPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostQuestion_PostId",
                table: "PostQuestion",
                column: "PostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_Id",
                table: "Post",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_LessonPlanId",
                table: "Post",
                column: "LessonPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostQuestion_Post_PostId",
                table: "PostQuestion",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostQuestion_Post_PostId",
                table: "PostQuestion");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropIndex(
                name: "IX_PostQuestion_PostId",
                table: "PostQuestion");

            migrationBuilder.CreateTable(
                name: "PostBase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    LessonPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ContentTypeTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContentType = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<short>(type: "smallint", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostBase_LessonPlan_LessonPlanId",
                        column: x => x.LessonPlanId,
                        principalTable: "LessonPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostBase_PostQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "PostQuestion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImagePost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagePost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagePost_PostBase_Id",
                        column: x => x.Id,
                        principalTable: "PostBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoundPost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoundPost_PostBase_Id",
                        column: x => x.Id,
                        principalTable: "PostBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TextPost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextPost_PostBase_Id",
                        column: x => x.Id,
                        principalTable: "PostBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoPost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoPost_PostBase_Id",
                        column: x => x.Id,
                        principalTable: "PostBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagePost_Id",
                table: "ImagePost",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostBase_Id",
                table: "PostBase",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostBase_LessonPlanId",
                table: "PostBase",
                column: "LessonPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PostBase_QuestionId",
                table: "PostBase",
                column: "QuestionId",
                unique: true,
                filter: "[QuestionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SoundPost_Id",
                table: "SoundPost",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TextPost_Id",
                table: "TextPost",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoPost_Id",
                table: "VideoPost",
                column: "Id",
                unique: true);
        }
    }
}
