using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication3.Migrations
{
    public partial class SeedFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into features (name) values ('Feature1')");
            migrationBuilder.Sql("Insert into features (name) values ('Feature2')");
            migrationBuilder.Sql("Insert into features (name) values ('Feature3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from features where name in ('feature1,feature2,feature3')");
        }
    }
}
