using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLib.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nodemon_AbonementSourceTyp",
                columns: table => new
                {
                    AbonementSourceTypEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Typ = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_AbonementSourceTyp", x => x.AbonementSourceTypEntityId);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_AbonementTyp",
                columns: table => new
                {
                    AbonementTargetTypEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Typ = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_AbonementTyp", x => x.AbonementTargetTypEntityId);
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
                name: "nodemon_ScheduleDays",
                columns: table => new
                {
                    NodeMonScheduleDaysEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DayTypNr = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_ScheduleDays", x => x.NodeMonScheduleDaysEntityId);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_Schedules",
                columns: table => new
                {
                    NodeMonSchedulesEntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ScheduleTyp = table.Column<string>(nullable: false),
                    TimedIntervall = table.Column<long>(nullable: false),
                    Intervall = table.Column<long>(nullable: false),
                    StartTime = table.Column<string>(nullable: false),
                    EndTime = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_Schedules", x => x.NodeMonSchedulesEntityId);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_Settings",
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
                    table.PrimaryKey("PK_nodemon_Settings", x => x.SettingsEntityId);
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
                name: "nodemon_Abonement",
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
                    table.PrimaryKey("PK_nodemon_Abonement", x => x.AbonementEntityEntityId);
                    table.ForeignKey(
                        name: "FK_nodemon_Abonement_nodemon_AbonementTyp_AbonementTargetTypEntityId",
                        column: x => x.AbonementTargetTypEntityId,
                        principalTable: "nodemon_AbonementTyp",
                        principalColumn: "AbonementTargetTypEntityId",
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
                    Created = table.Column<long>(nullable: false),
                    Updated = table.Column<long>(nullable: false),
                    Uptime = table.Column<long>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Proofs = table.Column<string>(nullable: true),
                    PublicConfig = table.Column<string>(nullable: true),
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
                name: "nodemon_SchedulesToDays",
                columns: table => new
                {
                    NodeMonSchedulesEntityId = table.Column<int>(nullable: false),
                    NodeMonScheduleDaysEntityId = table.Column<int>(nullable: false),
                    NodeMonSchedulesToDaysEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_SchedulesToDays", x => new { x.NodeMonSchedulesEntityId, x.NodeMonScheduleDaysEntityId });
                    table.ForeignKey(
                        name: "FK_nodemon_SchedulesToDays_nodemon_ScheduleDays_NodeMonScheduleDaysEntityId",
                        column: x => x.NodeMonScheduleDaysEntityId,
                        principalTable: "nodemon_ScheduleDays",
                        principalColumn: "NodeMonScheduleDaysEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nodemon_SchedulesToDays_nodemon_Schedules_NodeMonSchedulesEntityId",
                        column: x => x.NodeMonSchedulesEntityId,
                        principalTable: "nodemon_Schedules",
                        principalColumn: "NodeMonSchedulesEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nodemon_AbonementsToSources",
                columns: table => new
                {
                    AbonementSourceTypEntityId = table.Column<int>(nullable: false),
                    AbonementEntityId = table.Column<int>(nullable: false),
                    AbonementsSourcesEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_AbonementsToSources", x => new { x.AbonementEntityId, x.AbonementSourceTypEntityId });
                    table.ForeignKey(
                        name: "FK_nodemon_AbonementsToSources_nodemon_Abonement_AbonementEntityId",
                        column: x => x.AbonementEntityId,
                        principalTable: "nodemon_Abonement",
                        principalColumn: "AbonementEntityEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nodemon_AbonementsToSources_nodemon_AbonementSourceTyp_AbonementSourceTypEntityId",
                        column: x => x.AbonementSourceTypEntityId,
                        principalTable: "nodemon_AbonementSourceTyp",
                        principalColumn: "AbonementSourceTypEntityId",
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
                    Updated = table.Column<long>(nullable: false),
                    Uptime = table.Column<long>(nullable: false)
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
                        name: "FK_nodemon_WalletAddress_nodemon_TokenHistory_TokenHistoryEntityId",
                        column: x => x.TokenHistoryEntityId,
                        principalTable: "nodemon_TokenHistory",
                        principalColumn: "TokenHistoryEntityId",
                        onDelete: ReferentialAction.Restrict);
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
                    WalletAddressesWalletAddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodemon_Farmer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nodemon_Farmer_nodemon_WalletAddress_WalletAddressesWalletAddressId",
                        column: x => x.WalletAddressesWalletAddressId,
                        principalTable: "nodemon_WalletAddress",
                        principalColumn: "WalletAddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_Abonement_AbonementTargetTypEntityId",
                table: "nodemon_Abonement",
                column: "AbonementTargetTypEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_nodemon_AbonementsToSources_AbonementSourceTypEntityId",
                table: "nodemon_AbonementsToSources",
                column: "AbonementSourceTypEntityId");

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
                name: "IX_nodemon_SchedulesToDays_NodeMonScheduleDaysEntityId",
                table: "nodemon_SchedulesToDays",
                column: "NodeMonScheduleDaysEntityId");

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
                name: "FK_nodemon_WalletAddress_nodemon_Farmer_FarmerEntityId",
                table: "nodemon_WalletAddress",
                column: "FarmerEntityId",
                principalTable: "nodemon_Farmer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_nodemon_Farmer_nodemon_WalletAddress_WalletAddressesWalletAddressId",
                table: "nodemon_Farmer");

            migrationBuilder.DropTable(
                name: "nodemon_AbonementsToSources");

            migrationBuilder.DropTable(
                name: "nodemon_FarmLocation");

            migrationBuilder.DropTable(
                name: "nodemon_Iface");

            migrationBuilder.DropTable(
                name: "nodemon_NodeLocation");

            migrationBuilder.DropTable(
                name: "nodemon_NodeLocationHistory");

            migrationBuilder.DropTable(
                name: "nodemon_ReservedResources");

            migrationBuilder.DropTable(
                name: "nodemon_ReservedResourcesHistory");

            migrationBuilder.DropTable(
                name: "nodemon_ResourcePrice");

            migrationBuilder.DropTable(
                name: "nodemon_SchedulesToDays");

            migrationBuilder.DropTable(
                name: "nodemon_Settings");

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
                name: "nodemon_Abonement");

            migrationBuilder.DropTable(
                name: "nodemon_AbonementSourceTyp");

            migrationBuilder.DropTable(
                name: "nodemon_ScheduleDays");

            migrationBuilder.DropTable(
                name: "nodemon_Schedules");

            migrationBuilder.DropTable(
                name: "nodemon_NodeHistory");

            migrationBuilder.DropTable(
                name: "nodemon_AbonementTyp");

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
