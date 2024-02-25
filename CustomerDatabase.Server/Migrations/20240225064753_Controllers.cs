using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerDatabase.Server.Migrations
{
    /// <inheritdoc />
    public partial class Controllers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    adressLineOne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adressLineTwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "custPhone",
                columns: table => new
                {
                    custPhoneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    PhoneID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custPhone", x => x.custPhoneID);
                    table.ForeignKey(
                        name: "FK_custPhone_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    EmailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.EmailId);
                    table.ForeignKey(
                        name: "FK_Email_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    PhoneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.PhoneID);
                });

            migrationBuilder.CreateTable(
                name: "custAddress",
                columns: table => new
                {
                    CustAddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custAddress", x => x.CustAddressID);
                    table.ForeignKey(
                        name: "FK_custAddress_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_custAddress_address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zipcode",
                columns: table => new
                {
                    ZipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CityAndState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zipcode", x => x.ZipId);
                    table.ForeignKey(
                        name: "FK_Zipcode_address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CallHistory",
                columns: table => new
                {
                    HistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    PhoneID = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumberPhoneID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallHistory", x => x.HistoryID);
                    table.ForeignKey(
                        name: "FK_CallHistory_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallHistory_PhoneNumber_PhoneNumberPhoneID",
                        column: x => x.PhoneNumberPhoneID,
                        principalTable: "PhoneNumber",
                        principalColumn: "PhoneID");
                });

            migrationBuilder.CreateTable(
                name: "custZip",
                columns: table => new
                {
                    CustZipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    ZipID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ZipcodeZipId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custZip", x => x.CustZipID);
                    table.ForeignKey(
                        name: "FK_custZip_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_custZip_Zipcode_ZipcodeZipId",
                        column: x => x.ZipcodeZipId,
                        principalTable: "Zipcode",
                        principalColumn: "ZipId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallHistory_CustomerID",
                table: "CallHistory",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CallHistory_PhoneNumberPhoneID",
                table: "CallHistory",
                column: "PhoneNumberPhoneID");

            migrationBuilder.CreateIndex(
                name: "IX_custAddress_AddressID",
                table: "custAddress",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_custAddress_CustomerID",
                table: "custAddress",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_custPhone_CustomerID",
                table: "custPhone",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_custZip_CustomerID",
                table: "custZip",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_custZip_ZipcodeZipId",
                table: "custZip",
                column: "ZipcodeZipId");

            migrationBuilder.CreateIndex(
                name: "IX_Email_CustomerID",
                table: "Email",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Zipcode_AddressID",
                table: "Zipcode",
                column: "AddressID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallHistory");

            migrationBuilder.DropTable(
                name: "custAddress");

            migrationBuilder.DropTable(
                name: "custPhone");

            migrationBuilder.DropTable(
                name: "custZip");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "Zipcode");

            migrationBuilder.DropTable(
                name: "address");
        }
    }
}
