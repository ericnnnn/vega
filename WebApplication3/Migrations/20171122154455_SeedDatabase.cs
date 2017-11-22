using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication3.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into makes(name) values('Make1')");
            migrationBuilder.Sql("Insert into makes(name) values('Make2')");
            migrationBuilder.Sql("Insert into makes(name) values('Make3')");

            migrationBuilder.Sql("Insert into models(name,makeid) values('Make1-ModelA',(select id from makes where name='make1'))");
            migrationBuilder.Sql("Insert into models(name,makeid) values('Make1-ModelB',(select id from makes where name='make1'))");
            migrationBuilder.Sql("Insert into models(name,makeid) values('Make1-ModelC',(select id from makes where name='make1'))");

            migrationBuilder.Sql("Insert into models(name,makeid) values('Make3-ModelA',(select id from makes where name='make2'))");
            migrationBuilder.Sql("Insert into models(name,makeid) values('Make3-ModelB',(select id from makes where name='make2'))");
            migrationBuilder.Sql("Insert into models(name,makeid) values('Make3-ModelC',(select id from makes where name='make2'))");

            migrationBuilder.Sql("Insert into models(name,makeid) values('Make3-ModelA',(select id from makes where name='make3'))");
            migrationBuilder.Sql("Insert into models(name,makeid) values('Make3-ModelB',(select id from makes where name='make3'))");
            migrationBuilder.Sql("Insert into models(name,makeid) values('Make3-ModelC',(select id from makes where name='make3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from makes where name in ('make1','make2','make3')");
            //migrationBuilder.Sql("delete from models");
        }
    }
}
