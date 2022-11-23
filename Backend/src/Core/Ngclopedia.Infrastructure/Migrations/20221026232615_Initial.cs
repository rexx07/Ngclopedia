using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ngclopedia.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Area = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Building = table.Column<string>(type: "text", nullable: false),
                    Apartment = table.Column<string>(type: "text", nullable: true),
                    ZipPostalCode = table.Column<string>(type: "text", nullable: true),
                    AddressType = table.Column<int>(type: "integer", nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: true),
                    PoliticalOfficeId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoliticalPartyId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    AllowComments = table.Column<bool>(type: "boolean", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    PublishedStatus = table.Column<int>(type: "integer", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false),
                    ArticleCommunity = table.Column<int>(type: "integer", nullable: false),
                    Edited = table.Column<bool>(type: "boolean", nullable: false),
                    Edits = table.Column<List<string>>(type: "text[]", nullable: true),
                    Images = table.Column<List<string>>(type: "text[]", nullable: true),
                    Tags = table.Column<List<string>>(type: "text[]", nullable: false),
                    ApplicationUserId1 = table.Column<string>(type: "text", nullable: true),
                    CategoryBasedCommunityId = table.Column<Guid>(type: "uuid", nullable: true),
                    LocationBasedCommunityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "Category Based Communities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Categories = table.Column<int[]>(type: "integer[]", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LogoUrl = table.Column<string>(type: "text", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rules = table.Column<List<string>>(type: "text[]", nullable: true),
                    FAQ = table.Column<List<string>>(type: "text[]", nullable: true),
                    Info = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category Based Communities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Images = table.Column<List<string>>(type: "text[]", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uuid", nullable: true),
                    CommentId = table.Column<Guid>(type: "uuid", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false),
                    Edited = table.Column<bool>(type: "boolean", nullable: false),
                    Edits = table.Column<List<string>>(type: "text[]", nullable: true),
                    ApplicationUserId1 = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    FacebookName = table.Column<string>(type: "text", nullable: true),
                    TwitterUsername = table.Column<string>(type: "text", nullable: true),
                    InstagramUsername = table.Column<string>(type: "text", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "text", nullable: true),
                    PhoneNumbers = table.Column<List<string>>(type: "text[]", nullable: false),
                    Emails = table.Column<List<string>>(type: "text[]", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: true),
                    PoliticalOfficeHolderId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoliticalOfficeId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoliticalPartyId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location Based Communities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LogoUrl = table.Column<string>(type: "text", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rules = table.Column<List<string>>(type: "text[]", nullable: true),
                    FAQ = table.Column<List<string>>(type: "text[]", nullable: true),
                    Info = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location Based Communities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location Based Communities_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Introduction = table.Column<string>(type: "text", nullable: false),
                    Pcode = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    AdminType = table.Column<int>(type: "integer", nullable: false),
                    AdminLevel = table.Column<int>(type: "integer", nullable: false),
                    Continent = table.Column<int>(type: "integer", nullable: false),
                    LocationBasedCommunityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Location Based Communities_LocationBasedCommunity~",
                        column: x => x.LocationBasedCommunityId,
                        principalTable: "Location Based Communities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    AvatarUrl = table.Column<string>(type: "text", nullable: false),
                    Images = table.Column<List<string>>(type: "text[]", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    CoverUrl = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CategoryBasedCommunityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CategoryBasedCommunityId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CategoryBasedCommunityId2 = table.Column<Guid>(type: "uuid", nullable: true),
                    LocationBasedCommunityId = table.Column<Guid>(type: "uuid", nullable: true),
                    LocationBasedCommunityId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    LocationBasedCommunityId2 = table.Column<Guid>(type: "uuid", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Category Based Communities_CategoryBasedCommunityId",
                        column: x => x.CategoryBasedCommunityId,
                        principalTable: "Category Based Communities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Category Based Communities_CategoryBasedCommunityId1",
                        column: x => x.CategoryBasedCommunityId1,
                        principalTable: "Category Based Communities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Category Based Communities_CategoryBasedCommunityId2",
                        column: x => x.CategoryBasedCommunityId2,
                        principalTable: "Category Based Communities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Location Based Communities_LocationBasedCommunityId",
                        column: x => x.LocationBasedCommunityId,
                        principalTable: "Location Based Communities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Location Based Communities_LocationBasedCommunityId1",
                        column: x => x.LocationBasedCommunityId1,
                        principalTable: "Location Based Communities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Location Based Communities_LocationBasedCommunityId2",
                        column: x => x.LocationBasedCommunityId2,
                        principalTable: "Location Based Communities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReactionType = table.Column<int>(type: "integer", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uuid", nullable: true),
                    CommentId = table.Column<Guid>(type: "uuid", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false),
                    ApplicationUserId1 = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reactions_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reactions_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reactions_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reactions_Users_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Political Office Holder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    AvatarUrl = table.Column<string>(type: "text", nullable: true),
                    OtherNames = table.Column<List<string>>(type: "text[]", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PoliticalAffiliations = table.Column<List<string>>(type: "text[]", nullable: true),
                    Spouses = table.Column<List<string>>(type: "text[]", nullable: true),
                    Children = table.Column<List<string>>(type: "text[]", nullable: true),
                    Occupations = table.Column<List<string>>(type: "text[]", nullable: true),
                    Relatives = table.Column<List<string>>(type: "text[]", nullable: true),
                    AlmaMater = table.Column<string>(type: "text", nullable: true),
                    Awards = table.Column<List<string>>(type: "text[]", nullable: true),
                    PoliticalOfficeId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Political Office Holder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Political Parties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    PartyChairman = table.Column<string>(type: "text", nullable: false),
                    PartySecretary = table.Column<string>(type: "text", nullable: false),
                    GoverningBody = table.Column<string>(type: "text", nullable: false),
                    Founded = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Merged = table.Column<bool>(type: "boolean", nullable: false),
                    LogoUrl = table.Column<string>(type: "text", nullable: false),
                    Ideology = table.Column<string>(type: "text", nullable: false),
                    Slogan = table.Column<string>(type: "text", nullable: false),
                    EstMembersCount = table.Column<int>(type: "integer", nullable: false),
                    colours = table.Column<List<string>>(type: "text[]", nullable: false),
                    FormerNames = table.Column<List<string>>(type: "text[]", nullable: true),
                    Founders = table.Column<List<string>>(type: "text[]", nullable: true),
                    PoliticalOfficeHolderId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoliticalPartyId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Political Parties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Political Parties_Political Office Holder_PoliticalOfficeHo~",
                        column: x => x.PoliticalOfficeHolderId,
                        principalTable: "Political Office Holder",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Political Parties_Political Parties_PoliticalPartyId",
                        column: x => x.PoliticalPartyId,
                        principalTable: "Political Parties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Political Offices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Office = table.Column<int>(type: "integer", nullable: false),
                    AvatarUrl = table.Column<string>(type: "text", nullable: true),
                    TermLimits = table.Column<int>(type: "integer", nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentTenureStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CurrentTenureEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NextElection = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Functions = table.Column<List<string>>(type: "text[]", nullable: false),
                    PoliticalOfficeHolderId = table.Column<Guid>(type: "uuid", nullable: true),
                    PoliticalPartyId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Political Offices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Political Offices_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Political Offices_Political Office Holder_PoliticalOfficeHo~",
                        column: x => x.PoliticalOfficeHolderId,
                        principalTable: "Political Office Holder",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Political Offices_Political Parties_PoliticalPartyId",
                        column: x => x.PoliticalPartyId,
                        principalTable: "Political Parties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ApplicationUserId",
                table: "Addresses",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_LocationId",
                table: "Addresses",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PoliticalOfficeId",
                table: "Addresses",
                column: "PoliticalOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PoliticalPartyId",
                table: "Addresses",
                column: "PoliticalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ApplicationUserId",
                table: "Articles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ApplicationUserId1",
                table: "Articles",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryBasedCommunityId",
                table: "Articles",
                column: "CategoryBasedCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_LocationBasedCommunityId",
                table: "Articles",
                column: "LocationBasedCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_LocationId",
                table: "Articles",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category Based Communities_ApplicationUserId",
                table: "Category Based Communities",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category Based Communities_ContactId",
                table: "Category Based Communities",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ApplicationUserId1",
                table: "Comments",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentId",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ApplicationUserId",
                table: "Contacts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PoliticalOfficeHolderId",
                table: "Contacts",
                column: "PoliticalOfficeHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PoliticalOfficeId",
                table: "Contacts",
                column: "PoliticalOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PoliticalPartyId",
                table: "Contacts",
                column: "PoliticalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Location Based Communities_ApplicationUserId",
                table: "Location Based Communities",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Location Based Communities_ContactId",
                table: "Location Based Communities",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationBasedCommunityId",
                table: "Locations",
                column: "LocationBasedCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Political Office Holder_PoliticalOfficeId",
                table: "Political Office Holder",
                column: "PoliticalOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Political Offices_LocationId",
                table: "Political Offices",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Political Offices_PoliticalOfficeHolderId",
                table: "Political Offices",
                column: "PoliticalOfficeHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Political Offices_PoliticalPartyId",
                table: "Political Offices",
                column: "PoliticalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Political Parties_PoliticalOfficeHolderId",
                table: "Political Parties",
                column: "PoliticalOfficeHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Political Parties_PoliticalPartyId",
                table: "Political Parties",
                column: "PoliticalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_ApplicationUserId",
                table: "Reactions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_ApplicationUserId1",
                table: "Reactions",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_ArticleId",
                table: "Reactions",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_CommentId",
                table: "Reactions",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CategoryBasedCommunityId",
                table: "Users",
                column: "CategoryBasedCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CategoryBasedCommunityId1",
                table: "Users",
                column: "CategoryBasedCommunityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CategoryBasedCommunityId2",
                table: "Users",
                column: "CategoryBasedCommunityId2");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LocationBasedCommunityId",
                table: "Users",
                column: "LocationBasedCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LocationBasedCommunityId1",
                table: "Users",
                column: "LocationBasedCommunityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LocationBasedCommunityId2",
                table: "Users",
                column: "LocationBasedCommunityId2");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Locations_LocationId",
                table: "Addresses",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Political Offices_PoliticalOfficeId",
                table: "Addresses",
                column: "PoliticalOfficeId",
                principalTable: "Political Offices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Political Parties_PoliticalPartyId",
                table: "Addresses",
                column: "PoliticalPartyId",
                principalTable: "Political Parties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_ApplicationUserId",
                table: "Addresses",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Category Based Communities_CategoryBasedCommunityId",
                table: "Articles",
                column: "CategoryBasedCommunityId",
                principalTable: "Category Based Communities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Location Based Communities_LocationBasedCommunityId",
                table: "Articles",
                column: "LocationBasedCommunityId",
                principalTable: "Location Based Communities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Locations_LocationId",
                table: "Articles",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_ApplicationUserId",
                table: "Articles",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_ApplicationUserId1",
                table: "Articles",
                column: "ApplicationUserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_Users_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category Based Communities_Contacts_ContactId",
                table: "Category Based Communities",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category Based Communities_Users_ApplicationUserId",
                table: "Category Based Communities",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_ApplicationUserId1",
                table: "Comments",
                column: "ApplicationUserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Political Office Holder_PoliticalOfficeHolderId",
                table: "Contacts",
                column: "PoliticalOfficeHolderId",
                principalTable: "Political Office Holder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Political Offices_PoliticalOfficeId",
                table: "Contacts",
                column: "PoliticalOfficeId",
                principalTable: "Political Offices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Political Parties_PoliticalPartyId",
                table: "Contacts",
                column: "PoliticalPartyId",
                principalTable: "Political Parties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_ApplicationUserId",
                table: "Contacts",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Location Based Communities_Users_ApplicationUserId",
                table: "Location Based Communities",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Political Office Holder_Political Offices_PoliticalOfficeId",
                table: "Political Office Holder",
                column: "PoliticalOfficeId",
                principalTable: "Political Offices",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Political Offices_Locations_LocationId",
                table: "Political Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Political Offices_PoliticalOfficeId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Political Office Holder_Political Offices_PoliticalOfficeId",
                table: "Political Office Holder");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Political Parties_PoliticalPartyId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Category Based Communities_Users_ApplicationUserId",
                table: "Category Based Communities");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_ApplicationUserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Location Based Communities_Users_ApplicationUserId",
                table: "Location Based Communities");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Political Offices");

            migrationBuilder.DropTable(
                name: "Political Parties");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Category Based Communities");

            migrationBuilder.DropTable(
                name: "Location Based Communities");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Political Office Holder");
        }
    }
}
