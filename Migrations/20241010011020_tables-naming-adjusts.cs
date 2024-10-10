using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DayMapper_BE.Migrations
{
    /// <inheritdoc />
    public partial class tablesnamingadjusts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_People_person_id",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_People_addresses_address_id",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_People_person_id",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_rol_id",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "people");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "customers");

            migrationBuilder.RenameIndex(
                name: "IX_Users_rol_id",
                table: "users",
                newName: "IX_users_rol_id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_person_id",
                table: "users",
                newName: "IX_users_person_id");

            migrationBuilder.RenameIndex(
                name: "IX_People_address_id",
                table: "people",
                newName: "IX_people_address_id");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_person_id",
                table: "customers",
                newName: "IX_customers_person_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_people",
                table: "people",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_customers_people_person_id",
                table: "customers",
                column: "person_id",
                principalTable: "people",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_people_addresses_address_id",
                table: "people",
                column: "address_id",
                principalTable: "addresses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_people_person_id",
                table: "users",
                column: "person_id",
                principalTable: "people",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_rol_id",
                table: "users",
                column: "rol_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customers_people_person_id",
                table: "customers");

            migrationBuilder.DropForeignKey(
                name: "FK_people_addresses_address_id",
                table: "people");

            migrationBuilder.DropForeignKey(
                name: "FK_users_people_person_id",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_rol_id",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_people",
                table: "people");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                table: "customers");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "people",
                newName: "People");

            migrationBuilder.RenameTable(
                name: "customers",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_users_rol_id",
                table: "Users",
                newName: "IX_Users_rol_id");

            migrationBuilder.RenameIndex(
                name: "IX_users_person_id",
                table: "Users",
                newName: "IX_Users_person_id");

            migrationBuilder.RenameIndex(
                name: "IX_people_address_id",
                table: "People",
                newName: "IX_People_address_id");

            migrationBuilder.RenameIndex(
                name: "IX_customers_person_id",
                table: "Customers",
                newName: "IX_Customers_person_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_People_person_id",
                table: "Customers",
                column: "person_id",
                principalTable: "People",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_addresses_address_id",
                table: "People",
                column: "address_id",
                principalTable: "addresses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_People_person_id",
                table: "Users",
                column: "person_id",
                principalTable: "People",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_rol_id",
                table: "Users",
                column: "rol_id",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
