using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PatientManagement.Models;
using System;
using System.Linq;

namespace PatientManagement.Data
{
    public static class DataSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Diseases.Any() || context.NCDs.Any() || context.Allergies.Any())
                {
                    return;
                }

                // Seed Diseases
                context.Diseases.AddRange(
                    new DiseaseInformation { Name = "Disease 1" },
                    new DiseaseInformation { Name = "Disease 2" },
                    new DiseaseInformation { Name = "Disease 3" }
                );

                // Seed NCDs
                context.NCDs.AddRange(
                    new NCD { Name = "NCD 1" },
                    new NCD { Name = "NCD 2" },
                    new NCD { Name = "NCD 3" }
                );

                // Seed Allergies
                context.Allergies.AddRange(
                    new Allergies { Name = "Allergy 1" },
                    new Allergies { Name = "Allergy 2" },
                    new Allergies { Name = "Allergy 3" }
                );

                context.SaveChanges();
            }
        }
    }
}
