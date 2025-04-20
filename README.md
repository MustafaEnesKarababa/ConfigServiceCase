Proje Adı: ConfigServiceCase

Proje Açıklaması:
ConfigServiceCase, uygulama konfigürasyonlarını yönetmek ve bu verileri veritabanından çekerek cache'de saklamak için geliştirilmiş bir çözüm sunar. Konfigürasyonlar belirli aralıklarla güncellenir, böylece uygulamalar her zaman güncel veriye erişir. ConfigServiceCase çözümü, ConfigLibrary'yi kullanarak veritabanından veri çeker, ConfigAdminApi API'si ile bu verileri yönetir.

Bileşenler:
ConfigLibrary: Konfigürasyon verilerinin yönetildiği temel kütüphane.

ConfigAdminApi: Konfigürasyonları yönetmek için CRUD işlemleri sağlayan API.

ConfigLibrary.Tests: ConfigLibrary içerisinde yapılan işlemleri test eden test projeleri.

Kurulum:
  - Gerekli NuGet paketlerini yükleyin.
    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.Design
    - Microsoft.EntityFrameworkCore.SqlServer
    - Microsoft.EntityFrameworkCore.Tools
    - Moq
    - xunit
    
  - Veritabanı bağlantısı için update-database yapın. Api'yı kullanmak için appsettings.json içerisindeki connectionString'i kendinize uygun haliyle düzenleyin. configurationReader'ı kullanacaksanız bu düzenlemeyi yapmanıza gerek yok. Sadece Api'yı çalıştırmak için ihtiyacınız var. configurationReader'ı kullanırken vereceğiniz connstr bundan bağımsızdır.

Kullanım:
ConfigAdminApi API'sini kullanarak konfigürasyonları ekleyebilir, güncelleyebilir ve silebilirsiniz.

ConfigLibrary tarafından sağlanan ConfigurationReader sınıfı ile veritabanından konfigürasyonları çekebilir ve cache mekanizması ile veriyi güncelleyebilirsiniz. Bunun için repository'ime eklediğim Test_App'i kullanabiirsiniz. Ya da tamamen bağımsız bir projeye referans vererek ConfigLibrary kullanılabilir.

Testler:
Testler için ConfigLibrary.Tests projesi kullanılmaktadır. Testleri çalıştırmak için XUnit gibi test çerçevelerini kullanabilirsiniz.
