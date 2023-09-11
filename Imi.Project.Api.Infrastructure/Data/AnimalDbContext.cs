using Imi.Project.Api.Core.Claims;
using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Imi.Project.Api.Infrastructure.Data
{
    public class AnimalDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Breeding> Breedings { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Kind> Kinds { get; set; }

        public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Breeding>().HasData(
                new[]
                {
                    new Breeding
                    {
                        Id = 1,
                        Name = "Schuimnestbouwer"
                    },
                    new Breeding
                    {
                        Id = 2,
                        Name = "Holenbroeder"
                    },
                    new Breeding
                    {
                        Id = 3,
                        Name = "Vrijlegger"
                    },
                    new Breeding
                    {
                        Id = 4,
                        Name = "Substraatbroeder"
                    },
                    new Breeding
                    {
                        Id = 5,
                        Name = "Muilbroeder"
                    },
                    new Breeding
                    {
                        Id = 6,
                        Name = "Vrouwtje houdt bij"
                    },
                    new Breeding
                    {
                        Id = 7,
                        Name = "Eierlevendbarend"
                    },
                    new Breeding
                    {
                        Id = 8,
                        Name = "Bodemleggers"
                    },
                    new Breeding
                    {
                        Id = 9,
                        Name = "Koekoeksbroeders"
                    },
                    new Breeding
                    {
                        Id = 10,
                        Name = "Mannetje houdt bij"
                    },

                });

            modelBuilder.Entity<Diet>().HasData(
                new[]
                {
                    new Diet
                    {
                        Id = 1,
                        Name = "Omnivoor"
                    },
                    new Diet
                    {
                        Id = 2,
                        Name = "Herbivoor"
                    },
                    new Diet
                    {
                        Id = 3,
                        Name = "Algentabletten"
                    },
                    new Diet
                    {
                        Id = 4,
                        Name = "Daphnia - Droogvoer"
                    },
                    new Diet
                    {
                        Id = 5,
                        Name = "Spirulina - Droogvoer"
                    },
                    new Diet
                    {
                        Id = 6,
                        Name = "Carnivoor"
                    },
                    new Diet
                    {
                        Id = 7,
                        Name = "Artemia - Levend voer"
                    },
                    new Diet
                    {
                        Id = 8,
                        Name = "Levende vissen"
                    },
                    new Diet
                    {
                        Id = 9,
                        Name = "Muggenlarven - Levend voer"
                    },
                    new Diet
                    {
                        Id = 10,
                        Name = "Watervlooien"
                    },

                });

            modelBuilder.Entity<Kind>().HasData(
                new[]
                {
                    new Kind
                    {
                        Id = 1,
                        Name = "Vis",
                        ImageUrl = new Uri("https://img.pixers.pics/pho_wat(s3:700/FO/52/08/83/96/700_FO52088396_612b0a2384be2c002b7be437f3372043.jpg,700,494,cms:2018/10/5bd1b6b8d04b8_220x50-watermark.png,over,480,444,jpg)/stickers-leuke-cartoon-vis.jpg.jpg")
                    },
                    new Kind
                    {
                        Id = 2,
                        Name = "Garnaal",
                        ImageUrl = new Uri("https://img.pixers.pics/pho_wat(s3:700/FO/45/52/09/12/700_FO45520912_f40c182c4c12dc9f2610125a81b8b8b3.jpg,700,540,cms:2018/10/5bd1b6b8d04b8_220x50-watermark.png,over,480,490,jpg)/fotobehang-grappige-garnalen-cartoon.jpg.jpg")
                    },
                    new Kind
                    {
                        Id = 3,
                        Name = "Kreeft",
                        ImageUrl = new Uri("https://img.freepik.com/premium-vector/cartoon-kreeft-illustratie_29190-3564.jpg?w=2000")
                    },
                    new Kind
                    {
                        Id = 4,
                        Name = "Slak",
                        ImageUrl = new Uri("https://img.freepik.com/premium-vector/schattige-cartoon-slak_160606-341.jpg?w=2000")
                    },
                    new Kind
                    {
                        Id = 5,
                        Name = "Amfibiën",
                        ImageUrl = new Uri("https://i.pinimg.com/originals/dd/f2/78/ddf2783a9bed5888963ecf47a8e6a53d.jpg")
                    },
                    new Kind
                    {
                        Id = 6,
                        Name = "Krab",
                        ImageUrl = new Uri("https://us.123rf.com/450wm/vectorcoolarts/vectorcoolarts2104/vectorcoolarts210400025/168293491-leuke-vrolijke-krab-cartoon-afbeelding.jpg?ver=6")
                    },
                    new Kind
                    {
                        Id = 7,
                        Name = "Zeepaarden",
                        ImageUrl = new Uri("https://static.vecteezy.com/ti/gratis-vector/p3/1265646-schattig-blauw-zeepaardje-cartoon-vector.jpg")
                    },
                    new Kind
                    {
                        Id = 8,
                        Name = "Schelpdieren",
                        ImageUrl = new Uri("https://media.istockphoto.com/vectors/cartoon-happy-oyster-vector-id470840750?b=1&k=20&m=470840750&s=612x612&w=0&h=bN-iY22PQ9zgL2r1ZgtY6GJwnED_mC4CatojSiJ9Y-0=")
                    },
                    new Kind
                    {
                        Id = 9,
                        Name = "Schildpad",
                        ImageUrl = new Uri("https://img.freepik.com/premium-vector/gelukkig-schildpad-cartoon_160606-329.jpg?w=2000")
                    }

                });

            modelBuilder.Entity<Continent>().HasData(
                new[]
                {
                    new Continent
                    {
                        Id = 1,
                        Name = "Azië",
                        ImageUrl = new Uri("https://www.landenkompas.nl/img/continenten/continent-azie.png")
                    },
                    new Continent
                    {
                        Id = 2,
                        Name = "Afrika",
                        ImageUrl = new Uri("https://www.landenkompas.nl/img/continenten/continent-afrika.png")
                    },
                    new Continent
                    {
                        Id = 3,
                        Name = "Noord-Amerika",
                        ImageUrl = new Uri("https://www.landenkompas.nl/img/continenten/continent-noord-amerika.png")
                    },
                    new Continent
                    {
                        Id = 4,
                        Name = "Zuid-Amerika",
                        ImageUrl = new Uri("https://www.landenkompas.nl/img/continenten/continent-zuid-amerika.png")
                    },
                    new Continent
                    {
                        Id = 5,
                        Name = "Atlantische Oceaan",
                        ImageUrl = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/0/06/Atlantic_Ocean.png/266px-Atlantic_Ocean.png")
                    },
                    new Continent
                    {
                        Id = 6,
                        Name = "Australië - Oceanië",
                        ImageUrl = new Uri("https://www.landenkompas.nl/img/continenten/continent-oceanie.png")
                    },
                    new Continent
                    {
                        Id = 7,
                        Name = "Midden-Amerika",
                        ImageUrl=new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Middle_America_%28orthographic_projection%29.svg/266px-Middle_America_%28orthographic_projection%29.svg.png")
                    },
                    new Continent
                    {
                        Id = 8,
                        Name = "Europa",
                        ImageUrl = new Uri("https://www.landenkompas.nl/img/continenten/continent-europa.png")
                    },
                    new Continent
                    {
                        Id = 9,
                        Name = "Madagaskar",
                        ImageUrl = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/8/82/LocationMadagascar.svg/1920px-LocationMadagascar.svg.png")
                    },
                    new Continent
                    {
                        Id = 10,
                        Name = "Malawi",
                        ImageUrl = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/0/05/Lake_Malawi_seen_from_orbit.jpg/266px-Lake_Malawi_seen_from_orbit.jpg")
                    }
                });

            modelBuilder.Entity<Social>().HasData(
                    new[]
                    {
                    new Social
                    {
                        Id = 1,
                        Name= "Solitair"
                    },
                    new Social
                    {
                        Id = 2,
                        Name = "Koppel"
                    },
                    new Social
                    {
                        Id = 3,
                        Name = "Groep"
                    },
                    new Social
                    {
                        Id = 4,
                        Name = "Harem"
                    },
                    new Social
                    {
                        Id = 5,
                        Name = "Kolonie"
                    },
                    new Social
                    {
                        Id = 6,
                        Name = "School"
                    }
                });

            modelBuilder.Entity<Animal>().HasData(
                new[]
                {
                    new Animal
                    {
                        Id = 1,
                        NameFamily = "Osphronemidae",
                        NameDutch = "Betta Splendens",
                        ImageUrl = new Uri("https://www.aquariumfans.nl/wp-content/uploads/2016/09/Een-kempvis-spreidt-zijn-prachtige-rode-vinnen.jpg"),
                        BreedingId = 1,
                        DietId = 1,
                        KindId = 1,
                        ContinentId = 1,
                        SocialId = 1,
                        TempMin = 20, TempMax = 28,
                        PhMin = 7,
                        PhMax = 8,
                        GhMin = 8,
                        GhMax = 12
                    },
                    new Animal
                    {
                            Id = 2,
                            NameFamily = "Loricariidae",
                            NameDutch = "Ancistruss",
                            ImageUrl = new Uri("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzOSqOT7KqM_Dd81qqwWrPgkxCpF1AWq8LynTdeKWcV7DsJf8-qd7O2knrmu4nuz8k2dU&usqp=CAU"),
                            BreedingId = 2,
                            DietId = 3,
                            KindId = 1,
                            ContinentId = 4,
                            SocialId = 2,
                            TempMin = 23,
                            TempMax = 26,
                            PhMin = 6,
                            PhMax = 8,
                            GhMin = 5,
                            GhMax = 15
                    },
                    new Animal
                    {
                        Id = 3,
                        NameFamily = "Sesarmidae",
                        NameDutch = "Vampierkrab",
                        ImageUrl = new Uri("https://dennerle.com/sites/default/files/styles/newspicture/public/uploads/public/news/geosesarma-dennerle.jpg?itok=UlaS87qc"),
                        BreedingId = 6,
                        DietId = 9,
                        KindId = 6,
                        ContinentId = 1,
                        SocialId = 3,
                        TempMin = 23,
                        TempMax = 26,
                        PhMin = 6,
                        PhMax = 8,
                        GhMin = 5,
                        GhMax = 15
                    },
                    new Animal
                    {
                        Id = 4,
                        NameFamily = "Osteoglossidae",
                        NameDutch = "Zilveren Arowana",
                        ImageUrl = new Uri("https://vissenaquarium.nl/wp-content/uploads/2016/05/Zilveren-Arowana-300x199.jpg"),
                        BreedingId = 6,
                        DietId = 8,
                        KindId = 1,
                        ContinentId = 4,
                        SocialId = 3,
                        TempMin = 23,
                        TempMax = 28,
                        PhMin = 6,
                        PhMax = 7,
                        GhMin = 2,
                        GhMax = 6
                    },
                    new Animal
                    {
                        Id = 5,
                        NameFamily = "Neritidae",
                        NameDutch = "Rode Neritina Slak",
                        ImageUrl = new Uri("https://www.azaqua.nl/14525-thickbox_default/neritina-waigiensis.jpg"),
                        BreedingId = 4,
                        DietId = 6,
                        KindId = 4,
                        ContinentId = 1,
                        SocialId = 3,

                        TempMin = 20,
                        TempMax = 30,
                        PhMin = 7,
                        PhMax = 9,
                        GhMin = 10,
                        GhMax = 30
                    },
                    new Animal
                    {
                        Id = 6,
                        NameFamily = "Pipidae",
                        NameDutch = "Dwergklauwkikker",
                        ImageUrl = new Uri("https://cdn.myonlinestore.eu/93c794e2-6be1-11e9-a722-44a8421b9960/image/cache/article/e19adb5fb7200b2ec41c5f5242733222e2f3ca6c.jpg"),
                        BreedingId = 3,
                        DietId = 6,
                        KindId = 5,
                        ContinentId = 2,
                        SocialId = 3,

                        TempMin = 24,
                        TempMax = 27,
                        PhMin = 5,
                        PhMax = 7,
                        GhMin = 5,
                        GhMax = 15
                    },
                    new Animal
                    {
                        Id = 7,
                        NameFamily = "Atyidae",
                        NameDutch = "Afrikaanse Waaierhandgarnaal",
                        ImageUrl = new Uri("https://www.garnalenkweker.nl/database/garnalenfotos/gk_shrimp_atya_gabonensis_02.jpg"),
                        BreedingId = 6,
                        DietId = 1,
                        KindId = 2,
                        ContinentId = 2,
                        SocialId = 4,

                        TempMin = 20,
                        TempMax = 30,
                        PhMin = 6,
                        PhMax = 8,
                        GhMin = 5,
                        GhMax = 20
                    },
                    new Animal
                    {
                        Id = 8,
                        NameFamily = "Atyidae",
                        NameDutch = "Kardinaalgarnaal",
                        ImageUrl = new Uri("https://www.aquainfo.nl/wp-content/uploads/2018/03/Caridina-sp-Sulawesi-Kardinaal-Garnaal.jpg"),
                        BreedingId = 6,
                        DietId = 1,
                        KindId = 2,
                        ContinentId = 6,
                        SocialId = 3,

                        TempMin = 18,
                        TempMax = 25,
                        PhMin = 6,
                        PhMax = 8,
                        GhMin = 5,
                        GhMax = 20
                    },
                    new Animal
                    {
                        Id = 9,
                        NameFamily = "Diodontidae",
                        NameDutch = "Ballonegelvis",
                        ImageUrl = new Uri("https://aquainfo.nl/wp-content/uploads/2012/09/Diodon-holocanthus-opgezet-1.jpg"),
                        BreedingId = 7,
                        DietId = 6,
                        KindId = 1,
                        ContinentId = 5,
                        SocialId = 1,

                        TempMin = 23,
                        TempMax = 26,
                        PhMin = 8,
                        PhMax = 9,
                        GhMin = 4,
                        GhMax = 7
                    },
                    new Animal
                    {
                        Id = 10,
                        NameFamily = "Cyprinidae",
                        NameDutch = "Rasbora Galaxy",
                        ImageUrl = new Uri("https://www.aquariumvissenwinkel.nl/pub/media/catalog/product/cache/6adf04d0a500106b8356e43536d091ec/g/a/galaxyrasbora2.jpg"),
                        BreedingId = 3,
                        DietId = 6,
                        KindId = 1,
                        ContinentId = 1,
                        SocialId = 6,

                        TempMin = 20,
                        TempMax = 25,
                        PhMin = 7,
                        PhMax = 8,
                        GhMin = 3,
                        GhMax = 10
                    },
                    new Animal
                    {
                        Id = 11,
                        NameFamily = "Gymnophiona",
                        NameDutch = "Axolotl",
                        ImageUrl = new Uri("https://usercontent.one/wp/www.salamanders.nl/wp-content/uploads/2018/08/axolotl-1-1024x678.jpg"),
                        BreedingId = 4,
                        DietId = 6,
                        KindId = 5,
                        ContinentId = 7,
                        SocialId = 1,

                        TempMin = 14,
                        TempMax = 20,
                        PhMin = 6,
                        PhMax = 8,
                        GhMin = 5,
                        GhMax = 7
                    }
                }) ;

            string password = "Test123?";

            string adminUserName = "admin@imi.be";
            string imiuserUserName = "user@imi.be";
            string imiRefuserUsername = "refuser@imi.be";
            string mdeuserUsername = "mde-user@imi.be";

            string adminId = "00000000-1111-1111-1111-000000000001";
            string imiuserId = "00000000-1111-1111-1111-000000000002";
            string imirefuserId = "00000000-1111-1111-1111-000000000003";
            string mdeuserId = "00000000-1111-1111-1111-000000000004";

            string adminRoleId = "10000000-0000-0000-0000-000000000001";
            string adminRoleName = "Admin";
            string userRoleId = "10000000-0000-0000-0000-000000000003";
            string userRoleName = "User";

            IPasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

            ApplicationUser mdeUser = new ApplicationUser
            {
                Birthday = new DateTime(1985, 04, 17),
                UserName = mdeuserUsername,
                NormalizedUserName = mdeuserUsername.ToUpper(),
                Email = mdeuserUsername,
                NormalizedEmail = mdeuserUsername.ToUpper(),
                EmailConfirmed = true,
                Id = mdeuserId,
                SecurityStamp = "704af8f2-454f-4c67-91f7-fd72b3082d94",
                ConcurrencyStamp = "128af8f2-454f-4d9y-91f7-fd72b5632d94",
                TermsAndConditions = true
            };

            ApplicationUser admin = new ApplicationUser
            {
                Birthday = new DateTime(1985, 04, 17),
                UserName = adminUserName,
                NormalizedUserName = adminUserName.ToUpper(),
                Email = adminUserName,
                NormalizedEmail = adminUserName.ToUpper(),
                EmailConfirmed = true,
                Id = adminId,
                SecurityStamp = "82855de4-2699-409c-aa9e-426bf6dd73ad",
                ConcurrencyStamp = "4ef543f6-20a4-435d-b3fe-8dfe368439e5",
                TermsAndConditions = true
            };

            ApplicationUser imiUser = new ApplicationUser
            {
                Birthday = new DateTime(1985, 08, 02),
                UserName = imiuserUserName,
                NormalizedUserName = imiuserUserName.ToUpper(),
                Email = imiuserUserName,
                NormalizedEmail = imiuserUserName.ToUpper(),
                EmailConfirmed = true,
                Id = imiuserId,
                SecurityStamp = "3e5afa49-5b79-4d3b-b2d8-35bbda250834",
                ConcurrencyStamp = "a6a4703e-8c70-40b5-bd11-cda1be1a7e5f",
                TermsAndConditions = true
            };

            ApplicationUser imiRefuser = new ApplicationUser
            {
                Birthday = new DateTime(1965, 01, 02),
                UserName = imiRefuserUsername,
                NormalizedUserName = imiRefuserUsername.ToUpper(),
                Email = imiRefuserUsername,
                NormalizedEmail = imiRefuserUsername.ToUpper(),
                EmailConfirmed = true,
                Id = imirefuserId,
                SecurityStamp = "3406f134-0b4b-47c6-a9c6-a38a5fc352a0",
                ConcurrencyStamp = "97b5c114-8f42-4c1f-b7c2-d7cb5039b989",
                TermsAndConditions = false
            };

            admin.PasswordHash = passwordHasher.HashPassword(admin, password);
            imiUser.PasswordHash = passwordHasher.HashPassword(imiUser, password);
            imiRefuser.PasswordHash = passwordHasher.HashPassword(imiRefuser, password);
            mdeUser.PasswordHash = passwordHasher.HashPassword(mdeUser, password);

            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(
                new IdentityUserClaim<string>
                {
                    Id = 1,
                    UserId = adminId,
                    ClaimType = MyClaims.TermsClaims,
                    ClaimValue = admin.TermsAndConditions.ToString()
                },
                new IdentityUserClaim<string>
                {
                    Id = 2,
                    UserId = imiuserId,
                    ClaimType = MyClaims.TermsClaims,
                    ClaimValue = imiUser.TermsAndConditions.ToString()
                },
                new IdentityUserClaim<string>
                {
                    Id = 3,
                    UserId = imirefuserId,
                    ClaimType = MyClaims.TermsClaims,
                    ClaimValue = imiRefuser.TermsAndConditions.ToString()
                },
                new IdentityUserClaim<string>
                {
                    Id = 4,
                    UserId = mdeuserId,
                    ClaimType = MyClaims.TermsClaims,
                    ClaimValue = mdeUser.TermsAndConditions.ToString()
                });

            modelBuilder.Entity<ApplicationUser>().HasData(admin);
            modelBuilder.Entity<ApplicationUser>().HasData(imiUser);
            modelBuilder.Entity<ApplicationUser>().HasData(imiRefuser);
            modelBuilder.Entity<ApplicationUser>().HasData(mdeUser);


            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = adminRoleName,
                    NormalizedName = adminRoleName.ToUpper()
                },
                new IdentityRole
                {
                    Id = userRoleId,
                    Name = userRoleName,
                    NormalizedName = userRoleName.ToUpper()
                });


            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = adminId,
                    RoleId = adminRoleId
                },
                new IdentityUserRole<string>
                {
                    UserId = imiuserId,
                    RoleId = userRoleId
                },
                new IdentityUserRole<string>
                {
                    UserId = imirefuserId,
                    RoleId = userRoleId
                },
                new IdentityUserRole<string>
                {
                    UserId = mdeuserId,
                    RoleId = adminRoleId
                });



        }
    }
}
