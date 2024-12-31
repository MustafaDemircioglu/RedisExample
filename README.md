Proje Açıklaması
Bu proje, Redis'i önbellek (cache) çözümü olarak kullanarak, Dapper ile veritabanı işlemlerini hızlı ve verimli bir şekilde gerçekleştirmeyi amaçlayan bir uygulamadır. 
Redis, yüksek performanslı veri depolama ve hızlı veri erişimi sağlarken, Dapper ise .NET uygulamaları için hafif ve hızlı bir ORM (Object-Relational Mapper) olarak veri tabanı etkileşimlerini yönetir. 
Bu proje, Redis'in veri önbellekleme yetenekleri ile Dapper'ın veritabanı sorgularını hızlı bir şekilde işlemesini entegre ederek uygulama performansını arttırmayı hedeflemektedir.

Kullanılan Teknolojiler:
Redis: Yüksek performanslı ve esnek bir veri yapısı sunan açık kaynaklı bir veri yapısı sunucusu. Bu projede, sık erişilen verilerin hızlı bir şekilde önbelleğe alınması için kullanılmıştır.
Dapper: .NET uygulamaları için minimalist bir ORM. Veritabanı sorgularını doğrudan ve hızlı bir şekilde yönetir. Bu projede, Dapper kullanılarak veritabanı işlemleri verimli bir şekilde gerçekleştirilmiştir.
.NET Core / .NET 5+: Uygulama, .NET platformunda geliştirilmiştir.
SQL Nortwind veritabanı kullanılmıştır.

Özellikler:
Veri Önbellekleme: Redis, sık erişilen verileri hızlıca depolamak ve almak için kullanılır. Böylece veritabanı yükü azaltılır ve uygulamanın performansı artırılır.
Hızlı Veritabanı Sorguları: Dapper, doğrudan SQL sorguları ile çalışarak uygulamanın veritabanı erişimini hızlandırır ve kolaylaştırır.
Veritabanı ve Redis Entegrasyonu: Redis, Dapper ile yapılan veritabanı sorgularının sonuçlarını önbelleğe alır, böylece veri tabanına olan ihtiyaç azalmaktadır.
Kurulum ve Kullanım:
Redis'in kurulumu: Redis'in bilgisayarınızda kurulu olduğundan emin olun. Redis resmi web sitesinden indirip kurabilirsiniz.

Projeyi Çalıştırma:
Projeyi GitHub'dan klonlayın.
Projenin bağımlılıklarını yükleyin (NuGet paketleri).
Veritabanı bağlantı dizesini ve Redis yapılandırmasını yapılandırın.
