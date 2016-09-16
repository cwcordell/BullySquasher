using BullySquasher.Models;

namespace BullySquasher.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BullySquasher.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BullySquasher.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
//            var date = DateTime.UtcNow;
            context.ChildMessages.AddOrUpdate(
//                p => p.ChildDeviceId,
//                new ChildMessage { ChildDeviceId = 2}
//                new ChildMessage { ChildDeviceId = 2, message = "Saundra has a bad attitude.", isBullyMessage = false, DateCreated = date.Add(new TimeSpan(-1000)), DateModified = date.Add(new TimeSpan(-1000)) },
//                new ChildMessage { ChildDeviceId = 2, message = "He is so mean and is a jerk for doing that to you Laura. Why don't you come over and we can talk about how to get back at him.",
//                    isBullyMessage = true, DateCreated = date.Add(new TimeSpan(1000)), DateModified = date.Add(new TimeSpan(1000))},
//                new ChildMessage { ChildDeviceId = 2, message = "Did you hear about the bomb threat at the high school in Summersville?",
//                    isBullyMessage = false, DateCreated = date.Add(new TimeSpan(2000)), DateModified = date.Add(new TimeSpan(2000)) },
//                new ChildMessage { ChildDeviceId = 2, message = "Why did you leave?", isBullyMessage = false, DateCreated = date.Add(new TimeSpan(3000)), DateModified = date.Add(new TimeSpan(3000)) },
//                new ChildMessage { ChildDeviceId = 2, message = "Julie, you are a dork! :)", isBullyMessage = false, DateCreated = date.Add(new TimeSpan(4000)), DateModified = date.Add(new TimeSpan(4000)) },
//                new ChildMessage { ChildDeviceId = 3, message = "Paul is a moron.", isBullyMessage = null, DateCreated = date.Add(new TimeSpan(-12000)), DateModified = date.Add(new TimeSpan(-12000)) },
//                new ChildMessage { ChildDeviceId = 3, message = "What time are we supposed to be at the gym?", isBullyMessage = false, DateCreated = date.Add(new TimeSpan(-10000)), DateModified = date.Add(new TimeSpan(-10000)) },
//                new ChildMessage { ChildDeviceId = 3, message = "LOL", isBullyMessage = false, DateCreated = date.Add(new TimeSpan(-2000)), DateModified = date.Add(new TimeSpan(-200)) },
//                new ChildMessage { ChildDeviceId = 3, message = "u b so soft bro. brb", isBullyMessage = false, DateCreated = date.Add(new TimeSpan(-1800)), DateModified = date.Add(new TimeSpan(-1800)) },
//                new ChildMessage { ChildDeviceId = 3, message = "Paris is nice this time of year.", isBullyMessage = false, DateCreated = date.Add(new TimeSpan(-1500)), DateModified = date.Add(new TimeSpan(-1500)) },
//                new ChildMessage { ChildDeviceId = 3, message = "Frank ate the beans.", isBullyMessage = false, DateCreated = date.Add(new TimeSpan(-1200)), DateModified = date.Add(new TimeSpan(-1200)) },
//                new ChildMessage { ChildDeviceId = 3, message = "Probably", isBullyMessage = false, DateCreated = date.Add(new TimeSpan(-1000)), DateModified = date.Add(new TimeSpan(-1000)) },
//                new ChildMessage { ChildDeviceId = 3, message = "Like 3 little ducks.", isBullyMessage = false, DateCreated = date.Add(new TimeSpan(-500)), DateModified = date.Add(new TimeSpan(-500)) },
//                new ChildMessage { ChildDeviceId = 4, message = "I hate facebook.", isBullyMessage = false, DateCreated = date.Add(new TimeSpan(-50000)), DateModified = date.Add(new TimeSpan(-50000)) },
//                new ChildMessage { ChildDeviceId = 4, message = "Tom as to be joking. That guy is full of bs.", isBullyMessage = true, DateCreated = date.Add(new TimeSpan(-5500)), DateModified = date.Add(new TimeSpan(-5500)) },
//                new ChildMessage { ChildDeviceId = 4, message = "Populate the quantity then isolate the values.", isBullyMessage = false, DateCreated = date.Add(new TimeSpan(-400)), DateModified = date.Add(new TimeSpan(-400)) },
//                new ChildMessage { ChildDeviceId = 4, message = "I need some new speakers from my car.", isBullyMessage = false, DateCreated = date.Add(new TimeSpan(-5100)), DateModified = date.Add(new TimeSpan(-5100)) }
            );
            
        }
    }
}
