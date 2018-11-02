using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RainChance.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayPrediction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Time = table.Column<DateTimeOffset>(nullable: false),
                    PrecipIntensity = table.Column<double>(nullable: false),
                    PrecipProbability = table.Column<double>(nullable: false),
                    DewPoint = table.Column<double>(nullable: false),
                    Humidity = table.Column<double>(nullable: false),
                    Pressure = table.Column<double>(nullable: false),
                    WindSpeed = table.Column<double>(nullable: false),
                    WindBearing = table.Column<int>(nullable: false),
                    CloudCover = table.Column<double>(nullable: false),
                    UvIndex = table.Column<double>(nullable: false),
                    Visibility = table.Column<double>(nullable: false),
                    SunriseTime = table.Column<DateTimeOffset>(nullable: false),
                    SunsetTime = table.Column<DateTimeOffset>(nullable: false),
                    MoonPhase = table.Column<double>(nullable: false),
                    PrecipIntensityMax = table.Column<double>(nullable: false),
                    PrecipIntensityMaxTime = table.Column<DateTimeOffset>(nullable: false),
                    PrecipAccumulation = table.Column<double>(nullable: false),
                    PrecipType = table.Column<string>(nullable: true),
                    TemperatureHigh = table.Column<double>(nullable: false),
                    TemperatureHighTime = table.Column<DateTimeOffset>(nullable: false),
                    TemperatureLow = table.Column<double>(nullable: false),
                    TemperatureLowTime = table.Column<DateTimeOffset>(nullable: false),
                    ApparentTemperatureHigh = table.Column<double>(nullable: false),
                    ApparentTemperatureHighTime = table.Column<DateTimeOffset>(nullable: false),
                    ApparentTemperatureLow = table.Column<double>(nullable: false),
                    ApparentTemperatureLowTime = table.Column<DateTimeOffset>(nullable: false),
                    UvIndexTime = table.Column<DateTimeOffset>(nullable: false),
                    TemperatureMin = table.Column<double>(nullable: false),
                    TemperatureMinTime = table.Column<DateTimeOffset>(nullable: false),
                    TemperatureMax = table.Column<double>(nullable: false),
                    TemperatureMaxTime = table.Column<DateTimeOffset>(nullable: false),
                    ApparentTemperatureMin = table.Column<double>(nullable: false),
                    ApparentTemperatureMinTime = table.Column<DateTimeOffset>(nullable: false),
                    ApparentTemperatureMax = table.Column<double>(nullable: false),
                    ApparentTemperatureMaxTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayPrediction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HourPrediction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Time = table.Column<DateTimeOffset>(nullable: false),
                    PrecipIntensity = table.Column<double>(nullable: false),
                    PrecipProbability = table.Column<double>(nullable: false),
                    DewPoint = table.Column<double>(nullable: false),
                    Humidity = table.Column<double>(nullable: false),
                    Pressure = table.Column<double>(nullable: false),
                    WindSpeed = table.Column<double>(nullable: false),
                    WindBearing = table.Column<int>(nullable: false),
                    CloudCover = table.Column<double>(nullable: false),
                    UvIndex = table.Column<double>(nullable: false),
                    Visibility = table.Column<double>(nullable: false),
                    DayPredictionId = table.Column<Guid>(nullable: false),
                    Temperature = table.Column<double>(nullable: false),
                    ApparentTemperature = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourPrediction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourPrediction_DayPrediction_DayPredictionId",
                        column: x => x.DayPredictionId,
                        principalTable: "DayPrediction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HourPrediction_DayPredictionId",
                table: "HourPrediction",
                column: "DayPredictionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HourPrediction");

            migrationBuilder.DropTable(
                name: "DayPrediction");
        }
    }
}
