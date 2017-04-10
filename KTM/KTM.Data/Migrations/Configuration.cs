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
                            Engine = @"DESIGN
1-cylinder, 4-stroke engine
DISPLACEMENT
124.7 cm³
BORE
58 mm
STROKE
47.2 mm
POWER IN KW
11 kW
STARTER
Electric starter
LUBRICATION
Wet sump
TRANSMISSION
6-speed
PRIMARY DRIVE
22:72
SECONDARY GEAR RATIO
14:45
COOLING
Liquid cooled
CLUTCH
Wet multi-disc clutch, mechanically actuated
EMS
Bosch EMS",
                            Category = context.Categories.FirstOrDefault(g => g.Name == "Supersport"),
                            ImageUrls = new[] { new ImageUrl() { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/supersport/rc-1251/rc-125-2017/f5003q1/pho_bike_90_re.png" }
                        },
                            Author = admin
                        },
                         new Motorcycle()
                         {
                             Title = "RC 200",
                             Description = @"RC 200 is the first step into KTM´s Ready to Race philosophy. The premium full faired bike is an eye-catcher for its outstanding style. The 200cc engine is combining top performance together with efficient mileage. Premium components such as USD front fork, multifunctional fully digital display and radial brake caliper are completing the package and making RC 200 an excellent value for money full faired motorcycle.",
                             Engine = @"DESIGN
1-cylinder, 4-stroke engine
DISPLACEMENT
199.5 cm³
BORE
72 mm
STROKE
49 mm
POWER IN KW
19 kW
STARTER
Electric starter
LUBRICATION
Wet sump
TRANSMISSION
6-speed
PRIMARY DRIVE
22:72
SECONDARY GEAR RATIO
14:42
COOLING
Liquid cooled
CLUTCH
Wet multi-disc clutch, mechanically actuated
EMS
Bosch EMS",
                             Category = context.Categories.FirstOrDefault(g => g.Name == "Supersport"),
                             ImageUrls = new[] { new ImageUrl() { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/supersport/rc-2001/rc-200-2017/f5103q1/pho_bike_90_re.png" }
                        },
                             Author = admin
                         },

                          new Motorcycle()
                          {
                              Title = "RC 390",
                              Description = @"A sports bike in its purest form. Reduced to the essentials. Agile, fast, suitable for A2 driving license and extremely sporty. Whether you are on country roads or the racetrack, the Moto3 genes are perceptible in every manoeuvre and convey pure race feeling. The handling – simply spectacular. The performance – incredible. The power – awesome.",
                              Engine = @"DESIGN
1-cylinder, 4-stroke engine
DISPLACEMENT
373.2 cm³
BORE
89 mm
STROKE
60 mm
POWER IN KW
32 kW
STARTER
Electric starter
LUBRICATION
Semi-dry sump
TRANSMISSION
6-speed
PRIMARY DRIVE
30:80
SECONDARY GEAR RATIO
15:45
COOLING
Liquid cooled
CLUTCH
PASC™ antihopping clutch, mechanically operated
EMS
Bosch EMS with RBW",
                              Category = context.Categories.FirstOrDefault(g => g.Name == "Supersport"),
                              ImageUrls = new[] { new ImageUrl() { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/supersport/rc-3902/rc-390-2017/f5303q1/pho_bike_90_re.png" }
                        },
                              Author = admin
                          },



                     //Naked
                     new Motorcycle()
                     {
                         Title = "125 DUKE",
                         Description = @"The 125 DUKE is not a toy. It’s a genuine motorcycle, up there with the best in its class and better equipped than some of the big bikes. Back in 2013 it was the first 125 to receive ABS as standard, now it’s at that forefront again with an LED headlight, a TFT display and optional integrated connectivity. On top of that, the refined 4-stroke single cylinder with fuel injection system and 6-speed transmission combines class-leading performance with limited thirst  – except for adventures. There’s no better place to start.",
                         Engine = @"DESIGN
1-cylinder, 4-stroke engine
DISPLACEMENT
124.7 cm³
BORE
58 mm
STROKE
47.2 mm
POWER IN KW
11 kW
STARTER
Electric starter
LUBRICATION
Wet sump
TRANSMISSION
6-speed
PRIMARY DRIVE
22:72
SECONDARY GEAR RATIO
14:45
COOLING
Liquid cooled
CLUTCH
Wet multi-disc clutch, mechanically actuated
EMS
Bosch EMS",
                         Category = context.Categories.FirstOrDefault(g => g.Name == "Naked"),
                         ImageUrls = new[] { new ImageUrl() { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/naked-bike/125-duke2/125-duke-2017/f4003q1/pho_bike_90_re.png" }
                        },
                         Author = admin
                     },

                    new Motorcycle()
                    {
                        Title = "690 DUKE R",
                        Description = @"The standard 690 Duke is a firecracker of a bike, light as a feather and lightning quick. But we wouldn’t be true to ourselves if we didn’t try to push things just a little bit further. So we did, creating the ultimate single-cylinder street bike on the face of the planet. Really, it’s that spectacul’R.",
                        Engine = @"DESIGN
1-cylinder, 4-stroke engine
DISPLACEMENT
690 cm³
BORE
102 mm
STROKE
84.5 mm
POWER IN KW
55 kW
STARTER
Electric starter
LUBRICATION
Forced oil lubrication with 2 oil pumps
TRANSMISSION
6-speed
PRIMARY DRIVE
36:79
SECONDARY GEAR RATIO
16:40
COOLING
Liquid cooled
CLUTCH
APTC(TM) slipper clutch, hydraulically actuated
EMS
Keihin EMS with RBW, twin ignition",
                        Category = context.Categories.FirstOrDefault(g => g.Name == "Naked"),
                        ImageUrls = new[] { new ImageUrl() { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/naked-bike/690-duke-r2/690-duke-r-2017/f9703q1/pho_bike_90_re.png" }
                        },
                        Author = admin
                    },
                       new Motorcycle()
                       {
                           Title = "690 DUKE",
                           Description = @"Two decades ago, the original Duke was nothing short of revolutionary. KTM’s first single-cylinder street bike grew into a cult classic, adding extreme fun to a raw and radical concept. In 2017, the fully revised 690 DUKE stays faithful to its ancestor’s ways, but adds future-proof refinements: impressive smoothness, sophisticated electronics, improved ergonomics and a good old power boost over last year’s model. This firmly cements the world’s strongest single-cylinder production motorcycle at the cutting edge of engineering. Speaking of which: carving corners has never been more fun, thanks to its revised fork offset. Long live the Duke!",
                           Engine = @"DESIGN
1-cylinder, 4-stroke engine
DISPLACEMENT
690 cm³
BORE
102 mm
STROKE
84.5 mm
POWER IN KW
54 kW
STARTER
Electric starter
LUBRICATION
Forced oil lubrication with 2 oil pumps
TRANSMISSION
6-speed
PRIMARY DRIVE
36:79
SECONDARY GEAR RATIO
16:40
COOLING
Liquid cooled
CLUTCH
APTC(TM) slipper clutch, hydraulically actuated
EMS
Keihin EMS with RBW, twin ignition",
                           Category = context.Categories.FirstOrDefault(g => g.Name == "Naked"),
                           ImageUrls = new[] { new ImageUrl() { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/naked-bike/690-duke2/690-duke-2017/f9703q3/pho_bike_90_re.png" }
                        },
                           Author = admin
                       },

                       new Motorcycle()
                       {
                           Title = "1290 SUPER DUKE R",
                           Description = @"This is our punk record - pure, raw and straight to the point: speed. Its V-twin, the most powerful one we ever muscled into a street bike, beats the battle drums at 177 hp, while its purebred chassis is set to stay ahead when the straight is devoured. When corners become prey. Even on a bad day, thanks to state-of-the-art rider assistance systems. No, scratch that. Grin amplifiers.",
                           Engine = @"DESIGN
2-cylinder, 4-stroke, V 75°
DISPLACEMENT
1301 cm³
BORE
108 mm
STROKE
71 mm
POWER IN KW
130 kW
STARTER
Electric starter
LUBRICATION
Forced oil lubrication with 3 oil pumps
TRANSMISSION
6-speed
PRIMARY DRIVE
40:76
SECONDARY GEAR RATIO
17:38
COOLING
Liquid cooled
CLUTCH
PASC (TM) slipper clutch, hydraulically actuated
EMS
Keihin EMS with RBW and cruise control, double ignition",
                           Category = context.Categories.FirstOrDefault(g => g.Name == "Naked"),
                           ImageUrls = new[] { new ImageUrl() { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/naked-bike/1290-super-duke-r2/1290-super-duke-r-2017/f9903q2/pho_bike_90_re.png" }
                        },
                           Author = admin
                       },



                             //Travel
                             new Motorcycle()
                             {
                                 Title = "1290 SUPER ADVENTURE T",
                                 Description = @"The KTM 1290 SUPER ADVENTURE T is ready to travel to the top of the food chain, matching its need for speed with your lust for life. This extremely well-equipped 1,301cc powerhouse goes from cruising with a passenger to racing a local at the flick of your wrist. And without breaking a sweat, thanks to KTM’s advanced electronics that help you outrun and outsmart tricky conditions. It has never been more comfortable to leave your comfort zone. So go, chase the horizon. You might even catch it",
                                 Engine = @"DESIGN:2-cylinder, 4-stroke, V 75°
DISPLACEMENT:
1301 cm³
BORE:
108 mm
STROKE:
71 mm
POWER IN KW:
118 kW
STARTER:
Electric starter
LUBRICATION:
Forced oil lubrication with 3 oil pumps
TRANSMISSION:
6-speed
PRIMARY DRIVE:
40:76
COOLING:
Liquid cooled
CLUTCH:
PASC (TM) slipper clutch, hydraulically actuated
EMS:
Keihin EMS with RBW and cruise control, double ignition",
                                 Category = context.Categories.FirstOrDefault(g => g.Name == "Travel"),
                                 ImageUrls = new[] { new ImageUrl() { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/travel/1290-super-adventure-t/1290-super-adventure-t-2017/f9903qa/pho_bike_90_re.png" }
                        },
                                 Author = admin
                             },


                           new Motorcycle()
                           {
                               Title = "1290 SUPER ADVENTURE S",
                               Description = @"Whack the throttle wide open in the middle of a nasty corner. Brake hard while fully leant over. No harm is done - just grin and rocket on. Even when you’re bending the laws of physics, KTM’s combination of 160 hp, 140 Nm of torque and a mere 238 kg is kept in check by the most advanced electronics in the world of motorcycling. All you have to do is focus on the road ahead - and hold on tight. But the KTM 1290 SUPER ADVENTURE S offers buttery smooth cruising as well, if that’s what you really want… ",
                               Engine = @"DESIGN
2-cylinder, 4-stroke, V 75°
DISPLACEMENT
1301 cm³
BORE
108 mm
STROKE
71 mm
POWER IN KW
118 kW
STARTER
Electric starter
LUBRICATION
Forced oil lubrication with 3 oil pumps
TRANSMISSION
6-speed
PRIMARY DRIVE
40:76
SECONDARY GEAR RATIO
17:42
COOLING
Liquid cooled
CLUTCH
PASC (TM) slipper clutch, hydraulically actuated
EMS
Keihin EMS with RBW and cruise control, double ignition",
                               Category = context.Categories.FirstOrDefault(g => g.Name == "Travel"),
                               ImageUrls = new[] { new ImageUrl() { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/travel/1090-adventure/1090-adventure-2017/f9903qc/pho_bike_90_re.png" }
                        },
                               Author = admin
                           },

                          new Motorcycle()
                          {
                              Title = "1090 ADVENTURE",
                              Description = @"Those who want to travel far and fast, don’t need a lot. Just the best. So we built the KTM 1090 ADVENTURE to be light on its feet, yet adequately equipped and easier to ride than ever. Easy on your wallet too. Nevertheless, multi-mode traction control and ABS come as standard and the engine is built using the same state-of-the art technology as the KTM 1290 SUPER ADVENTURE models. Even though this V-twin is a little smaller, it still delivers 125 hp (92 kW). And you can order a 35 kW-version that is A2 license compatible, which makes entry into the world of adventure travel smooth as a silk road. The featherweight chassis and well-balanced suspension team up with prize-winning Metzeler Tourance Next tires to take you wherever you dare, whenever you want. All fun, no bulk – this bike is made to load up on adrenaline instead.",
                              Engine = @"DESIGN
2-cylinder, 4-stroke, V 75°
DISPLACEMENT
1050 cm³
BORE
103 mm
STROKE
63 mm
POWER IN KW
92 kW
STARTER
Electric starter
LUBRICATION
Forced oil lubrication with 3 oil pumps
TRANSMISSION
6-speed
PRIMARY DRIVE
40:76
SECONDARY GEAR RATIO
17:42
COOLING
Liquid cooled
CLUTCH
PASC (TM) slipper clutch, hydraulically actuated
EMS
Keihin EMS with RBW, twin ignition",
                              Category = context.Categories.FirstOrDefault(g => g.Name == "Travel"),
                              ImageUrls = new[] { new ImageUrl() { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/travel/1090-adventure/1090-adventure-2017/f9903qc/pho_bike_90_re.png" }
                        },
                              Author = admin
                          },

                            new Motorcycle()
                            {
                                Title = "1090 ADVENTURE R",
                                Description = @"The KTM 1090 ADVENTURE R stares down anything in its path. Bespoke WP suspension, offroad wheels and a tough yet fuel-efficient engine are ready to rumble. Decades of rally raid victories roar within. As shrewd as it is chiseled, this bike uses the same state-of-the-art technology as the KTM 1290 ADVENTURE R and even though its engine capacity is smaller, it’s still big on power: 125 hp (92 kW). That’s 23 more than Fabrizio Meoni’s Dakar winning 950. The world is yours - Devour it.",
                                Engine = @"DESIGN
2-cylinder, 4-stroke, V 75°
DISPLACEMENT
1050 cm³
BORE
103 mm
STROKE
63 mm
POWER IN KW
92 kW
STARTER
Electric starter
LUBRICATION
Forced oil lubrication with 3 oil pumps
TRANSMISSION
6-speed
PRIMARY DRIVE
40:76
SECONDARY GEAR RATIO
17:42
COOLING
Liquid cooled
CLUTCH
PASC (TM) slipper clutch, hydraulically actuated
EMS
Keihin EMS with RBW, twin ignition",
                                Category = context.Categories.FirstOrDefault(g => g.Name == "Travel"),
                                ImageUrls = new[] { new ImageUrl() { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/travel/1090-adventure-r/1090-adventure-r-2017/f9903qd/pho_bike_90_re.png" }
                        },
                                Author = admin
                            },


                          //Supermoto
                          new Motorcycle()
                          {
                              Title = "690 SMC R",
                              Description = @"What isn't there, doesn't weigh anything either - the 690 SMC R is designed according to this motto. It arrives at the starting line in peak condition with twin plug ignition, ride-by-wire, new ABS and a revamped chassis. Powerful, sports-oriented, yet still very comfortable – what could make a drifter happier? The KTM 690 SMC R: the unrivalled Supermoto for the most demanding requirements, which leaves all others in its wake: suitable for racing or everyday use, potent design, state-of-the-art.",
                              Engine = @"DESIGN
1-cylinder, 4-stroke engine
DISPLACEMENT
690 cm³
BORE
102 mm
STROKE
84.5 mm
POWER IN KW
49 kW
STARTER
Electric starter
LUBRICATION
Forced oil lubrication with 2 oil pumps
TRANSMISSION
6-speed
PRIMARY DRIVE
36:79
SECONDARY GEAR RATIO
16:42
COOLING
Liquid cooled
CLUTCH
APTC(TM) slipper clutch, hydraulically actuated
EMS
Keihin EMS with RBW, twin ignition",
                              Category = context.Categories.FirstOrDefault(g => g.Name == "Supermoto"),
                              ImageUrls = new[] { new ImageUrl() { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/supermoto/690-smc-r2/690-smc-r-2017/f9703q9/pho_bike_90_re.png" }
                        },
                              Author = admin
                          },

                      //Enduro
                      new Motorcycle()
                      {
                          Title = "690 ENDURO R",
                          Description = @"Powerful engine, cool look, fantastic chassis set-up and optimum ergonomics - the KTM 690 Enduro R unites outstanding offroad qualities with unbeatable all-round ability - plus a shape radically optimized. It feels just as at home in the city and on rural roads as it does on gravel and tough terrain. The even more advanced single-cylinder combines the classic Enduro concept with state-of-the-art technology and sporty all-round ability with suitability for everyday use. Perfect workmanship and impressive details reflect the typical KTM philosophy.",
                          Engine = @"ENGINE DESIGN:
1-cylinder, 4-stroke engine\r\n
DISPLACEMENT:
690 cm³\r\n
BORE:
102 mm\r\n
STROKE:
84.5 mm\r\n
STARTER:
Electric starter\r\n
TRANSMISSION:
6-speed\r\n
PRIMARY DRIVE:
36:79\r\n
SECONDARY GEAR RATIO:
15:45\r\n
CLUTCH:
APTC(TM) slipper clutch, hydraulically actuated\r\n
EMS:
Keihin EMS with RBW, twin ignition\r\n",
                          Category = context.Categories.FirstOrDefault(g => g.Name == "Enduro"),
                          ImageUrls = new[] { new ImageUrl() { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/enduro/690-enduro-r2/690-enduro-r-2017/f9703q8/pho_bike_90_re.png" }
                        },
                          Author = admin
                      },

                            new Motorcycle()
                            {
                                Title = "450 EXC-F",
                                Description = @"Looking to up your Enduro game? Look no further. Thanks to its all-new, much more compact SOHC engine fitted in a redesigned chassis, the 450 EXC-F is the strongest, most competitive bike in the E2 class. Combined with a low weight and off-the-shelve 4-stroke ferocity, this pioneer will boldly take you where no rider has gone before. Or at least never faster.",
                                Engine = @"DESIGN
1-cylinder, 4-stroke engine
DISPLACEMENT
449.3 cm³
BORE
95 mm
STROKE
63.4 mm
STARTER
Electric starter
TRANSMISSION
6-speed
PRIMARY DRIVE
31:76
SECONDARY GEAR RATIO
14:52
CLUTCH
Wet, DDS multi-disc clutch, Brembo hydraulics
EMS
Keihin EMS",
                                Category = context.Categories.FirstOrDefault(g => g.Name == "Enduro"),
                                ImageUrls = new[] {
                                    new ImageUrl()
                                    {
                                        Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/enduro/450-exc-f/450-exc-f-2017/f8403q9/pho_bike_90_re.png"
                                    },
                                    new ImageUrl()
                                    {
                                        Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/enduro/450-exc-f/450-exc-f-2017/f8403q9/pho_bike_90_vo.png"
                                    }, 
                        },
                                Author = admin
                            },

                              new Motorcycle()
                              {
                                  Title = "150 XC-W",
                                  Description = @"‘XC’ means cross-country. ‘W’ represents its wide-ratio transmission. ‘KTM’ stands for winning. This model is a race-ready bike built for closed course Enduro rides or races that don’t require a homologated motorcycle. And for riders who don’t want to drag around the extra weight that comes with homologation requirements. With the agility of a 125 and enough muscle to take the fight to the 250 cm³ 4-strokes, this bike punches well above its weight. That’s why when the going gets tough, the tough get an XC-W.",
                                  Engine = @"DESIGN
1-cylinder, 2-stroke engine
DISPLACEMENT
143.99 cm³
BORE
58 mm
STROKE
54.4 mm
STARTER
Kick and electric starter
TRANSMISSION
6-speed
PRIMARY DRIVE
23:73
SECONDARY GEAR RATIO
13:50
CLUTCH
wet multi-disc clutch, Brembo hydraulics
EMS
Kokusan",
                                  Category = context.Categories.FirstOrDefault(g => g.Name == "Enduro"),
                                  ImageUrls = new[] { new ImageUrl() { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/enduro/150-xc-w/150-xc-w-2017/f7101q3/pho_bike_90_re.png" }
                        },
                                  Author = admin
                              },

                               new Motorcycle()
                               {
                                   Title = "500 EXC-F",
                                   Description = @"The 500 EXC-F is the strongest Enduro bike in the world, although that doesn’t mean it’s a bully. This motorcycle is as lean and civilized as a thoroughbred racehorse. But let it rip, and its all-new 4-stroke SOHC engine flings the redesigned chassis across all sorts of terrain. Probably ahead of the competition. No sweat, just glory.",
                                   Engine = @"DESIGN
1-cylinder, 4-stroke engine
DISPLACEMENT
510.4 cm³
BORE
95 mm
STROKE
72 mm
STARTER
Electric starter
TRANSMISSION
6-speed
PRIMARY DRIVE
31:76
SECONDARY GEAR RATIO
14:50
CLUTCH
Wet, DDS multi-disc clutch, Brembo hydraulics
EMS
Keihin EMS",
                                   Category = context.Categories.FirstOrDefault(g => g.Name == "Enduro"),
                                   ImageUrls = new[] { new ImageUrl() { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/enduro/500-exc-f/500-exc-f-2017/f8503q9/pho_bike_90_re.png" }
                        },
                                   Author = admin
                               },
                                      //Freeride
                                      new Motorcycle()
                                      {
                                          Title = "FREERIDE 350",
                                          Description = @"Freedom has a name: on the FREERIDE 350, only the rider determines the route. Since it is on the market, it impressed everyone who had always wanted to ride offroad ""for the heck of it"", without any pressure to perform. For the upcoming model year, KTM is focussing clearly with its further refinement of the FREERIDE 350 on increased all-round potential and enhanced suitability for everyday use. For example, an extended top gear and a longer final transmission ratio lower the revs and reduce fuel consumption along highway sections, while the shortened five lower gears as ever guarantee optimum power delivery offroad. Numerous optimized details further improve the durability and reliability of the new FREERIDE 350 and contribute to reducing its already extraordinarily low weight even further.",
                                          Engine = @"DESIGN
1-cylinder, 4-stroke engine
DISPLACEMENT
349.7 cm³
BORE
88 mm
STROKE
57.5 mm
STARTER
Electric starter
TRANSMISSION
6-speed
PRIMARY DRIVE
24:73
SECONDARY GEAR RATIO
12:48
CLUTCH
Wet, multi-disc clutch, Formula hydraulics
EMS
Keihin EMS",
                                          Category = context.Categories.FirstOrDefault(g => g.Name == "Freeride"),
                                          ImageUrls = new[] { new ImageUrl() { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/freeride/freeride-3503/freeride-350-2017/f8203q4/pho_bike_pers_revo.png" }
                        },
                                          Author = admin
                                      },
                                      new Motorcycle()
                                      {
                                          Title = "FREERIDE 250 R",
                                          Description = @"All those who have never had the opportunity to enjoy the punch of a powerful two-stroke in a lightweight, agile offroad chassis are in for a surprise with the Freeride 250 R. However, those who have already had this pleasure know: The power of such an engine develops completely differently, the expanding combustion gases effectively pressing down twice as often on the crankshaft as a four-stroke. Consequently, KTM two-stroke enduros, which are designed more for high peak power, still pull away forcefully from the very bottom up and that's a real pleasure. And since the engine on the FREERIDE 250 R is tuned completely in keeping with the Freeride notion - not for maximum power but for harmonious torque progression and optimum rideability - this motorcycle is an all-rounder that feels all the more at home, the tougher the terrain becomes.",
                                          Engine = @"DESIGN
1-cylinder, 2-stroke engine
DISPLACEMENT
249 cm³
BORE
66.4 mm
STROKE
72 mm
STARTER
Electric starter
TRANSMISSION
6-speed
PRIMARY DRIVE
26:72
SECONDARY GEAR RATIO
14:46
CLUTCH
Wet, CSS multi-disc clutch, Formula hydraulics
EMS
Kokusan",
                                          Category = context.Categories.FirstOrDefault(g => g.Name == "Freeride"),
                                          ImageUrls = new[] { new ImageUrl() { Url = "http://www.ktm.com/globalassets/products-pim-data/ke2-11001/freeride/freeride-250-r2/freeride-250-r-2017/f7303q4/pho_bike_90_re.png" }
                        },
                                          Author = admin
                                      }








//                    new Motorcycle()
//                    {
//                        Title = "Fallout 4",
//                        Description = @"Bethesda Motorcycle Studios, the award-winning creators of Fallout 3 and The Elder Scrolls V: Skyrim, welcome you to the world of Fallout 4 - their most ambitious game ever, and the next generation of open-world gaming.",
//                        Engine = @"MINIMUM: 
//OS: Windows 7/8/10 (64-bit OS required) 
//Processor: Intel Core i5-2300 2.8 GHz/AMD Phenom II X4 945 3.0 GHz or equivalent 
//Memory: 8 GB RAM 
//Graphics: NVIDIA GTX 550 Ti 2GB/AMD Radeon HD 7870 2GB or equivalent 
//Hard Drive: 30 GB available space
//RECOMMENDED: 
//OS: Windows 7/8/10 (64-bit OS required) 
//Processor: Intel Core i7 4790 3.6 GHz/AMD FX-9590 4.7 GHz or equivalent 
//Memory: 8 GB RAM 
//Graphics: NVIDIA GTX 780 3GB/AMD Radeon R9 290X 4GB or equivalent 
//Hard Drive: 30 GB available space",
//                        Category = context.Categories.FirstOrDefault(g => g.Name == "Freeride"),
//                        ImageUrls = new[] { new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/377160/ss_4733a1f56becbff21118435bd49561d0ed2392e7.600x338.jpg?t=1447358782" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/377160/ss_f7861bd71e6c0c218d8ff69fb1c626aec0d187cf.600x338.jpg?t=1447358782" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/377160/ss_910437ac708aed7c028f6e43a6224c633d086b0a.600x338.jpg?t=1447358782" } },
//                        Author = admin
//                    },
//                    new Motorcycle()
//                    {
//                        Title = "Dota 2",
//                        Description = @"Dota is a competitive game of action and strategy, played both professionally and casually by millions of passionate fans worldwide. Players pick from a pool of over a hundred heroes, forming two teams of five players.",
//                        Engine = @"Windows
//MINIMUM: 
//OS: Windows 7 
//Processor: Dual core from Intel or AMD at 2.8 GHz 
//Memory: 4 GB RAM 
//Graphics: nVidia GeForce 8600/9600GT, ATI/AMD Radeon HD2600/3600 
//DirectX: Version 9.0c 
//Network: Broadband Internet connection 
//Hard Drive: 8 GB available space 
//Sound Card: DirectX Compatible",
//                        Category = context.Categories.FirstOrDefault(g => g.Name == "Freeride"),
//                        ImageUrls = new[] { new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/570/ss_09f21774b2309fcb67a2d9f8b385b47c48e985ff.600x338.jpg?t=1447883099" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/570/ss_2a951d65c6084004dcdc292d4944c0fb4a059624.600x338.jpg?t=1447883099" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/570/ss_6a426a8d2d15ce7d7d9077f81c95daf3257fe387.600x338.jpg?t=1447883099" } },
//                        Author = admin
//                    },
//                    new Motorcycle()
//                    {
//                        Title = "Grand Theft Auto V",
//                        Description = @"A young street hustler, a retired bank robber and a terrifying psychopath must pull off a series of dangerous heists to survive in a ruthless city in which they can trust nobody, least of all each other.",
//                        Engine = @"MINIMUM: 
//OS: Windows 8.1 64 Bit, Windows 8 64 Bit, Windows 7 64 Bit Service Pack 1, Windows Vista 64 Bit Service Pack 2* (*NVIDIA video card recommended if running Vista OS) 
//Processor: Intel Core 2 Quad CPU Q6600 @ 2.40GHz (4 CPUs) / AMD Phenom 9850 Quad-Core Processor (4 CPUs) @ 2.5GHz 
//Memory: 4 GB RAM 
//Graphics: NVIDIA 9800 GT 1GB / AMD HD 4870 1GB (DX 10, 10.1, 11) 
//Hard Drive: 65 GB available space 
//Sound Card: 100% DirectX 10 compatible
//RECOMMENDED: 
//OS: Windows 8.1 64 Bit, Windows 8 64 Bit, Windows 7 64 Bit Service Pack 1 
//Processor: Intel Core i5 3470 @ 3.2GHz (4 CPUs) / AMD X8 FX-8350 @ 4GHz (8 CPUs) 
//Memory: 8 GB RAM 
//Graphics: NVIDIA GTX 660 2GB / AMD HD 7870 2GB 
//Hard Drive: 65 GB available space 
//Sound Card: 100% DirectX 10 compatible",
//                        Category = context.Categories.FirstOrDefault(g => g.Name == "Enduro"),
//                        ImageUrls = new[] { new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/271590/ss_ea78dfa1d7d81c3781287cab165f64ca70f1f2ea.600x338.jpg?t=1447687485" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/271590/ss_d1555f147b4667f70fac769985df629cbfda40b8.600x338.jpg?t=1447687485" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/271590/ss_680684304e38a9c58a55866cde99469ae8ef510c.600x338.jpg?t=1447687485" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/271590/ss_be2b9e45c671f95b8bc9fde58dbbd1154b0b633a.600x338.jpg?t=1447687485" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/271590/ss_54a59b51d9a3dbd5cf6b8d8745716b293633a50b.600x338.jpg?t=1447687485" } },
//                        Author = admin
//                    },
//                    new Motorcycle()
//                    {
//                        Title = "Team Fortress 2",
//                        Description = @"Nine distinct classes provide a broad range of tactical abilities and personalities. Constantly updated with new game modes, maps, equipment and, most importantly, hats!",
//                        Engine = @"Windows
//MINIMUM: 
//OS: WindowsR 7 (32/64-bit)/Vista/XP 
//Processor: 1.7 GHz Processor or better 
//Memory: 512 MB RAM 
//DirectX: Version 8.1 
//Network: Broadband Internet connection 
//Hard Drive: 15 GB available space 
//Additional Notes: Mouse, Keyboard
//RECOMMENDED: 
//OS: WindowsR 7 (32/64-bit) 
//Processor: Pentium 4 processor (3.0GHz, or better) 
//Memory: 1 GB RAM 
//DirectX: Version 9.0c 
//Network: Broadband Internet connection 
//Hard Drive: 15 GB available space 
//Additional Notes: Mouse, Keyboard",
//                        Category = context.Categories.FirstOrDefault(g => g.Name == "Freeride"),
//                        ImageUrls = new[] { new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/440/0000002574.600x338.jpg?t=1447886799" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/440/0000002575.600x338.jpg?t=1447886799" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/440/0000002576.600x338.jpg?t=1447886799" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/440/0000002577.600x338.jpg?t=1447886799" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/440/0000002579.600x338.jpg?t=1447886799" } },
//                        Author = admin
//                    },
//                    new Motorcycle()
//                    {
//                        Title = "Garry's Mod",
//                        Description = @"Garry's Mod is a physics sandbox. There aren't any predefined aims or goals. We give you the tools and leave you to play.",
//                        Engine = @"Windows
//MINIMUM:  
//OS: WindowsR Vista/XP/2000 
//Processor: 1.8 GHz Processor 
//Memory: 2GB RAM 
//Graphics: DirectXR 9 level Graphics Card (Requires support for SSE) 
//Hard Drive: 1GB 
//Other Requirements: Internet Connection
//Mac OS X
//MINIMUM: OS X version Snow Leopard 10.6.3, 2GB RAM, NVIDIA GeForce 8 or higher, ATI X1600 or higher, or Intel HD 3000 or higher Mouse, Keyboard, Internet Connection, Monitor",
//                        Category = context.Categories.FirstOrDefault(g => g.Name == "Enduro"),
//                        ImageUrls = new[] { new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/4000/ss_4162b10390d84aa600e5ed895fdc885482eb2e71.600x338.jpg?t=1421333577" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/4000/ss_ff27d52a103d1685e4981673c4f700b860cb23de.600x338.jpg?t=1421333577" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/4000/ss_65ec9828538eac8db20efc8149990060911fefc4.600x338.jpg?t=1421333577" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/4000/ss_c13ffded1d71bedfa7ede94c11cbd21fbd21a32c.600x338.jpg?t=1421333577" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/4000/0000000827.600x338.jpg?t=1421333577" } },
//                        Author = admin
//                    },
//                    new Motorcycle()
//                    {
//                        Title = "Verdun",
//                        Description = @"Verdun is the first multiplayer FPS set in a realistic First World War setting. The merciless trench warfare offers a unique battlefield experience, immersing you and your squad into intense battles of attack and defense.",
//                        Engine = @"Windows
//MINIMUM: 
//OS: Windows Vista/7/8 
//Processor: Intel Core2 Duo 2.4Ghz or Higher / AMD 3Ghz or Higher 
//Memory: 3 GB RAM 
//Graphics: Geforce GTX 960M / Radeon HD 7750 or higher, 1GB video card memory 
//DirectX: Version 9.0c 
//Network: Broadband Internet connection 
//Hard Drive: 12 GB available space 
//Additional Notes: Multiplayer only, make sure you have a stable and fast internet connection.
//RECOMMENDED: 
//Memory: 4 GB RAM 
//Graphics: 2GB video card memory",
//                        Category = context.Categories.FirstOrDefault(g => g.Name == "Enduro"),
//                        ImageUrls = new[] { new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/242860/ss_e86e8ce863bd67f5fcc5f03b1f4cf75a76f711b6.600x338.jpg?t=1448057367" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/242860/ss_47d9116d5268cf8a64c452cb0f26809a9eaec2e5.600x338.jpg?t=1448057367" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/242860/ss_d0aea9deb102217936445c11b930b915d974e4e3.600x338.jpg?t=1448057367" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/242860/ss_ba7a42fc33abe1b3a616531bbd65aab2e4cb9af4.600x338.jpg?t=1448057367" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/242860/ss_bba495d434a53719c0ff80b77f179c09979e8a09.600x338.jpg?t=1448057367" },
//                            new ImageUrl() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/242860/ss_a70d9b23cbd9a7241bdb2795a678fcc2c39d3df4.600x338.jpg?t=1448057367" } },
//                        Author = admin
//                    }
);
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