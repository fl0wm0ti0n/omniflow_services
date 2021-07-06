using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NodeMonitor.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "generic_AbonementSourceTyp",
                columns: table => new
                {
                    AbonementSourceTypEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Typ = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_AbonementSourceTyp", x => x.AbonementSourceTypEntityId);
                });

            migrationBuilder.CreateTable(
                name: "generic_AbonementTyp",
                columns: table => new
                {
                    AbonementTargetTypEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Typ = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_AbonementTyp", x => x.AbonementTargetTypEntityId);
                });

            migrationBuilder.CreateTable(
                name: "generic_DeviceTypes",
                columns: table => new
                {
                    DeviceTypEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_DeviceTypes", x => x.DeviceTypEntityId);
                });

            migrationBuilder.CreateTable(
                name: "generic_Privileges",
                columns: table => new
                {
                    PrivilegeEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_Privileges", x => x.PrivilegeEntityId);
                });

            migrationBuilder.CreateTable(
                name: "generic_ScheduleDays",
                columns: table => new
                {
                    ScheduleDaysEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_ScheduleDays", x => x.ScheduleDaysEntityId);
                });

            migrationBuilder.CreateTable(
                name: "generic_ScheduleTaskTypes",
                columns: table => new
                {
                    ScheduleTaskTypEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_ScheduleTaskTypes", x => x.ScheduleTaskTypEntityId);
                });

            migrationBuilder.CreateTable(
                name: "generic_ScheduleTriggerTypes",
                columns: table => new
                {
                    ScheduleTriggerTypEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_ScheduleTriggerTypes", x => x.ScheduleTriggerTypEntityId);
                });

            migrationBuilder.CreateTable(
                name: "generic_ScheduleTypes",
                columns: table => new
                {
                    ScheduleTypEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_ScheduleTypes", x => x.ScheduleTypEntityId);
                });

            migrationBuilder.CreateTable(
                name: "generic_Settings",
                columns: table => new
                {
                    SettingsEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ServiceTyp = table.Column<string>(nullable: false),
                    ServiceId = table.Column<string>(nullable: false),
                    System = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_Settings", x => x.SettingsEntityId);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_Farm",
                columns: table => new
                {
                    FarmEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmId = table.Column<long>(nullable: false),
                    ThreebotId = table.Column<long>(nullable: true),
                    IyoOrganization = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PrefixZero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_Farm", x => x.FarmEntityId);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_ThreefoldApiUriList",
                columns: table => new
                {
                    ThreefoldApiUriEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Uri = table.Column<string>(nullable: false),
                    Typ = table.Column<string>(nullable: false),
                    List = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_ThreefoldApiUriList", x => x.ThreefoldApiUriEntityId);
                });

            migrationBuilder.CreateTable(
                name: "generic_Abonement",
                columns: table => new
                {
                    AbonementEntityEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    UserFk = table.Column<int>(nullable: false),
                    Target = table.Column<string>(nullable: false),
                    Source = table.Column<string>(nullable: false),
                    AbonementTargetTypEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_Abonement", x => x.AbonementEntityEntityId);
                    table.ForeignKey(
                        name: "FK_generic_Abonement_generic_AbonementTyp_AbonementTargetTypEntityId",
                        column: x => x.AbonementTargetTypEntityId,
                        principalTable: "generic_AbonementTyp",
                        principalColumn: "AbonementTargetTypEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "generic_Functions",
                columns: table => new
                {
                    FunctionEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Class = table.Column<string>(nullable: false),
                    PrivilegeEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_Functions", x => x.FunctionEntityId);
                    table.ForeignKey(
                        name: "FK_generic_Functions_generic_Privileges_PrivilegeEntityId",
                        column: x => x.PrivilegeEntityId,
                        principalTable: "generic_Privileges",
                        principalColumn: "PrivilegeEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "generic_Users",
                columns: table => new
                {
                    UserEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PrivilegesEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_Users", x => x.UserEntityId);
                    table.ForeignKey(
                        name: "FK_generic_Users_generic_Privileges_PrivilegesEntityId",
                        column: x => x.PrivilegesEntityId,
                        principalTable: "generic_Privileges",
                        principalColumn: "PrivilegeEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_FarmLocation",
                columns: table => new
                {
                    FarmLocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City_farm = table.Column<string>(nullable: false),
                    Country_farm = table.Column<string>(nullable: false),
                    Continent_farm = table.Column<string>(nullable: false),
                    Latitude_farm = table.Column<long>(nullable: false),
                    Longitude_farm = table.Column<long>(nullable: false),
                    FarmEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_FarmLocation", x => x.FarmLocationId);
                    table.ForeignKey(
                        name: "FK_nodemon_FarmLocation_nodemon_Farm_FarmEntityId",
                        column: x => x.FarmEntityId,
                        principalTable: "nodemon_Farm",
                        principalColumn: "FarmEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_Node",
                columns: table => new
                {
                    NodeEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<long>(nullable: false),
                    NodeId = table.Column<string>(nullable: false),
                    NodeIdV1 = table.Column<string>(nullable: true),
                    FarmId = table.Column<long>(nullable: false),
                    FarmEntityId = table.Column<int>(nullable: true),
                    OsVersion = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Uptime = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Proofs = table.Column<string>(nullable: true),
                    FreeToUse = table.Column<bool>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    PublicKeyHex = table.Column<string>(nullable: true),
                    WgPorts = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_Node", x => x.NodeEntityId);
                    table.ForeignKey(
                        name: "FK_nodemon_Node_nodemon_Farm_FarmEntityId",
                        column: x => x.FarmEntityId,
                        principalTable: "nodemon_Farm",
                        principalColumn: "FarmEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_ResourcePrice",
                columns: table => new
                {
                    ResourcePriceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<long>(nullable: false),
                    Cru = table.Column<long>(nullable: false),
                    Mru = table.Column<long>(nullable: false),
                    Hru = table.Column<long>(nullable: false),
                    Sru = table.Column<long>(nullable: false),
                    Nru = table.Column<long>(nullable: false),
                    FarmEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_ResourcePrice", x => x.ResourcePriceId);
                    table.ForeignKey(
                        name: "FK_nodemon_ResourcePrice_nodemon_Farm_FarmEntityId",
                        column: x => x.FarmEntityId,
                        principalTable: "nodemon_Farm",
                        principalColumn: "FarmEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "generic_AbonementsToSources",
                columns: table => new
                {
                    AbonementSourceTypEntityId = table.Column<int>(nullable: false),
                    AbonementEntityId = table.Column<int>(nullable: false),
                    AbonementsSourcesEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_AbonementsToSources", x => new { x.AbonementEntityId, x.AbonementSourceTypEntityId });
                    table.ForeignKey(
                        name: "FK_generic_AbonementsToSources_generic_Abonement_AbonementEntityId",
                        column: x => x.AbonementEntityId,
                        principalTable: "generic_Abonement",
                        principalColumn: "AbonementEntityEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_generic_AbonementsToSources_generic_AbonementSourceTyp_AbonementSourceTypEntityId",
                        column: x => x.AbonementSourceTypEntityId,
                        principalTable: "generic_AbonementSourceTyp",
                        principalColumn: "AbonementSourceTypEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "generic_Schedules",
                columns: table => new
                {
                    SchedulesEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ScheduleTypEntityId = table.Column<int>(nullable: false),
                    TimedIntervall = table.Column<long>(type: "bigint", nullable: false),
                    Intervall = table.Column<long>(type: "bigint", nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    LastTime = table.Column<DateTime>(nullable: false),
                    NextTime = table.Column<DateTime>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    UserEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_Schedules", x => x.SchedulesEntityId);
                    table.ForeignKey(
                        name: "FK_generic_Schedules_generic_ScheduleTypes_ScheduleTypEntityId",
                        column: x => x.ScheduleTypEntityId,
                        principalTable: "generic_ScheduleTypes",
                        principalColumn: "ScheduleTypEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_generic_Schedules_generic_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "generic_Users",
                        principalColumn: "UserEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "generic_UserDevices",
                columns: table => new
                {
                    UserDeviceEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DeviceTypEntityId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Secrets = table.Column<string>(nullable: true),
                    Latitude = table.Column<long>(nullable: false),
                    Longitude = table.Column<long>(nullable: false),
                    UserEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_UserDevices", x => x.UserDeviceEntityId);
                    table.ForeignKey(
                        name: "FK_generic_UserDevices_generic_DeviceTypes_DeviceTypEntityId",
                        column: x => x.DeviceTypEntityId,
                        principalTable: "generic_DeviceTypes",
                        principalColumn: "DeviceTypEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_generic_UserDevices_generic_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "generic_Users",
                        principalColumn: "UserEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "generic_UserLocation",
                columns: table => new
                {
                    UserLocationEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Continent = table.Column<string>(nullable: true),
                    Latitude = table.Column<long>(nullable: false),
                    Longitude = table.Column<long>(nullable: false),
                    UserEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_UserLocation", x => x.UserLocationEntityId);
                    table.ForeignKey(
                        name: "FK_generic_UserLocation_generic_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "generic_Users",
                        principalColumn: "UserEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_Iface",
                columns: table => new
                {
                    IfaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Addrs = table.Column<string>(nullable: true),
                    Gateway = table.Column<string>(nullable: true),
                    Macaddress = table.Column<string>(nullable: true),
                    NodeEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_Iface", x => x.IfaceId);
                    table.ForeignKey(
                        name: "FK_nodemon_Iface_nodemon_Node_NodeEntityId",
                        column: x => x.NodeEntityId,
                        principalTable: "nodemon_Node",
                        principalColumn: "NodeEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_NodeHistory",
                columns: table => new
                {
                    NodeHistoryEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<long>(nullable: false),
                    NodeEntityId = table.Column<int>(nullable: false),
                    OsVersion = table.Column<string>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Uptime = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_NodeHistory", x => x.NodeHistoryEntityId);
                    table.ForeignKey(
                        name: "FK_nodemon_NodeHistory_nodemon_Node_NodeEntityId",
                        column: x => x.NodeEntityId,
                        principalTable: "nodemon_Node",
                        principalColumn: "NodeEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_NodeLocation",
                columns: table => new
                {
                    NodeLocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityNode = table.Column<string>(nullable: false),
                    CountryNode = table.Column<string>(nullable: false),
                    ContinentNode = table.Column<string>(nullable: false),
                    LatitudeNode = table.Column<double>(nullable: false),
                    LongitudeNode = table.Column<double>(nullable: false),
                    NodeEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_NodeLocation", x => x.NodeLocationId);
                    table.ForeignKey(
                        name: "FK_nodemon_NodeLocation_nodemon_Node_NodeEntityId",
                        column: x => x.NodeEntityId,
                        principalTable: "nodemon_Node",
                        principalColumn: "NodeEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_PublicConfig",
                columns: table => new
                {
                    PublicConfigEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Master = table.Column<string>(nullable: true),
                    Type = table.Column<long>(nullable: false),
                    Ipv4 = table.Column<string>(nullable: true),
                    Ipv6 = table.Column<string>(nullable: true),
                    Gw4 = table.Column<string>(nullable: true),
                    Gw6 = table.Column<string>(nullable: true),
                    Version = table.Column<long>(nullable: false),
                    NodeEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_PublicConfig", x => x.PublicConfigEntityId);
                    table.ForeignKey(
                        name: "FK_nodemon_PublicConfig_nodemon_Node_NodeEntityId",
                        column: x => x.NodeEntityId,
                        principalTable: "nodemon_Node",
                        principalColumn: "NodeEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_ReservedResources",
                columns: table => new
                {
                    ReservedResourcesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cru = table.Column<long>(nullable: false),
                    Mru = table.Column<long>(nullable: false),
                    Hru = table.Column<long>(nullable: false),
                    Sru = table.Column<long>(nullable: false),
                    NodeEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_ReservedResources", x => x.ReservedResourcesId);
                    table.ForeignKey(
                        name: "FK_nodemon_ReservedResources_nodemon_Node_NodeEntityId",
                        column: x => x.NodeEntityId,
                        principalTable: "nodemon_Node",
                        principalColumn: "NodeEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_TokenHistory",
                columns: table => new
                {
                    TokenHistoryEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountOfTokens = table.Column<long>(nullable: false),
                    PayOutDate = table.Column<DateTime>(nullable: false),
                    NodeEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_TokenHistory", x => x.TokenHistoryEntityId);
                    table.ForeignKey(
                        name: "FK_nodemon_TokenHistory_nodemon_Node_NodeEntityId",
                        column: x => x.NodeEntityId,
                        principalTable: "nodemon_Node",
                        principalColumn: "NodeEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_TotalResources",
                columns: table => new
                {
                    TotalResourcesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cru = table.Column<long>(nullable: false),
                    Mru = table.Column<long>(nullable: false),
                    Hru = table.Column<long>(nullable: false),
                    Sru = table.Column<long>(nullable: false),
                    NodeEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_TotalResources", x => x.TotalResourcesId);
                    table.ForeignKey(
                        name: "FK_nodemon_TotalResources_nodemon_Node_NodeEntityId",
                        column: x => x.NodeEntityId,
                        principalTable: "nodemon_Node",
                        principalColumn: "NodeEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_UsedResources",
                columns: table => new
                {
                    UsedResourcesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cru = table.Column<long>(nullable: false),
                    Mru = table.Column<long>(nullable: false),
                    Hru = table.Column<long>(nullable: false),
                    Sru = table.Column<long>(nullable: false),
                    NodeEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_UsedResources", x => x.UsedResourcesId);
                    table.ForeignKey(
                        name: "FK_nodemon_UsedResources_nodemon_Node_NodeEntityId",
                        column: x => x.NodeEntityId,
                        principalTable: "nodemon_Node",
                        principalColumn: "NodeEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_Workloads",
                columns: table => new
                {
                    WorkloadsEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Network = table.Column<long>(nullable: false),
                    Volume = table.Column<long>(nullable: false),
                    ZdbNamespace = table.Column<long>(nullable: false),
                    Container = table.Column<long>(nullable: false),
                    K8SVm = table.Column<long>(nullable: false),
                    Proxy = table.Column<long>(nullable: false),
                    ReverseProxy = table.Column<long>(nullable: false),
                    Subdomain = table.Column<long>(nullable: false),
                    DelegateDomain = table.Column<long>(nullable: false),
                    NodeEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_Workloads", x => x.WorkloadsEntityId);
                    table.ForeignKey(
                        name: "FK_nodemon_Workloads_nodemon_Node_NodeEntityId",
                        column: x => x.NodeEntityId,
                        principalTable: "nodemon_Node",
                        principalColumn: "NodeEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "generic_SchedulesToDays",
                columns: table => new
                {
                    SchedulesEntityId = table.Column<int>(nullable: false),
                    ScheduleDaysEntityId = table.Column<int>(nullable: false),
                    SchedulesToDaysEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_SchedulesToDays", x => new { x.SchedulesEntityId, x.ScheduleDaysEntityId });
                    table.ForeignKey(
                        name: "FK_generic_SchedulesToDays_generic_ScheduleDays_ScheduleDaysEntityId",
                        column: x => x.ScheduleDaysEntityId,
                        principalTable: "generic_ScheduleDays",
                        principalColumn: "ScheduleDaysEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_generic_SchedulesToDays_generic_Schedules_SchedulesEntityId",
                        column: x => x.SchedulesEntityId,
                        principalTable: "generic_Schedules",
                        principalColumn: "SchedulesEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "generic_ScheduleTasks",
                columns: table => new
                {
                    ScheduleTaskEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ScheduleTaskTypEntityId = table.Column<int>(nullable: false),
                    Task = table.Column<string>(nullable: false),
                    SchedulesEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_ScheduleTasks", x => x.ScheduleTaskEntityId);
                    table.ForeignKey(
                        name: "FK_generic_ScheduleTasks_generic_ScheduleTaskTypes_ScheduleTaskTypEntityId",
                        column: x => x.ScheduleTaskTypEntityId,
                        principalTable: "generic_ScheduleTaskTypes",
                        principalColumn: "ScheduleTaskTypEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_generic_ScheduleTasks_generic_Schedules_SchedulesEntityId",
                        column: x => x.SchedulesEntityId,
                        principalTable: "generic_Schedules",
                        principalColumn: "SchedulesEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "generic_ScheduleToUsers",
                columns: table => new
                {
                    SchedulesEntityId = table.Column<int>(nullable: false),
                    UserEntityId = table.Column<int>(nullable: false),
                    SchedulesToUsersEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_ScheduleToUsers", x => new { x.SchedulesEntityId, x.UserEntityId });
                    table.ForeignKey(
                        name: "FK_generic_ScheduleToUsers_generic_Schedules_SchedulesEntityId",
                        column: x => x.SchedulesEntityId,
                        principalTable: "generic_Schedules",
                        principalColumn: "SchedulesEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_generic_ScheduleToUsers_generic_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "generic_Users",
                        principalColumn: "UserEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "generic_ScheduleTriggers",
                columns: table => new
                {
                    ScheduleTriggerEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ScheduleTriggerTypEntityId = table.Column<int>(nullable: false),
                    Trigger = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    SchedulesEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_ScheduleTriggers", x => x.ScheduleTriggerEntityId);
                    table.ForeignKey(
                        name: "FK_generic_ScheduleTriggers_generic_ScheduleTriggerTypes_ScheduleTriggerTypEntityId",
                        column: x => x.ScheduleTriggerTypEntityId,
                        principalTable: "generic_ScheduleTriggerTypes",
                        principalColumn: "ScheduleTriggerTypEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_generic_ScheduleTriggers_generic_Schedules_SchedulesEntityId",
                        column: x => x.SchedulesEntityId,
                        principalTable: "generic_Schedules",
                        principalColumn: "SchedulesEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_NodeLocationHistory",
                columns: table => new
                {
                    NodeLocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityNode = table.Column<string>(nullable: false),
                    CountryNode = table.Column<string>(nullable: false),
                    ContinentNode = table.Column<string>(nullable: false),
                    LatitudeNode = table.Column<double>(nullable: false),
                    LongitudeNode = table.Column<double>(nullable: false),
                    NodeHistoryEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_NodeLocationHistory", x => x.NodeLocationId);
                    table.ForeignKey(
                        name: "FK_nodemon_NodeLocationHistory_nodemon_NodeHistory_NodeHistoryEntityId",
                        column: x => x.NodeHistoryEntityId,
                        principalTable: "nodemon_NodeHistory",
                        principalColumn: "NodeHistoryEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_ReservedResourcesHistory",
                columns: table => new
                {
                    ReservedResourcesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cru = table.Column<long>(nullable: false),
                    Mru = table.Column<long>(nullable: false),
                    Hru = table.Column<long>(nullable: false),
                    Sru = table.Column<long>(nullable: false),
                    NodeHistoryEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_ReservedResourcesHistory", x => x.ReservedResourcesId);
                    table.ForeignKey(
                        name: "FK_nodemon_ReservedResourcesHistory_nodemon_NodeHistory_NodeHistoryEntityId",
                        column: x => x.NodeHistoryEntityId,
                        principalTable: "nodemon_NodeHistory",
                        principalColumn: "NodeHistoryEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_TotalResourcesHistory",
                columns: table => new
                {
                    TotalResourcesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cru = table.Column<long>(nullable: false),
                    Mru = table.Column<long>(nullable: false),
                    Hru = table.Column<long>(nullable: false),
                    Sru = table.Column<long>(nullable: false),
                    NodeHistoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_TotalResourcesHistory", x => x.TotalResourcesId);
                    table.ForeignKey(
                        name: "FK_nodemon_TotalResourcesHistory_nodemon_NodeHistory_NodeHistoryId",
                        column: x => x.NodeHistoryId,
                        principalTable: "nodemon_NodeHistory",
                        principalColumn: "NodeHistoryEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_UsedResourcesHistory",
                columns: table => new
                {
                    UsedResourcesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cru = table.Column<long>(nullable: false),
                    Mru = table.Column<long>(nullable: false),
                    Hru = table.Column<long>(nullable: false),
                    Sru = table.Column<long>(nullable: false),
                    NodeHistoryEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_UsedResourcesHistory", x => x.UsedResourcesId);
                    table.ForeignKey(
                        name: "FK_nodemon_UsedResourcesHistory_nodemon_NodeHistory_NodeHistoryEntityId",
                        column: x => x.NodeHistoryEntityId,
                        principalTable: "nodemon_NodeHistory",
                        principalColumn: "NodeHistoryEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_Farmer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreebotId = table.Column<long>(nullable: false),
                    IyoOrganization = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false),
                    Nickname = table.Column<string>(nullable: false),
                    WalletAddressesWalletAddressId = table.Column<int>(nullable: true),
                    UserEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_Farmer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nodemon_Farmer_generic_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "generic_Users",
                        principalColumn: "UserEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_WalletAddress",
                columns: table => new
                {
                    WalletAddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asset = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    TokenHistoryEntityId = table.Column<int>(nullable: true),
                    FarmEntityId = table.Column<int>(nullable: true),
                    FarmerEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_WalletAddress", x => x.WalletAddressId);
                    table.ForeignKey(
                        name: "FK_nodemon_WalletAddress_nodemon_Farm_FarmEntityId",
                        column: x => x.FarmEntityId,
                        principalTable: "nodemon_Farm",
                        principalColumn: "FarmEntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_nodemon_WalletAddress_nodemon_Farmer_FarmerEntityId",
                        column: x => x.FarmerEntityId,
                        principalTable: "nodemon_Farmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_nodemon_WalletAddress_nodemon_TokenHistory_TokenHistoryEntityId",
                        column: x => x.TokenHistoryEntityId,
                        principalTable: "nodemon_TokenHistory",
                        principalColumn: "TokenHistoryEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "generic_DeviceTypes",
                columns: new[] { "DeviceTypEntityId", "Name" },
                values: new object[,]
                {
                    { 1, "Messenger" },
                    { 2, "Email" },
                    { 3, "Telephone" },
                    { 4, "WebUI" }
                });

            migrationBuilder.InsertData(
                table: "generic_Privileges",
                columns: new[] { "PrivilegeEntityId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Admin" },
                    { 2, null, "Default" }
                });

            migrationBuilder.InsertData(
                table: "generic_ScheduleDays",
                columns: new[] { "ScheduleDaysEntityId", "Name" },
                values: new object[,]
                {
                    { 6, "Samstag" },
                    { 5, "Freitag" },
                    { 4, "Donnerstag" },
                    { 7, "Sonntag" },
                    { 2, "Dienstag" },
                    { 1, "Montag" },
                    { 3, "Mittwoch" }
                });

            migrationBuilder.InsertData(
                table: "generic_ScheduleTaskTypes",
                columns: new[] { "ScheduleTaskTypEntityId", "Name" },
                values: new object[,]
                {
                    { 1, "GetData" },
                    { 2, "Message" },
                    { 3, "empty" }
                });

            migrationBuilder.InsertData(
                table: "generic_ScheduleTriggerTypes",
                columns: new[] { "ScheduleTriggerTypEntityId", "Name" },
                values: new object[,]
                {
                    { 1, "GotData" },
                    { 2, "GotMessage" },
                    { 3, "ShutOffEvent" },
                    { 4, "ShutOnEvent" },
                    { 5, "TimedEvent" },
                    { 6, "LogEvent" }
                });

            migrationBuilder.InsertData(
                table: "generic_ScheduleTypes",
                columns: new[] { "ScheduleTypEntityId", "Name" },
                values: new object[,]
                {
                    { 2, "Triggered" },
                    { 1, "Timed" },
                    { 3, "empty" }
                });

            migrationBuilder.InsertData(
                table: "generic_Users",
                columns: new[] { "UserEntityId", "Active", "BirthDate", "Description", "Lastname", "Name", "Nickname", "Password", "PrivilegesEntityId" },
                values: new object[] { 1, true, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin", "admin", "admin", "admin", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_generic_Abonement_AbonementTargetTypEntityId",
                table: "generic_Abonement",
                column: "AbonementTargetTypEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_generic_AbonementsToSources_AbonementSourceTypEntityId",
                table: "generic_AbonementsToSources",
                column: "AbonementSourceTypEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_generic_Functions_PrivilegeEntityId",
                table: "generic_Functions",
                column: "PrivilegeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_generic_Schedules_ScheduleTypEntityId",
                table: "generic_Schedules",
                column: "ScheduleTypEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_generic_Schedules_UserEntityId",
                table: "generic_Schedules",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_generic_SchedulesToDays_ScheduleDaysEntityId",
                table: "generic_SchedulesToDays",
                column: "ScheduleDaysEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_generic_ScheduleTasks_ScheduleTaskTypEntityId",
                table: "generic_ScheduleTasks",
                column: "ScheduleTaskTypEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_generic_ScheduleTasks_SchedulesEntityId",
                table: "generic_ScheduleTasks",
                column: "SchedulesEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_generic_ScheduleToUsers_UserEntityId",
                table: "generic_ScheduleToUsers",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_generic_ScheduleTriggers_ScheduleTriggerTypEntityId",
                table: "generic_ScheduleTriggers",
                column: "ScheduleTriggerTypEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_generic_ScheduleTriggers_SchedulesEntityId",
                table: "generic_ScheduleTriggers",
                column: "SchedulesEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_generic_UserDevices_DeviceTypEntityId",
                table: "generic_UserDevices",
                column: "DeviceTypEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_generic_UserDevices_UserEntityId",
                table: "generic_UserDevices",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_generic_UserLocation_UserEntityId",
                table: "generic_UserLocation",
                column: "UserEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_generic_Users_PrivilegesEntityId",
                table: "generic_Users",
                column: "PrivilegesEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_Farmer_UserEntityId",
                table: "nodemon_Farmer",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_Farmer_WalletAddressesWalletAddressId",
                table: "nodemon_Farmer",
                column: "WalletAddressesWalletAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_FarmLocation_FarmEntityId",
                table: "nodemon_FarmLocation",
                column: "FarmEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_Iface_NodeEntityId",
                table: "nodemon_Iface",
                column: "NodeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_Node_FarmEntityId",
                table: "nodemon_Node",
                column: "FarmEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_NodeHistory_NodeEntityId",
                table: "nodemon_NodeHistory",
                column: "NodeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_NodeLocation_NodeEntityId",
                table: "nodemon_NodeLocation",
                column: "NodeEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_NodeLocationHistory_NodeHistoryEntityId",
                table: "nodemon_NodeLocationHistory",
                column: "NodeHistoryEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_PublicConfig_NodeEntityId",
                table: "nodemon_PublicConfig",
                column: "NodeEntityId",
                unique: true,
                filter: "[NodeEntityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_ReservedResources_NodeEntityId",
                table: "nodemon_ReservedResources",
                column: "NodeEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_ReservedResourcesHistory_NodeHistoryEntityId",
                table: "nodemon_ReservedResourcesHistory",
                column: "NodeHistoryEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_ResourcePrice_FarmEntityId",
                table: "nodemon_ResourcePrice",
                column: "FarmEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_TokenHistory_NodeEntityId",
                table: "nodemon_TokenHistory",
                column: "NodeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_TotalResources_NodeEntityId",
                table: "nodemon_TotalResources",
                column: "NodeEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_TotalResourcesHistory_NodeHistoryId",
                table: "nodemon_TotalResourcesHistory",
                column: "NodeHistoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_UsedResources_NodeEntityId",
                table: "nodemon_UsedResources",
                column: "NodeEntityId",
                unique: true,
                filter: "[NodeEntityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_UsedResourcesHistory_NodeHistoryEntityId",
                table: "nodemon_UsedResourcesHistory",
                column: "NodeHistoryEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_WalletAddress_FarmEntityId",
                table: "nodemon_WalletAddress",
                column: "FarmEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_WalletAddress_FarmerEntityId",
                table: "nodemon_WalletAddress",
                column: "FarmerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_WalletAddress_TokenHistoryEntityId",
                table: "nodemon_WalletAddress",
                column: "TokenHistoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_Workloads_NodeEntityId",
                table: "nodemon_Workloads",
                column: "NodeEntityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_nodemon_Farmer_nodemon_WalletAddress_WalletAddressesWalletAddressId",
                table: "nodemon_Farmer",
                column: "WalletAddressesWalletAddressId",
                principalTable: "nodemon_WalletAddress",
                principalColumn: "WalletAddressId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_generic_Users_generic_Privileges_PrivilegesEntityId",
                table: "generic_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_nodemon_Farmer_generic_Users_UserEntityId",
                table: "nodemon_Farmer");

            migrationBuilder.DropForeignKey(
                name: "FK_nodemon_Farmer_nodemon_WalletAddress_WalletAddressesWalletAddressId",
                table: "nodemon_Farmer");

            migrationBuilder.DropTable(
                name: "generic_AbonementsToSources");

            migrationBuilder.DropTable(
                name: "generic_Functions");

            migrationBuilder.DropTable(
                name: "generic_SchedulesToDays");

            migrationBuilder.DropTable(
                name: "generic_ScheduleTasks");

            migrationBuilder.DropTable(
                name: "generic_ScheduleToUsers");

            migrationBuilder.DropTable(
                name: "generic_ScheduleTriggers");

            migrationBuilder.DropTable(
                name: "generic_Settings");

            migrationBuilder.DropTable(
                name: "generic_UserDevices");

            migrationBuilder.DropTable(
                name: "generic_UserLocation");

            migrationBuilder.DropTable(
                name: "nodemon_FarmLocation");

            migrationBuilder.DropTable(
                name: "nodemon_Iface");

            migrationBuilder.DropTable(
                name: "nodemon_NodeLocation");

            migrationBuilder.DropTable(
                name: "nodemon_NodeLocationHistory");

            migrationBuilder.DropTable(
                name: "nodemon_PublicConfig");

            migrationBuilder.DropTable(
                name: "nodemon_ReservedResources");

            migrationBuilder.DropTable(
                name: "nodemon_ReservedResourcesHistory");

            migrationBuilder.DropTable(
                name: "nodemon_ResourcePrice");

            migrationBuilder.DropTable(
                name: "nodemon_ThreefoldApiUriList");

            migrationBuilder.DropTable(
                name: "nodemon_TotalResources");

            migrationBuilder.DropTable(
                name: "nodemon_TotalResourcesHistory");

            migrationBuilder.DropTable(
                name: "nodemon_UsedResources");

            migrationBuilder.DropTable(
                name: "nodemon_UsedResourcesHistory");

            migrationBuilder.DropTable(
                name: "nodemon_Workloads");

            migrationBuilder.DropTable(
                name: "generic_Abonement");

            migrationBuilder.DropTable(
                name: "generic_AbonementSourceTyp");

            migrationBuilder.DropTable(
                name: "generic_ScheduleDays");

            migrationBuilder.DropTable(
                name: "generic_ScheduleTaskTypes");

            migrationBuilder.DropTable(
                name: "generic_ScheduleTriggerTypes");

            migrationBuilder.DropTable(
                name: "generic_Schedules");

            migrationBuilder.DropTable(
                name: "generic_DeviceTypes");

            migrationBuilder.DropTable(
                name: "nodemon_NodeHistory");

            migrationBuilder.DropTable(
                name: "generic_AbonementTyp");

            migrationBuilder.DropTable(
                name: "generic_ScheduleTypes");

            migrationBuilder.DropTable(
                name: "generic_Privileges");

            migrationBuilder.DropTable(
                name: "generic_Users");

            migrationBuilder.DropTable(
                name: "nodemon_WalletAddress");

            migrationBuilder.DropTable(
                name: "nodemon_Farmer");

            migrationBuilder.DropTable(
                name: "nodemon_TokenHistory");

            migrationBuilder.DropTable(
                name: "nodemon_Node");

            migrationBuilder.DropTable(
                name: "nodemon_Farm");
        }
    }
}
