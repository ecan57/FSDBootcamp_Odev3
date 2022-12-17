using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Odev_3API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Akademisyenler",
                columns: table => new
                {
                    AkademisyenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Unvan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    İsim = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Soyisim = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TCKimlikNo = table.Column<long>(name: "T.C. Kimlik No", type: "bigint", maxLength: 11, nullable: false),
                    DoğumTarihi = table.Column<DateTime>(name: "Doğum Tarihi", type: "date", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EPosta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AnabilimDalı = table.Column<string>(name: "Anabilim Dalı", type: "nvarchar(25)", maxLength: 25, nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UptatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UptatedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Akademisyenler", x => x.AkademisyenId);
                });

            migrationBuilder.CreateTable(
                name: "Öğrenci",
                columns: table => new
                {
                    OgrenciNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    İsim = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Soyisim = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TCKimlikNo = table.Column<long>(name: "T.C. Kimlik No", type: "bigint", maxLength: 11, nullable: false),
                    DoğumTarihi = table.Column<DateTime>(name: "Doğum Tarihi", type: "date", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EPosta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bölüm = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Sınıf = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UptatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UptatedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Öğrenci No", x => x.OgrenciNo);
                });

            migrationBuilder.CreateTable(
                name: "Dersler",
                columns: table => new
                {
                    DersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DersKodu = table.Column<string>(name: "Ders Kodu", type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DersAdı = table.Column<string>(name: "Ders Adı", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DersSaati = table.Column<short>(name: "Ders Saati", type: "smallint", nullable: false),
                    Kredi = table.Column<short>(type: "smallint", nullable: false),
                    Dönem = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Derslik = table.Column<string>(type: "text", maxLength: 10, nullable: true),
                    Açıklama = table.Column<string>(type: "text", maxLength: 25, nullable: true),
                    ZorunluMu = table.Column<bool>(type: "bit", nullable: false),
                    AkademisyenId = table.Column<int>(type: "int", nullable: false),
                    AkademisyenId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UptatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UptatedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dersler", x => x.DersId);
                    table.ForeignKey(
                        name: "FK_Dersler_Akademisyenler_AkademisyenId1",
                        column: x => x.AkademisyenId1,
                        principalTable: "Akademisyenler",
                        principalColumn: "AkademisyenId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DersOgrenci",
                columns: table => new
                {
                    DerslerDersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OgrencilerOgrenciNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersOgrenci", x => new { x.DerslerDersId, x.OgrencilerOgrenciNo });
                    table.ForeignKey(
                        name: "FK_DersOgrenci_Dersler_DerslerDersId",
                        column: x => x.DerslerDersId,
                        principalTable: "Dersler",
                        principalColumn: "DersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersOgrenci_Öğrenci_OgrencilerOgrenciNo",
                        column: x => x.OgrencilerOgrenciNo,
                        principalTable: "Öğrenci",
                        principalColumn: "OgrenciNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dersler_AkademisyenId1",
                table: "Dersler",
                column: "AkademisyenId1");

            migrationBuilder.CreateIndex(
                name: "IX_DersOgrenci_OgrencilerOgrenciNo",
                table: "DersOgrenci",
                column: "OgrencilerOgrenciNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DersOgrenci");

            migrationBuilder.DropTable(
                name: "Dersler");

            migrationBuilder.DropTable(
                name: "Öğrenci");

            migrationBuilder.DropTable(
                name: "Akademisyenler");
        }
    }
}
