﻿// <auto-generated />
using System;
using Infrastructure.RDBMS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookCrossingBackEnd.Migrations
{
    [DbContext(typeof(BookCrossingContext))]
    partial class BookCrossingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.RDBMS.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("firstname")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsConfirmed")
                        .HasColumnName("is_confirmed")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("lastname")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Bernard",
                            IsConfirmed = true,
                            LastName = "Fernandez"
                        });
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("ImagePath")
                        .HasColumnName("imagepath")
                        .HasColumnType("nvarchar(260)")
                        .HasMaxLength(260);

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Notice")
                        .HasColumnName("notice")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Publisher")
                        .HasColumnName("publisher")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<double>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rating")
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<string>("State")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .HasDefaultValue("Available");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("UserId");

                    b.ToTable("Book");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateAdded = new DateTime(2020, 7, 20, 22, 34, 58, 574, DateTimeKind.Local).AddTicks(9566),
                            LanguageId = 1,
                            Name = "Adventures of Junior",
                            Rating = 0.0,
                            State = "Available",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.BookAuthor", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnName("book_id")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnName("author_id")
                        .HasColumnType("int");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthor");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorId = 1
                        });
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.BookGenre", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnName("book_id")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnName("genre_id")
                        .HasColumnType("int");

                    b.HasKey("BookId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("BookGenre");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            GenreId = 1
                        });
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fantasy"
                        });
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Language");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ukrainian"
                        });
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("city")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<bool>("IsActive")
                        .HasColumnName("is_active")
                        .HasColumnType("bit");

                    b.Property<string>("OfficeName")
                        .HasColumnName("office_name")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnName("street")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Location");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Lviv",
                            IsActive = true,
                            OfficeName = "SoftServe",
                            Street = "Gorodoc'kogo"
                        });
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnName("book_id")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnName("owner_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReceiveDate")
                        .HasColumnName("receive_date")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnName("request_date")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("UserId");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.ResetPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConfirmationNumber")
                        .IsRequired()
                        .HasColumnName("confirmation_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ResetDate")
                        .HasColumnName("reset_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ResetPassword");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "User"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.ScheduleJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RequestId")
                        .HasColumnName("requestId")
                        .HasColumnType("int");

                    b.Property<string>("ScheduleId")
                        .IsRequired()
                        .HasColumnName("scheduleId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("ScheduleJob");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("birth_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("firstname")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<bool>("IsEmailAllowed")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("email_allowed")
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("lastname")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("MiddleName")
                        .HasColumnName("middlename")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisteredDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("registered_date")
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("role_id")
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int?>("UserRoomId")
                        .HasColumnName("user_room_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserRoomId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@gmail.com",
                            FirstName = "Admin",
                            IsEmailAllowed = false,
                            LastName = "Adminovich",
                            MiddleName = "Adminovski",
                            Password = "admin",
                            RegisteredDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleId = 2
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "test@gmail.com",
                            FirstName = "Toster",
                            IsEmailAllowed = false,
                            LastName = "Tosterovich",
                            MiddleName = "Test",
                            Password = "test",
                            RegisteredDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleId = 1,
                            UserRoomId = 1
                        });
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.UserRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LocationId")
                        .HasColumnName("location_id")
                        .HasColumnType("int");

                    b.Property<string>("RoomNumber")
                        .HasColumnName("room_number")
                        .HasColumnType("nvarchar(7)")
                        .HasMaxLength(7);

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("UserRoom");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LocationId = 1,
                            RoomNumber = "4040"
                        });
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.Wish", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnName("book_id")
                        .HasColumnType("int");

                    b.HasKey("UserId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("Wish");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.Book", b =>
                {
                    b.HasOne("Domain.RDBMS.Entities.Language", "Language")
                        .WithMany("Books")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.RDBMS.Entities.User", "User")
                        .WithMany("Book")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.BookAuthor", b =>
                {
                    b.HasOne("Domain.RDBMS.Entities.Author", "Author")
                        .WithMany("BookAuthor")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.RDBMS.Entities.Book", "Book")
                        .WithMany("BookAuthor")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.BookGenre", b =>
                {
                    b.HasOne("Domain.RDBMS.Entities.Book", "Book")
                        .WithMany("BookGenre")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.RDBMS.Entities.Genre", "Genre")
                        .WithMany("BookGenre")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.RefreshToken", b =>
                {
                    b.HasOne("Domain.RDBMS.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.Request", b =>
                {
                    b.HasOne("Domain.RDBMS.Entities.Book", "Book")
                        .WithMany("Request")
                        .HasForeignKey("BookId")
                        .IsRequired();

                    b.HasOne("Domain.RDBMS.Entities.User", "Owner")
                        .WithMany("RequestOwner")
                        .HasForeignKey("OwnerId")
                        .IsRequired();

                    b.HasOne("Domain.RDBMS.Entities.User", "User")
                        .WithMany("RequestUser")
                        .HasForeignKey("UserId")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.User", b =>
                {
                    b.HasOne("Domain.RDBMS.Entities.Role", "Role")
                        .WithMany("User")
                        .HasForeignKey("RoleId")
                        .IsRequired();

                    b.HasOne("Domain.RDBMS.Entities.UserRoom", "UserRoom")
                        .WithMany("User")
                        .HasForeignKey("UserRoomId");
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.UserRoom", b =>
                {
                    b.HasOne("Domain.RDBMS.Entities.Location", "Location")
                        .WithMany("UserRoom")
                        .HasForeignKey("LocationId")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.RDBMS.Entities.Wish", b =>
                {
                    b.HasOne("Domain.RDBMS.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.RDBMS.Entities.User", "User")
                        .WithMany("Wish")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
