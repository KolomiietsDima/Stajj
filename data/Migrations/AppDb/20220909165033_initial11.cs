using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations.AppDb
{
    public partial class initial11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageReply_Message_MessageId",
                table: "MessageReply");

            migrationBuilder.AlterColumn<int>(
                name: "MessageId",
                table: "MessageReply",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReply_Message_MessageId",
                table: "MessageReply",
                column: "MessageId",
                principalTable: "Message",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageReply_Message_MessageId",
                table: "MessageReply");

            migrationBuilder.AlterColumn<int>(
                name: "MessageId",
                table: "MessageReply",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReply_Message_MessageId",
                table: "MessageReply",
                column: "MessageId",
                principalTable: "Message",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
