using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sofa.CourseManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Institutes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address_Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address_State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address_Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Role = table.Column<int>(type: "int", nullable: true),
                    RoleTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true),
                    LevelTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InstituteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstituteId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Field_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Field_Institutes_InstituteId1",
                        column: x => x.InstituteId1,
                        principalTable: "Institutes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InstituteUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstituteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituteUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstituteUser_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstituteUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstituteUser_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AgeRange = table.Column<int>(type: "int", nullable: true),
                    AgeRangeTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Field_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true),
                    LevelTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    TypeTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldQuestion_Field_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldQuestion_Field_FieldId1",
                        column: x => x.FieldId1,
                        principalTable: "Field",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseLanguage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Language = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseLanguage_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursePlacement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePlacement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursePlacement_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePlacement_Course_CourseId1",
                        column: x => x.CourseId1,
                        principalTable: "Course",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseUser_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseUser_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OccurredDate = table.Column<DateTimeOffset>(type: "datetimeoffset", maxLength: 34, nullable: true),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Session_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Session_Course_CourseId1",
                        column: x => x.CourseId1,
                        principalTable: "Course",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FieldQuestionChoice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsAnswer = table.Column<bool>(type: "bit", nullable: false),
                    FieldQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldQuestionChoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldQuestionChoice_FieldQuestion_FieldQuestionId",
                        column: x => x.FieldQuestionId,
                        principalTable: "FieldQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostQuestion_FieldQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "FieldQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursePlacementQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<short>(type: "smallint", nullable: true),
                    PlacementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    coursePlacementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePlacementQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursePlacementQuestion_CoursePlacement_PlacementId",
                        column: x => x.PlacementId,
                        principalTable: "CoursePlacement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePlacementQuestion_CoursePlacement_coursePlacementId",
                        column: x => x.coursePlacementId,
                        principalTable: "CoursePlacement",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CoursePlacementQuestion_FieldQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "FieldQuestion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LessonPlan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CourseLanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonPlan_CourseLanguage_CourseLanguageId",
                        column: x => x.CourseLanguageId,
                        principalTable: "CourseLanguage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LessonPlan_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonPlan_Session_SessionId1",
                        column: x => x.SessionId1,
                        principalTable: "Session",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostBase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Order = table.Column<short>(type: "smallint", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ContentType = table.Column<int>(type: "int", nullable: true),
                    ContentTypeTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LessonPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonPlanId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
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
                        name: "FK_PostBase_LessonPlan_LessonPlanId1",
                        column: x => x.LessonPlanId1,
                        principalTable: "LessonPlan",
                        principalColumn: "Id");
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
                name: "IX_Course_FieldId",
                table: "Course",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Id",
                table: "Course",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseLanguage_CourseId",
                table: "CourseLanguage",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLanguage_Id",
                table: "CourseLanguage",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePlacement_CourseId",
                table: "CoursePlacement",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePlacement_CourseId1",
                table: "CoursePlacement",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePlacement_Id",
                table: "CoursePlacement",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePlacementQuestion_coursePlacementId",
                table: "CoursePlacementQuestion",
                column: "coursePlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePlacementQuestion_Id",
                table: "CoursePlacementQuestion",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursePlacementQuestion_PlacementId",
                table: "CoursePlacementQuestion",
                column: "PlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePlacementQuestion_QuestionId",
                table: "CoursePlacementQuestion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseUser_CourseId",
                table: "CourseUser",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseUser_Id",
                table: "CourseUser",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseUser_UserId",
                table: "CourseUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseUser_UserId1",
                table: "CourseUser",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Field_Id",
                table: "Field",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Field_InstituteId",
                table: "Field",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Field_InstituteId1",
                table: "Field",
                column: "InstituteId1");

            migrationBuilder.CreateIndex(
                name: "IX_FieldQuestion_FieldId",
                table: "FieldQuestion",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldQuestion_FieldId1",
                table: "FieldQuestion",
                column: "FieldId1");

            migrationBuilder.CreateIndex(
                name: "IX_FieldQuestion_Id",
                table: "FieldQuestion",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FieldQuestionChoice_FieldQuestionId",
                table: "FieldQuestionChoice",
                column: "FieldQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldQuestionChoice_Id",
                table: "FieldQuestionChoice",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImagePost_Id",
                table: "ImagePost",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Institutes_Id",
                table: "Institutes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstituteUser_Id",
                table: "InstituteUser",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstituteUser_InstituteId",
                table: "InstituteUser",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteUser_UserId",
                table: "InstituteUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteUser_UserId1",
                table: "InstituteUser",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlan_CourseLanguageId",
                table: "LessonPlan",
                column: "CourseLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlan_Id",
                table: "LessonPlan",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlan_SessionId",
                table: "LessonPlan",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonPlan_SessionId1",
                table: "LessonPlan",
                column: "SessionId1");

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
                name: "IX_PostBase_LessonPlanId1",
                table: "PostBase",
                column: "LessonPlanId1");

            migrationBuilder.CreateIndex(
                name: "IX_PostBase_QuestionId",
                table: "PostBase",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostQuestion_Id",
                table: "PostQuestion",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostQuestion_QuestionId",
                table: "PostQuestion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_CourseId",
                table: "Session",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_CourseId1",
                table: "Session",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_Session_Id",
                table: "Session",
                column: "Id",
                unique: true);

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
                name: "IX_User_Id",
                table: "User",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoPost_Id",
                table: "VideoPost",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursePlacementQuestion");

            migrationBuilder.DropTable(
                name: "CourseUser");

            migrationBuilder.DropTable(
                name: "FieldQuestionChoice");

            migrationBuilder.DropTable(
                name: "ImagePost");

            migrationBuilder.DropTable(
                name: "InstituteUser");

            migrationBuilder.DropTable(
                name: "SoundPost");

            migrationBuilder.DropTable(
                name: "TextPost");

            migrationBuilder.DropTable(
                name: "VideoPost");

            migrationBuilder.DropTable(
                name: "CoursePlacement");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "PostBase");

            migrationBuilder.DropTable(
                name: "LessonPlan");

            migrationBuilder.DropTable(
                name: "PostQuestion");

            migrationBuilder.DropTable(
                name: "CourseLanguage");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "FieldQuestion");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "Institutes");
        }
    }
}
