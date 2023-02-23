using Catalog.Api.Entites;
using DnsClient;
using MongoDB.Driver;
using MongoDB.Driver.Core.Misc;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;
using System;
using System.IO.Pipelines;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Catalog.Api.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existproduct = productCollection.Find(p => true).Any();
            if (!existproduct)
            {
                productCollection.InsertManyAsync(GetSeedData());
            }
        }

        private static IEnumerable<Product> GetSeedData()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id="61ca84a91c2022f0131d0a1f",
                   Name= "I Phone X",
                   Description= " The I Phone X features a sleek design with a glass front and glass back," +
                   " both made with durable Corning glass, and a sturdy stainless steel frame. It boasts a stunning 5.8-inch Super Retina HD display with True Tone technology, " +
                   "providing a clear and vibrant viewing experience. The phone also includes a dual 12MP camera system with Portrait mode, Portrait Lighting, and 4K video recording," +
                   " as well as a 7MP TrueDepth front camera with Portrait mode and Portrait Lighting. With Face ID, you can unlock your phone securely and easily with just a glance," +
                   " and the A11 Bionic chip provides lightning-fast performance. " +
                   "The I Phone X is also water and dust resistant and supports wireless charging.",
                   Summary="Also known as Apple iPhone 10 or Apple iPhone Ten," +
                   " the I Phone X is a top-of-the-line smartphone with impressive features and a modern design.",
                   ImageFile="product1.img",
                    Price=950.50m,
                    Catagory="Smart Phone"
                },
                new Product()
                {
                    Id="61ca84a91c2022f0131d0a20",
                    Name="Galaxy A73",
                    Description= "The Galaxy A73 is a powerful and stylish smartphone that offers a premium user experience. It features a large 6.7-inch Super AMOLED Plus display with a resolution of 2400 x 1080 pixels, providing stunning visuals and vivid colors. The phone is powered by an octa-core processor and comes with 8GB of RAM and 128GB of storage, providing plenty of space for all your apps, photos, and videos.The Galaxy A73 also features a versatile quad - camera system, with a 64MP main camera, a 12MP ultra - wide camera, a 5MP macro camera, and a 5MP depth sensor.The front - facing camera is a 32MP sensor that delivers sharp and detailed selfies.Other features of the Galaxy A73 include a large 5000mAh battery, fast charging, and an in-display fingerprint sensor for added security.",
                    Summary=" The Galaxy A73 is a feature - packed smartphone with a large display, powerful processor, and versatile camera system, making it a great choice for anyone who wants a high - end device at an affordable price.",
                    ImageFile=" product1.img",
                    Price= 499.99m,
                    Catagory=" Smart Phone"
                },
                new Product()
                {
                    Id="61ca84a91c2022f0131d0a21",
                    Name="Galaxy A10",
                    Description=" The Galaxy A10 is a budget-friendly smartphone that offers a solid user experience. It features a 6.2-inch Infinity-V display with a resolution of 720 x 1520 pixels, providing a clear and vibrant viewing experience. The phone is powered by an octa-core processor and comes with 2GB of RAM and 32GB of storage, which can be expanded with a microSD card. The Galaxy A10 also features a 13MP rear camera and a 5MP front-facing camera, both of which can capture decent photos and videos. Other features of the Galaxy A10 include a 3400mAh battery, fast charging, and face recognition for easy unlocking.",
                    Summary=" The Galaxy A10 is an affordable smartphone that offers a good balance of features and performance, making it a great choice for anyone who wants a reliable device without breaking the bank.",
                    ImageFile=" product1.img",
                    Price= 149.99m,
                   Catagory=" Smart Phone"
                },
                new Product()
                {
                    Id="61ca84a91c2022f0131d0a22",
                    Name="Galaxy S20",
                    Description=" The Galaxy S20 is a high-end smartphone that offers top-of-the-line features and performance. It features a 6.2-inch Dynamic AMOLED display with a resolution of 3200 x 1440 pixels, providing stunning visuals and vibrant colors. The phone is powered by an octa-core processor and comes with 12GB of RAM and 128GB of storage, providing plenty of space for all your apps, photos, and videos. The Galaxy S20 also features a versatile triple-camera system, with a 12MP main camera, a 64MP telephoto camera, and a 12MP ultra-wide camera. The front-facing camera is a 10MP sensor that delivers sharp and detailed selfies. Other features of the Galaxy S20 include a large 4000mAh battery, fast charging, and wireless charging. It also supports 5G connectivity for lightning-fast data speeds.",
                    Summary=" The Galaxy S20 is a premium smartphone that offers cutting-edge features and performance, making it a great choice for anyone who wants the best of the best.",
                    ImageFile=" product1.img",
                    Price= 999.99m,
                    Catagory=" Smart Phone"
                },
                new Product()
                {
                    Id="61ca84a91c2022f0131d0a23",
                    Name="Galaxy S23",
                    Description=" The Galaxy S23 is a highly anticipated upcoming smartphone from Samsung. While specific details are not yet available, it is expected to feature a large and vibrant display, a powerful processor, and a versatile camera system. It is also likely to include advanced features such as 5G connectivity, wireless charging, and improved biometric security measures. More information will be released as the launch date approaches.",
                    Summary=" The Galaxy S23 is an eagerly awaited smartphone that is expected to offer top-of-the-line features and performance, making it a great choice for anyone who wants the latest and greatest technology.",
                    ImageFile=" product1.img",
                    Price= 999.99m,
                    Catagory=" Smart Phone"
                }
            };
        }
    }
}
