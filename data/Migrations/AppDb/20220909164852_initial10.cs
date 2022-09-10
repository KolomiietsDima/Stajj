using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations.AppDb
{
    public partial class initial10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "MessageReply",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ChatId",
                table: "Participants",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_UserId",
                table: "Participants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReply_MessageId",
                table: "MessageReply",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ChatId",
                table: "Message",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId",
                table: "Message",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Chat_ChatId",
                table: "Message",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_UserId",
                table: "Message",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReply_Message_MessageId",
                table: "MessageReply",
                column: "MessageId",
                principalTable: "Message",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Chat_ChatId",
                table: "Participants",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Users_UserId",
                table: "Participants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Chat_ChatId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Users_UserId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageReply_Message_MessageId",
                table: "MessageReply");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Chat_ChatId",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Users_UserId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_ChatId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_UserId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_MessageReply_MessageId",
                table: "MessageReply");

            migrationBuilder.DropIndex(
                name: "IX_Message_ChatId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_UserId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "MessageReply");
        }
    }
}
