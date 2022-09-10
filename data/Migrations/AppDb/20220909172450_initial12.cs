using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations.AppDb
{
    public partial class initial12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageReply_Message_MessageId",
                table: "MessageReply");

            migrationBuilder.DropIndex(
                name: "IX_MessageReply_MessageId",
                table: "MessageReply");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "MessageReply");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReply_Id_MessageForward",
                table: "MessageReply",
                column: "Id_MessageForward");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReply_Message_Id_MessageForward",
                table: "MessageReply",
                column: "Id_MessageForward",
                principalTable: "Message",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageReply_Message_Id_MessageForward",
                table: "MessageReply");

            migrationBuilder.DropIndex(
                name: "IX_MessageReply_Id_MessageForward",
                table: "MessageReply");

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "MessageReply",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageReply_MessageId",
                table: "MessageReply",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReply_Message_MessageId",
                table: "MessageReply",
                column: "MessageId",
                principalTable: "Message",
                principalColumn: "Id");
        }
    }
}
