using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Kalbe.Migrations
{
    /// <inheritdoc />
    public partial class StudyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_molecules",
                columns: table => new
                {
                    IdMolecules = table.Column<Guid>(type: "uuid", nullable: false),
                    MoleculesName = table.Column<string>(type: "text", nullable: false),
                    MolDescription = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_molecules", x => x.IdMolecules);
                });

            migrationBuilder.CreateTable(
                name: "m_study_status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_study_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "m_study",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudyId = table.Column<string>(type: "text", nullable: false),
                    VersionId = table.Column<int>(type: "integer", nullable: false),
                    ProtocolTitle = table.Column<string>(type: "text", nullable: false),
                    ProtocolCode = table.Column<string>(type: "text", nullable: false),
                    MoleculesId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudyStatusId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_study", x => x.Id);
                    table.ForeignKey(
                        name: "FK_m_study_m_molecules_MoleculesId",
                        column: x => x.MoleculesId,
                        principalTable: "m_molecules",
                        principalColumn: "IdMolecules",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_m_study_m_study_status_StudyStatusId",
                        column: x => x.StudyStatusId,
                        principalTable: "m_study_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_study_MoleculesId",
                table: "m_study",
                column: "MoleculesId");

            migrationBuilder.CreateIndex(
                name: "IX_m_study_StudyStatusId",
                table: "m_study",
                column: "StudyStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_study");

            migrationBuilder.DropTable(
                name: "m_molecules");

            migrationBuilder.DropTable(
                name: "m_study_status");
        }
    }
}
