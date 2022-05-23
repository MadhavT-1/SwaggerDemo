using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SwaggerDemo.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "acl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    readUsers = table.Column<List<string>>(type: "text[]", nullable: true),
                    readGroups = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    businessUnit = table.Column<string>(type: "text", nullable: true),
                    aclsId = table.Column<int>(type: "integer", nullable: true),
                    expiryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BUnit_acl_aclsId",
                        column: x => x.aclsId,
                        principalTable: "acl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "attributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    key = table.Column<string>(type: "text", nullable: true),
                    value = table.Column<string>(type: "text", nullable: true),
                    BUnitId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_attributes_BUnit_BUnitId",
                        column: x => x.BUnitId,
                        principalTable: "BUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    filename = table.Column<string>(type: "text", nullable: true),
                    fileSize = table.Column<int>(type: "integer", nullable: false),
                    mimeType = table.Column<string>(type: "text", nullable: true),
                    hash = table.Column<string>(type: "text", nullable: true),
                    attrId = table.Column<int>(type: "integer", nullable: true),
                    BUnitId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_files_attributes_attrId",
                        column: x => x.attrId,
                        principalTable: "attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_files_BUnit_BUnitId",
                        column: x => x.BUnitId,
                        principalTable: "BUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_attributes_BUnitId",
                table: "attributes",
                column: "BUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BUnit_aclsId",
                table: "BUnit",
                column: "aclsId");

            migrationBuilder.CreateIndex(
                name: "IX_files_attrId",
                table: "files",
                column: "attrId");

            migrationBuilder.CreateIndex(
                name: "IX_files_BUnitId",
                table: "files",
                column: "BUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "files");

            migrationBuilder.DropTable(
                name: "attributes");

            migrationBuilder.DropTable(
                name: "BUnit");

            migrationBuilder.DropTable(
                name: "acl");
        }
    }
}
