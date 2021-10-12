using MasterProject.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MasterProject.Infrastructure.Data.Config
{
    /// <summary>
    /// This class will be used for applying client specific configuration. 
    /// It will be also used for seeding initial data. 
    /// </summary>
    public class ClientConfiguration : BaseEntityConfiguration<Client>
    {
        /// <summary>
        /// This class will be used for applying entity specific configuration. 
        /// It will be also used for seeding initial data. 
        /// </summary>
        /// <param name="builder">Entity builder</param>
        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            base.Configure(builder);

            List<Client> clients = new List<Client> {
            new Client { Name = "ABC Client", Id = Guid.Parse("15789274-A08E-4CCB-A149-BDE633421026"), CreatedOn = DateTime.Now }
            };
            builder.HasData(clients);
        }
    }
}
