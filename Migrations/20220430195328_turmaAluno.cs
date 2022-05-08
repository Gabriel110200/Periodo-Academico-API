using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class turmaAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Turmas_TurmaId",
                table: "Aluno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aluno",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Turmas");

            migrationBuilder.RenameTable(
                name: "Aluno",
                newName: "Alunos");

            migrationBuilder.RenameIndex(
                name: "IX_Aluno_TurmaId",
                table: "Alunos",
                newName: "IX_Alunos_TurmaId");

            migrationBuilder.AlterColumn<int>(
                name: "TurmaId",
                table: "Alunos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alunos",
                table: "Alunos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alunos",
                table: "Alunos");

            migrationBuilder.RenameTable(
                name: "Alunos",
                newName: "Aluno");

            migrationBuilder.RenameIndex(
                name: "IX_Alunos_TurmaId",
                table: "Aluno",
                newName: "IX_Aluno_TurmaId");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Turmas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TurmaId",
                table: "Aluno",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aluno",
                table: "Aluno",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Turmas_TurmaId",
                table: "Aluno",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
