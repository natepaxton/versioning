using Microsoft.EntityFrameworkCore.Migrations;
using VersioningDemo.Helpers;

#nullable disable

namespace VersioningDemo.Migrations
{
    /// <inheritdoc />
    public partial class WidgetsQuery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = SqlHelpers.GetEmbeddedResource("usp_WidgetsQuery_V00.sql");
            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            return;
        }
    }
}
