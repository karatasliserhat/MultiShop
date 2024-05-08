using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.Order.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Detail",
                table: "Adddress",
                newName: "ZipCode");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Adddress",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Detail1",
                table: "Adddress",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Detail2",
                table: "Adddress",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Adddress",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Adddress",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Adddress",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Adddress",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Adddress");

            migrationBuilder.DropColumn(
                name: "Detail1",
                table: "Adddress");

            migrationBuilder.DropColumn(
                name: "Detail2",
                table: "Adddress");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Adddress");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Adddress");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Adddress");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Adddress");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Adddress",
                newName: "Detail");
        }
    }
}
