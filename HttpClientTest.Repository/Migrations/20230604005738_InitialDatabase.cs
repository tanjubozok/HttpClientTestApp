using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HttpClientTest.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    AppRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppRoles_AppRoleId",
                        column: x => x.AppRoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogCategories_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    AuthorEmail = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentCommentId = table.Column<int>(type: "int", nullable: true),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Member" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Email", "Name", "Password", "Surname", "Username" },
                values: new object[,]
                {
                    { 1, "admin@localhost", "Admin", "123456", "Guest", "admin" },
                    { 2, "member@localhost", "Member", "123456", "Guest", "member" },
                    { 3, ".@gmail.com", "Kezlik", "x_kMIA", "Abacı", "Bulut.Akan50" },
                    { 4, ".28@yahoo.com", "Altan", "6Fl7gv", "Gürmen", "Boncuk48" },
                    { 5, "_25@yahoo.com", "Adlıbeğ", "1FVSAd", "Akyürek", "Gonul_Ozbir46" },
                    { 6, ".@gmail.com", "Ekeç", "4VdxIH", "Tütüncü", "Adraman.Kuzucu" },
                    { 7, ".@hotmail.com", "Ilgın", "oMYTiy", "Baykam", "Adiguzel20" },
                    { 8, "96@yahoo.com", "Buzaçtutuk", "iSwmF8", "Kaplangı", "Kivanc_Turkyilmaz" },
                    { 9, "71@yahoo.com", "Çemgen", "LqnmGe", "Evliyaoğlu", "Baltar_Sarioglu" },
                    { 10, "70@hotmail.com", "Bozkurt", "c93AW1", "Okumuş", "Bagtas_Duygulu93" },
                    { 11, "_81@gmail.com", "Bağatursepi", "qGuggl", "Babacan", "Kizilalma.Koc62" },
                    { 12, "_49@yahoo.com", "Alpyörük", "gh8zpX", "Çetiner", "Abaka72" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Books & Home" },
                    { 2, "Industrial & Clothing" },
                    { 3, "Sports & Beauty" },
                    { 4, "Toys & Shoes" },
                    { 5, "Grocery" },
                    { 6, "Outdoors & Shoes" },
                    { 7, "Electronics & Home" },
                    { 8, "Tools & Health" },
                    { 9, "Jewelery" },
                    { 10, "Kids & Garden" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "Id", "AppRoleId", "AppUserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 2, 3 },
                    { 4, 2, 4 },
                    { 5, 2, 5 },
                    { 6, 2, 6 },
                    { 7, 2, 7 },
                    { 8, 2, 8 },
                    { 9, 2, 9 },
                    { 10, 2, 10 },
                    { 11, 2, 11 },
                    { 12, 2, 12 }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "AppUserId", "CreatedAt", "Description", "ImagePath", "ShortDescription", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 10, 3, 12, 7, 50, 54, DateTimeKind.Local).AddTicks(5326), "Consectetur ab ut quasi ducimus numquam dicta quasi. Consequatur qui molestiae quia için. İçin çünkü beğendim dolorem çobanın quasi kutusu tempora blanditiis. Dolorem eum dağılımı modi.", "default.jpeg", "Balıkhaneye cesurca adresini qui otobüs ışık ipsum ad değirmeni eaque ki nisi voluptas eve teldeki dergi yapacakmış çünkü dolorem magni quia.", "Sıla gitti quia ut un quis." },
                    { 2, 1, new DateTime(2022, 7, 4, 17, 18, 21, 391, DateTimeKind.Local).AddTicks(1403), "Labore ad mıknatıslı. Nesciunt voluptatem qui dolore gazete sit. Karşıdakine quis vitae praesentium öyle sandalye adanaya. Tv aut ipsum hesap sed tv. İusto ona ut ipsam.", "default.jpeg", "Gidecekmiş accusantium sevindi sed açılmadan nostrum de neque umut in kapının yaptı magni.", "Mi lakin." },
                    { 3, 1, new DateTime(2022, 12, 6, 19, 14, 55, 291, DateTimeKind.Local).AddTicks(4826), "Mi eaque ipsam. Explicabo architecto voluptatem dolores corporis odio. Un un et. Corporis nesciunt kapının rem vitae totam kapının ex.", "default.jpeg", "Nihil sıfat et consequuntur kalemi patlıcan ipsam koştum filmini sıla oldular ekşili dolorem nihil gazete illo totam ve aut quia.", "Voluptatem dolor dicta corporis sevindi dolayı ea doloremque hesap ullam ducimus." },
                    { 4, 1, new DateTime(2022, 12, 10, 9, 12, 3, 729, DateTimeKind.Local).AddTicks(3759), "İncidunt in ipsum quia sarmal qui gitti enim umut explicabo. Sandalye veritatis quae eius koştum ea amet ekşili gitti. Makinesi totam türemiş veniam tv ut iure nisi sit.", "default.jpeg", "Aperiam numquam dağılımı aut çorba incidunt ratione quis için doloremque çarpan explicabo quasi koşuyorlar koşuyorlar bahar illo aut de doğru.", "Sıradanlıktan et in deleniti ut uzattı sandalye ekşili blanditiis." },
                    { 5, 1, new DateTime(2022, 8, 11, 16, 59, 13, 803, DateTimeKind.Local).AddTicks(4777), "Ut eius olduğu patlıcan ipsum molestiae labore öyle. Ratione değirmeni velit non dicta ışık kutusu çünkü. Quaerat quis ut perferendis. Beğendim kalemi laudantium beğendim tempora. De quasi ut gülüyorum architecto quia magni. Quaerat okuma bilgiyasayarı.", "default.jpeg", "Gidecekmiş mi ut yaptı iure ut aperiam adipisci amet autem amet totam ab veniam rem ama sıfat blanditiis qui commodi koşuyorlar açılmadan doğru eaque sevindi dolorem için.", "Voluptatem neque sed çorba et." },
                    { 6, 1, new DateTime(2022, 7, 29, 0, 4, 6, 770, DateTimeKind.Local).AddTicks(1395), "Quaerat bundan makinesi eum. Ona ışık aliquam çobanın perferendis. Bilgisayarı quis voluptatem voluptatem beatae çorba sequi çarpan bilgiyasayarı odit. Dağılımı dolorem filmini gülüyorum incidunt koşuyorlar eius telefonu.", "default.jpeg", "Layıkıyla labore quis ama numquam quia magni reprehenderit minima sequi anlamsız et teldeki.", "Teldeki totam gitti hesap iusto commodi okuma." },
                    { 7, 1, new DateTime(2023, 5, 28, 13, 33, 56, 834, DateTimeKind.Local).AddTicks(188), "Voluptatem aut teldeki illo consequatur ipsam fugit. Voluptatem kalemi dolayı. Eum quia hesap anlamsız nisi sokaklarda sit et alias cesurca. Sarmal biber veniam gördüm qui sed bilgiyasayarı quia. Eum vel filmini iusto.", "default.jpeg", "Göze labore camisi fugit sit tempora voluptate tv mutlu dignissimos sit çobanın sequi nemo eve nemo enim camisi ut reprehenderit balıkhaneye sed.", "Qui." },
                    { 8, 1, new DateTime(2022, 7, 23, 1, 3, 4, 5, DateTimeKind.Local).AddTicks(440), "Biber uzattı çorba un suscipit çobanın. Architecto quae accusantium domates sit. Quae qui consequatur kutusu yaptı ışık adresini sequi uzattı oldular. Çarpan cesurca voluptatem cesurca reprehenderit sed dışarı. Consequatur quia bilgiyasayarı sinema sandalye sıfat qui lakin voluptatem alias. Domates aspernatur sarmal et anlamsız patlıcan alias exercitationem göze.", "default.jpeg", "Labore aspernatur beatae sevindi hesap sit qui sıla sequi modi salladı layıkıyla sed magni labore et accusantium ona neque sandalye de.", "Çorba." },
                    { 9, 1, new DateTime(2023, 1, 7, 17, 26, 28, 50, DateTimeKind.Local).AddTicks(5971), "İpsum consequuntur voluptatem değirmeni sarmal suscipit. Sokaklarda lambadaki değerli commodi commodi illo amet beğendim. Balıkhaneye hesap consequatur dolorem batarya koyun için gördüm ea.", "default.jpeg", "Odit voluptatem illo sequi çobanın corporis çorba eaque voluptatem in quia ipsa reprehenderit nihil dolayı.", "Ad suscipit duyulmamış ki sıfat kutusu biber." },
                    { 10, 1, new DateTime(2022, 8, 16, 2, 12, 51, 415, DateTimeKind.Local).AddTicks(5096), "Vitae eos ut in düşünüyor karşıdakine. Consequuntur dolayı sevindi exercitationem rem ullam için filmini sandalye architecto. Et explicabo inventore enim çünkü explicabo orta numquam. Dolore lakin qui domates ipsam laudantium. Gül suscipit salladı dignissimos gül sit değirmeni.", "default.jpeg", "Amet adresini autem mıknatıslı ki için sevindi enim masaya quis balıkhaneye vitae çarpan minima.", "Dağılımı sinema gördüm labore praesentium dignissimos ve ut." },
                    { 11, 1, new DateTime(2023, 2, 13, 1, 14, 40, 484, DateTimeKind.Local).AddTicks(6497), "Quae mıknatıslı cezbelendi odio. De domates sit. Hesap kutusu dağılımı esse aliquid. Sunt numquam çobanın quis sayfası vel duyulmamış kutusu dolore sandalye. Aut bahar şafak explicabo ratione sayfası amet çakıl doloremque olduğu. Yaptı reprehenderit esse ipsa.", "default.jpeg", "Laboriosam gülüyorum kutusu nesciunt ex göze umut ut eos de ama türemiş orta magni ona ratione dignissimos ışık ut adipisci voluptatum neque gördüm bilgiyasayarı ex un alias cezbelendi fugit nostrum.", "Sıradanlıktan rem hesap explicabo architecto göze dışarı." },
                    { 12, 1, new DateTime(2022, 10, 19, 1, 36, 10, 588, DateTimeKind.Local).AddTicks(7444), "Telefonu değirmeni otobüs makinesi balıkhaneye quae gidecekmiş değirmeni magni amet. Kalemi fugit reprehenderit voluptatum. Türemiş mi dağılımı ötekinden. Ötekinden gülüyorum sıradanlıktan sit sed.", "default.jpeg", "Layıkıyla qui blanditiis adipisci teldeki değirmeni consequatur corporis autem modi velit gidecekmiş eum quia açılmadan ullam ut ut patlıcan qui çıktılar quis in sit balıkhaneye veniam aut nostrum dolorem nostrum.", "Bundan inventore veritatis ut et adresini için anlamsız." },
                    { 13, 1, new DateTime(2023, 4, 3, 22, 57, 25, 604, DateTimeKind.Local).AddTicks(6901), "Aliquam corporis magni bilgiyasayarı aspernatur düşünüyor. Kutusu aperiam tv yapacakmış beğendim adipisci uzattı ipsum ducimus sit. Hesap dolore ut incidunt dağılımı biber doloremque doğru tv eum.", "default.jpeg", "Qui kalemi ipsum voluptatem dağılımı voluptatem ut ona çıktılar dolorem değirmeni quae quam adresini ipsam nemo değerli adanaya consequuntur bilgisayarı sequi gördüm.", "Işık çıktılar sit." },
                    { 14, 1, new DateTime(2023, 3, 19, 22, 46, 20, 184, DateTimeKind.Local).AddTicks(3230), "Adipisci çobanın dolayı filmini adipisci sit orta mıknatıslı sevindi magnam. Nostrum göze laudantium quia. İncidunt patlıcan vel. Dolore sandalye sequi gördüm mıknatıslı. Bilgisayarı nostrum vitae voluptatum çarpan consequuntur deleniti quia. Çakıl voluptatem eius accusantium sevindi quis lambadaki.", "default.jpeg", "Layıkıyla aut laboriosam domates sunt kutusu iure un hesap batarya çünkü numquam camisi ona consequatur teldeki voluptatem çıktılar deleniti sed ratione.", "Çıktılar de ea modi sevindi masaya." },
                    { 15, 1, new DateTime(2022, 8, 2, 20, 5, 8, 90, DateTimeKind.Local).AddTicks(9239), "Gül voluptas nesciunt quasi düşünüyor orta ea nemo. Sıfat sunt exercitationem koyun blanditiis. Dergi ducimus ex consequatur quia teldeki. Adanaya voluptatem ut eos değirmeni gidecekmiş dergi laudantium. Olduğu esse nostrum nemo çarpan yapacakmış duyulmamış ötekinden otobüs veniam. Laboriosam ışık modi quam balıkhaneye laudantium deleniti.", "default.jpeg", "Değerli et nihil veritatis koyun karşıdakine anlamsız explicabo ab ekşili.", "Şafak veniam de accusantium ve adanaya praesentium eum kulu çıktılar." },
                    { 16, 1, new DateTime(2023, 1, 25, 6, 28, 39, 897, DateTimeKind.Local).AddTicks(2329), "Quis nesciunt gördüm. Koşuyorlar suscipit consequatur consequatur fugit. Aliquid eos sinema quia ab dignissimos. Sed veniam inventore commodi voluptatem beğendim ışık aut bahar. Quaerat eos aliquid. Qui non dolores consequuntur quasi masanın.", "default.jpeg", "Göze mi aspernatur bundan anlamsız voluptatem voluptatem quam ut odio odit ipsum dolayı minima aliquid.", "Filmini tv aut." },
                    { 17, 1, new DateTime(2022, 12, 23, 0, 20, 28, 298, DateTimeKind.Local).AddTicks(662), "Biber enim ratione. Ut sarmal voluptatem dolores değerli sit. Çünkü sevindi ab. Eaque duyulmamış voluptas ona. Aperiam molestiae domates et ut sit.", "default.jpeg", "Ullam totam sarmal sequi makinesi bahar laboriosam ipsa corporis anlamsız quasi velit aut çünkü consectetur ducimus ullam gül değirmeni masanın aut alias incidunt.", "Reprehenderit laudantium şafak sıla." },
                    { 18, 1, new DateTime(2022, 10, 30, 3, 40, 25, 398, DateTimeKind.Local).AddTicks(1812), "Sıradanlıktan sandalye nisi incidunt tv bilgisayarı odit. Dolorem sıradanlıktan olduğu enim değirmeni çorba velit veritatis kutusu modi. Odit velit aperiam gül dolayı sıradanlıktan autem.", "default.jpeg", "Velit oldular qui cezbelendi velit koşuyorlar neque masaya değirmeni quam sit ut deleniti quia eius ipsum perferendis ea.", "Yapacakmış vitae nihil ki düşünüyor nihil ipsum et." },
                    { 19, 1, new DateTime(2022, 12, 21, 7, 8, 45, 864, DateTimeKind.Local).AddTicks(8771), "İusto et sit commodi sit fugit adanaya. Velit bundan ut filmini. Camisi sıfat corporis et kulu quis. Architecto amet velit sıla. Dolorem uzattı magnam. Voluptatem voluptatem blanditiis rem anlamsız.", "default.jpeg", "Koşuyorlar teldeki nisi explicabo velit odio enim çıktılar suscipit voluptatem mi ve.", "İçin dergi cesurca." },
                    { 20, 1, new DateTime(2022, 8, 22, 23, 17, 6, 981, DateTimeKind.Local).AddTicks(8606), "Nisi bilgisayarı laudantium laboriosam gül. Ratione neque consequatur karşıdakine magni ışık molestiae suscipit. Göze iusto sit exercitationem consequatur cezbelendi. Nisi eaque ratione incidunt. Değerli neque quaerat yapacakmış dolayı sed.", "default.jpeg", "Dolor quis consequuntur aperiam batarya et voluptatem eve iusto dolayı ea türemiş sit göze sayfası eaque oldular orta quasi gülüyorum adresini oldular sandalye gazete.", "Quam suscipit orta sit camisi bundan." }
                });

            migrationBuilder.InsertData(
                table: "BlogCategories",
                columns: new[] { "Id", "BlogId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 2 },
                    { 5, 5, 3 },
                    { 6, 6, 3 },
                    { 7, 7, 4 },
                    { 8, 8, 4 },
                    { 9, 9, 5 },
                    { 10, 10, 5 },
                    { 11, 11, 6 },
                    { 12, 12, 6 },
                    { 13, 13, 7 },
                    { 14, 14, 7 },
                    { 15, 15, 8 },
                    { 16, 16, 8 },
                    { 17, 17, 9 },
                    { 18, 18, 9 },
                    { 19, 19, 10 },
                    { 20, 20, 10 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorEmail", "AuthorName", "BlogId", "CreatedAt", "Description", "ParentCommentId" },
                values: new object[,]
                {
                    { 1, "Avluc0@yahoo.com", "İkeme Çetiner", 9, new DateTime(2023, 3, 8, 4, 11, 35, 255, DateTimeKind.Local).AddTicks(7861), "Molestiae mıknatıslı sit et açılmadan sayfası perferendis rem. Layıkıyla ea sinema gitti. Bilgiyasayarı sunt consectetur.", null },
                    { 2, "Aydarkagan13@hotmail.com", "Bulak Tuğlu", 9, new DateTime(2023, 1, 9, 18, 7, 11, 970, DateTimeKind.Local).AddTicks(919), "Göze eaque umut ab suscipit sıla enim bahar layıkıyla. Veniam quaerat voluptatum cezbelendi aut eos. Dolor dolor alias.", null },
                    { 3, "Bozboru.Tutuncu@yahoo.com", "Asığ Türkdoğan", 3, new DateTime(2023, 4, 1, 21, 25, 26, 644, DateTimeKind.Local).AddTicks(2992), "Kapının architecto sit dicta commodi aperiam odit dolayı. Adipisci blanditiis autem karşıdakine nemo explicabo qui masaya teldeki sed. Ex koştum eum iure değerli.", null },
                    { 4, "Bayna91@hotmail.com", "Alp Çörekçi", 12, new DateTime(2022, 7, 13, 14, 23, 3, 531, DateTimeKind.Local).AddTicks(3559), "Düşünüyor kulu voluptatem. Yazın veniam patlıcan. Velit rem amet aliquam modi commodi çobanın. Çıktılar eaque odit dolore consequatur. Sıradanlıktan otobüs eius yapacakmış consectetur. Quia dışarı gitti sokaklarda gül ut un umut fugit.", null },
                    { 5, "Balakatay50@hotmail.com", "Börübars Egeli", 17, new DateTime(2022, 12, 18, 11, 42, 51, 794, DateTimeKind.Local).AddTicks(9353), "Çakıl quaerat sit gülüyorum nisi. Fugit modi quia qui eum dolorem gazete quis. Koyun ekşili duyulmamış.", null },
                    { 6, "Engin_Yetkiner@hotmail.com", "Badabul Adan", 18, new DateTime(2023, 2, 27, 5, 41, 18, 536, DateTimeKind.Local).AddTicks(4361), "Veniam dicta balıkhaneye ab. Ex esse voluptatem qui çünkü orta numquam suscipit ve ve. Eve uzattı eum sayfası ullam cesurca çünkü veniam ea sayfası. Açılmadan dağılımı voluptatum reprehenderit ipsum.", null },
                    { 7, "Bagaisbara.Ayverdi79@gmail.com", "Abşar Akaydın", 9, new DateTime(2022, 10, 18, 22, 11, 31, 844, DateTimeKind.Local).AddTicks(6809), "Duyulmamış molestiae domates gidecekmiş laboriosam. Nemo laboriosam salladı cezbelendi. Adanaya çünkü batarya in un quam.", null },
                    { 8, "Borlukcu_Kuzucu@hotmail.com", "Arnaç Akgül", 19, new DateTime(2022, 12, 1, 14, 35, 49, 827, DateTimeKind.Local).AddTicks(217), "Çıktılar et sevindi sokaklarda eaque. Neque voluptatum beğendim quia voluptatem voluptatem. Bundan iure sinema. İn bahar qui commodi gitti çobanın sit beğendim ex.", null },
                    { 9, "Calapkulu.Oymen@hotmail.com", "Erentüz Dağlaroğlu", 20, new DateTime(2023, 4, 11, 22, 3, 2, 97, DateTimeKind.Local).AddTicks(8902), "Sed gitti layıkıyla magnam. Velit bilgisayarı quia ratione alias accusantium laudantium in oldular quaerat. Odio ve değirmeni mıknatıslı bilgiyasayarı ipsam. Totam ad eaque beatae tempora. Cesurca inventore şafak batarya deleniti düşünüyor sit consequuntur vel kutusu. İure layıkıyla voluptatem incidunt sevindi koştum eos batarya dicta amet.", null },
                    { 10, "Aydemir.Egeli@hotmail.com", "Bükebuyruç Akşit", 1, new DateTime(2022, 11, 20, 17, 55, 29, 549, DateTimeKind.Local).AddTicks(9899), "Esse ad consequatur gitti aperiam sit dolore sandalye. Ex ekşili bilgiyasayarı adanaya fugit. Oldular ut anlamsız.", null },
                    { 11, "Beckem_Cevik95@gmail.com", "Alpturan Sözeri", 11, new DateTime(2022, 11, 23, 14, 26, 17, 967, DateTimeKind.Local).AddTicks(1087), "Quasi corporis et dolores layıkıyla un. Eum non inventore alias düşünüyor. Bilgisayarı adanaya umut incidunt değerli sed praesentium et biber deleniti. Non koşuyorlar okuma consectetur inventore ut çıktılar. Quia ea koştum çünkü ışık perferendis. Qui aut ona koyun sed kapının odio sıla aspernatur.", null },
                    { 12, "Bekecarslantegin75@hotmail.com", "Çobulmak Çevik", 15, new DateTime(2022, 9, 26, 21, 9, 59, 566, DateTimeKind.Local).AddTicks(3889), "Ötekinden sayfası laboriosam gazete karşıdakine quis quis. Çorba ad vitae et neque nihil çakıl accusantium quis. Ekşili değirmeni voluptate için duyulmamış gitti neque quia. Ad consequatur sokaklarda sit olduğu çıktılar sequi sayfası mutlu. Mıknatıslı ullam praesentium. Karşıdakine consectetur cezbelendi bilgisayarı.", null },
                    { 13, "Baydar.Bolatli@hotmail.com", "Işıl Erbay", 20, new DateTime(2022, 7, 10, 13, 34, 59, 750, DateTimeKind.Local).AddTicks(4919), "Cesurca ratione deleniti bundan göze değerli odit ötekinden blanditiis. Praesentium uzattı mi quis. Vel nemo deleniti doğru in yaptı sıradanlıktan lakin çıktılar. Ea incidunt nihil bahar eum laboriosam. Commodi quis explicabo teldeki olduğu et çakıl beatae. Kapının patlıcan batarya değerli ab bilgiyasayarı accusantium teldeki.", null },
                    { 14, "Keyken29@gmail.com", "Atış Akan", 1, new DateTime(2023, 1, 18, 0, 48, 5, 388, DateTimeKind.Local).AddTicks(537), "Eos modi sıradanlıktan veritatis. Sed gazete adanaya corporis sayfası çakıl otobüs çünkü gördüm. Ullam aliquam quae blanditiis totam numquam. Cesurca uzattı sıradanlıktan gördüm adanaya commodi magni perferendis aspernatur nihil.", null },
                    { 15, "Aybalta.Arslanoglu@yahoo.com", "Baltur Erçetin", 3, new DateTime(2023, 4, 12, 20, 43, 43, 96, DateTimeKind.Local).AddTicks(5320), "Esse eum yaptı sequi sit totam amet layıkıyla eum. Işık sıla otobüs umut ipsum. Aspernatur modi çakıl. İçin hesap commodi eaque tv. Et non sinema veniam dolore incidunt enim corporis kalemi ea.", null },
                    { 16, "Bickici_Denkel98@gmail.com", "Güler Dizdar ", 20, new DateTime(2022, 6, 28, 7, 20, 27, 11, DateTimeKind.Local).AddTicks(6452), "Çünkü reprehenderit voluptatem filmini odit veniam odio ve. Çorba labore ipsa sunt aut mutlu umut laudantium kulu. Sayfası aperiam camisi cezbelendi. Et sinema nemo commodi mi suscipit ut reprehenderit. Beğendim minima laboriosam yapacakmış. Laboriosam nisi quia dolor laboriosam.", null },
                    { 17, "Barmakli.Karaer@yahoo.com", "Adalan Dağdaş", 18, new DateTime(2023, 4, 16, 9, 34, 45, 752, DateTimeKind.Local).AddTicks(6471), "Çorba nemo dolores adipisci quae mıknatıslı veritatis enim. Eaque lakin balıkhaneye nesciunt ratione suscipit nemo kulu velit deleniti. Voluptate vitae velit labore fugit un.", null },
                    { 18, "Asartegin_Yetkiner@hotmail.com", "Bağa Yorulmaz", 2, new DateTime(2023, 4, 26, 1, 35, 53, 76, DateTimeKind.Local).AddTicks(7435), "Consectetur laboriosam vel eos ea karşıdakine quis cezbelendi voluptatum. Işık batarya sit filmini açılmadan praesentium magnam ratione. Nihil ipsam çünkü hesap velit sed koşuyorlar. Rem ekşili incidunt gidecekmiş teldeki. Consequatur aut neque velit uzattı tempora.", null },
                    { 19, "Bolmus_Kuday40@gmail.com", "Algu Balaban", 7, new DateTime(2022, 10, 17, 22, 45, 4, 815, DateTimeKind.Local).AddTicks(2722), "Eaque blanditiis yapacakmış lambadaki gidecekmiş cezbelendi ut. Accusantium dolayı quia odio sed. Doloremque aut corporis bundan türemiş sıradanlıktan ab ipsam blanditiis anlamsız. Voluptate filmini neque ab dolore consectetur sit camisi.", null },
                    { 20, "Bumen_Pektemek@yahoo.com", "Baybora Aclan", 15, new DateTime(2022, 9, 8, 11, 42, 59, 524, DateTimeKind.Local).AddTicks(5419), "İnventore de perferendis sıfat sayfası. Et sinema ki. Bundan telefonu quia masaya dışarı kulu laboriosam. Aut ex batarya çünkü non consequatur eaque. Alias ex voluptas.", null },
                    { 21, "Bayuncur_Tasli@gmail.com", "Atımer Çevik", 2, new DateTime(2022, 6, 15, 2, 13, 8, 510, DateTimeKind.Local).AddTicks(2284), "Perferendis dolores totam amet. Ve karşıdakine exercitationem. Suscipit deleniti nemo aperiam düşünüyor odio patlıcan voluptatem voluptatem. Consequatur nesciunt enim velit ea accusantium enim. Koyun tv dolayı yazın perferendis magni in. Uzattı çorba tempora sed voluptatem lambadaki bilgiyasayarı.", null },
                    { 22, "Inc31@hotmail.com", "Bayram Pekkan", 1, new DateTime(2022, 9, 20, 21, 15, 37, 683, DateTimeKind.Local).AddTicks(3847), "Un incidunt iure bundan in cezbelendi uzattı corporis ratione dolorem. Düşünüyor dolores dolorem explicabo. Eaque dolores commodi quia quia dicta.", null },
                    { 23, "Irinckol.Alpugan@hotmail.com", "Çimen Yeşilkaya", 7, new DateTime(2022, 11, 8, 1, 2, 37, 158, DateTimeKind.Local).AddTicks(7120), "Quam türemiş sinema eius düşünüyor batarya numquam velit veniam quam. Nisi sed beğendim laboriosam batarya aliquid karşıdakine orta. Ekşili okuma laboriosam açılmadan gitti otobüs ve labore ex.", null },
                    { 24, "Atalmis24@yahoo.com", "Gönül Akay", 11, new DateTime(2022, 8, 20, 12, 37, 54, 222, DateTimeKind.Local).AddTicks(9855), "Mi dağılımı quis ötekinden ea ratione. Explicabo sunt sunt sıradanlıktan lakin ullam alias quia ipsum dignissimos. Gitti fugit commodi de de et voluptatem. Sed odio lambadaki masaya voluptatum. Domates ducimus karşıdakine ekşili dignissimos modi cesurca ut. Tempora cesurca perferendis voluptate doğru blanditiis ipsa ab velit alias.", null },
                    { 25, "Bayik_Baykam@hotmail.com", "Aydınalp Çatalbaş", 7, new DateTime(2022, 8, 29, 20, 33, 33, 715, DateTimeKind.Local).AddTicks(4841), "Vel accusantium inventore mutlu quae için qui voluptatem eaque çorba. Voluptatem ona ducimus quis sinema. Dignissimos aliquid modi doğru eos ut sit.", null },
                    { 26, "Bayincur_Kirac@gmail.com", "Bağaturipi Gürmen", 10, new DateTime(2022, 7, 29, 19, 14, 36, 352, DateTimeKind.Local).AddTicks(2763), "Ki sokaklarda qui orta gül oldular velit. Mi numquam nisi. Dolorem gazete değerli sarmal de corporis quia consequuntur. Esse olduğu sed dolor koşuyorlar ratione quia quia bilgiyasayarı perferendis. Sunt eaque non et uzattı.", null },
                    { 27, "Alperen_Bicer28@yahoo.com", "Alabörü Ertürk", 17, new DateTime(2022, 11, 29, 14, 34, 33, 5, DateTimeKind.Local).AddTicks(7899), "Totam kulu praesentium praesentium teldeki veritatis sunt. Masanın yaptı autem sinema çobanın aut un layıkıyla reprehenderit. Bundan minima okuma ea qui nihil sed exercitationem.", null },
                    { 28, "Bilgekagan_Kececi40@gmail.com", "Bıtrı Hakyemez", 20, new DateTime(2022, 8, 17, 18, 46, 24, 126, DateTimeKind.Local).AddTicks(2882), "Sed doloremque voluptatem eve dolorem adanaya tv deleniti yapacakmış. Voluptatem camisi aut teldeki adresini. Laudantium sandalye modi lambadaki teldeki blanditiis olduğu. İpsa sandalye modi gülüyorum alias ex un fugit minima. Aut dolores lakin domates ki ratione enim molestiae.", null },
                    { 29, "Berke19@yahoo.com", "İlbilge Adıvar", 7, new DateTime(2023, 5, 16, 12, 23, 46, 656, DateTimeKind.Local).AddTicks(4190), "Sinema bilgiyasayarı cezbelendi sıradanlıktan koşuyorlar tempora anlamsız batarya bundan. Patlıcan vitae çünkü ab sit bilgiyasayarı ipsum koyun. Çünkü eius masanın architecto et yazın camisi adanaya. Sıfat kulu dağılımı sarmal. Magni voluptatum ratione bahar reprehenderit gül.", null },
                    { 30, "Begarslan.Ertepinar@gmail.com", "Baykuzu Alpuğan", 2, new DateTime(2023, 5, 10, 19, 9, 32, 312, DateTimeKind.Local).AddTicks(7676), "Lambadaki totam esse eaque aperiam qui adresini ullam in eum. Mıknatıslı quaerat de odio modi minima. Tv ea otobüs eaque ut. Makinesi eaque sit aperiam ötekinden sıradanlıktan esse. Gazete iusto exercitationem de aut quia sequi sinema voluptatem. Beğendim ışık oldular voluptatem lakin.", null },
                    { 31, "Cingir17@yahoo.com", "Başak Babaoğlu", 4, new DateTime(2023, 4, 9, 4, 38, 29, 914, DateTimeKind.Local).AddTicks(9633), "Et qui qui vitae filmini qui ona eum domates. Layıkıyla beğendim aspernatur corporis sandalye esse nemo ab açılmadan. Quis explicabo ad exercitationem consequatur minima.", null },
                    { 32, "Artiinal.Dusenkalkar@hotmail.com", "Çağrı Karaduman", 18, new DateTime(2023, 1, 14, 3, 31, 22, 386, DateTimeKind.Local).AddTicks(104), "Autem gitti kulu qui. Yazın için öyle. Quam magni fugit ea adresini voluptate voluptas mıknatıslı ea dağılımı. Sequi aut şafak yazın lakin balıkhaneye şafak minima. Ama ışık ex exercitationem nesciunt dolore ea domates aut qui.", null },
                    { 33, "Bunsuz88@gmail.com", "Aşantuğrul Elmastaşoğlu", 14, new DateTime(2023, 1, 12, 18, 16, 57, 188, DateTimeKind.Local).AddTicks(7578), "Dolayı layıkıyla modi dignissimos vitae beatae explicabo. Voluptatum quia aspernatur magni labore sandalye qui. İpsam çobanın quis. Quia makinesi et dignissimos aperiam consequatur illo alias. Voluptatum bilgisayarı dolores praesentium layıkıyla odio.", null },
                    { 34, "Burulgu26@hotmail.com", "Bulmuş Yalçın", 4, new DateTime(2023, 5, 8, 0, 25, 14, 817, DateTimeKind.Local).AddTicks(6245), "Gazete ratione eve sayfası qui nemo çakıl koştum batarya değirmeni. Işık eve ipsum. Biber un gördüm accusantium layıkıyla beatae gidecekmiş. Balıkhaneye dağılımı consequatur praesentium dicta mi ötekinden deleniti duyulmamış. Göze bilgisayarı düşünüyor ex domates filmini filmini ut. Biber inventore aliquid yapacakmış adipisci.", null },
                    { 35, "Barcadurdu57@yahoo.com", "Arıkağan Köylüoğlu", 19, new DateTime(2022, 9, 18, 4, 34, 41, 987, DateTimeKind.Local).AddTicks(2065), "Dicta bilgiyasayarı incidunt consequuntur sit magni totam çarpan adipisci ratione. Nihil adipisci exercitationem değerli patlıcan kapının hesap kulu. Mi iusto dergi sit alias minima quis.", null },
                    { 36, "Bumen3@yahoo.com", "Baybora Barbarosoğlu", 5, new DateTime(2022, 8, 25, 18, 39, 51, 843, DateTimeKind.Local).AddTicks(7124), "Dağılımı şafak kulu çobanın. Non iusto rem eos çarpan. Cesurca voluptatum ışık bundan ut dergi alias velit. Ducimus ipsum enim. Aut aut salladı laboriosam ipsa autem ea sed biber gördüm. Non fugit labore aspernatur eos voluptate neque incidunt değirmeni dolorem.", null },
                    { 37, "Atli10@yahoo.com", "Çağrıtegin Arıcan", 20, new DateTime(2022, 7, 4, 19, 37, 4, 997, DateTimeKind.Local).AddTicks(8869), "Değirmeni adipisci sokaklarda açılmadan ullam. Ab teldeki sequi. Ad yazın eve aut sit aperiam sit oldular yapacakmış. Tempora masanın masanın adanaya sit anlamsız mıknatıslı değirmeni commodi. Ab sayfası ut vitae.", null },
                    { 38, "Artut32@yahoo.com", "Bakağul Saygıner", 15, new DateTime(2022, 10, 5, 8, 3, 12, 851, DateTimeKind.Local).AddTicks(5914), "Aliquam orta consequatur. Nesciunt deleniti kulu. Mutlu beatae gazete tempora. Quis mıknatıslı aut otobüs eve kalemi mıknatıslı. Oldular gidecekmiş deleniti.", null },
                    { 39, "Bidin.Agaoglu@yahoo.com", "Baybiçen Hakyemez", 2, new DateTime(2023, 1, 24, 13, 7, 54, 805, DateTimeKind.Local).AddTicks(900), "Bahar beatae sed patlıcan eos qui sed sıfat bilgisayarı eve. Magnam gülüyorum ışık voluptatem olduğu consequatur ab dolorem olduğu. Sequi ut blanditiis quia sandalye dağılımı türemiş odit.", null },
                    { 40, "Cabus_Pektemek73@hotmail.com", "Bükebuyruç Tokatlıoğlu", 19, new DateTime(2022, 9, 7, 1, 10, 27, 368, DateTimeKind.Local).AddTicks(6287), "Gidecekmiş ve karşıdakine sayfası dolor. Odit nisi çarpan ona eaque mi et velit masaya çakıl. Türemiş quia masanın consequatur umut incidunt beğendim ki praesentium. Dolorem explicabo ut.", null },
                    { 41, "Bugrakarakagan84@gmail.com", "Arkış Uca", 12, new DateTime(2022, 8, 2, 8, 55, 57, 530, DateTimeKind.Local).AddTicks(1010), "Velit consectetur gazete için fugit vel voluptatem sayfası sequi. Non açılmadan sed ekşili gördüm odit praesentium gülüyorum gazete açılmadan. Dışarı sarmal incidunt ea. Sit non değirmeni explicabo vel ve. Yapacakmış accusantium dolores consequuntur quia de sıla veniam. Blanditiis ut uzattı velit cesurca quam exercitationem.", null },
                    { 42, "Basci.Adivar53@yahoo.com", "Armağan Özdoğan", 9, new DateTime(2022, 12, 23, 23, 15, 32, 262, DateTimeKind.Local).AddTicks(9043), "Değirmeni corporis batarya voluptatem aut umut. Dolor mıknatıslı esse un ışık dergi velit consequuntur türemiş alias. Cezbelendi otobüs cesurca velit quaerat sed. Sıfat voluptatem ea ab dağılımı qui kulu laboriosam. Ut kapının sıfat çakıl sequi et. Tv balıkhaneye göze in voluptatem.", null },
                    { 43, "Burkay.Abaci69@hotmail.com", "Balamır Taşlı", 1, new DateTime(2023, 4, 12, 16, 7, 10, 359, DateTimeKind.Local).AddTicks(389), "Sit sequi teldeki voluptatum. Nemo dolayı yaptı. Dağılımı in ut. Dolor autem ipsum bundan sed beatae consequatur velit veritatis qui. Eius quia esse quae perferendis.", null },
                    { 44, "Beg.Cevik38@hotmail.com", "Arademir Kaya ", 20, new DateTime(2023, 4, 1, 4, 22, 50, 652, DateTimeKind.Local).AddTicks(6013), "Layıkıyla ona vel batarya mıknatıslı gülüyorum suscipit. Un consequuntur ratione quaerat voluptatum aut ipsam enim. Patlıcan inventore amet dağılımı deleniti. Açılmadan voluptatum veritatis otobüs göze. Türemiş explicabo gidecekmiş.", null },
                    { 45, "Basademir44@yahoo.com", "Alpdoğan Yeşilkaya", 7, new DateTime(2022, 10, 30, 4, 50, 35, 320, DateTimeKind.Local).AddTicks(3531), "İncidunt vitae quasi quam laudantium dağılımı umut sayfası cesurca. Masanın bahar reprehenderit duyulmamış et. Salladı quis patlıcan adanaya.", null },
                    { 46, "Arslanyabgu82@yahoo.com", "Arkın Koçyiğit", 10, new DateTime(2022, 10, 18, 16, 42, 50, 99, DateTimeKind.Local).AddTicks(4644), "Et ex labore dolayı in in aliquid minima. Oldular exercitationem beğendim qui et. Ducimus masanın accusantium ona cezbelendi sit açılmadan mutlu. Aut sıla consequuntur quae perferendis aut quia enim domates.", null },
                    { 47, "Baybure46@hotmail.com", "Gelincik Günday", 19, new DateTime(2023, 2, 16, 5, 34, 28, 250, DateTimeKind.Local).AddTicks(9991), "Gitti patlıcan değerli lambadaki laboriosam ama çünkü. Suscipit beğendim layıkıyla. Velit architecto consequatur okuma. Çünkü sequi magni laudantium ut ad sit kutusu. Masaya quia iure.", null },
                    { 48, "Erdenikatun_Yetkiner16@yahoo.com", "Alpkara Demirbaş", 13, new DateTime(2023, 1, 21, 8, 12, 23, 980, DateTimeKind.Local).AddTicks(3955), "İnventore patlıcan modi olduğu düşünüyor koyun sevindi için. Quasi sit adresini exercitationem voluptatem. Öyle consequatur modi dignissimos. Dışarı sarmal consequatur odio olduğu quaerat. Beatae düşünüyor duyulmamış dolor rem adresini neque.", null },
                    { 49, "Baybicen43@gmail.com", "Baturalp Pektemek", 5, new DateTime(2023, 1, 26, 3, 14, 38, 410, DateTimeKind.Local).AddTicks(1795), "Quae magni çıktılar quis karşıdakine koyun aliquam accusantium mıknatıslı aliquam. Et ullam quia tv exercitationem suscipit cezbelendi doloremque anlamsız masanın. Mi aut vel molestiae qui değerli qui esse dolor. Aspernatur dolayı laboriosam kulu quae numquam.", null },
                    { 50, "Atakagan54@yahoo.com", "Çağrıbeğ Dağdaş", 8, new DateTime(2023, 3, 9, 1, 1, 53, 566, DateTimeKind.Local).AddTicks(1526), "Batarya autem quaerat amet laboriosam. Gül amet batarya batarya quia ut. Yaptı quia patlıcan ötekinden kapının consequatur sokaklarda çarpan. Ve batarya mutlu layıkıyla eum. İllo aliquam voluptatem velit.", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_AppRoleId",
                table: "AppUserRoles",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_AppUserId_AppRoleId",
                table: "AppUserRoles",
                columns: new[] { "AppUserId", "AppRoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategories_BlogId",
                table: "BlogCategories",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategories_CategoryId_BlogId",
                table: "BlogCategories",
                columns: new[] { "CategoryId", "BlogId" });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AppUserId",
                table: "Blogs",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "BlogCategories");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
