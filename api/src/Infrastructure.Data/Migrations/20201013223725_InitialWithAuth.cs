﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class InitialWithAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: true),
                    PurchasePrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(36)", nullable: true),
                    BookId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriptions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Name", "PurchasePrice", "Text" },
                values: new object[,]
                {
                    { new Guid("108e8ab4-44b7-4070-a0ed-5678707e8bca"), "Rage", 17.780000000000001, @"Bob Woodward’s new book, Rage, is an unprecedented and intimate tour de force of new reporting on the Trump presidency facing a global pandemic, economic disaster and racial unrest.

                Woodward, the #1 international bestselling author of Fear: Trump in the White House, has uncovered the precise moment the president was warned that the Covid-19 epidemic would be the biggest national security threat to his presidency. In dramatic detail, Woodward takes readers into the Oval Office as Trump’s head pops up when he is told in January 2020 that the pandemic could reach the scale of the 1918 Spanish Flu that killed 675,000 Americans.

                In 17 on-the-record interviews with Woodward over seven volatile months—an utterly vivid window into Trump’s mind—the president provides a self-portrait that is part denial and part combative interchange mixed with surprising moments of doubt as he glimpses the perils in the presidency and what he calls the “dynamite behind every door.”

                At key decision points, Rage shows how Trump’s responses to the crises of 2020 were rooted in the instincts, habits and style he developed during his first three years as president.

                Revisiting the earliest days of the Trump presidency, Rage reveals how Secretary of Defense James Mattis, Secretary of State Rex Tillerson and Director of National Intelligence Dan Coats struggled to keep the country safe as the president dismantled any semblance of collegial national security decision making.

                Rage draws from hundreds of hours of interviews with firsthand witnesses as well as participants’ notes, emails, diaries, calendars and confidential documents.

                Woodward obtained 25 never-seen personal letters exchanged between Trump and North Korean leader Kim Jong Un, who describes the bond between the two leaders as out of a “fantasy film.”

                Trump insists to Woodward he will triumph over Covid-19 and the economic calamity. “Don’t worry about it, Bob. Okay?” Trump told the author in July. “Don’t worry about it. We’ll get to do another book. You’ll find I was right.”" },
                    { new Guid("d5b9ecac-881d-4a8a-92ee-e8f5881cd0d1"), "Solutions and Other Problems", 18.449999999999999, @"Solutions and Other Problems includes humorous stories from Allie Brosh’s childhood; the adventures of her very bad animals; merciless dissection of her own character flaws; incisive essays on grief, loneliness, and powerlessness; as well as reflections on the absurdity of modern life.

                This full-color, beautifully illustrated edition features all-new material with more than 1,600 pieces of art. Solutions and Other Problems marks the return of a beloved American humorist who has “the observational skills of a scientist, the creativity of an artist, and the wit of a comedian” (Bill Gates).

                Praise for Allie Brosh’s Hyperbole and a Half:
                “Imagine if David Sedaris could draw….Enchanting.” —People
                “One of the best things I’ve ever read in my life.” —Marc Maron
                “Will make you laugh until you sob, even when Brosh describes her struggle with depression.” —Entertainment Weekly
                “I would gladly pay to sit in a room full of people reading this book, merely to share the laughter.” —The Philadelphia Inquirer
                “In a culture that encourages people to carry mental illness as a secret burden….Brosh’s bracing honesty is a gift.” —Chicago Tribune" },
                    { new Guid("13965e6f-9b20-4cf0-b1d6-9af06b2ed003"), "Greenlights", 18.710000000000001, @"I’ve been in this life for fifty years, been trying to work out its riddle for forty-two, and been keeping diaries of clues to that riddle for the last thirty-five. Notes about successes and failures, joys and sorrows, things that made me marvel, and things that made me laugh out loud. How to be fair. How to have less stress. How to have fun. How to hurt people less. How to get hurt less. How to be a good man. How to have meaning in life. How to be more me.
                 
                Recently, I worked up the courage to sit down with those diaries. I found stories I experienced, lessons I learned and forgot, poems, prayers, prescriptions, beliefs about what matters, some great photographs, and a whole bunch of bumper stickers. I found a reliable theme, an approach to living that gave me more satisfaction, at the time, and still: If you know how, and when, to deal with life’s challenges—how to get relative with the inevitable—you can enjoy a state of success I call “catching greenlights.”
                 
                So I took a one-way ticket to the desert and wrote this book: an album, a record, a story of my life so far. This is fifty years of my sights and seens, felts and figured-outs, cools and shamefuls. Graces, truths, and beauties of brutality. Getting away withs, getting caughts, and getting wets while trying to dance between the raindrops.
                 
                Hopefully, it’s medicine that tastes good, a couple of aspirin instead of the infirmary, a spaceship to Mars without needing your pilot’s license, going to church without having to be born again, and laughing through the tears.
                 
                It’s a love letter. To life.
                 
                It’s also a guide to catching more greenlights—and to realizing that the yellows and reds eventually turn green too.
                 
                Good luck." },
                    { new Guid("b7efdf5e-7e57-4f68-b56b-424cff3e7cfc"), "Compromised: Counterintelligence and the Threat of Donald J. Trump", 17.989999999999998, @"When he opened the FBI investigation into Russia’s election interference, Peter Strzok had already spent more than two decades defending the United States against foreign threats. His career in counterintelligence ended shortly thereafter, when the Trump administration used his private expression of political opinions to force him out of the Bureau in August 2018. But by that time, Strzok had seen more than enough to convince him that the commander in chief had fallen under the sway of America’s adversary in the Kremlin.

                In Compromised, Strzok draws on lessons from a long career—from his role in the Russian illegals case that inspired The Americans to his service as lead FBI agent on the Mueller investigation—to construct a devastating account of foreign influence at the highest levels of our government. And he grapples with a question that should concern every U.S. citizen: When a president appears to favor personal and Russian interests over those of our nation, has he become a national security threat?" },
                    { new Guid("84ee2740-0df6-46b5-8d8b-376dccb52f39"), "The 48 Laws of Power", 30.0, @"In the book that People magazine proclaimed “beguiling” and “fascinating,” Robert Greene and Joost Elffers have distilled three thousand years of the history of power into 48 essential laws by drawing from the philosophies of Machiavelli, Sun Tzu, and Carl Von Clausewitz and also from the lives of figures ranging from Henry Kissinger to P.T. Barnum.
                 
                Some laws teach the need for prudence (“Law 1: Never Outshine the Master”), others teach the value of confidence (“Law 28: Enter Action with Boldness”), and many recommend absolute self-preservation (“Law 15: Crush Your Enemy Totally”). Every law, though, has one thing in common: an interest in total domination. In a bold and arresting two-color package, The 48 Laws of Power is ideal whether your aim is conquest, self-defense, or simply to understand the rules of the game." },
                    { new Guid("35d55a9a-39c2-42be-9520-fc30c39e0f5e"), "Eat a Peach: A Memoir", 16.800000000000001, @"In 2004, Momofuku Noodle Bar opened in a tiny, stark space in Manhattan’s East Village. Its young chef-owner, David Chang, worked the line, serving ramen and pork buns to a mix of fellow restaurant cooks and confused diners whose idea of ramen was instant noodles in Styrofoam cups. It would have been impossible to know it at the time—and certainly Chang would have bet against himself—but he, who had failed at almost every endeavor in his life, was about to become one of the most influential chefs of his generation, driven by the question, “What if the underground could become the mainstream?”
                 
                Chang grew up the youngest son of a deeply religious Korean American family in Virginia. Graduating college aimless and depressed, he fled the States for Japan, hoping to find some sense of belonging. While teaching English in a backwater town, he experienced the highs of his first full-blown manic episode, and began to think that the cooking and sharing of food could give him both purpose and agency in his life.

                Full of grace, candor, grit, and humor, Eat a Peach chronicles Chang’s switchback path. He lays bare his mistakes and wonders about his extraordinary luck as he recounts the improbable series of events that led him to the top of his profession. He wrestles with his lifelong feelings of otherness and inadequacy, explores the mental illness that almost killed him, and finds hope in the shared value of deliciousness. Along the way, Chang gives us a penetrating look at restaurant life, in which he balances his deep love for the kitchen with unflinching honesty about the industry’s history of brutishness and its uncertain future." },
                    { new Guid("26fa110f-9a46-4aa8-844f-af903964c525"), "The Luckiest Man: Life with John McCain", 30.489999999999998, @"More so than almost anyone outside of McCain’s immediate family, Mark Salter had unparalleled access to and served to influence the Senator’s thoughts and actions, cowriting seven books with him and acting as a valued confidant. Now, in The Luckiest Man, Salter draws on the storied facets of McCain’s early biography as well as the later-in-life political philosophy for which the nation knew and loved him, delivering an intimate and comprehensive account of McCain’s life and philosophy.

                Salter covers all the major events of McCain’s life—his peripatetic childhood, his naval service—but introduces, too, aspects of the man that the public rarely saw and hardly knew. Woven throughout this narrative is also the story of Salter and McCain’s close relationship, including how they met, and why their friendship stood the test of time in a political world known for its fickle personalities and frail bonds.

                Through Salter’s revealing portrayal of one of our country’s finest public servants, McCain emerges as both the man we knew him to be and also someone entirely new. Glimpses of his restlessness, his curiosity, his courage, and sentimentality are rendered with sensitivity and care—as only Mark Salter could provide. The capstone to Salter’s intimate and decades-spanning time with the Senator, The Luckiest Man is the authoritative last word on the stories McCain was too modest to tell himself and an influential life not soon to be forgotten." },
                    { new Guid("98c02bad-95ee-48d6-9355-5fb012972d41"), "Abe: Abraham Lincoln in His Times", 45.0, @"From one of the great historians of nineteenth-century America, a revelatory and enthralling new biography of Lincoln, many years in the making, that brings him to life within his turbulent age

                David S. Reynolds, author of the Bancroft Prize-winning cultural biography of Walt Whitman and many other iconic works of nineteenth century American history, understands the currents in which Abraham Lincoln swam as well as anyone alive. His magisterial biography Abe is the product of full-body immersion into the riotous tumult of American life in the decades before the Civil War.

                It was a country growing up and being pulled apart at the same time, with a democratic popular culture that reflected the country's contradictions. Lincoln's lineage was considered auspicious by Emerson, Whitman, and others who prophesied that a new man from the West would emerge to balance North and South. From New England Puritan stock on his father's side and Virginia Cavalier gentry on his mother's, Lincoln was linked by blood to the central conflict of the age. And an enduring theme of his life, Reynolds shows, was his genius for striking a balance between opposing forces. Lacking formal schooling but with an unquenchable thirst for self-improvement, Lincoln had a talent for wrestling and bawdy jokes that made him popular with his peers, even as his appetite for poetry and prodigious gifts for memorization set him apart from them through his childhood, his years as a lawyer, and his entrance into politics.

                No one can transcend the limitations of their time, and Lincoln was no exception. But what emerges from Reynolds's masterful reckoning is a man who at each stage in his life managed to arrive at a broader view of things than all but his most enlightened peers. As a politician, he moved too slowly for some and too swiftly for many, but he always pushed toward justice while keeping the whole nation in mind. Abe culminates, of course, in the Civil War, the defining test of Lincoln and his beloved country. Reynolds shows us the extraordinary range of cultural knowledge Lincoln drew from as he shaped a vision of true union, transforming, in Martin Luther King Jr.'s words, ""the jangling discords of our nation into a beautiful symphony of brotherhood.""

                Abraham Lincoln did not come out of nowhere.But if he was shaped by his times, he also managed at his life's fateful hour to shape them to an extent few could have foreseen. Ultimately, this is the great drama that astonishes us still, and that Abe brings to fresh and vivid life. The measure of that life will always be part of our American education." }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_BookId",
                table: "Subscriptions",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
