using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudOperationUsingCF.Migrations
{
    public partial class add_dept_alter_employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FKDeptId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_FKDeptId",
                table: "Employees",
                column: "FKDeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Department_FKDeptId",
                table: "Employees",
                column: "FKDeptId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_FKDeptId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Employees_FKDeptId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FKDeptId",
                table: "Employees");
        }
    }
}
