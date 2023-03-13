using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bugtracker_api_net.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BugTrackerCompany",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugTrackerCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BugTrackerEmployees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActivated = table.Column<bool>(type: "boolean", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    PreviousPasswordsHash = table.Column<List<string>>(type: "text[]", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    IsLockout = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugTrackerEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BugTrackerEmployees_BugTrackerCompany_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "BugTrackerCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BugTrackerManager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyID = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    PreviousPasswordsHash = table.Column<List<string>>(type: "text[]", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    IsLockout = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugTrackerManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BugTrackerManager_BugTrackerCompany_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "BugTrackerCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BugTrackerProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugTrackerProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BugTrackerProjects_BugTrackerCompany_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "BugTrackerCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BugTrackerNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NotificationMessage = table.Column<string>(type: "text", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    ManagerId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugTrackerNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BugTrackerNotifications_BugTrackerEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "BugTrackerEmployees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BugTrackerNotifications_BugTrackerManager_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "BugTrackerManager",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BugTrackerIssues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DueTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugTrackerIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BugTrackerIssues_BugTrackerCompany_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "BugTrackerCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BugTrackerIssues_BugTrackerEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "BugTrackerEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BugTrackerIssues_BugTrackerProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BugTrackerProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BugTrackerReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientFirstName = table.Column<string>(type: "text", nullable: false),
                    ClientLastName = table.Column<string>(type: "text", nullable: false),
                    ClientEmail = table.Column<string>(type: "text", nullable: false),
                    Rate = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugTrackerReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BugTrackerReviews_BugTrackerCompany_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "BugTrackerCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BugTrackerReviews_BugTrackerProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BugTrackerProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BugTrackerReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    IssueID = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugTrackerReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BugTrackerReports_BugTrackerCompany_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "BugTrackerCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BugTrackerReports_BugTrackerEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "BugTrackerEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BugTrackerReports_BugTrackerIssues_IssueID",
                        column: x => x.IssueID,
                        principalTable: "BugTrackerIssues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BugTrackerReports_BugTrackerProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BugTrackerProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerEmployees_CompanyId",
                table: "BugTrackerEmployees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerIssues_CompanyId",
                table: "BugTrackerIssues",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerIssues_EmployeeId",
                table: "BugTrackerIssues",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerIssues_ProjectId",
                table: "BugTrackerIssues",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerManager_CompanyID",
                table: "BugTrackerManager",
                column: "CompanyID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerNotifications_EmployeeId",
                table: "BugTrackerNotifications",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerNotifications_ManagerId",
                table: "BugTrackerNotifications",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerProjects_CompanyId",
                table: "BugTrackerProjects",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerReports_CompanyId",
                table: "BugTrackerReports",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerReports_EmployeeId",
                table: "BugTrackerReports",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerReports_IssueID",
                table: "BugTrackerReports",
                column: "IssueID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerReports_ProjectId",
                table: "BugTrackerReports",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerReviews_CompanyId",
                table: "BugTrackerReviews",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerReviews_ProjectId",
                table: "BugTrackerReviews",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BugTrackerNotifications");

            migrationBuilder.DropTable(
                name: "BugTrackerReports");

            migrationBuilder.DropTable(
                name: "BugTrackerReviews");

            migrationBuilder.DropTable(
                name: "BugTrackerManager");

            migrationBuilder.DropTable(
                name: "BugTrackerIssues");

            migrationBuilder.DropTable(
                name: "BugTrackerEmployees");

            migrationBuilder.DropTable(
                name: "BugTrackerProjects");

            migrationBuilder.DropTable(
                name: "BugTrackerCompany");
        }
    }
}
