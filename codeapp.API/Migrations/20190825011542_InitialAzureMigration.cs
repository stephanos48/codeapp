using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace codeapp.API.Migrations
{
    public partial class InitialAzureMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    AccessFailedCount = table.Column<int>(nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    KnownAs = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastActive = table.Column<DateTime>(nullable: false),
                    Introduction = table.Column<string>(nullable: true),
                    LookingFor = table.Column<string>(nullable: true),
                    Interests = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDivisions",
                columns: table => new
                {
                    CustomerDivisionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerDivisionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDivisions", x => x.CustomerDivisionId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    Product = table.Column<string>(nullable: true),
                    Union = table.Column<bool>(nullable: false),
                    AnnualRevenue = table.Column<string>(nullable: true),
                    CompanyStart = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Dispositions",
                columns: table => new
                {
                    DispositionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DispositionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositions", x => x.DispositionId);
                });

            migrationBuilder.CreateTable(
                name: "MlsDivision",
                columns: table => new
                {
                    MlsDivisionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MlsDivisionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MlsDivision", x => x.MlsDivisionId);
                });

            migrationBuilder.CreateTable(
                name: "NcrStatuses",
                columns: table => new
                {
                    NcrStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NcrStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NcrStatuses", x => x.NcrStatusId);
                });

            migrationBuilder.CreateTable(
                name: "NcrTypes",
                columns: table => new
                {
                    NcrTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NcrTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NcrTypes", x => x.NcrTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Responsibles",
                columns: table => new
                {
                    ResponsibleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeName = table.Column<string>(nullable: true),
                    EmployeeTitle = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibles", x => x.ResponsibleId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupplierName = table.Column<string>(nullable: true),
                    SupplierNo = table.Column<string>(nullable: true),
                    SupplierType = table.Column<string>(nullable: true),
                    AnnualRev = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    SubCategory = table.Column<string>(nullable: true),
                    DetailCategory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    LikerId = table.Column<int>(nullable: false),
                    LikeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.LikerId, x.LikeeId });
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_LikeeId",
                        column: x => x.LikeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_LikerId",
                        column: x => x.LikerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SenderId = table.Column<int>(nullable: false),
                    RecipientId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    IsRead = table.Column<bool>(nullable: false),
                    DateRead = table.Column<DateTime>(nullable: true),
                    MessageSent = table.Column<DateTime>(nullable: false),
                    SenderDeleted = table.Column<bool>(nullable: false),
                    RecipientDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    PublicId = table.Column<string>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scrums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ResponsibleId = table.Column<int>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    CompletionDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scrums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scrums_Responsibles_ResponsibleId",
                        column: x => x.ResponsibleId,
                        principalTable: "Responsibles",
                        principalColumn: "ResponsibleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ncrs",
                columns: table => new
                {
                    NcrId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NcrNo = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    NcrTypeId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    CustomerDivisionId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    PartNumber = table.Column<string>(nullable: true),
                    PartDescription = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    PartCost = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    DefectDescription = table.Column<string>(nullable: true),
                    DefectCode = table.Column<string>(nullable: true),
                    MlsDivisionId = table.Column<int>(nullable: false),
                    DispositionId = table.Column<int>(nullable: false),
                    DispositionDate = table.Column<DateTime>(nullable: false),
                    DispositionBy = table.Column<string>(nullable: true),
                    NcrStatusId = table.Column<int>(nullable: false),
                    ReworkNo = table.Column<string>(nullable: true),
                    ReworkCompletedBy = table.Column<string>(nullable: true),
                    ReworkHrs = table.Column<string>(nullable: true),
                    ReworkPartsUsed = table.Column<string>(nullable: true),
                    ReworkPartsScrapped = table.Column<string>(nullable: true),
                    ReworkQty = table.Column<int>(nullable: false),
                    ReworkStatus = table.Column<string>(nullable: true),
                    ReworkNotes = table.Column<string>(nullable: true),
                    ScrapNo = table.Column<string>(nullable: true),
                    ScarpApprovedBy = table.Column<string>(nullable: true),
                    ScrapApprovalDate = table.Column<DateTime>(nullable: false),
                    ScarppedBy = table.Column<string>(nullable: true),
                    ScrapDate = table.Column<DateTime>(nullable: false),
                    ScrapQty = table.Column<int>(nullable: false),
                    ScrapStatus = table.Column<string>(nullable: true),
                    ScrapNotes = table.Column<string>(nullable: true),
                    CompletionDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ncrs", x => x.NcrId);
                    table.ForeignKey(
                        name: "FK_Ncrs_CustomerDivisions_CustomerDivisionId",
                        column: x => x.CustomerDivisionId,
                        principalTable: "CustomerDivisions",
                        principalColumn: "CustomerDivisionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ncrs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ncrs_Dispositions_DispositionId",
                        column: x => x.DispositionId,
                        principalTable: "Dispositions",
                        principalColumn: "DispositionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ncrs_MlsDivision_MlsDivisionId",
                        column: x => x.MlsDivisionId,
                        principalTable: "MlsDivision",
                        principalColumn: "MlsDivisionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ncrs_NcrStatuses_NcrStatusId",
                        column: x => x.NcrStatusId,
                        principalTable: "NcrStatuses",
                        principalColumn: "NcrStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ncrs_NcrTypes_NcrTypeId",
                        column: x => x.NcrTypeId,
                        principalTable: "NcrTypes",
                        principalColumn: "NcrTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ncrs_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikeeId",
                table: "Likes",
                column: "LikeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Ncrs_CustomerDivisionId",
                table: "Ncrs",
                column: "CustomerDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ncrs_CustomerId",
                table: "Ncrs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ncrs_DispositionId",
                table: "Ncrs",
                column: "DispositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ncrs_MlsDivisionId",
                table: "Ncrs",
                column: "MlsDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ncrs_NcrStatusId",
                table: "Ncrs",
                column: "NcrStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Ncrs_NcrTypeId",
                table: "Ncrs",
                column: "NcrTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ncrs_SupplierId",
                table: "Ncrs",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Scrums_ResponsibleId",
                table: "Scrums",
                column: "ResponsibleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Ncrs");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Scrums");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CustomerDivisions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Dispositions");

            migrationBuilder.DropTable(
                name: "MlsDivision");

            migrationBuilder.DropTable(
                name: "NcrStatuses");

            migrationBuilder.DropTable(
                name: "NcrTypes");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Responsibles");
        }
    }
}
