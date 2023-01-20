using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayementSystem.Migrations
{
    /// <inheritdoc />
    public partial class jobs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /* migrationBuilder.DropForeignKey(
                name: "FK_Payment_Recipient_RecipientID",
                table: "Payment"); */

            migrationBuilder.AddColumn<int>(
                name: "JobID",
                table: "Recipient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RecipientID",
                table: "Payment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipient_JobID",
                table: "Recipient",
                column: "JobID");

            /* migrationBuilder.AddForeignKey(
                name: "FK_Payment_Recipient_RecipientID",
                table: "Payment",
                column: "RecipientID",
                principalTable: "Recipient",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipient_Job_JobID",
                table: "Recipient",
                column: "JobID",
                principalTable: "Job",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade); */
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Recipient_RecipientID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipient_Job_JobID",
                table: "Recipient");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Recipient_JobID",
                table: "Recipient");

            migrationBuilder.DropColumn(
                name: "JobID",
                table: "Recipient");

            migrationBuilder.AlterColumn<int>(
                name: "RecipientID",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Recipient_RecipientID",
                table: "Payment",
                column: "RecipientID",
                principalTable: "Recipient",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
