using AndalusRestaurant.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AndalusRestaurant.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Define composite key and relationships for ProductIngredient
            modelBuilder.Entity<ProductIngredient>()
    .HasKey(pi => new
    {
        pi.ProductId,
        pi.IngredientId
    });

            modelBuilder.Entity<ProductIngredient>()
            .HasOne(pi => pi.Product)
            .WithMany(p => p.ProductIngredients)
            .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductIngredient>()
        .HasOne(pi => pi.Ingredient)
        .WithMany(i => i.ProductIngredients)
        .HasForeignKey(pi => pi.IngredientId);
            // Seed Data for Moroccan Cuisine
            modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Entrée" },
            new Category { CategoryId = 2, Name = "Plat Principal" },
            new Category { CategoryId = 3, Name = "Accompagnement" },
            new Category { CategoryId = 4, Name = "Dessert" },
            new Category { CategoryId = 5, Name = "Boisson" });


            modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient { IngredientId = 1, Name = "Agneau" },
            new Ingredient { IngredientId = 2, Name = "Poulet" },
            new Ingredient { IngredientId = 3, Name = "Semoule de blé" },
            new Ingredient { IngredientId = 4, Name = "Pois chiches" },
            new Ingredient { IngredientId = 5, Name = "Raisins secs" },
            new Ingredient { IngredientId = 6, Name = "Citron confit" },
            new Ingredient { IngredientId = 7, Name = "Olives" },
            new Ingredient { IngredientId = 8, Name = "Miel" },
            new Ingredient { IngredientId = 9, Name = "Cannelle" },
            new Ingredient { IngredientId = 10, Name = "Amande" }
            );

            modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, Name = "Couscous Royal",
                Description = "Un plat traditionnel marocain avec semoule, légumes, poulet et agneau",

                Price = 7.50m,
                Stock = 50,
                CategoryId = 2
            },

            new Product
            {

                ProductId = 2,
                Name = "Tajine de Poulet au Citron Confit",
                Description = "Tajine de poulet aux olives et citrons confits.",
                Price = 6.99m,
                Stock = 40,
                CategoryId = 2
            },
            new Product
            {
                ProductId = 3,
                Name = "Harira",
                Description = "Soupe marocaine a base de pois chiches, lentilles et tomates.",
                Price = 3.99m,
                Stock = 60,
                CategoryId = 1

            },


            new Product
            {
                ProductId = 4,
                Name = "Pastilla au Poulet",
                Description = "Feuilleté sucré-salé farci de poulet, amandes et épices.",
                Price = 5.99m,
                Stock = 30,
                CategoryId = 1

            },
            
            new Product
            {
                ProductId = 5,
                Name = "Thé à la Menthe",
                Description = "Boisson traditionnelle marocaine préparée avec du thé vert et de lamenthe fraiche.",
                Price = 1.50m,
                Stock = 100,
                CategoryId = 5

            },
            new Product
            {
                ProductId = 6,
                Name = "Chebakia",
                Description = "Pâtisserie marocaine au miel et graines de sésame.",
                Price = 2.50m,
                Stock = 70,
                CategoryId = 4


            }


            );
            modelBuilder.Entity<ProductIngredient>().HasData(
                new ProductIngredient { ProductId = 1, IngredientId = 1 },
                new ProductIngredient { ProductId = 1, IngredientId = 3 },
                new ProductIngredient { ProductId = 1, IngredientId = 4 },
                new ProductIngredient { ProductId = 1, IngredientId = 5 },
                new ProductIngredient { ProductId = 2, IngredientId = 2 },
                new ProductIngredient { ProductId = 2, IngredientId = 6 },
                new ProductIngredient { ProductId = 2, IngredientId = 7 },
                new ProductIngredient { ProductId = 3, IngredientId = 3 },
                new ProductIngredient { ProductId = 3, IngredientId = 4 },
                new ProductIngredient { ProductId = 3, IngredientId = 9 },
                new ProductIngredient { ProductId = 4, IngredientId = 2 },
                new ProductIngredient { ProductId = 4, IngredientId = 8 },
                new ProductIngredient { ProductId = 4, IngredientId = 10 },
                new ProductIngredient { ProductId = 5, IngredientId = 7 },
                new ProductIngredient { ProductId = 5, IngredientId = 8 },
                new ProductIngredient { ProductId = 6, IngredientId = 8 },
                new ProductIngredient { ProductId = 6, IngredientId = 9 },
                new ProductIngredient { ProductId = 6, IngredientId = 10 }
            );





        }

    }
}
