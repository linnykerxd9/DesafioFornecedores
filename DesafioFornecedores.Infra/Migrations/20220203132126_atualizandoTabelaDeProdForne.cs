using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioFornecedores.Infra.Migrations
{
    public partial class atualizandoTabelaDeProdForne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "TB_Product",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TB_Product_SupplierId",
                table: "TB_Product",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Category_Name",
                table: "TB_Category",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Product_TB_Supplier_SupplierId",
                table: "TB_Product",
                column: "SupplierId",
                principalTable: "TB_Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Product_TB_Supplier_SupplierId",
                table: "TB_Product");

            migrationBuilder.DropIndex(
                name: "IX_TB_Product_SupplierId",
                table: "TB_Product");

            migrationBuilder.DropIndex(
                name: "IX_TB_Category_Name",
                table: "TB_Category");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "TB_Product");
        }
    }
}
