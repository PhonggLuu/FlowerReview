using FlowerReviewApp.Models;

namespace FlowerReviewApp
{
    public class Seed
    {
        private readonly SONUNGVIENREVIEWContext _context;

        public Seed(SONUNGVIENREVIEWContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            if(!_context.DetailedProductOwners.Any())
            {
                var dpowners = new List<DetailedProductOwner>()
                {
                    new DetailedProductOwner()
                    {
                        DetailedProduct = new DetailedProduct
                        {
                            DetailedProductName = "Sen đá hoa hồng 1-1",
                            Image = "https://hoasendatphcm.com/wp-content/uploads/2021/09/sen-da-hoa-hong-phap2.jpg",
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            Product = new Product
                            {
                                ProductName = "Sen đá hoa hồng 1",
                                ProductDescription = "Sen đá hoa hồng phù hợp để trang trí bàn làm việc, bàn cà phê, góc học tập, góc riêng của bạn",
                                Image = "https://hoasendatphcm.com/wp-content/uploads/2021/09/sen-da-hoa-hong-phap2.jpg",
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now,
                                Category = new Category
                                {
                                    CategoryName = "Sen đá hoa hồng",
                                    Image = "https://hoasendatphcm.com/wp-content/uploads/2021/09/sen-da-hoa-hong-phap2.jpg",
                                    CreatedAt = DateTime.Now,
                                    UpdatedAt = DateTime.Now
                                }
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Sen đá hoa hồng 1-1", Text = "Dễ thương", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title= "Sen đá hoa hồng 1-1",Text = "Rẻ, đẹp", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title= "Sen đá hoa hồng 1-1", Text = "Nice", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Phong", LastName = "Luu" } },
                            }
                        },
                        Owner = new Owner
                        {
                            FirstName = "Phong",
                            LastName = "Luu",
                            Country = new Country
                            {
                                Name = "VietNam"
                            }
                        }
                    },
                    new DetailedProductOwner()
                    {
                        DetailedProduct = new DetailedProduct
                        {
                            DetailedProductName = "Sen đá lá thơm 1-1",
                            Image = "https://dalatfarm.net/wp-content/uploads/2020/10/sen-da-la-thom-2.jpg",
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            Product = new Product
                            {
                                ProductName = "Sen đá lá thơm 1",
                                ProductDescription = "Sen đá Lá Thơm hay còn tên gọi là cây Nhất Mạt Hương là loại cây trên lá có một mùi hương nhẹ, bạn chỉ cần chạm tay và lá hoặc lại gần cây và hít một hơi, bạn sẽ thấy thoải mái và dễ chịu.",
                                Image = "https://dalatfarm.net/wp-content/uploads/2020/10/sen-da-la-thom-2.jpg",
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now,
                                Category = new Category
                                {
                                    CategoryName = "Sen đá lá thơm",
                                    Image = "https://dalatfarm.net/wp-content/uploads/2020/10/sen-da-la-thom-2.jpg",
                                    CreatedAt = DateTime.Now,
                                    UpdatedAt = DateTime.Now
                                }
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Sen đá lá thơm 1-1", Text = "Rất thơm", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title= "Sen đá lá thơm 1-1",Text = "Đẹp quá", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title= "Sen đá lá thơm 1-1", Text = "Đẹp tuyệt vời", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owner = new Owner
                        {
                            FirstName = "Harry",
                            LastName = "Potter",
                            Country = new Country
                            {
                                Name = "VietNam"
                            }
                        }
                    },
                    new DetailedProductOwner()
                    {
                        DetailedProduct = new DetailedProduct
                        {
                            DetailedProductName = "Sen đá kim cương 1-1",
                            Image = "https://www.cleanipedia.com/images/5iwkm8ckyw6v/2Y2vvGdAqUhsk2DrckjZci/bbdb702f0ae4cc3a8a0aca556c78406f/aW1hZ2UucG5n/1200w/sen-%C4%91%C3%A1-kim-c%C6%B0%C6%A1ng.jpg",
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            Product = new Product
                            {
                                ProductName = "Sen đá kim cương 1",
                                ProductDescription = "Sen đá Kim Cương có vẻ ngoài mập mạp và góc cạnh như một viên kim cương. mang nhiều ý nghĩa tốt đẹp như: Sức sống mạnh mẽ và tình yêu vĩnh cửu.",
                                Image = "https://www.cleanipedia.com/images/5iwkm8ckyw6v/2Y2vvGdAqUhsk2DrckjZci/bbdb702f0ae4cc3a8a0aca556c78406f/aW1hZ2UucG5n/1200w/sen-%C4%91%C3%A1-kim-c%C6%B0%C6%A1ng.jpg",
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now,
                                Category = new Category
                                {
                                    CategoryName = "Sen đá kim cương",
                                    Image = "https://www.cleanipedia.com/images/5iwkm8ckyw6v/2Y2vvGdAqUhsk2DrckjZci/bbdb702f0ae4cc3a8a0aca556c78406f/aW1hZ2UucG5n/1200w/sen-%C4%91%C3%A1-kim-c%C6%B0%C6%A1ng.jpg",
                                    CreatedAt = DateTime.Now,
                                    UpdatedAt = DateTime.Now
                                }
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Sen đá kim cương 1-1", Text = "Màu rất đẹp", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title= "Sen đá kim cương 1-1",Text = "Rất hợp để bàn làm việc", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title= "Sen đá kim cương 1-1", Text = "Cây nhỏ", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owner = new Owner
                        {
                            FirstName = "Son",
                            LastName = "Tung",
                            Country = new Country
                            {
                                Name = "VietNam"
                            }
                        }
                    }
                };
                _context.DetailedProductOwners.AddRange(dpowners);
                _context.SaveChanges();
            }
        }
    }
}
