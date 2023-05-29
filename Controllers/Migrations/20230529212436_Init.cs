using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Controller.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Terminated = table.Column<bool>(type: "bit", nullable: false),
                    TerminatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayStubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gross = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Net = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FederalTaxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FICATaxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedicareTaxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StateTaxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deductions401K = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoursWorked = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Week = table.Column<short>(type: "smallint", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayStubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayStubs_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacationTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacationAvailable = table.Column<double>(type: "float", nullable: false),
                    VacationAvail = table.Column<double>(type: "float", nullable: false),
                    HolidayAvailable = table.Column<double>(type: "float", nullable: false),
                    HolidayAvail = table.Column<double>(type: "float", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacationTime_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "City", "Country", "CreatedDate", "Email", "FName", "LName", "PayRate", "Phone", "PostalCode", "Region", "Terminated", "TerminatedDate", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "One Apple Parkway", "Cupertino", "United States", new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(2990), "Joseph.Huntley@outlook.com", "Joseph", "Huntley", 32.50m, "(810) 555-1100", "123456", "California", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), ".Net Developer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "One Apple Parkway", "Cupertino", "United States", new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3040), "John.Doe@outlook.com", "John", "Doe", 27.56m, "(810) 555-1100", "123456", "California", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Designer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PayStubs",
                columns: new[] { "Id", "CreatedDate", "Date", "Deductions401K", "EmployeeId", "FICATaxes", "FederalTaxes", "Gross", "HoursWorked", "MedicareTaxes", "Net", "StateTaxes", "UpdatedDate", "Week" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3300), new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 17.20m, 1, 106.64m, 134.02m, 17.20m, 80.0, 24.94m, 1385.27m, 55.00m, new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3310), (short)4 },
                    { 2, new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3320), new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 17.20m, 1, 106.64m, 134.02m, 17.20m, 80.0, 24.94m, 1385.27m, 55.00m, new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3330), (short)4 },
                    { 3, new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3380), new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 17.20m, 2, 106.64m, 134.02m, 17.20m, 80.0, 24.94m, 1385.27m, 55.00m, new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3390), (short)4 },
                    { 4, new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3410), new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 17.20m, 2, 106.64m, 134.02m, 17.20m, 80.0, 24.94m, 1385.27m, 55.00m, new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3410), (short)4 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "EmployeeId", "Password", "Salt", "UpdatedDate", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 29, 17, 24, 36, 488, DateTimeKind.Local).AddTicks(60), 1, "50C2C9A046D2EACA5181ACE70C24DCCC57954C8368F90B6FEC4D24CF1C1ECEA7E724F46D459A459C4F9B668DD2DA7F7C42E1BF43E0551A3F845F5DE83B8AD192", new byte[] { 199, 225, 157, 13, 34, 106, 174, 94, 95, 47, 127, 174, 102, 2, 255, 211, 160, 40, 21, 167, 12, 171, 140, 92, 205, 71, 12, 180, 36, 213, 56, 118, 216, 64, 221, 46, 72, 88, 189, 145, 50, 10, 251, 79, 254, 163, 178, 167, 166, 113, 15, 113, 68, 165, 178, 168, 56, 120, 220, 148, 122, 126, 134, 246 }, new DateTime(2023, 5, 29, 17, 24, 36, 488, DateTimeKind.Local).AddTicks(120), "Joseph.Huntley" },
                    { 2, new DateTime(2023, 5, 29, 17, 24, 36, 727, DateTimeKind.Local).AddTicks(870), 2, "EE85A9BB8C831235B1254239477244D475480F3179BA8831B94A1D4509EBEAB4A7E3372E47E6CA225B214AA2AB863664552A39C427DC3E8557E96F50D3F4A012", new byte[] { 133, 179, 232, 164, 219, 140, 103, 45, 242, 129, 104, 59, 143, 88, 66, 194, 37, 78, 130, 79, 52, 141, 44, 233, 121, 249, 172, 90, 16, 198, 67, 202, 206, 239, 5, 206, 2, 12, 224, 155, 199, 71, 243, 235, 100, 220, 149, 244, 154, 60, 104, 34, 125, 131, 104, 20, 183, 250, 209, 197, 194, 182, 3, 36 }, new DateTime(2023, 5, 29, 17, 24, 36, 727, DateTimeKind.Local).AddTicks(920), "John.Doe" }
                });

            migrationBuilder.InsertData(
                table: "VacationTime",
                columns: new[] { "Id", "CreatedDate", "EmployeeId", "HolidayAvail", "HolidayAvailable", "UpdatedDate", "VacationAvail", "VacationAvailable" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3450), 1, 6.0, 16.0, new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3460), 20.0, 100.0 },
                    { 2, new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3460), 2, 8.0, 12.0, new DateTime(2023, 5, 29, 17, 24, 36, 196, DateTimeKind.Local).AddTicks(3470), 16.0, 104.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayStubs_EmployeeId",
                table: "PayStubs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeId",
                table: "Users",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationTime_EmployeeId",
                table: "VacationTime",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayStubs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VacationTime");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
