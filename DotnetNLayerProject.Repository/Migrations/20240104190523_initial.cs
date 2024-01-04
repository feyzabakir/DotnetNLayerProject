using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetNLayerProject.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Writers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WriterName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WriterMail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    WriterPassword = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BlogContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    WriterID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blogs_Writers_WriterID",
                        column: x => x.WriterID,
                        principalTable: "Writers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedDate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Teknoloji", new DateTime(2024, 1, 4, 22, 5, 23, 69, DateTimeKind.Local).AddTicks(6227), null },
                    { 2, "Yazılım", new DateTime(2024, 1, 4, 22, 5, 23, 69, DateTimeKind.Local).AddTicks(6229), null },
                    { 3, "Trendler", new DateTime(2024, 1, 4, 22, 5, 23, 69, DateTimeKind.Local).AddTicks(6230), null }
                });

            migrationBuilder.InsertData(
                table: "Writers",
                columns: new[] { "Id", "CreatedDate", "UpdatedDate", "WriterMail", "WriterName", "WriterPassword" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 4, 22, 5, 23, 69, DateTimeKind.Local).AddTicks(6390), null, "feyza@gmail.com", "Feyza Bakır", "feyza123" },
                    { 2, new DateTime(2024, 1, 4, 22, 5, 23, 69, DateTimeKind.Local).AddTicks(6391), null, "aysecinar@gmail.com", "Ayşe Çınar", "ayse123" },
                    { 3, new DateTime(2024, 1, 4, 22, 5, 23, 69, DateTimeKind.Local).AddTicks(6392), null, "aliyilmaz@gmail.com", "Ali Yılmaz", "ali123" }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "BlogContent", "BlogTitle", "CategoryID", "CreatedDate", "UpdatedDate", "WriterID" },
                values: new object[] { 1, "Git Nedir ?Git, bir versiyon kontrol sistemi olarak bilinen açık kaynaklı bir yazılımdır ve genellikle yazılım geliştirme süreçlerinde kullanılır. Git, proje dosyalarının değişikliklerini takip etmeye, farklı sürümleri yönetmeye ve işbirliği yapmaya olanak tanır.Git, Linux kurucusu Linus Torvalds tarafından geliştirilen bir versiyon kontrol sistemidir. Linux çekirdeğinin farklı developer’lar tarafından geliştirilmesi konusu git’in ortaya çıkmasını sağlamıştır.", "Git Versiyon Kontrol Sistemi", 1, new DateTime(2024, 1, 4, 22, 5, 23, 69, DateTimeKind.Local).AddTicks(6034), null, 1 });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "BlogContent", "BlogTitle", "CategoryID", "CreatedDate", "UpdatedDate", "WriterID" },
                values: new object[] { 2, "Katmanlar sorumlulukların ayrılması ve bağımlılıkların yönetilmesi için kullanılan bir yöntemdir. Her katmanın belirli bir sorumluluğu vardır. Daha yüksek bir katman, hizmetleri daha düşük bir katmanda kullanabilir ancak daha düşük bir katman, hizmetleri daha yüksek bir katmanda kullanamaz.", "N Katmanlı Mimari", 2, new DateTime(2024, 1, 4, 22, 5, 23, 69, DateTimeKind.Local).AddTicks(6045), null, 2 });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "BlogContent", "BlogTitle", "CategoryID", "CreatedDate", "UpdatedDate", "WriterID" },
                values: new object[] { 3, "Bu sayıda alanında uzman yirmi iki kişinin görüşlerini okuyacaksınız. Bu sene kamuoyunun nabzını da yoklayarak yazarlarımız için iki dönem kuralı getirdim. Yani ilk iki sayıda da katkı sağlayan yazarlarımız bu sayıda yer almadı. Bunun yanında geçen sayıda bulunup bu sene müsait olamayan veya trendleri yeterince takip edemediğini düşünen yazarlarımız da bu sayıda yer almadı. Yeri gelmişken bu sayıda da sadece iki kadın yazılımcı, yazar olarak yer aldı. Ayrıca iki arkadaş son haftalardaki bazı aksilikler dolayısıyla yazı gönderemedi.", "Yazılım Dünyasında 2023 Trendleri", 3, new DateTime(2024, 1, 4, 22, 5, 23, 69, DateTimeKind.Local).AddTicks(6046), null, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryID",
                table: "Blogs",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_WriterID",
                table: "Blogs",
                column: "WriterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Writers");
        }
    }
}
