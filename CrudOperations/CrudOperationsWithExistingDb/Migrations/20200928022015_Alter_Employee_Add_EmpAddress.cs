using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudOperationsWithExistingDb.Migrations
{
    public partial class Alter_Employee_Add_EmpAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Department",
            //    columns: table => new
            //    {
            //        PKDepartmentId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DepartmentName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
            //        IsActive = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Department", x => x.PKDepartmentId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Employee",
            //    columns: table => new
            //    {
            //        PKEmployeeId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FKDeptId = table.Column<int>(nullable: false),
            //        EmployeeName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
            //        EmployeeSalary = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
            //        EmployeeAddress = table.Column<string>(maxLength: 250, nullable: true, defaultValue: ""),
            //        IsActive = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Employee", x => x.PKEmployeeId);
            //        table.ForeignKey(
            //            name: "FK_Employee_Department",
            //            column: x => x.FKDeptId,
            //            principalTable: "Department",
            //            principalColumn: "PKDepartmentId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Employee_FKDeptId",
            //    table: "Employee",
            //    column: "FKDeptId");


            migrationBuilder.AddColumn<string>("EmployeeAddress", "Employee", maxLength: 250, defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Employee");

            //migrationBuilder.DropTable(
            //    name: "Department");

            migrationBuilder.DropColumn("EmployeeAddress", "Employee");
        }
    }
}
