using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraineeTracker.App.Migrations
{
    /// <inheritdoc />
    public partial class GradeCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "TrackerItems",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PercentGrade",
                table: "TrackerItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "TrackerItems");

            migrationBuilder.DropColumn(
                name: "PercentGrade",
                table: "TrackerItems");
        }
    }
}
