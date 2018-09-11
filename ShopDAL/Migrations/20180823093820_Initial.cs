using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DaycareDAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    SubNumber = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountRelations",
                columns: table => new
                {
                    AccountRelationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RelationType = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    ObjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRelations", x => x.AccountRelationId);
                    table.ForeignKey(
                        name: "FK_AccountRelations_Accounts_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountRelations_Accounts_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "Code", "Name" },
                values: new object[] { 1, 9820, "Merelbeke" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "CityId", "Number", "Street", "SubNumber" },
                values: new object[] { 1, 1, 35, "Hundelgemsesteenweg", 4 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AddressId", "FirstName", "LastName" },
                values: new object[] { 1, 1, "Jos", "Baert" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AddressId", "FirstName", "LastName" },
                values: new object[] { 2, 1, "Hanelore", "Baert" });

            migrationBuilder.InsertData(
                table: "AccountRelations",
                columns: new[] { "AccountRelationId", "ObjectId", "RelationType", "SubjectId" },
                values: new object[] { 1, 2, 0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AccountRelations_ObjectId",
                table: "AccountRelations",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRelations_SubjectId",
                table: "AccountRelations",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AddressId",
                table: "Accounts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountRelations");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
