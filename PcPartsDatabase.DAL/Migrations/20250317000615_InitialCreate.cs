using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PcPartsDatabase.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GraphicsCards",
                columns: table => new
                {
                    GraphicsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GraphicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraphicCoreSpeed = table.Column<int>(type: "int", nullable: false),
                    GraphicSpeed = table.Column<int>(type: "int", nullable: false),
                    GraphicMemoryMB = table.Column<int>(type: "int", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphicsCards", x => x.GraphicsID);
                });

            migrationBuilder.CreateTable(
                name: "OperatingSystem",
                columns: table => new
                {
                    OsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOpenSource = table.Column<bool>(type: "bit", nullable: false),
                    OsDeveloper = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingSystem", x => x.OsID);
                });

            migrationBuilder.CreateTable(
                name: "Processor",
                columns: table => new
                {
                    ProcessorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoreSpeed = table.Column<int>(type: "int", nullable: false),
                    CoreNums = table.Column<int>(type: "int", nullable: false),
                    CacheAmount = table.Column<int>(type: "int", nullable: false),
                    isOverclockable = table.Column<bool>(type: "bit", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processor", x => x.ProcessorID);
                });

            migrationBuilder.CreateTable(
                name: "System",
                columns: table => new
                {
                    SystemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComputerDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessorID = table.Column<int>(type: "int", nullable: true),
                    GraphicsID = table.Column<int>(type: "int", nullable: true),
                    OsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System", x => x.SystemID);
                    table.ForeignKey(
                        name: "FK_System_GraphicsCards_GraphicsID",
                        column: x => x.GraphicsID,
                        principalTable: "GraphicsCards",
                        principalColumn: "GraphicsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_System_OperatingSystem_OsID",
                        column: x => x.OsID,
                        principalTable: "OperatingSystem",
                        principalColumn: "OsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_System_Processor_ProcessorID",
                        column: x => x.ProcessorID,
                        principalTable: "Processor",
                        principalColumn: "ProcessorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    StorageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageAmount = table.Column<int>(type: "int", nullable: false),
                    StorageBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSolidState = table.Column<bool>(type: "bit", nullable: false),
                    SystemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.StorageID);
                    table.ForeignKey(
                        name: "FK_Storage_System_SystemID",
                        column: x => x.SystemID,
                        principalTable: "System",
                        principalColumn: "SystemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Storage_SystemID",
                table: "Storage",
                column: "SystemID");

            migrationBuilder.CreateIndex(
                name: "IX_System_GraphicsID",
                table: "System",
                column: "GraphicsID");

            migrationBuilder.CreateIndex(
                name: "IX_System_OsID",
                table: "System",
                column: "OsID");

            migrationBuilder.CreateIndex(
                name: "IX_System_ProcessorID",
                table: "System",
                column: "ProcessorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "System");

            migrationBuilder.DropTable(
                name: "GraphicsCards");

            migrationBuilder.DropTable(
                name: "OperatingSystem");

            migrationBuilder.DropTable(
                name: "Processor");
        }
    }
}
