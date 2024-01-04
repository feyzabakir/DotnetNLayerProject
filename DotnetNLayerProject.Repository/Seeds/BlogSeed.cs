using DotnetNLayerProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNLayerProject.Repository.Seeds
{
    public class BlogSeed : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasData(
                new Blog
                {
                    Id = 1,
                    BlogTitle = "Git Versiyon Kontrol Sistemi",
                    BlogContent = "Git Nedir ?Git, bir versiyon kontrol sistemi olarak bilinen açık kaynaklı bir yazılımdır ve genellikle yazılım geliştirme süreçlerinde kullanılır. Git, proje dosyalarının değişikliklerini takip etmeye, farklı sürümleri yönetmeye ve işbirliği yapmaya olanak tanır.Git, Linux kurucusu Linus Torvalds tarafından geliştirilen bir versiyon kontrol sistemidir. Linux çekirdeğinin farklı developer’lar tarafından geliştirilmesi konusu git’in ortaya çıkmasını sağlamıştır.",
                    CategoryID = 1,
                    WriterID = 1,
                    CreatedDate = DateTime.Now
                },
                new Blog
                {
                    Id = 2,
                    BlogTitle = "N Katmanlı Mimari",
                    BlogContent = "Katmanlar sorumlulukların ayrılması ve bağımlılıkların yönetilmesi için kullanılan bir yöntemdir. Her katmanın belirli bir sorumluluğu vardır. Daha yüksek bir katman, hizmetleri daha düşük bir katmanda kullanabilir ancak daha düşük bir katman, hizmetleri daha yüksek bir katmanda kullanamaz.",
                    CategoryID = 2,
                    WriterID = 2,
                    CreatedDate = DateTime.Now
                },
                new Blog
                {
                    Id = 3,
                    BlogTitle = "Yazılım Dünyasında 2023 Trendleri",
                    BlogContent = "Bu sayıda alanında uzman yirmi iki kişinin görüşlerini okuyacaksınız. Bu sene kamuoyunun nabzını da yoklayarak yazarlarımız için iki dönem kuralı getirdim. Yani ilk iki sayıda da katkı sağlayan yazarlarımız bu sayıda yer almadı. Bunun yanında geçen sayıda bulunup bu sene müsait olamayan veya trendleri yeterince takip edemediğini düşünen yazarlarımız da bu sayıda yer almadı. Yeri gelmişken bu sayıda da sadece iki kadın yazılımcı, yazar olarak yer aldı. Ayrıca iki arkadaş son haftalardaki bazı aksilikler dolayısıyla yazı gönderemedi.",
                    CategoryID = 3,
                    WriterID = 3,
                    CreatedDate = DateTime.Now
                }

                );
        }
    }
}
