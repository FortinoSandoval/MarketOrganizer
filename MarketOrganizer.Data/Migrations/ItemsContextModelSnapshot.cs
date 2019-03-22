﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MarketOrganizer.Data.Models;

namespace MarketOrganizer.Data.Migrations
{
  [DbContext(typeof(ItemsContext))]
  partial class ItemsContextModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
          .HasAnnotation("Relational:MaxIdentifierLength", 128)
          .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

      modelBuilder.Entity("api.Models.Items", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            b.Property<int>("BuyPrice");

            b.Property<int>("HighestMarketPrice");

            b.Property<string>("ItemName");

            b.Property<int>("SellPrice");

            b.HasKey("Id");

            b.ToTable("Item");
          });
#pragma warning restore 612, 618
    }
  }
}
