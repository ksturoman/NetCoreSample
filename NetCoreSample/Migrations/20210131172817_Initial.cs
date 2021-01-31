using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreSample.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTask", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "JobTask",
                columns: new[] { "Id", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9fdf8eb6-0613-44dd-853b-a244a880409d"), new DateTimeOffset(new DateTime(2021, 1, 31, 17, 28, 17, 486, DateTimeKind.Unspecified).AddTicks(4649), new TimeSpan(0, 0, 0, 0, 0)), 0, null },
                    { new Guid("ff40f52d-741c-4c6c-acc8-a423b9447678"), new DateTimeOffset(new DateTime(2021, 1, 31, 17, 28, 17, 486, DateTimeKind.Unspecified).AddTicks(5628), new TimeSpan(0, 0, 0, 0, 0)), 2, null },
                    { new Guid("b41d22f7-0f5e-41e1-88f0-afae48cd1d16"), new DateTimeOffset(new DateTime(2021, 1, 31, 17, 28, 17, 486, DateTimeKind.Unspecified).AddTicks(5650), new TimeSpan(0, 0, 0, 0, 0)), 1, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobTask");
        }
    }
}
