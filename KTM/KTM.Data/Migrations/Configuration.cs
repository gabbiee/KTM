namespace KTM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using KTM.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class Configuration : DbMigrationsConfiguration<KTMContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(KTMContext context)
        {
            this.SeedUsers(context);
            this.SeedNews(context);
            this.SeedCategories(context);
            this.SeedMotorcycles(context);
            this.SeedRatings(context);
            this.SeedReviews(context);
        }

        private void SeedNews(KTMContext context)
        {
            if (!context.News.Any())
            {
                var admin = context.Users.FirstOrDefault(u => u.UserName == "admin");
                context.News.AddOrUpdate(
                    c => c.Title,
                    new News()
                    {
                        Title = "News 1",
                        Content = "random text put here pls",
                        ImageUrls = new[] { new ImageUrl()
                  { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/supersport/rc-1251/rc-125-2017/f5003q1/pho_bike_90_re.png"} ,
                  }
                    },
                        new News()
                        {
                            Title = "News 2",
                            Content = "random text put here pls bee",
                            ImageUrls = new[] { new ImageUrl()
                  { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/supersport/rc-1251/rc-125-2017/f5003q1/pho_bike_90_re.png"} ,
                  }
                        });
            }
        }

        private void SeedUsers(KTMContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole("Admin");

                roleManager.Create(role);
            }

            if (!context.Users.Any())
            {
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                User user;
                user = new User() { UserName = "admin", Email = "admin@gmail.com" };
                userManager.Create(user, "Admin123");
                userManager.AddToRole(user.Id, "Admin");
                user = new User() { UserName = "pesho", Email = "pesho@abv.bg" };
                userManager.Create(user, "Pesho123");
                user = new User() { UserName = "gosho", Email = "gosho@abv.bg" };
                userManager.Create(user, "Gosho123");
            }
        }

        private void SeedCategories(KTMContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddOrUpdate(
                c => c.Name,
                 new Category() { Name = "Enduro" },
                 new Category() { Name = "Freeride" },
                 new Category() { Name = "Supermoto" },
                 new Category() { Name = "Travel" },
                 new Category() { Name = "Naked" },
                 new Category() { Name = "Supersport" });
                context.SaveChanges();
            }
        }

        private void SeedMotorcycles(KTMContext context)
        {
            if (!context.Motorcycles.Any())
            {
                var admin = context.Users.FirstOrDefault(u => u.UserName == "admin");
                context.Motorcycles.AddOrUpdate(
                    c => c.Title,
                        //new Motorcycle()
                        //{
                        //    Title = "",
                        //    Description = @"",
                        //    Engine = @"",
                        //    Category = context.Categories.FirstOrDefault(g => g.Name == "Supersport"),
                        //    ImageUrls = new[] { new ImageUrl() { Url = "www.ktm.com" }
                        //    },
                        //    Author = admin
                        //},

                        //Supersport
                        new Motorcycle()
                        {
                            Title = "RC 125",
                            Description = @"The entry level for really ambitious racers. The state-of-the-art, water-cooled DOHC engine delivers 11 kW (15 hp), 12 Nm of torque and total race performance for everyday use. Every ride turns into preparation for the next race with the new street-legal KTM RC 125.",
                            Engine = @"DESIGN: 1-cylinder, 4-stroke engine"
                                +"\r\n" + "DISPLACEMENT: 124.7 cm³"
                                +"\r\n" + "BORE: 58 mm"
                                +"\r\n" + "STROKE: 47.2 mm"
                                +"\r\n" + "POWER IN KW: 11 kW"
                                +"\r\n" + "STARTER: Electric starter"
                                +"\r\n" + "LUBRICATION: Wet sump"
                                +"\r\n" + "TRANSMISSION: 6-speed"
                                +"\r\n" + "PRIMARY DRIVE: 22:72"
                                +"\r\n" + "SECONDARY GEAR RATIO: 14:45"
                                +"\r\n" + "COOLING: Liquid cooled"
                                +"\r\n" + "CLUTCH: Wet multi-disc clutch, mechanically actuated"
                                +"\r\n" + "EMS: Bosch EMS",
                            Category = context.Categories.FirstOrDefault(g => g.Name == "Supersport"),
                            ImageUrls = new[]
                            {
                                new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvSEgwM3JJeUM2QWc" }
                            
                            },
                            Author = admin
                        },
                         new Motorcycle()
                         {
                             Title = "RC 200",
                             Description = @"RC 200 is the first step into KTM´s Ready to Race philosophy. The premium full faired bike is an eye-catcher for its outstanding style. The 200cc engine is combining top performance together with efficient mileage. Premium components such as USD front fork, multifunctional fully digital display and radial brake caliper are completing the package and making RC 200 an excellent value for money full faired motorcycle.",
                             Engine = @"DESIGN: 1-cylinder, 4-stroke engine"
                                +"\r\n" + "DISPLACEMENT: 199.5 cm³"
                                +"\r\n" + "BORE: 72 mm"
                                +"\r\n" + "STROKE: 49 mm"
                                +"\r\n" + "POWER IN KW: 19 kW"
                                +"\r\n" + "Electric starter"
                                +"\r\n" + "LUBRICATION: Wet sump"
                                +"\r\n" + "TRANSMISSION: 6-speed"
                                +"\r\n" + "PRIMARY DRIVE:22:72"
                                + "\r\n" + "SECONDARY GEAR RATIO: 14:42"
                                +"\r\n" + "COOLING: Liquid cooled"
                                +"\r\n" + "CLUTCH: Wet multi-disc clutch, mechanically actuated"
                                +"\r\n" + "EMS: Bosch EMS",
                             Category = context.Categories.FirstOrDefault(g => g.Name == "Supersport"),
                             ImageUrls = new[] {
                                 new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvOTV6dUd5M1g5NUE" },
                                  new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvZmdiUjNfcXFYMVE" },
                                   new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvNUFKZ1BnZW1xWWc" }
                             },
                             Author = admin
                         },

                          new Motorcycle()
                          {
                              Title = "RC 390",
                              Description = @"A sports bike in its purest form. Reduced to the essentials. Agile, fast, suitable for A2 driving license and extremely sporty. Whether you are on country roads or the racetrack, the Moto3 genes are perceptible in every manoeuvre and convey pure race feeling. The handling – simply spectacular. The performance – incredible. The power – awesome.",
                              Engine = @"DESIGN: 1-cylinder, 4-stroke engine"
                                +"\r\n" + "DISPLACEMENT: 373.2 cm³"
                                +"\r\n" + "BORE: 89 mm"
                                +"\r\n" + "STROKE: 60 mm"
                                +"\r\n" + "POWER IN KW: 32 kW"
                                +"\r\n" + "STARTER: Electric starter"
                                +"\r\n" + "LUBRICATION: Semi-dry sump"
                                +"\r\n" + "TRANSMISSION: 6-speed"
                                +"\r\n" + "PRIMARY DRIVE: 30:80"
                                +"\r\n" + "SECONDARY GEAR RATIO: 15:45"
                                +"\r\n" + "COOLING: Liquid cooled"
                                +"\r\n" + "CLUTCH: PASC™ antihopping clutch, mechanically operated"
                                +"\r\n" + "Bosch EMS with RBW",
                              Category = context.Categories.FirstOrDefault(g => g.Name == "Supersport"),
                              ImageUrls = new[] {
                                 new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvdFppekcwZjQtRlk" },
                                  new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-Kvd05maUdqTklRa2c" },
                                   new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvNXdadS1xR0RrbzA" }
                             },
                              Author = admin
                          },



                     //Naked
                     new Motorcycle()
                     {
                         Title = "125 DUKE",
                         Description = @"The 125 DUKE is not a toy. It’s a genuine motorcycle, up there with the best in its class and better equipped than some of the big bikes. Back in 2013 it was the first 125 to receive ABS as standard, now it’s at that forefront again with an LED headlight, a TFT display and optional integrated connectivity. On top of that, the refined 4-stroke single cylinder with fuel injection system and 6-speed transmission combines class-leading performance with limited thirst  – except for adventures. There’s no better place to start.",
                         Engine = @"DESIGN: 1-cylinder, 4-stroke engine"
                                +"\r\n" + "DISPLACEMENT: 124.7 cm³"
                                +"\r\n" + "BORE: 58 mm"
                                +"\r\n" + "STROKE: 47.2 mm"
                                +"\r\n" + "POWER IN KW: 11 kW"
                                +"\r\n" + "STARTER: Electric starter"
                                +"\r\n" + "LUBRICATION: Wet sump"
                                +"\r\n" + "TRANSMISSION: 6-speed"
                                +"\r\n" + "PRIMARY DRIVE: 22:72"
                                +"\r\n" + "SECONDARY GEAR RATIO: 14:45"
                                +"\r\n" + "COOLING: Liquid cooled"
                                +"\r\n" + "Wet multi-disc clutch, mechanically actuated"
                                +"\r\n" + "EMS: Bosch EMS",
                         Category = context.Categories.FirstOrDefault(g => g.Name == "Naked"),
                         ImageUrls = new[] {
                                 new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvT0NLQkczUkw5U00" },
                                  new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvRXZqTW5LeV9CSkU" }
                             },
                         Author = admin
                     },

                    new Motorcycle()
                    {
                        Title = "690 DUKE R",
                        Description = @"The standard 690 Duke is a firecracker of a bike, light as a feather and lightning quick. But we wouldn’t be true to ourselves if we didn’t try to push things just a little bit further. So we did, creating the ultimate single-cylinder street bike on the face of the planet. Really, it’s that spectacul’R.",
                        Engine = @"DESIGN: 1-cylinder, 4-stroke engine"
                                +"\r\n" + "DISPLACEMENT: 690 cm³"
                                +"\r\n" + "BORE: 102 mm"
                                +"\r\n" + "STROKE: 84.5 mm"
                                +"\r\n" + "POWER IN KW: 55 kW"
                                +"\r\n" + "STARTER: Electric starter"
                                +"\r\n" + "LUBRICATION: Forced oil lubrication with 2 oil pumps"
                                +"\r\n" + "TRANSMISSION: 6-speed"
                                +"\r\n" + "PRIMARY DRIVE: 36:79"
                                +"\r\n" + "SECONDARY GEAR RATIO: 16:40"
                                +"\r\n" + "COOLING: Liquid cooled"
                                +"\r\n" + "CLUTCH: APTC(TM) slipper clutch, hydraulically actuated"
                                +"\r\n" + "EMS: Keihin EMS with RBW, twin ignition",
                        Category = context.Categories.FirstOrDefault(g => g.Name == "Naked"),
                        ImageUrls = new[] {
                                 new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvZXFEWjNDNmN3SG8" },
                          },
                        Author = admin
                    },
                       new Motorcycle()
                       {
                           Title = "690 DUKE",
                           Description = @"Two decades ago, the original Duke was nothing short of revolutionary. KTM’s first single-cylinder street bike grew into a cult classic, adding extreme fun to a raw and radical concept. In 2017, the fully revised 690 DUKE stays faithful to its ancestor’s ways, but adds future-proof refinements: impressive smoothness, sophisticated electronics, improved ergonomics and a good old power boost over last year’s model. This firmly cements the world’s strongest single-cylinder production motorcycle at the cutting edge of engineering. Speaking of which: carving corners has never been more fun, thanks to its revised fork offset. Long live the Duke!",
                           Engine = @"DESIGN: 1-cylinder, 4-stroke engine"
                                +"\r\n" + "DISPLACEMENT: 690 cm³"
                                +"\r\n" + "BORE: 102 mm"
                                +"\r\n" + "STROKE: 84.5 mm"
                                +"\r\n" + "POWER IN KW: 54 kW"
                                +"\r\n" + "STARTER: Electric starter"
                                +"\r\n" + "LUBRICATION: Forced oil lubrication with 2 oil pumps"
                                +"\r\n" + "TRANSMISSION: 6-speed"
                                +"\r\n" + "PRIMARY DRIVE: 36:79"
                                +"\r\n" + "SECONDARY GEAR RATIO: 16:40"
                                +"\r\n" + "COOLING: Liquid cooled"
                                +"\r\n" + "CLUTCH: APTC(TM) slipper clutch, hydraulically actuated"
                                + "\r\n" + "EMS: Keihin EMS with RBW, twin ignition",
                           Category = context.Categories.FirstOrDefault(g => g.Name == "Naked"),
                           ImageUrls = new[] {
                                 new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvSjRDbXM1UGlheFU" },
                                  new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvMDRIaDlleXlUV00" }
                             },
                           Author = admin
                       },

                       new Motorcycle()
                       {
                           Title = "1290 SUPER DUKE R",
                           Description = @"This is our punk record - pure, raw and straight to the point: speed. Its V-twin, the most powerful one we ever muscled into a street bike, beats the battle drums at 177 hp, while its purebred chassis is set to stay ahead when the straight is devoured. When corners become prey. Even on a bad day, thanks to state-of-the-art rider assistance systems. No, scratch that. Grin amplifiers.",
                           Engine = @"DESIGN: 2-cylinder, 4-stroke, V 75°"
                                +"\r\n" + "DISPLACEMENT: 1301 cm³"
                                +"\r\n" + "BORE: 108 mm"
                                +"\r\n" + "STROKE: 71 mm"
                                +"\r\n" + "POWER IN KW: 130 kW"
                                +"\r\n" + "STARTER: Electric starter"
                                +"\r\n" + "LUBRICATION: Forced oil lubrication with 3 oil pumps"
                                +"\r\n" + "TRANSMISSION: 6-speed"
                                +"\r\n" + "PRIMARY DRIVE: 40:76"
                                +"\r\n" + "SECONDARY GEAR RATIO: 17:38"
                                +"\r\n" + "COOLING: Liquid cooled"
                                +"\r\n" + "CLUTCH: PASC (TM) slipper clutch, hydraulically actuated"
                                +"\r\n" + "EMS: Keihin EMS with RBW and cruise control, double ignition",
                           Category = context.Categories.FirstOrDefault(g => g.Name == "Naked"),
                           ImageUrls = new[] {
                                 new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvZ1JPa21TeTZ1NFU" },
                                  new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvWHRKRlBVdnpMMWs" }
                             },
                           Author = admin
                       },



                             //Travel
                             new Motorcycle()
                             {
                                 Title = "1290 SUPER ADVENTURE T",
                                 Description = @"The KTM 1290 SUPER ADVENTURE T is ready to travel to the top of the food chain, matching its need for speed with your lust for life. This extremely well-equipped 1,301cc powerhouse goes from cruising with a passenger to racing a local at the flick of your wrist. And without breaking a sweat, thanks to KTM’s advanced electronics that help you outrun and outsmart tricky conditions. It has never been more comfortable to leave your comfort zone. So go, chase the horizon. You might even catch it",
                                 Engine = @"DESIGN: 2-cylinder, 4-stroke, V 75°"
                                    +"\r\n" + "DISPLACEMENT: 1301 cm³"
                                    +"\r\n" + "BORE: 108 mm"
                                    +"\r\n" + "STROKE: 71 mm"
                                    +"\r\n" + "POWER IN KW: 118 kW"
                                    +"\r\n" + "STARTER: Electric starter"
                                    +"\r\n" + "LUBRICATION: Forced oil lubrication with 3 oil pumps"
                                    +"\r\n" + "TRANSMISSION: 6-speed"
                                    +"\r\n" + "PRIMARY DRIVE: 40:76"
                                    +"\r\n" + "COOLING: Liquid cooled"
                                    +"\r\n" + "CLUTCH: PASC (TM) slipper clutch, hydraulically actuated"
                                    +"\r\n" + "EMS: Keihin EMS with RBW and cruise control, double ignition",
                                 Category = context.Categories.FirstOrDefault(g => g.Name == "Travel"),
                                 ImageUrls = new[] {
                                 new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvRGQwUzhhWWM2Rjg" }
                             },
                                 Author = admin
                             },


                           new Motorcycle()
                           {
                               Title = "1290 SUPER ADVENTURE S",
                               Description = @"Whack the throttle wide open in the middle of a nasty corner. Brake hard while fully leant over. No harm is done - just grin and rocket on. Even when you’re bending the laws of physics, KTM’s combination of 160 hp, 140 Nm of torque and a mere 238 kg is kept in check by the most advanced electronics in the world of motorcycling. All you have to do is focus on the road ahead - and hold on tight. But the KTM 1290 SUPER ADVENTURE S offers buttery smooth cruising as well, if that’s what you really want… ",
                               Engine = @"DESIGN: 2-cylinder, 4-stroke, V 75°"
                                    +"\r\n" + "DISPLACEMENT: 1301 cm³"
                                    +"\r\n" + "BORE: 108 mm"
                                    +"\r\n" + "STROKE: 71 mm"
                                    +"\r\n" + "POWER IN KW: 118 kW"
                                    +"\r\n" + "STARTER: Electric starter"
                                    +"\r\n" + "LUBRICATION: Forced oil lubrication with 3 oil pumps"
                                    +"\r\n" + "TRANSMISSION: 6-speed"
                                    +"\r\n" + "PRIMARY DRIVE: 40:76"
                                    +"\r\n" + "SECONDARY GEAR RATIO: 17:42"
                                    +"\r\n" + "COOLING: Liquid cooled"
                                    +"\r\n" + "CLUTCH: PASC (TM) slipper clutch, hydraulically actuated"
                                    +"\r\n" + "EMS: Keihin EMS with RBW and cruise control, double ignition",
                               Category = context.Categories.FirstOrDefault(g => g.Name == "Travel"),
                               ImageUrls = new[] {
                                 new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvNXpkaFRqdUtRSjA" },
                                  new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvSjg1VFZ4VEFMdGc" },
                                   new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvV0RTSFQ5cnRnTG8" }
                             },
                               Author = admin
                           },

                          new Motorcycle()
                          {
                              Title = "1090 ADVENTURE",
                              Description = @"Those who want to travel far and fast, don’t need a lot. Just the best. So we built the KTM 1090 ADVENTURE to be light on its feet, yet adequately equipped and easier to ride than ever. Easy on your wallet too. Nevertheless, multi-mode traction control and ABS come as standard and the engine is built using the same state-of-the art technology as the KTM 1290 SUPER ADVENTURE models. Even though this V-twin is a little smaller, it still delivers 125 hp (92 kW). And you can order a 35 kW-version that is A2 license compatible, which makes entry into the world of adventure travel smooth as a silk road. The featherweight chassis and well-balanced suspension team up with prize-winning Metzeler Tourance Next tires to take you wherever you dare, whenever you want. All fun, no bulk – this bike is made to load up on adrenaline instead.",
                              Engine = @"DESIGN: 2-cylinder, 4-stroke, V 75°"
                                    +"\r\n" + "DISPLACEMENT: 1050 cm³"
                                    +"\r\n" + "BORE: 103 mm"
                                    +"\r\n" + "STROKE: 63 mm"
                                    +"\r\n" + "POWER IN KW: 92 kW"
                                    +"\r\n" + "STARTER: Electric starter"
                                    +"\r\n" + "LUBRICATION: Forced oil lubrication with 3 oil pumps"
                                    +"\r\n" + "TRANSMISSION: 6-speed"
                                    +"\r\n" + "PRIMARY DRIVE: 40:76"
                                    +"\r\n" + "SECONDARY GEAR RATIO: 17:42"
                                    +"\r\n" + "COOLING: Liquid cooled"
                                    +"\r\n" + "CLUTCH: PASC (TM) slipper clutch, hydraulically actuated"
                                    + "\r\n" + "Keihin EMS with RBW, twin ignition",
                              Category = context.Categories.FirstOrDefault(g => g.Name == "Travel"),
                              ImageUrls = new[] {
                                 new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvUHpBUUNuZ1gtN3c" },
                                  new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvZnNZX1ppMjBPRjA" },
                                   new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvZGRvR19fQ3hnVWM" }
                             },
                              Author = admin
                          },

                            new Motorcycle()
                            {
                                Title = "1090 ADVENTURE R",
                                Description = @"The KTM 1090 ADVENTURE R stares down anything in its path. Bespoke WP suspension, offroad wheels and a tough yet fuel-efficient engine are ready to rumble. Decades of rally raid victories roar within. As shrewd as it is chiseled, this bike uses the same state-of-the-art technology as the KTM 1290 ADVENTURE R and even though its engine capacity is smaller, it’s still big on power: 125 hp (92 kW). That’s 23 more than Fabrizio Meoni’s Dakar winning 950. The world is yours - Devour it.",
                                Engine = @"DESIGN: 2-cylinder, 4-stroke, V 75°"
                                    +"\r\n" + "DISPLACEMENT: 1050 cm³"
                                    +"\r\n" + "BORE: 103 mm"
                                    +"\r\n" + "STROKE: 63 mm"
                                    +"\r\n" + "POWER IN KW: 92 kW"
                                    +"\r\n" + "STARTER: Electric starter"
                                    +"\r\n" + "LUBRICATION: Forced oil lubrication with 3 oil pumps"
                                    +"\r\n" + "TRANSMISSION: 6-speed"
                                    +"\r\n" + "PRIMARY DRIVE: 40:76"
                                    +"\r\n" + "SECONDARY GEAR RATIO: 17:42"
                                    +"\r\n" + "COOLING: Liquid cooled"
                                    +"\r\n" + "CLUTCH: PASC (TM) slipper clutch, hydraulically actuated"
                                    + "\r\n" + "EMS: Keihin EMS with RBW, twin ignition",
                                Category = context.Categories.FirstOrDefault(g => g.Name == "Travel"),
                                ImageUrls = new[] {
                                 new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvQkVCQTZWQndWRWM" },
                                  new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-Kvb1BGNEpvSnM2RzA" }
                             },
                                Author = admin
                            },


                          //Supermoto
                          new Motorcycle()
                          {
                              Title = "690 SMC R",
                              Description = @"What isn't there, doesn't weigh anything either - the 690 SMC R is designed according to this motto. It arrives at the starting line in peak condition with twin plug ignition, ride-by-wire, new ABS and a revamped chassis. Powerful, sports-oriented, yet still very comfortable – what could make a drifter happier? The KTM 690 SMC R: the unrivalled Supermoto for the most demanding requirements, which leaves all others in its wake: suitable for racing or everyday use, potent design, state-of-the-art.",
                              Engine = @"DESIGN: 1-cylinder, 4-stroke engine"
                                  +"\r\n" + "DISPLACEMENT: 690 cm³"
                                  +"\r\n" + "BORE: 102 mm"
                                  +"\r\n" + "STROKE: 84.5 mm"
                                  +"\r\n" + "POWER IN KW: 49 kW"
                                  +"\r\n" + "STARTER: Electric starter"
                                  +"\r\n" + "LUBRICATION: Forced oil lubrication with 2 oil pumps"
                                  +"\r\n" + "TRANSMISSION: 6-speed"
                                  +"\r\n" + "PRIMARY DRIVE: 36:79"
                                  +"\r\n" + "SECONDARY GEAR RATIO: 16:42"
                                  +"\r\n" + "COOLING: Liquid cooled"
                                  +"\r\n" + "CLUTCH: APTC(TM) slipper clutch, hydraulically actuated"
                                  + "\r\n" + "EMS: Keihin EMS with RBW, twin ignition",
                              Category = context.Categories.FirstOrDefault(g => g.Name == "Supermoto"),
                              ImageUrls = new[] {
                                 new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvYTRoLW9MUXB3XzA" }
                             },
                              Author = admin
                          },

                      //Enduro
                      new Motorcycle()
                      {
                          Title = "690 ENDURO R",
                          Description = @"Powerful engine, cool look, fantastic chassis set-up and optimum ergonomics - the KTM 690 Enduro R unites outstanding offroad qualities with unbeatable all-round ability - plus a shape radically optimized. It feels just as at home in the city and on rural roads as it does on gravel and tough terrain. The even more advanced single-cylinder combines the classic Enduro concept with state-of-the-art technology and sporty all-round ability with suitability for everyday use. Perfect workmanship and impressive details reflect the typical KTM philosophy.",
                          Engine = @"ENGINE DESIGN: 1-cylinder, 4-stroke engine"
                                  +"\r\n" + "DISPLACEMENT: 690 cm³"
                                  +"\r\n" + "BORE: 102 mm"
                                  +"\r\n" + "STROKE: 84.5 mm"
                                  +"\r\n" + "STARTER: Electric starter"
                                  +"\r\n" + "TRANSMISSION: 6-speed"
                                  +"\r\n" + "PRIMARY DRIVE: 36:79"
                                  +"\r\n" + "SECONDARY GEAR RATIO: 15:45"
                                  +"\r\n" + "CLUTCH: APTC(TM) slipper clutch, hydraulically actuated"
                                  + "\r\n" + "EMS: Keihin EMS with RBW, twin ignition",
                          Category = context.Categories.FirstOrDefault(g => g.Name == "Enduro"),
                          ImageUrls = new[] {
                                 new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-Kva0g1TUNNV21GX0U" }
                             },
                          Author = admin
                      },

                            new Motorcycle()
                            {
                                Title = "450 EXC-F",
                                Description = @"Looking to up your Enduro game? Look no further. Thanks to its all-new, much more compact SOHC engine fitted in a redesigned chassis, the 450 EXC-F is the strongest, most competitive bike in the E2 class. Combined with a low weight and off-the-shelve 4-stroke ferocity, this pioneer will boldly take you where no rider has gone before. Or at least never faster.",
                                Engine = @"DESIGN: 1-cylinder, 4-stroke engine"
                                     +"\r\n" + "DISPLACEMENT: 449.3 cm³"
                                     +"\r\n" + "BORE: 95 mm"
                                     +"\r\n" + "STROKE: 63.4 mm"
                                     +"\r\n" + "STARTER: Electric starter"
                                     +"\r\n" + "TRANSMISSION: 6-speed"
                                     +"\r\n" + "PRIMARY DRIVE: 31:76"
                                     +"\r\n" + "SECONDARY GEAR RATIO: 14:52"
                                     +"\r\n" + "CLUTCH: Wet, DDS multi-disc clutch, Brembo hydraulics"
                                     + "\r\n" + "EMS: Keihin EMS",
                                Category = context.Categories.FirstOrDefault(g => g.Name == "Enduro"),
                                ImageUrls = new[] {
                                 new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-Kvc3IzVEEyNUtKQTg" },
                                  new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvR0QzeEZvNk4zYUk" },
                                   new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvVGdXV0lFcHRzYms" }
                             },
                                Author = admin
                            },

                              new Motorcycle()
                              {
                                  Title = "150 XC-W",
                                  Description = @"‘XC’ means cross-country. ‘W’ represents its wide-ratio transmission. ‘KTM’ stands for winning. This model is a race-ready bike built for closed course Enduro rides or races that don’t require a homologated motorcycle. And for riders who don’t want to drag around the extra weight that comes with homologation requirements. With the agility of a 125 and enough muscle to take the fight to the 250 cm³ 4-strokes, this bike punches well above its weight. That’s why when the going gets tough, the tough get an XC-W.",
                                  Engine = @"DESIGN: 1-cylinder, 2-stroke engine"
                                      +"\r\n" + "DISPLACEMENT: 143.99 cm³"
                                      +"\r\n" + "BORE: 58 mm"
                                      +"\r\n" + "STROKE: 54.4 mm"
                                      +"\r\n" + "STARTER: Kick and electric starter"
                                      +"\r\n" + "TRANSMISSION: 6-speed"
                                      +"\r\n" + "PRIMARY DRIVE: 23:73"
                                      +"\r\n" + "SECONDARY GEAR RATIO: 13:50"
                                      +"\r\n" + "CLUTCH: wet multi-disc clutch, Brembo hydraulics"
                                      + "\r\n" + "EMS: Kokusan",
                                  Category = context.Categories.FirstOrDefault(g => g.Name == "Enduro"),
                                  ImageUrls = new[] {
                                 new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvTFpQYmowdy1FaDA" }
                             },
                                  Author = admin
                              },

                               new Motorcycle()
                               {
                                   Title = "500 EXC-F",
                                   Description = @"The 500 EXC-F is the strongest Enduro bike in the world, although that doesn’t mean it’s a bully. This motorcycle is as lean and civilized as a thoroughbred racehorse. But let it rip, and its all-new 4-stroke SOHC engine flings the redesigned chassis across all sorts of terrain. Probably ahead of the competition. No sweat, just glory.",
                                   Engine = @"DESIGN: 1-cylinder, 4-stroke engine"
                                      +"\r\n" + "DISPLACEMENT: 510.4 cm³"
                                      +"\r\n" + "BORE: 95 mm"
                                      +"\r\n" + "STROKE: 72 mm"
                                      +"\r\n" + "STARTER: Electric starter"
                                      +"\r\n" + "TRANSMISSION: 6-speed"
                                      +"\r\n" + "PRIMARY DRIVE: 31:76"
                                      +"\r\n" + "SECONDARY GEAR RATIO: 14:50"
                                      +"\r\n" + "CLUTCH: Wet, DDS multi-disc clutch, Brembo hydraulics"
                                      + "\r\n" + "EMS: Keihin EMS",
                                   Category = context.Categories.FirstOrDefault(g => g.Name == "Enduro"),
                                   ImageUrls = new[] {
                                 new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvQ09TOUFmLVhoSjA" },
                                  new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvQ254NnhaS055UW8" },
                                   new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-Kvam1JX3pTcVU0LVk" }
                             },
                                   Author = admin
                              },
                                      //Freeride
                                      new Motorcycle()
                                      {
                                          Title = "FREERIDE 350",
                                          Description = @"Freedom has a name: on the FREERIDE 350, only the rider determines the route. Since it is on the market, it impressed everyone who had always wanted to ride offroad ""for the heck of it"", without any pressure to perform. For the upcoming model year, KTM is focussing clearly with its further refinement of the FREERIDE 350 on increased all-round potential and enhanced suitability for everyday use. For example, an extended top gear and a longer final transmission ratio lower the revs and reduce fuel consumption along highway sections, while the shortened five lower gears as ever guarantee optimum power delivery offroad. Numerous optimized details further improve the durability and reliability of the new FREERIDE 350 and contribute to reducing its already extraordinarily low weight even further.",
                                          Engine = @"DESIGN: 1-cylinder, 4-stroke engine"
                                            + "\r\n" +"DISPLACEMENT: 349.7 cm³"
                                            + "\r\n" +"BORE: 88 mm"
                                            + "\r\n" +"STROKE: 57.5 mm"
                                            + "\r\n" +"STARTER: Electric starter"
                                            + "\r\n" +"TRANSMISSION: 6-speed"
                                            + "\r\n" +"PRIMARY DRIVE: 24:73"
                                            + "\r\n" +"SECONDARY GEAR RATIO: 12:48"
                                            + "\r\n" +"CLUTCH: Wet, multi-disc clutch, Formula hydraulics"
                                            + "\r\n" + "EMS: Keihin EMS",
                                          Category = context.Categories.FirstOrDefault(g => g.Name == "Freeride"),
                                          ImageUrls = new[] {
                                 new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvclNXTW1KVUE3UFE" },
                                  new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvaFdVZGpfTjVVTmM" }
                             },
                                          Author = admin
                                      },
                                      new Motorcycle()
                                      {
                                          Title = "FREERIDE 250 R",
                                          Description = @"All those who have never had the opportunity to enjoy the punch of a powerful two-stroke in a lightweight, agile offroad chassis are in for a surprise with the Freeride 250 R. However, those who have already had this pleasure know: The power of such an engine develops completely differently, the expanding combustion gases effectively pressing down twice as often on the crankshaft as a four-stroke. Consequently, KTM two-stroke enduros, which are designed more for high peak power, still pull away forcefully from the very bottom up and that's a real pleasure. And since the engine on the FREERIDE 250 R is tuned completely in keeping with the Freeride notion - not for maximum power but for harmonious torque progression and optimum rideability - this motorcycle is an all-rounder that feels all the more at home, the tougher the terrain becomes.",
                                          Engine = @"DESIGN: 1-cylinder, 2-stroke engine"+"\r\n"+
                                          "DISPLACEMENT: 249 cm³"+"\r\n"+
                                          "BORE: 66.4 mm" + "\r\n" +
                                          "STROKE: 72 mm" + "\r\n" +
                                          "STARTER: Electric starter" + "\r\n" +
                                          "TRANSMISSION: 6-speed" + "\r\n" +
                                          "PRIMARY DRIVE: 26:72" + "\r\n" +
                                          "SECONDARY GEAR RATIO: 14:46" + "\r\n" +
                                          "CLUTCH: Wet, CSS multi-disc clutch, Formula hydraulics" + "\r\n" +
                                          "EMS: Kokusan",
                                          Category = context.Categories.FirstOrDefault(g => g.Name == "Freeride"),
                                          ImageUrls = new[] {
                                 new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvcUhKSWZRMjl2bG8" },
                                  new ImageUrl() { Url = "https://drive.google.com/uc?id=0ByuTp8DIw-KvNXJteGZMN2s5bGc" }
                             },
                                          Author = admin
                                      });

                context.SaveChanges();
            }
        }

        private void SeedRatings(KTMContext context)
        {
            if (!context.Ratings.Any())
            {
                context.Ratings.AddOrUpdate(
                  new Rating()
                  {
                      Author = context.Users.FirstOrDefault(u => u.UserName == "pesho"),
                      Value = 2,
                      Motorcycle = context.Motorcycles.FirstOrDefault(g => g.Title == "690 ENDURO R")
                  },
                    new Rating()
                    {
                        Author = context.Users.FirstOrDefault(u => u.UserName == "gosho"),
                        Value = 5,
                        Motorcycle = context.Motorcycles.FirstOrDefault(g => g.Title == "690 ENDURO R")
                    },
                    new Rating()
                    {
                        Author = context.Users.FirstOrDefault(u => u.UserName == "pesho"),
                        Value = 4,
                        Motorcycle = context.Motorcycles.FirstOrDefault(g => g.Title == "690 ENDURO R")
                    },
                    new Rating()
                    {
                        Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                        Value = 5,
                        Motorcycle = context.Motorcycles.FirstOrDefault(g => g.Title == "690 ENDURO R")
                    });

                context.SaveChanges();
            }
        }

        private void SeedReviews(KTMContext context)
        {
            if (!context.Reviews.Any())
            {
                context.Reviews.AddOrUpdate(
                    new Review()
                    {
                        Author = context.Users.FirstOrDefault(u => u.UserName == "pesho"),
                        CreationTime = new DateTime(2015, 1, 21),
                        Content = "i recommend this game",
                        Motorcycle = context.Motorcycles.FirstOrDefault(g => g.Title == "690 ENDURO R")
                    },
                    new Review()
                    {
                        Author = context.Users.FirstOrDefault(u => u.UserName == "gosho"),
                        CreationTime = new DateTime(2014, 3, 12),
                        Content = "The good CS with a lot of new benefits and bonuses",
                        Motorcycle = context.Motorcycles.FirstOrDefault(g => g.Title == "690 ENDURO R")
                    },
                    new Review()
                    {
                        Author = context.Users.FirstOrDefault(u => u.UserName == "pesho"),
                        CreationTime = new DateTime(2014, 10, 10),
                        Content = "It's like Dota 2 but with less wizards and more Russians.",
                        Motorcycle = context.Motorcycles.FirstOrDefault(g => g.Title == "690 ENDURO R")
                    });
                context.SaveChanges();
            }
        }
    }
}