using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "data");

            migrationBuilder.CreateTable(
                name: "ApplicationEntityAccessExpressions",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationEntityId = table.Column<int>(type: "int", nullable: false),
                    PropertyApplicationEntityId = table.Column<int>(type: "int", nullable: true),
                    PropertyAccessExpresion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContextAccessExpresion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationEntityAccessExpressions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationEntityProperties",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationEntityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsStandard = table.Column<bool>(type: "bit", nullable: false),
                    IsNullable = table.Column<bool>(type: "bit", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncludeInName = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationEntityProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Communications",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationEntityId = table.Column<int>(type: "int", nullable: false),
                    CommunicationTemplateId = table.Column<int>(type: "int", nullable: false),
                    eId = table.Column<int>(type: "int", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationTemplates",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationEntityId = table.Column<int>(type: "int", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommunicationTypeId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromId = table.Column<int>(type: "int", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityScripts",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmitEventType = table.Column<int>(type: "int", nullable: false),
                    ScriptId = table.Column<int>(type: "int", nullable: false),
                    ApplicationEntityId = table.Column<int>(type: "int", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityScripts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filters",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationEntityId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationEntityId = table.Column<int>(type: "int", nullable: true),
                    IsPreferred = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnershipEntityAccesses",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationEntityId = table.Column<int>(type: "int", nullable: true),
                    IntUserId = table.Column<int>(type: "int", nullable: false),
                    eId = table.Column<int>(type: "int", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnershipEntityAccesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StateActions",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationEntityId = table.Column<int>(type: "int", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldTypeId = table.Column<int>(type: "int", nullable: false),
                    ApplicationEntityPropertyId = table.Column<int>(type: "int", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    IsStandard = table.Column<bool>(type: "bit", nullable: false),
                    IsMultiSelect = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    IncludeInName = table.Column<bool>(type: "bit", nullable: false),
                    NameTransform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_ApplicationEntityProperties_ApplicationEntityPropertyId",
                        column: x => x.ApplicationEntityPropertyId,
                        principalSchema: "data",
                        principalTable: "ApplicationEntityProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StateActionStatements",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateActionId = table.Column<int>(type: "int", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationEntityPropertyId = table.Column<int>(type: "int", nullable: false),
                    currentValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nextValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDefinedRoleId = table.Column<int>(type: "int", nullable: true),
                    CommunicationTemplateId = table.Column<int>(type: "int", nullable: true),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateActionStatements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateActionStatements_ApplicationEntityProperties_ApplicationEntityPropertyId",
                        column: x => x.ApplicationEntityPropertyId,
                        principalSchema: "data",
                        principalTable: "ApplicationEntityProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StateActionStatements_CommunicationTemplates_CommunicationTemplateId",
                        column: x => x.CommunicationTemplateId,
                        principalSchema: "data",
                        principalTable: "CommunicationTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StateActionStatements_StateActions_StateActionId",
                        column: x => x.StateActionId,
                        principalSchema: "data",
                        principalTable: "StateActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupToApplicationFileMappings",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationFileTypeId = table.Column<int>(type: "int", nullable: false),
                    ApplicationFileGroupId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupToApplicationFileMappings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationFiles",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationFileTypeId = table.Column<int>(type: "int", nullable: false),
                    ServerDirectoryId = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationTemplateRoleRecieverMaps",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunicationTemplateId = table.Column<int>(type: "int", nullable: false),
                    ToId = table.Column<int>(type: "int", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationTemplateRoleRecieverMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunicationTemplateRoleRecieverMaps_CommunicationTemplates_CommunicationTemplateId",
                        column: x => x.CommunicationTemplateId,
                        principalSchema: "data",
                        principalTable: "CommunicationTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationTemplateUserRecieverMaps",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunicationTemplateId = table.Column<int>(type: "int", nullable: false),
                    ToId = table.Column<int>(type: "int", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationTemplateUserRecieverMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunicationTemplateUserRecieverMaps_CommunicationTemplates_CommunicationTemplateId",
                        column: x => x.CommunicationTemplateId,
                        principalSchema: "data",
                        principalTable: "CommunicationTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomPageLinks",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomPageId = table.Column<int>(type: "int", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomPageLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDefinedRoles",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgId = table.Column<int>(type: "int", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DashboardId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDefinedRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Widgets",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WidgetTypeId = table.Column<int>(type: "int", nullable: false),
                    WidgetTemplateId = table.Column<int>(type: "int", nullable: false),
                    DashboardId = table.Column<int>(type: "int", nullable: false),
                    WidgetDataId = table.Column<int>(type: "int", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Row = table.Column<int>(type: "int", nullable: false),
                    ColSpan = table.Column<int>(type: "int", nullable: false),
                    RowSpan = table.Column<int>(type: "int", nullable: false),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widgets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldEvents",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    script = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldEvents_Fields_FieldId",
                        column: x => x.FieldId,
                        principalSchema: "data",
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilterFields",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommonFilterId = table.Column<int>(type: "int", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    FilterOperator = table.Column<int>(type: "int", nullable: false),
                    FilterValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LockValue = table.Column<bool>(type: "bit", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilterFields_Fields_FieldId",
                        column: x => x.FieldId,
                        principalSchema: "data",
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilterFields_Filters_CommonFilterId",
                        column: x => x.CommonFilterId,
                        principalSchema: "data",
                        principalTable: "Filters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormFieldMaps",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFieldMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormFieldMaps_Fields_FieldId",
                        column: x => x.FieldId,
                        principalSchema: "data",
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormFieldMaps_Forms_FormId",
                        column: x => x.FormId,
                        principalSchema: "data",
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionLists",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldId = table.Column<int>(type: "int", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionLists_Fields_FieldId",
                        column: x => x.FieldId,
                        principalSchema: "data",
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilterLists",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilterFieldId = table.Column<int>(type: "int", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    FilterId = table.Column<int>(type: "int", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilterLists_FilterFields_FilterFieldId",
                        column: x => x.FilterFieldId,
                        principalSchema: "data",
                        principalTable: "FilterFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilterLists_Filters_FilterId",
                        column: x => x.FilterId,
                        principalSchema: "data",
                        principalTable: "Filters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilterResultFields",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expression = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommonFilterId = table.Column<int>(type: "int", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ExcludeInQueryExpression = table.Column<bool>(type: "bit", nullable: false),
                    ViewTransformExpression = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterResultFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilterResultFields_Filters_CommonFilterId",
                        column: x => x.CommonFilterId,
                        principalSchema: "data",
                        principalTable: "Filters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormEvents",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    script = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormEvents_Forms_FormId",
                        column: x => x.FormId,
                        principalSchema: "data",
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationEntities",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    IsStandard = table.Column<bool>(type: "bit", nullable: false),
                    IsOwnershipEntity = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postfix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGlobalSearchble = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationFileGroups",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFileGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationFileTypes",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFileTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationTypes",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomPages",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dashboards",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldTypes",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionListId = table.Column<int>(type: "int", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_OptionLists_OptionListId",
                        column: x => x.OptionListId,
                        principalSchema: "data",
                        principalTable: "OptionLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentOrganizationId = table.Column<int>(type: "int", nullable: true),
                    IsParent = table.Column<bool>(type: "bit", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Organizations_ParentOrganizationId",
                        column: x => x.ParentOrganizationId,
                        principalSchema: "data",
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IntUsers",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgId = table.Column<int>(type: "int", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntUsers_Organizations_OrgId",
                        column: x => x.OrgId,
                        principalSchema: "data",
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PageLinks",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linkName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageLinks_IntUsers_ArchieveById",
                        column: x => x.ArchieveById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageLinks_IntUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageLinks_IntUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Scripts",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scripts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scripts_IntUsers_ArchieveById",
                        column: x => x.ArchieveById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scripts_IntUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scripts_IntUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServerDirectories",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentDirectoryId = table.Column<int>(type: "int", nullable: true),
                    FullPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerDirectories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServerDirectories_IntUsers_ArchieveById",
                        column: x => x.ArchieveById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServerDirectories_IntUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServerDirectories_IntUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServerDirectories_ServerDirectories_ParentDirectoryId",
                        column: x => x.ParentDirectoryId,
                        principalSchema: "data",
                        principalTable: "ServerDirectories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StateActionAccesses",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateActionId = table.Column<int>(type: "int", nullable: false),
                    UserDefinedRoleId = table.Column<int>(type: "int", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateActionAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateActionAccesses_IntUsers_ArchieveById",
                        column: x => x.ArchieveById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StateActionAccesses_IntUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StateActionAccesses_IntUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StateActionAccesses_StateActions_StateActionId",
                        column: x => x.StateActionId,
                        principalSchema: "data",
                        principalTable: "StateActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StateActionAccesses_UserDefinedRoles_UserDefinedRoleId",
                        column: x => x.UserDefinedRoleId,
                        principalSchema: "data",
                        principalTable: "UserDefinedRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDefinedRoleMaps",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDefinedRoleMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDefinedRoleMaps_IntUsers_ArchieveById",
                        column: x => x.ArchieveById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDefinedRoleMaps_IntUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDefinedRoleMaps_IntUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDefinedRoleMaps_UserDefinedRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "data",
                        principalTable: "UserDefinedRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDefinedRoleToUserMaps",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    IntUserId = table.Column<int>(type: "int", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDefinedRoleToUserMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDefinedRoleToUserMaps_IntUsers_ArchieveById",
                        column: x => x.ArchieveById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDefinedRoleToUserMaps_IntUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDefinedRoleToUserMaps_IntUsers_IntUserId",
                        column: x => x.IntUserId,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDefinedRoleToUserMaps_IntUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDefinedRoleToUserMaps_UserDefinedRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "data",
                        principalTable: "UserDefinedRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WidgetParameterTypes",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetParameterTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidgetParameterTypes_IntUsers_ArchieveById",
                        column: x => x.ArchieveById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WidgetParameterTypes_IntUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WidgetParameterTypes_IntUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WidgetTemplates",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidgetTemplates_IntUsers_ArchieveById",
                        column: x => x.ArchieveById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WidgetTemplates_IntUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WidgetTemplates_IntUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WidgetTypes",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidgetTypes_IntUsers_ArchieveById",
                        column: x => x.ArchieveById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WidgetTypes_IntUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WidgetTypes_IntUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PageAccesses",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageAccesses_IntUsers_ArchieveById",
                        column: x => x.ArchieveById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageAccesses_IntUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageAccesses_IntUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageAccesses_PageLinks_LinkId",
                        column: x => x.LinkId,
                        principalSchema: "data",
                        principalTable: "PageLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageAccesses_UserDefinedRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "data",
                        principalTable: "UserDefinedRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WidgetDatas",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScriptId = table.Column<int>(type: "int", nullable: true),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidgetDatas_IntUsers_ArchieveById",
                        column: x => x.ArchieveById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WidgetDatas_IntUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WidgetDatas_IntUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WidgetDatas_Scripts_ScriptId",
                        column: x => x.ScriptId,
                        principalSchema: "data",
                        principalTable: "Scripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WidgetParameters",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WidgetParameterTypeId = table.Column<int>(type: "int", nullable: false),
                    WidgetDataId = table.Column<int>(type: "int", nullable: false),
                    Expression = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchieveById = table.Column<int>(type: "int", nullable: true),
                    ArchieveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidgetParameters_IntUsers_ArchieveById",
                        column: x => x.ArchieveById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WidgetParameters_IntUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WidgetParameters_IntUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalSchema: "data",
                        principalTable: "IntUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WidgetParameters_WidgetDatas_WidgetDataId",
                        column: x => x.WidgetDataId,
                        principalSchema: "data",
                        principalTable: "WidgetDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WidgetParameters_WidgetParameterTypes_WidgetParameterTypeId",
                        column: x => x.WidgetParameterTypeId,
                        principalSchema: "data",
                        principalTable: "WidgetParameterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEntities_ArchieveById",
                schema: "data",
                table: "ApplicationEntities",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEntities_CreatedById",
                schema: "data",
                table: "ApplicationEntities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEntities_ModifiedById",
                schema: "data",
                table: "ApplicationEntities",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEntityAccessExpressions_ApplicationEntityId",
                schema: "data",
                table: "ApplicationEntityAccessExpressions",
                column: "ApplicationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEntityAccessExpressions_ArchieveById",
                schema: "data",
                table: "ApplicationEntityAccessExpressions",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEntityAccessExpressions_CreatedById",
                schema: "data",
                table: "ApplicationEntityAccessExpressions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEntityAccessExpressions_ModifiedById",
                schema: "data",
                table: "ApplicationEntityAccessExpressions",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEntityAccessExpressions_PropertyApplicationEntityId",
                schema: "data",
                table: "ApplicationEntityAccessExpressions",
                column: "PropertyApplicationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEntityProperties_ApplicationEntityId",
                schema: "data",
                table: "ApplicationEntityProperties",
                column: "ApplicationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEntityProperties_ArchieveById",
                schema: "data",
                table: "ApplicationEntityProperties",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEntityProperties_CreatedById",
                schema: "data",
                table: "ApplicationEntityProperties",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEntityProperties_ModifiedById",
                schema: "data",
                table: "ApplicationEntityProperties",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFileGroups_ArchieveById",
                schema: "data",
                table: "ApplicationFileGroups",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFileGroups_CreatedById",
                schema: "data",
                table: "ApplicationFileGroups",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFileGroups_ModifiedById",
                schema: "data",
                table: "ApplicationFileGroups",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFiles_ApplicationFileTypeId",
                schema: "data",
                table: "ApplicationFiles",
                column: "ApplicationFileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFiles_ArchieveById",
                schema: "data",
                table: "ApplicationFiles",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFiles_CreatedById",
                schema: "data",
                table: "ApplicationFiles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFiles_ModifiedById",
                schema: "data",
                table: "ApplicationFiles",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFiles_OwnerId",
                schema: "data",
                table: "ApplicationFiles",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFiles_ServerDirectoryId",
                schema: "data",
                table: "ApplicationFiles",
                column: "ServerDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFileTypes_ArchieveById",
                schema: "data",
                table: "ApplicationFileTypes",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFileTypes_CreatedById",
                schema: "data",
                table: "ApplicationFileTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFileTypes_ModifiedById",
                schema: "data",
                table: "ApplicationFileTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Communications_ApplicationEntityId",
                schema: "data",
                table: "Communications",
                column: "ApplicationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Communications_ArchieveById",
                schema: "data",
                table: "Communications",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_Communications_CommunicationTemplateId",
                schema: "data",
                table: "Communications",
                column: "CommunicationTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Communications_CreatedById",
                schema: "data",
                table: "Communications",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Communications_ModifiedById",
                schema: "data",
                table: "Communications",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTemplateRoleRecieverMaps_ArchieveById",
                schema: "data",
                table: "CommunicationTemplateRoleRecieverMaps",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTemplateRoleRecieverMaps_CommunicationTemplateId",
                schema: "data",
                table: "CommunicationTemplateRoleRecieverMaps",
                column: "CommunicationTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTemplateRoleRecieverMaps_CreatedById",
                schema: "data",
                table: "CommunicationTemplateRoleRecieverMaps",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTemplateRoleRecieverMaps_ModifiedById",
                schema: "data",
                table: "CommunicationTemplateRoleRecieverMaps",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTemplateRoleRecieverMaps_ToId",
                schema: "data",
                table: "CommunicationTemplateRoleRecieverMaps",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTemplates_ApplicationEntityId",
                schema: "data",
                table: "CommunicationTemplates",
                column: "ApplicationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTemplates_ArchieveById",
                schema: "data",
                table: "CommunicationTemplates",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTemplates_CommunicationTypeId",
                schema: "data",
                table: "CommunicationTemplates",
                column: "CommunicationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTemplates_CreatedById",
                schema: "data",
                table: "CommunicationTemplates",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTemplates_FromId",
                schema: "data",
                table: "CommunicationTemplates",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTemplates_ModifiedById",
                schema: "data",
                table: "CommunicationTemplates",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTemplateUserRecieverMaps_ArchieveById",
                schema: "data",
                table: "CommunicationTemplateUserRecieverMaps",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTemplateUserRecieverMaps_CommunicationTemplateId",
                schema: "data",
                table: "CommunicationTemplateUserRecieverMaps",
                column: "CommunicationTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTemplateUserRecieverMaps_CreatedById",
                schema: "data",
                table: "CommunicationTemplateUserRecieverMaps",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTemplateUserRecieverMaps_ModifiedById",
                schema: "data",
                table: "CommunicationTemplateUserRecieverMaps",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTemplateUserRecieverMaps_ToId",
                schema: "data",
                table: "CommunicationTemplateUserRecieverMaps",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTypes_ArchieveById",
                schema: "data",
                table: "CommunicationTypes",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTypes_CreatedById",
                schema: "data",
                table: "CommunicationTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationTypes_ModifiedById",
                schema: "data",
                table: "CommunicationTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_CustomPageLinks_ArchieveById",
                schema: "data",
                table: "CustomPageLinks",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_CustomPageLinks_CreatedById",
                schema: "data",
                table: "CustomPageLinks",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CustomPageLinks_CustomPageId",
                schema: "data",
                table: "CustomPageLinks",
                column: "CustomPageId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomPageLinks_ModifiedById",
                schema: "data",
                table: "CustomPageLinks",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_CustomPages_ArchieveById",
                schema: "data",
                table: "CustomPages",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_CustomPages_CreatedById",
                schema: "data",
                table: "CustomPages",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CustomPages_ModifiedById",
                schema: "data",
                table: "CustomPages",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_ArchieveById",
                schema: "data",
                table: "Dashboards",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_CreatedById",
                schema: "data",
                table: "Dashboards",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_ModifiedById",
                schema: "data",
                table: "Dashboards",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_EntityScripts_ApplicationEntityId",
                schema: "data",
                table: "EntityScripts",
                column: "ApplicationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityScripts_ArchieveById",
                schema: "data",
                table: "EntityScripts",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_EntityScripts_CreatedById",
                schema: "data",
                table: "EntityScripts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EntityScripts_ModifiedById",
                schema: "data",
                table: "EntityScripts",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_EntityScripts_ScriptId",
                schema: "data",
                table: "EntityScripts",
                column: "ScriptId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldEvents_ArchieveById",
                schema: "data",
                table: "FieldEvents",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_FieldEvents_CreatedById",
                schema: "data",
                table: "FieldEvents",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FieldEvents_FieldId",
                schema: "data",
                table: "FieldEvents",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldEvents_ModifiedById",
                schema: "data",
                table: "FieldEvents",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_ApplicationEntityPropertyId",
                schema: "data",
                table: "Fields",
                column: "ApplicationEntityPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_ArchieveById",
                schema: "data",
                table: "Fields",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_CreatedById",
                schema: "data",
                table: "Fields",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_FieldTypeId",
                schema: "data",
                table: "Fields",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_ModifiedById",
                schema: "data",
                table: "Fields",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_FieldTypes_ArchieveById",
                schema: "data",
                table: "FieldTypes",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_FieldTypes_CreatedById",
                schema: "data",
                table: "FieldTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FieldTypes_ModifiedById",
                schema: "data",
                table: "FieldTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_FilterFields_ArchieveById",
                schema: "data",
                table: "FilterFields",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_FilterFields_CommonFilterId",
                schema: "data",
                table: "FilterFields",
                column: "CommonFilterId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterFields_CreatedById",
                schema: "data",
                table: "FilterFields",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FilterFields_FieldId",
                schema: "data",
                table: "FilterFields",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterFields_ModifiedById",
                schema: "data",
                table: "FilterFields",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_FilterLists_ArchieveById",
                schema: "data",
                table: "FilterLists",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_FilterLists_CreatedById",
                schema: "data",
                table: "FilterLists",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FilterLists_FilterFieldId",
                schema: "data",
                table: "FilterLists",
                column: "FilterFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterLists_FilterId",
                schema: "data",
                table: "FilterLists",
                column: "FilterId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterLists_ModifiedById",
                schema: "data",
                table: "FilterLists",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_FilterResultFields_ArchieveById",
                schema: "data",
                table: "FilterResultFields",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_FilterResultFields_CommonFilterId",
                schema: "data",
                table: "FilterResultFields",
                column: "CommonFilterId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterResultFields_CreatedById",
                schema: "data",
                table: "FilterResultFields",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FilterResultFields_ModifiedById",
                schema: "data",
                table: "FilterResultFields",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_ApplicationEntityId",
                schema: "data",
                table: "Filters",
                column: "ApplicationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_ArchieveById",
                schema: "data",
                table: "Filters",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_CreatedById",
                schema: "data",
                table: "Filters",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_ModifiedById",
                schema: "data",
                table: "Filters",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_FormEvents_ArchieveById",
                schema: "data",
                table: "FormEvents",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_FormEvents_CreatedById",
                schema: "data",
                table: "FormEvents",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FormEvents_FormId",
                schema: "data",
                table: "FormEvents",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormEvents_ModifiedById",
                schema: "data",
                table: "FormEvents",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_FormFieldMaps_ArchieveById",
                schema: "data",
                table: "FormFieldMaps",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_FormFieldMaps_CreatedById",
                schema: "data",
                table: "FormFieldMaps",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FormFieldMaps_FieldId",
                schema: "data",
                table: "FormFieldMaps",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FormFieldMaps_FormId",
                schema: "data",
                table: "FormFieldMaps",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormFieldMaps_ModifiedById",
                schema: "data",
                table: "FormFieldMaps",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_ApplicationEntityId",
                schema: "data",
                table: "Forms",
                column: "ApplicationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_ArchieveById",
                schema: "data",
                table: "Forms",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_CreatedById",
                schema: "data",
                table: "Forms",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_ModifiedById",
                schema: "data",
                table: "Forms",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_GroupToApplicationFileMappings_ApplicationFileGroupId",
                schema: "data",
                table: "GroupToApplicationFileMappings",
                column: "ApplicationFileGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupToApplicationFileMappings_ApplicationFileTypeId",
                schema: "data",
                table: "GroupToApplicationFileMappings",
                column: "ApplicationFileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupToApplicationFileMappings_ArchieveById",
                schema: "data",
                table: "GroupToApplicationFileMappings",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_GroupToApplicationFileMappings_CreatedById",
                schema: "data",
                table: "GroupToApplicationFileMappings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GroupToApplicationFileMappings_ModifiedById",
                schema: "data",
                table: "GroupToApplicationFileMappings",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_IntUsers_OrgId",
                schema: "data",
                table: "IntUsers",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Labels_ArchieveById",
                schema: "data",
                table: "Labels",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_Labels_CreatedById",
                schema: "data",
                table: "Labels",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Labels_ModifiedById",
                schema: "data",
                table: "Labels",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_OptionLists_ArchieveById",
                schema: "data",
                table: "OptionLists",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_OptionLists_CreatedById",
                schema: "data",
                table: "OptionLists",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OptionLists_FieldId",
                schema: "data",
                table: "OptionLists",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionLists_ModifiedById",
                schema: "data",
                table: "OptionLists",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Options_ArchieveById",
                schema: "data",
                table: "Options",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_Options_CreatedById",
                schema: "data",
                table: "Options",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Options_ModifiedById",
                schema: "data",
                table: "Options",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Options_OptionListId",
                schema: "data",
                table: "Options",
                column: "OptionListId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_ArchieveById",
                schema: "data",
                table: "Organizations",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CreatedById",
                schema: "data",
                table: "Organizations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_ModifiedById",
                schema: "data",
                table: "Organizations",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_ParentOrganizationId",
                schema: "data",
                table: "Organizations",
                column: "ParentOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnershipEntityAccesses_ApplicationEntityId",
                schema: "data",
                table: "OwnershipEntityAccesses",
                column: "ApplicationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnershipEntityAccesses_ArchieveById",
                schema: "data",
                table: "OwnershipEntityAccesses",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_OwnershipEntityAccesses_CreatedById",
                schema: "data",
                table: "OwnershipEntityAccesses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OwnershipEntityAccesses_IntUserId",
                schema: "data",
                table: "OwnershipEntityAccesses",
                column: "IntUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnershipEntityAccesses_ModifiedById",
                schema: "data",
                table: "OwnershipEntityAccesses",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_PageAccesses_ArchieveById",
                schema: "data",
                table: "PageAccesses",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_PageAccesses_CreatedById",
                schema: "data",
                table: "PageAccesses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PageAccesses_LinkId",
                schema: "data",
                table: "PageAccesses",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_PageAccesses_ModifiedById",
                schema: "data",
                table: "PageAccesses",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_PageAccesses_RoleId",
                schema: "data",
                table: "PageAccesses",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PageLinks_ArchieveById",
                schema: "data",
                table: "PageLinks",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_PageLinks_CreatedById",
                schema: "data",
                table: "PageLinks",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PageLinks_ModifiedById",
                schema: "data",
                table: "PageLinks",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_ArchieveById",
                schema: "data",
                table: "Scripts",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_CreatedById",
                schema: "data",
                table: "Scripts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_ModifiedById",
                schema: "data",
                table: "Scripts",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ServerDirectories_ArchieveById",
                schema: "data",
                table: "ServerDirectories",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_ServerDirectories_CreatedById",
                schema: "data",
                table: "ServerDirectories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ServerDirectories_ModifiedById",
                schema: "data",
                table: "ServerDirectories",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ServerDirectories_ParentDirectoryId",
                schema: "data",
                table: "ServerDirectories",
                column: "ParentDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StateActionAccesses_ArchieveById",
                schema: "data",
                table: "StateActionAccesses",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_StateActionAccesses_CreatedById",
                schema: "data",
                table: "StateActionAccesses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StateActionAccesses_ModifiedById",
                schema: "data",
                table: "StateActionAccesses",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_StateActionAccesses_StateActionId",
                schema: "data",
                table: "StateActionAccesses",
                column: "StateActionId");

            migrationBuilder.CreateIndex(
                name: "IX_StateActionAccesses_UserDefinedRoleId",
                schema: "data",
                table: "StateActionAccesses",
                column: "UserDefinedRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_StateActions_ApplicationEntityId",
                schema: "data",
                table: "StateActions",
                column: "ApplicationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_StateActions_ArchieveById",
                schema: "data",
                table: "StateActions",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_StateActions_CreatedById",
                schema: "data",
                table: "StateActions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StateActions_ModifiedById",
                schema: "data",
                table: "StateActions",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_StateActionStatements_ApplicationEntityPropertyId",
                schema: "data",
                table: "StateActionStatements",
                column: "ApplicationEntityPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_StateActionStatements_ArchieveById",
                schema: "data",
                table: "StateActionStatements",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_StateActionStatements_CommunicationTemplateId",
                schema: "data",
                table: "StateActionStatements",
                column: "CommunicationTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_StateActionStatements_CreatedById",
                schema: "data",
                table: "StateActionStatements",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StateActionStatements_ModifiedById",
                schema: "data",
                table: "StateActionStatements",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_StateActionStatements_StateActionId",
                schema: "data",
                table: "StateActionStatements",
                column: "StateActionId");

            migrationBuilder.CreateIndex(
                name: "IX_StateActionStatements_UserDefinedRoleId",
                schema: "data",
                table: "StateActionStatements",
                column: "UserDefinedRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefinedRoleMaps_ArchieveById",
                schema: "data",
                table: "UserDefinedRoleMaps",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefinedRoleMaps_CreatedById",
                schema: "data",
                table: "UserDefinedRoleMaps",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefinedRoleMaps_ModifiedById",
                schema: "data",
                table: "UserDefinedRoleMaps",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefinedRoleMaps_RoleId",
                schema: "data",
                table: "UserDefinedRoleMaps",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefinedRoles_ArchieveById",
                schema: "data",
                table: "UserDefinedRoles",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefinedRoles_CreatedById",
                schema: "data",
                table: "UserDefinedRoles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefinedRoles_DashboardId",
                schema: "data",
                table: "UserDefinedRoles",
                column: "DashboardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefinedRoles_ModifiedById",
                schema: "data",
                table: "UserDefinedRoles",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefinedRoles_OrgId",
                schema: "data",
                table: "UserDefinedRoles",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefinedRoleToUserMaps_ArchieveById",
                schema: "data",
                table: "UserDefinedRoleToUserMaps",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefinedRoleToUserMaps_CreatedById",
                schema: "data",
                table: "UserDefinedRoleToUserMaps",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefinedRoleToUserMaps_IntUserId",
                schema: "data",
                table: "UserDefinedRoleToUserMaps",
                column: "IntUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefinedRoleToUserMaps_ModifiedById",
                schema: "data",
                table: "UserDefinedRoleToUserMaps",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserDefinedRoleToUserMaps_RoleId",
                schema: "data",
                table: "UserDefinedRoleToUserMaps",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetDatas_ArchieveById",
                schema: "data",
                table: "WidgetDatas",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetDatas_CreatedById",
                schema: "data",
                table: "WidgetDatas",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetDatas_ModifiedById",
                schema: "data",
                table: "WidgetDatas",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetDatas_ScriptId",
                schema: "data",
                table: "WidgetDatas",
                column: "ScriptId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetParameters_ArchieveById",
                schema: "data",
                table: "WidgetParameters",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetParameters_CreatedById",
                schema: "data",
                table: "WidgetParameters",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetParameters_ModifiedById",
                schema: "data",
                table: "WidgetParameters",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetParameters_WidgetDataId",
                schema: "data",
                table: "WidgetParameters",
                column: "WidgetDataId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetParameters_WidgetParameterTypeId",
                schema: "data",
                table: "WidgetParameters",
                column: "WidgetParameterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetParameterTypes_ArchieveById",
                schema: "data",
                table: "WidgetParameterTypes",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetParameterTypes_CreatedById",
                schema: "data",
                table: "WidgetParameterTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetParameterTypes_ModifiedById",
                schema: "data",
                table: "WidgetParameterTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Widgets_ArchieveById",
                schema: "data",
                table: "Widgets",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_Widgets_CreatedById",
                schema: "data",
                table: "Widgets",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Widgets_DashboardId",
                schema: "data",
                table: "Widgets",
                column: "DashboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Widgets_ModifiedById",
                schema: "data",
                table: "Widgets",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Widgets_WidgetDataId",
                schema: "data",
                table: "Widgets",
                column: "WidgetDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Widgets_WidgetTemplateId",
                schema: "data",
                table: "Widgets",
                column: "WidgetTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Widgets_WidgetTypeId",
                schema: "data",
                table: "Widgets",
                column: "WidgetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetTemplates_ArchieveById",
                schema: "data",
                table: "WidgetTemplates",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetTemplates_CreatedById",
                schema: "data",
                table: "WidgetTemplates",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetTemplates_ModifiedById",
                schema: "data",
                table: "WidgetTemplates",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetTypes_ArchieveById",
                schema: "data",
                table: "WidgetTypes",
                column: "ArchieveById");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetTypes_CreatedById",
                schema: "data",
                table: "WidgetTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetTypes_ModifiedById",
                schema: "data",
                table: "WidgetTypes",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationEntityAccessExpressions_ApplicationEntities_ApplicationEntityId",
                schema: "data",
                table: "ApplicationEntityAccessExpressions",
                column: "ApplicationEntityId",
                principalSchema: "data",
                principalTable: "ApplicationEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationEntityAccessExpressions_ApplicationEntities_PropertyApplicationEntityId",
                schema: "data",
                table: "ApplicationEntityAccessExpressions",
                column: "PropertyApplicationEntityId",
                principalSchema: "data",
                principalTable: "ApplicationEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationEntityAccessExpressions_IntUsers_ArchieveById",
                schema: "data",
                table: "ApplicationEntityAccessExpressions",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationEntityAccessExpressions_IntUsers_CreatedById",
                schema: "data",
                table: "ApplicationEntityAccessExpressions",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationEntityAccessExpressions_IntUsers_ModifiedById",
                schema: "data",
                table: "ApplicationEntityAccessExpressions",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationEntityProperties_ApplicationEntities_ApplicationEntityId",
                schema: "data",
                table: "ApplicationEntityProperties",
                column: "ApplicationEntityId",
                principalSchema: "data",
                principalTable: "ApplicationEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationEntityProperties_IntUsers_ArchieveById",
                schema: "data",
                table: "ApplicationEntityProperties",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationEntityProperties_IntUsers_CreatedById",
                schema: "data",
                table: "ApplicationEntityProperties",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationEntityProperties_IntUsers_ModifiedById",
                schema: "data",
                table: "ApplicationEntityProperties",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Communications_ApplicationEntities_ApplicationEntityId",
                schema: "data",
                table: "Communications",
                column: "ApplicationEntityId",
                principalSchema: "data",
                principalTable: "ApplicationEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Communications_CommunicationTemplates_CommunicationTemplateId",
                schema: "data",
                table: "Communications",
                column: "CommunicationTemplateId",
                principalSchema: "data",
                principalTable: "CommunicationTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Communications_IntUsers_ArchieveById",
                schema: "data",
                table: "Communications",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Communications_IntUsers_CreatedById",
                schema: "data",
                table: "Communications",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Communications_IntUsers_ModifiedById",
                schema: "data",
                table: "Communications",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTemplates_ApplicationEntities_ApplicationEntityId",
                schema: "data",
                table: "CommunicationTemplates",
                column: "ApplicationEntityId",
                principalSchema: "data",
                principalTable: "ApplicationEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTemplates_CommunicationTypes_CommunicationTypeId",
                schema: "data",
                table: "CommunicationTemplates",
                column: "CommunicationTypeId",
                principalSchema: "data",
                principalTable: "CommunicationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTemplates_IntUsers_ArchieveById",
                schema: "data",
                table: "CommunicationTemplates",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTemplates_IntUsers_CreatedById",
                schema: "data",
                table: "CommunicationTemplates",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTemplates_IntUsers_FromId",
                schema: "data",
                table: "CommunicationTemplates",
                column: "FromId",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTemplates_IntUsers_ModifiedById",
                schema: "data",
                table: "CommunicationTemplates",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityScripts_ApplicationEntities_ApplicationEntityId",
                schema: "data",
                table: "EntityScripts",
                column: "ApplicationEntityId",
                principalSchema: "data",
                principalTable: "ApplicationEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityScripts_IntUsers_ArchieveById",
                schema: "data",
                table: "EntityScripts",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityScripts_IntUsers_CreatedById",
                schema: "data",
                table: "EntityScripts",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityScripts_IntUsers_ModifiedById",
                schema: "data",
                table: "EntityScripts",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityScripts_Scripts_ScriptId",
                schema: "data",
                table: "EntityScripts",
                column: "ScriptId",
                principalSchema: "data",
                principalTable: "Scripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filters_ApplicationEntities_ApplicationEntityId",
                schema: "data",
                table: "Filters",
                column: "ApplicationEntityId",
                principalSchema: "data",
                principalTable: "ApplicationEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Filters_IntUsers_ArchieveById",
                schema: "data",
                table: "Filters",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Filters_IntUsers_CreatedById",
                schema: "data",
                table: "Filters",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Filters_IntUsers_ModifiedById",
                schema: "data",
                table: "Filters",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_ApplicationEntities_ApplicationEntityId",
                schema: "data",
                table: "Forms",
                column: "ApplicationEntityId",
                principalSchema: "data",
                principalTable: "ApplicationEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_IntUsers_ArchieveById",
                schema: "data",
                table: "Forms",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_IntUsers_CreatedById",
                schema: "data",
                table: "Forms",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_IntUsers_ModifiedById",
                schema: "data",
                table: "Forms",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipEntityAccesses_ApplicationEntities_ApplicationEntityId",
                schema: "data",
                table: "OwnershipEntityAccesses",
                column: "ApplicationEntityId",
                principalSchema: "data",
                principalTable: "ApplicationEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipEntityAccesses_IntUsers_ArchieveById",
                schema: "data",
                table: "OwnershipEntityAccesses",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipEntityAccesses_IntUsers_CreatedById",
                schema: "data",
                table: "OwnershipEntityAccesses",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipEntityAccesses_IntUsers_IntUserId",
                schema: "data",
                table: "OwnershipEntityAccesses",
                column: "IntUserId",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnershipEntityAccesses_IntUsers_ModifiedById",
                schema: "data",
                table: "OwnershipEntityAccesses",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StateActions_ApplicationEntities_ApplicationEntityId",
                schema: "data",
                table: "StateActions",
                column: "ApplicationEntityId",
                principalSchema: "data",
                principalTable: "ApplicationEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StateActions_IntUsers_ArchieveById",
                schema: "data",
                table: "StateActions",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StateActions_IntUsers_CreatedById",
                schema: "data",
                table: "StateActions",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StateActions_IntUsers_ModifiedById",
                schema: "data",
                table: "StateActions",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_FieldTypes_FieldTypeId",
                schema: "data",
                table: "Fields",
                column: "FieldTypeId",
                principalSchema: "data",
                principalTable: "FieldTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_IntUsers_ArchieveById",
                schema: "data",
                table: "Fields",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_IntUsers_CreatedById",
                schema: "data",
                table: "Fields",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_IntUsers_ModifiedById",
                schema: "data",
                table: "Fields",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StateActionStatements_IntUsers_ArchieveById",
                schema: "data",
                table: "StateActionStatements",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StateActionStatements_IntUsers_CreatedById",
                schema: "data",
                table: "StateActionStatements",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StateActionStatements_IntUsers_ModifiedById",
                schema: "data",
                table: "StateActionStatements",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StateActionStatements_UserDefinedRoles_UserDefinedRoleId",
                schema: "data",
                table: "StateActionStatements",
                column: "UserDefinedRoleId",
                principalSchema: "data",
                principalTable: "UserDefinedRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupToApplicationFileMappings_ApplicationFileGroups_ApplicationFileGroupId",
                schema: "data",
                table: "GroupToApplicationFileMappings",
                column: "ApplicationFileGroupId",
                principalSchema: "data",
                principalTable: "ApplicationFileGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupToApplicationFileMappings_ApplicationFileTypes_ApplicationFileTypeId",
                schema: "data",
                table: "GroupToApplicationFileMappings",
                column: "ApplicationFileTypeId",
                principalSchema: "data",
                principalTable: "ApplicationFileTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupToApplicationFileMappings_IntUsers_ArchieveById",
                schema: "data",
                table: "GroupToApplicationFileMappings",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupToApplicationFileMappings_IntUsers_CreatedById",
                schema: "data",
                table: "GroupToApplicationFileMappings",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupToApplicationFileMappings_IntUsers_ModifiedById",
                schema: "data",
                table: "GroupToApplicationFileMappings",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFiles_ApplicationFileTypes_ApplicationFileTypeId",
                schema: "data",
                table: "ApplicationFiles",
                column: "ApplicationFileTypeId",
                principalSchema: "data",
                principalTable: "ApplicationFileTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFiles_IntUsers_ArchieveById",
                schema: "data",
                table: "ApplicationFiles",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFiles_IntUsers_CreatedById",
                schema: "data",
                table: "ApplicationFiles",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFiles_IntUsers_ModifiedById",
                schema: "data",
                table: "ApplicationFiles",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFiles_IntUsers_OwnerId",
                schema: "data",
                table: "ApplicationFiles",
                column: "OwnerId",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFiles_ServerDirectories_ServerDirectoryId",
                schema: "data",
                table: "ApplicationFiles",
                column: "ServerDirectoryId",
                principalSchema: "data",
                principalTable: "ServerDirectories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTemplateRoleRecieverMaps_IntUsers_ArchieveById",
                schema: "data",
                table: "CommunicationTemplateRoleRecieverMaps",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTemplateRoleRecieverMaps_IntUsers_CreatedById",
                schema: "data",
                table: "CommunicationTemplateRoleRecieverMaps",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTemplateRoleRecieverMaps_IntUsers_ModifiedById",
                schema: "data",
                table: "CommunicationTemplateRoleRecieverMaps",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTemplateRoleRecieverMaps_UserDefinedRoles_ToId",
                schema: "data",
                table: "CommunicationTemplateRoleRecieverMaps",
                column: "ToId",
                principalSchema: "data",
                principalTable: "UserDefinedRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTemplateUserRecieverMaps_IntUsers_ArchieveById",
                schema: "data",
                table: "CommunicationTemplateUserRecieverMaps",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTemplateUserRecieverMaps_IntUsers_CreatedById",
                schema: "data",
                table: "CommunicationTemplateUserRecieverMaps",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTemplateUserRecieverMaps_IntUsers_ModifiedById",
                schema: "data",
                table: "CommunicationTemplateUserRecieverMaps",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTemplateUserRecieverMaps_IntUsers_ToId",
                schema: "data",
                table: "CommunicationTemplateUserRecieverMaps",
                column: "ToId",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomPageLinks_CustomPages_CustomPageId",
                schema: "data",
                table: "CustomPageLinks",
                column: "CustomPageId",
                principalSchema: "data",
                principalTable: "CustomPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomPageLinks_IntUsers_ArchieveById",
                schema: "data",
                table: "CustomPageLinks",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomPageLinks_IntUsers_CreatedById",
                schema: "data",
                table: "CustomPageLinks",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomPageLinks_IntUsers_ModifiedById",
                schema: "data",
                table: "CustomPageLinks",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDefinedRoles_Dashboards_DashboardId",
                schema: "data",
                table: "UserDefinedRoles",
                column: "DashboardId",
                principalSchema: "data",
                principalTable: "Dashboards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDefinedRoles_IntUsers_ArchieveById",
                schema: "data",
                table: "UserDefinedRoles",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDefinedRoles_IntUsers_CreatedById",
                schema: "data",
                table: "UserDefinedRoles",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDefinedRoles_IntUsers_ModifiedById",
                schema: "data",
                table: "UserDefinedRoles",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDefinedRoles_Organizations_OrgId",
                schema: "data",
                table: "UserDefinedRoles",
                column: "OrgId",
                principalSchema: "data",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Widgets_Dashboards_DashboardId",
                schema: "data",
                table: "Widgets",
                column: "DashboardId",
                principalSchema: "data",
                principalTable: "Dashboards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Widgets_IntUsers_ArchieveById",
                schema: "data",
                table: "Widgets",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Widgets_IntUsers_CreatedById",
                schema: "data",
                table: "Widgets",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Widgets_IntUsers_ModifiedById",
                schema: "data",
                table: "Widgets",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Widgets_WidgetDatas_WidgetDataId",
                schema: "data",
                table: "Widgets",
                column: "WidgetDataId",
                principalSchema: "data",
                principalTable: "WidgetDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Widgets_WidgetTemplates_WidgetTemplateId",
                schema: "data",
                table: "Widgets",
                column: "WidgetTemplateId",
                principalSchema: "data",
                principalTable: "WidgetTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Widgets_WidgetTypes_WidgetTypeId",
                schema: "data",
                table: "Widgets",
                column: "WidgetTypeId",
                principalSchema: "data",
                principalTable: "WidgetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldEvents_IntUsers_ArchieveById",
                schema: "data",
                table: "FieldEvents",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldEvents_IntUsers_CreatedById",
                schema: "data",
                table: "FieldEvents",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldEvents_IntUsers_ModifiedById",
                schema: "data",
                table: "FieldEvents",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilterFields_IntUsers_ArchieveById",
                schema: "data",
                table: "FilterFields",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilterFields_IntUsers_CreatedById",
                schema: "data",
                table: "FilterFields",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilterFields_IntUsers_ModifiedById",
                schema: "data",
                table: "FilterFields",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormFieldMaps_IntUsers_ArchieveById",
                schema: "data",
                table: "FormFieldMaps",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormFieldMaps_IntUsers_CreatedById",
                schema: "data",
                table: "FormFieldMaps",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormFieldMaps_IntUsers_ModifiedById",
                schema: "data",
                table: "FormFieldMaps",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionLists_IntUsers_ArchieveById",
                schema: "data",
                table: "OptionLists",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionLists_IntUsers_CreatedById",
                schema: "data",
                table: "OptionLists",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionLists_IntUsers_ModifiedById",
                schema: "data",
                table: "OptionLists",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilterLists_IntUsers_ArchieveById",
                schema: "data",
                table: "FilterLists",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilterLists_IntUsers_CreatedById",
                schema: "data",
                table: "FilterLists",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilterLists_IntUsers_ModifiedById",
                schema: "data",
                table: "FilterLists",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilterResultFields_IntUsers_ArchieveById",
                schema: "data",
                table: "FilterResultFields",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilterResultFields_IntUsers_CreatedById",
                schema: "data",
                table: "FilterResultFields",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilterResultFields_IntUsers_ModifiedById",
                schema: "data",
                table: "FilterResultFields",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormEvents_IntUsers_ArchieveById",
                schema: "data",
                table: "FormEvents",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormEvents_IntUsers_CreatedById",
                schema: "data",
                table: "FormEvents",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormEvents_IntUsers_ModifiedById",
                schema: "data",
                table: "FormEvents",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationEntities_IntUsers_ArchieveById",
                schema: "data",
                table: "ApplicationEntities",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationEntities_IntUsers_CreatedById",
                schema: "data",
                table: "ApplicationEntities",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationEntities_IntUsers_ModifiedById",
                schema: "data",
                table: "ApplicationEntities",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFileGroups_IntUsers_ArchieveById",
                schema: "data",
                table: "ApplicationFileGroups",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFileGroups_IntUsers_CreatedById",
                schema: "data",
                table: "ApplicationFileGroups",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFileGroups_IntUsers_ModifiedById",
                schema: "data",
                table: "ApplicationFileGroups",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFileTypes_IntUsers_ArchieveById",
                schema: "data",
                table: "ApplicationFileTypes",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFileTypes_IntUsers_CreatedById",
                schema: "data",
                table: "ApplicationFileTypes",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFileTypes_IntUsers_ModifiedById",
                schema: "data",
                table: "ApplicationFileTypes",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTypes_IntUsers_ArchieveById",
                schema: "data",
                table: "CommunicationTypes",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTypes_IntUsers_CreatedById",
                schema: "data",
                table: "CommunicationTypes",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunicationTypes_IntUsers_ModifiedById",
                schema: "data",
                table: "CommunicationTypes",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomPages_IntUsers_ArchieveById",
                schema: "data",
                table: "CustomPages",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomPages_IntUsers_CreatedById",
                schema: "data",
                table: "CustomPages",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomPages_IntUsers_ModifiedById",
                schema: "data",
                table: "CustomPages",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_IntUsers_ArchieveById",
                schema: "data",
                table: "Dashboards",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_IntUsers_CreatedById",
                schema: "data",
                table: "Dashboards",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_IntUsers_ModifiedById",
                schema: "data",
                table: "Dashboards",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldTypes_IntUsers_ArchieveById",
                schema: "data",
                table: "FieldTypes",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldTypes_IntUsers_CreatedById",
                schema: "data",
                table: "FieldTypes",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldTypes_IntUsers_ModifiedById",
                schema: "data",
                table: "FieldTypes",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_IntUsers_ArchieveById",
                schema: "data",
                table: "Labels",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_IntUsers_CreatedById",
                schema: "data",
                table: "Labels",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_IntUsers_ModifiedById",
                schema: "data",
                table: "Labels",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_IntUsers_ArchieveById",
                schema: "data",
                table: "Options",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_IntUsers_CreatedById",
                schema: "data",
                table: "Options",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_IntUsers_ModifiedById",
                schema: "data",
                table: "Options",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_IntUsers_ArchieveById",
                schema: "data",
                table: "Organizations",
                column: "ArchieveById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_IntUsers_CreatedById",
                schema: "data",
                table: "Organizations",
                column: "CreatedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_IntUsers_ModifiedById",
                schema: "data",
                table: "Organizations",
                column: "ModifiedById",
                principalSchema: "data",
                principalTable: "IntUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_IntUsers_ArchieveById",
                schema: "data",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_IntUsers_CreatedById",
                schema: "data",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_IntUsers_ModifiedById",
                schema: "data",
                table: "Organizations");

            migrationBuilder.DropTable(
                name: "ApplicationEntityAccessExpressions",
                schema: "data");

            migrationBuilder.DropTable(
                name: "ApplicationFiles",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Communications",
                schema: "data");

            migrationBuilder.DropTable(
                name: "CommunicationTemplateRoleRecieverMaps",
                schema: "data");

            migrationBuilder.DropTable(
                name: "CommunicationTemplateUserRecieverMaps",
                schema: "data");

            migrationBuilder.DropTable(
                name: "CustomPageLinks",
                schema: "data");

            migrationBuilder.DropTable(
                name: "EntityScripts",
                schema: "data");

            migrationBuilder.DropTable(
                name: "FieldEvents",
                schema: "data");

            migrationBuilder.DropTable(
                name: "FilterLists",
                schema: "data");

            migrationBuilder.DropTable(
                name: "FilterResultFields",
                schema: "data");

            migrationBuilder.DropTable(
                name: "FormEvents",
                schema: "data");

            migrationBuilder.DropTable(
                name: "FormFieldMaps",
                schema: "data");

            migrationBuilder.DropTable(
                name: "GroupToApplicationFileMappings",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Labels",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Options",
                schema: "data");

            migrationBuilder.DropTable(
                name: "OwnershipEntityAccesses",
                schema: "data");

            migrationBuilder.DropTable(
                name: "PageAccesses",
                schema: "data");

            migrationBuilder.DropTable(
                name: "StateActionAccesses",
                schema: "data");

            migrationBuilder.DropTable(
                name: "StateActionStatements",
                schema: "data");

            migrationBuilder.DropTable(
                name: "UserDefinedRoleMaps",
                schema: "data");

            migrationBuilder.DropTable(
                name: "UserDefinedRoleToUserMaps",
                schema: "data");

            migrationBuilder.DropTable(
                name: "WidgetParameters",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Widgets",
                schema: "data");

            migrationBuilder.DropTable(
                name: "ServerDirectories",
                schema: "data");

            migrationBuilder.DropTable(
                name: "CustomPages",
                schema: "data");

            migrationBuilder.DropTable(
                name: "FilterFields",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Forms",
                schema: "data");

            migrationBuilder.DropTable(
                name: "ApplicationFileGroups",
                schema: "data");

            migrationBuilder.DropTable(
                name: "ApplicationFileTypes",
                schema: "data");

            migrationBuilder.DropTable(
                name: "OptionLists",
                schema: "data");

            migrationBuilder.DropTable(
                name: "PageLinks",
                schema: "data");

            migrationBuilder.DropTable(
                name: "CommunicationTemplates",
                schema: "data");

            migrationBuilder.DropTable(
                name: "StateActions",
                schema: "data");

            migrationBuilder.DropTable(
                name: "UserDefinedRoles",
                schema: "data");

            migrationBuilder.DropTable(
                name: "WidgetParameterTypes",
                schema: "data");

            migrationBuilder.DropTable(
                name: "WidgetDatas",
                schema: "data");

            migrationBuilder.DropTable(
                name: "WidgetTemplates",
                schema: "data");

            migrationBuilder.DropTable(
                name: "WidgetTypes",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Filters",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Fields",
                schema: "data");

            migrationBuilder.DropTable(
                name: "CommunicationTypes",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Dashboards",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Scripts",
                schema: "data");

            migrationBuilder.DropTable(
                name: "ApplicationEntityProperties",
                schema: "data");

            migrationBuilder.DropTable(
                name: "FieldTypes",
                schema: "data");

            migrationBuilder.DropTable(
                name: "ApplicationEntities",
                schema: "data");

            migrationBuilder.DropTable(
                name: "IntUsers",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Organizations",
                schema: "data");
        }
    }
}
