using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TermsAndConditions = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breedings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breedings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kinds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Socials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameDutch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KindId = table.Column<int>(type: "int", nullable: false),
                    ContinentId = table.Column<int>(type: "int", nullable: false),
                    SocialId = table.Column<int>(type: "int", nullable: false),
                    BreedingId = table.Column<int>(type: "int", nullable: false),
                    DietId = table.Column<int>(type: "int", nullable: false),
                    TempMax = table.Column<int>(type: "int", nullable: false),
                    TempMin = table.Column<int>(type: "int", nullable: false),
                    PhMax = table.Column<int>(type: "int", nullable: false),
                    PhMin = table.Column<int>(type: "int", nullable: false),
                    GhMax = table.Column<int>(type: "int", nullable: false),
                    GhMin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Breedings_BreedingId",
                        column: x => x.BreedingId,
                        principalTable: "Breedings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Continents_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Kinds_KindId",
                        column: x => x.KindId,
                        principalTable: "Kinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Socials_SocialId",
                        column: x => x.SocialId,
                        principalTable: "Socials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10000000-0000-0000-0000-000000000003", "716fdb58-cb05-4688-b4ee-4067131b049f", "User", "USER" },
                    { "10000000-0000-0000-0000-000000000001", "fa11930c-a975-4055-8792-7435755cf985", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TermsAndConditions", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00000000-1111-1111-1111-000000000004", 0, new DateTime(1985, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "128af8f2-454f-4d9y-91f7-fd72b5632d94", "mde-user@imi.be", true, false, null, "MDE-USER@IMI.BE", "MDE-USER@IMI.BE", "AQAAAAEAACcQAAAAEAxb20ebTpJZUM1XcrLDg3DnsPAm3KszOR2YMcNoTWNZehH91CV/N6a3nlO8iYgk9w==", null, false, "704af8f2-454f-4c67-91f7-fd72b3082d94", true, false, "mde-user@imi.be" },
                    { "00000000-1111-1111-1111-000000000001", 0, new DateTime(1985, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "4ef543f6-20a4-435d-b3fe-8dfe368439e5", "admin@imi.be", true, false, null, "ADMIN@IMI.BE", "ADMIN@IMI.BE", "AQAAAAEAACcQAAAAEDcPC1O5OIPTf1UPfoi4UigDmwv001ZBeIA6oHExMfEnwVfgmyZQhH4eoL1laZYYsg==", null, false, "82855de4-2699-409c-aa9e-426bf6dd73ad", true, false, "admin@imi.be" },
                    { "00000000-1111-1111-1111-000000000003", 0, new DateTime(1965, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "97b5c114-8f42-4c1f-b7c2-d7cb5039b989", "refuser@imi.be", true, false, null, "REFUSER@IMI.BE", "REFUSER@IMI.BE", "AQAAAAEAACcQAAAAEH3BWSeNxRD9CCNMpByDHGMVAc+cHqBGyWER63Q3jI/V3kGFP+g5TIznJm83D+4jgA==", null, false, "3406f134-0b4b-47c6-a9c6-a38a5fc352a0", false, false, "refuser@imi.be" },
                    { "00000000-1111-1111-1111-000000000002", 0, new DateTime(1985, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "a6a4703e-8c70-40b5-bd11-cda1be1a7e5f", "user@imi.be", true, false, null, "USER@IMI.BE", "USER@IMI.BE", "AQAAAAEAACcQAAAAEMLBN+xr4cd3OsgMYo50EK8BmqPxqtzv7imZ74wIoDuNwKopXkNn9NjfiowUtI3q4w==", null, false, "3e5afa49-5b79-4d3b-b2d8-35bbda250834", true, false, "user@imi.be" }
                });

            migrationBuilder.InsertData(
                table: "Breedings",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Schuimnestbouwer" },
                    { 2, "Holenbroeder" },
                    { 3, "Vrijlegger" },
                    { 4, "Substraatbroeder" },
                    { 5, "Muilbroeder" },
                    { 6, "Vrouwtje houdt bij" },
                    { 7, "Eierlevendbarend" },
                    { 8, "Bodemleggers" },
                    { 9, "Koekoeksbroeders" },
                    { 10, "Mannetje houdt bij" }
                });

            migrationBuilder.InsertData(
                table: "Continents",
                columns: new[] { "Id", "Image", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 10, null, "https://upload.wikimedia.org/wikipedia/commons/thumb/0/05/Lake_Malawi_seen_from_orbit.jpg/266px-Lake_Malawi_seen_from_orbit.jpg", "Malawi" },
                    { 9, null, "https://upload.wikimedia.org/wikipedia/commons/thumb/8/82/LocationMadagascar.svg/1920px-LocationMadagascar.svg.png", "Madagaskar" },
                    { 8, null, "https://www.landenkompas.nl/img/continenten/continent-europa.png", "Europa" },
                    { 7, null, "https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Middle_America_%28orthographic_projection%29.svg/266px-Middle_America_%28orthographic_projection%29.svg.png", "Midden-Amerika" },
                    { 3, null, "https://www.landenkompas.nl/img/continenten/continent-noord-amerika.png", "Noord-Amerika" },
                    { 5, null, "https://upload.wikimedia.org/wikipedia/commons/thumb/0/06/Atlantic_Ocean.png/266px-Atlantic_Ocean.png", "Atlantische Oceaan" },
                    { 4, null, "https://www.landenkompas.nl/img/continenten/continent-zuid-amerika.png", "Zuid-Amerika" },
                    { 2, null, "https://www.landenkompas.nl/img/continenten/continent-afrika.png", "Afrika" },
                    { 1, null, "https://www.landenkompas.nl/img/continenten/continent-azie.png", "Azië" },
                    { 6, null, "https://www.landenkompas.nl/img/continenten/continent-oceanie.png", "Australië - Oceanië" }
                });

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "Levende vissen" },
                    { 10, "Watervlooien" },
                    { 9, "Muggenlarven - Levend voer" },
                    { 7, "Artemia - Levend voer" },
                    { 4, "Daphnia - Droogvoer" },
                    { 5, "Spirulina - Droogvoer" },
                    { 6, "Carnivoor" },
                    { 2, "Herbivoor" },
                    { 1, "Omnivoor" },
                    { 3, "Algentabletten" }
                });

            migrationBuilder.InsertData(
                table: "Kinds",
                columns: new[] { "Id", "Image", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, null, "https://img.pixers.pics/pho_wat(s3:700/FO/52/08/83/96/700_FO52088396_612b0a2384be2c002b7be437f3372043.jpg,700,494,cms:2018/10/5bd1b6b8d04b8_220x50-watermark.png,over,480,444,jpg)/stickers-leuke-cartoon-vis.jpg.jpg", "Vis" },
                    { 8, null, "https://media.istockphoto.com/vectors/cartoon-happy-oyster-vector-id470840750?b=1&k=20&m=470840750&s=612x612&w=0&h=bN-iY22PQ9zgL2r1ZgtY6GJwnED_mC4CatojSiJ9Y-0=", "Schelpdieren" },
                    { 6, null, "https://us.123rf.com/450wm/vectorcoolarts/vectorcoolarts2104/vectorcoolarts210400025/168293491-leuke-vrolijke-krab-cartoon-afbeelding.jpg?ver=6", "Krab" },
                    { 9, null, "https://img.freepik.com/premium-vector/gelukkig-schildpad-cartoon_160606-329.jpg?w=2000", "Schildpad" },
                    { 4, null, "https://img.freepik.com/premium-vector/schattige-cartoon-slak_160606-341.jpg?w=2000", "Slak" },
                    { 3, null, "https://img.freepik.com/premium-vector/cartoon-kreeft-illustratie_29190-3564.jpg?w=2000", "Kreeft" }
                });

            migrationBuilder.InsertData(
                table: "Kinds",
                columns: new[] { "Id", "Image", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 2, null, "https://img.pixers.pics/pho_wat(s3:700/FO/45/52/09/12/700_FO45520912_f40c182c4c12dc9f2610125a81b8b8b3.jpg,700,540,cms:2018/10/5bd1b6b8d04b8_220x50-watermark.png,over,480,490,jpg)/fotobehang-grappige-garnalen-cartoon.jpg.jpg", "Garnaal" },
                    { 5, null, "https://i.pinimg.com/originals/dd/f2/78/ddf2783a9bed5888963ecf47a8e6a53d.jpg", "Amfibiën" },
                    { 7, null, "https://static.vecteezy.com/ti/gratis-vector/p3/1265646-schattig-blauw-zeepaardje-cartoon-vector.jpg", "Zeepaarden" }
                });

            migrationBuilder.InsertData(
                table: "Socials",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Solitair" },
                    { 2, "Koppel" },
                    { 3, "Groep" },
                    { 4, "Harem" },
                    { 5, "Kolonie" },
                    { 6, "School" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "BreedingId", "ContinentId", "DietId", "GhMax", "GhMin", "Image", "ImageUrl", "KindId", "NameDutch", "NameFamily", "PhMax", "PhMin", "SocialId", "TempMax", "TempMin" },
                values: new object[,]
                {
                    { 4, 6, 4, 8, 6, 2, null, "https://vissenaquarium.nl/wp-content/uploads/2016/05/Zilveren-Arowana-300x199.jpg", 1, "Zilveren Arowana", "Osteoglossidae", 7, 6, 3, 28, 23 },
                    { 10, 3, 1, 6, 10, 3, null, "https://www.aquariumvissenwinkel.nl/pub/media/catalog/product/cache/6adf04d0a500106b8356e43536d091ec/g/a/galaxyrasbora2.jpg", 1, "Rasbora Galaxy", "Cyprinidae", 8, 7, 6, 25, 20 },
                    { 7, 6, 2, 1, 20, 5, null, "https://www.garnalenkweker.nl/database/garnalenfotos/gk_shrimp_atya_gabonensis_02.jpg", 2, "Afrikaanse Waaierhandgarnaal", "Atyidae", 8, 6, 4, 30, 20 },
                    { 8, 6, 6, 1, 20, 5, null, "https://www.aquainfo.nl/wp-content/uploads/2018/03/Caridina-sp-Sulawesi-Kardinaal-Garnaal.jpg", 2, "Kardinaalgarnaal", "Atyidae", 8, 6, 3, 25, 18 },
                    { 1, 1, 1, 1, 12, 8, null, "https://www.aquariumfans.nl/wp-content/uploads/2016/09/Een-kempvis-spreidt-zijn-prachtige-rode-vinnen.jpg", 1, "Betta Splendens", "Osphronemidae", 8, 7, 1, 28, 20 },
                    { 9, 7, 5, 6, 7, 4, null, "https://aquainfo.nl/wp-content/uploads/2012/09/Diodon-holocanthus-opgezet-1.jpg", 1, "Ballonegelvis", "Diodontidae", 9, 8, 1, 26, 23 },
                    { 11, 4, 7, 6, 7, 5, null, "https://usercontent.one/wp/www.salamanders.nl/wp-content/uploads/2018/08/axolotl-1-1024x678.jpg", 5, "Axolotl", "Gymnophiona", 8, 6, 1, 20, 14 },
                    { 2, 2, 4, 3, 15, 5, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzOSqOT7KqM_Dd81qqwWrPgkxCpF1AWq8LynTdeKWcV7DsJf8-qd7O2knrmu4nuz8k2dU&usqp=CAU", 1, "Ancistruss", "Loricariidae", 8, 6, 2, 26, 23 },
                    { 3, 6, 1, 9, 15, 5, null, "https://dennerle.com/sites/default/files/styles/newspicture/public/uploads/public/news/geosesarma-dennerle.jpg?itok=UlaS87qc", 6, "Vampierkrab", "Sesarmidae", 8, 6, 3, 26, 23 },
                    { 6, 3, 2, 6, 15, 5, null, "https://cdn.myonlinestore.eu/93c794e2-6be1-11e9-a722-44a8421b9960/image/cache/article/e19adb5fb7200b2ec41c5f5242733222e2f3ca6c.jpg", 5, "Dwergklauwkikker", "Pipidae", 7, 5, 3, 27, 24 },
                    { 5, 4, 1, 6, 30, 10, null, "https://www.azaqua.nl/14525-thickbox_default/neritina-waigiensis.jpg", 4, "Rode Neritina Slak", "Neritidae", 9, 7, 3, 30, 20 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "HasApprovedTermsAndConditions", "True", "00000000-1111-1111-1111-000000000001" },
                    { 4, "HasApprovedTermsAndConditions", "True", "00000000-1111-1111-1111-000000000004" },
                    { 3, "HasApprovedTermsAndConditions", "False", "00000000-1111-1111-1111-000000000003" },
                    { 2, "HasApprovedTermsAndConditions", "True", "00000000-1111-1111-1111-000000000002" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "10000000-0000-0000-0000-000000000001", "00000000-1111-1111-1111-000000000001" },
                    { "10000000-0000-0000-0000-000000000001", "00000000-1111-1111-1111-000000000004" },
                    { "10000000-0000-0000-0000-000000000003", "00000000-1111-1111-1111-000000000002" },
                    { "10000000-0000-0000-0000-000000000003", "00000000-1111-1111-1111-000000000003" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_BreedingId",
                table: "Animals",
                column: "BreedingId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ContinentId",
                table: "Animals",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_DietId",
                table: "Animals",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_KindId",
                table: "Animals",
                column: "KindId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SocialId",
                table: "Animals",
                column: "SocialId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

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
                name: "Breedings");

            migrationBuilder.DropTable(
                name: "Continents");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "Kinds");

            migrationBuilder.DropTable(
                name: "Socials");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
