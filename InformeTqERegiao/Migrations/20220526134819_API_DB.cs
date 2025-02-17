﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace InformeTqERegiao.Migrations
{
    public partial class API_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cidades",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cidades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "problemaDialogocs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_problemaDialogocs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidadesid = table.Column<int>(type: "int", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_cidades_Cidadesid",
                        column: x => x.Cidadesid,
                        principalTable: "cidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "permisao_usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    PermissaoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permisao_usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_permisao_usuario_permissao_PermissaoID",
                        column: x => x.PermissaoID,
                        principalTable: "permissao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_permisao_usuario_usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_permisao_usuario_PermissaoID",
                table: "permisao_usuario",
                column: "PermissaoID");

            migrationBuilder.CreateIndex(
                name: "IX_permisao_usuario_UsuarioID",
                table: "permisao_usuario",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_Cidadesid",
                table: "usuarios",
                column: "Cidadesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "permisao_usuario");

            migrationBuilder.DropTable(
                name: "problemaDialogocs");

            migrationBuilder.DropTable(
                name: "permissao");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "cidades");
        }
    }
}
