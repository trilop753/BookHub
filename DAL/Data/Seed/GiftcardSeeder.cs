using Bogus;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Seed
{
    public static class GiftcardSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var giftcards = PrepareGiftcards();
            var codes = PrepareGiftcardCodes(giftcards);

            modelBuilder.Entity<Giftcard>().HasData(giftcards);
            modelBuilder.Entity<GiftcardCode>().HasData(codes);
        }

        private static List<Giftcard> PrepareGiftcards()
        {
            var faker = new Faker<Giftcard>("en")
                .RuleFor(g => g.Id, f => f.IndexFaker + 1)
                .RuleFor(g => g.Name, f => f.Commerce.ProductName())
                .RuleFor(g => g.Amount, f => f.PickRandom(new[] { 250m, 500m, 1000m, 2000m }))
                .RuleFor(
                    g => g.ValidFrom,
                    f => f.Date.Between(new DateTime(2023, 1, 1), DateTime.Now)
                )
                .RuleFor(g => g.ValidTo, (f, g) => g.ValidFrom.AddMonths(f.Random.Int(6, 18)));

            return faker.Generate(5);
        }

        private static List<GiftcardCode> PrepareGiftcardCodes(List<Giftcard> giftcards)
        {
            var faker = new Faker("en");

            int idCounter = 1;
            int codesPerGiftcard = 10;

            List<GiftcardCode> allCodes = new();

            foreach (var gc in giftcards)
            {
                for (int i = 0; i < codesPerGiftcard; i++)
                {
                    allCodes.Add(
                        new GiftcardCode
                        {
                            Id = idCounter++,
                            GiftcardId = gc.Id,
                            Code = faker.Random.Replace("GC-####-####"),
                            IsUsed = faker.Random.Bool(0.2f),
                            OrderId = null,
                        }
                    );
                }
            }

            return allCodes;
        }
    }
}
