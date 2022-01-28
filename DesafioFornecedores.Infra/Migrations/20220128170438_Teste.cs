using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioFornecedores.Infra.Migrations
{
    public partial class Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "TB_Supplier");

            migrationBuilder.DropColumn(
                name: "SupplierPhysical_SupplierId",
                table: "TB_Supplier");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "TB_Supplier",
                type: "varchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "TB_Supplier",
                type: "varchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "TB_Supplier",
                type: "varchar(11)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "TB_Supplier",
                type: "varchar(14)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "TB_Supplier",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierPhysical_SupplierId",
                table: "TB_Supplier",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
