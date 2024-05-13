# CQRS-WebAPI
Basit bir .NET Core Web API uygulamasında CQRS Pattern'i incelemek için bu projeden faydalanabilirsiniz. Bu projeyle ilgili Medium yazı

Kullandığım Teknolojiler: \
🖥 .NET Core \
💾 Postgresql (EF Core ile) \
💾 MongoDB \
🎛️ Docker \

# Nasıl Ayağa Kaldırılır
1-Projenin olduğu dizine giderek ```docker-compose up -d``` komutuyla proje docker üzerinde çalıştırılır \
2-Containerlar ayağa kalktıktan sonra terminal ekranında _CQRS-DAL_ katmanının olduğu dizinde terminal ekranı açılarak migration işlemi için ```dotnet ef database update``` komutu çalıştırılır (veya Visual Studio'da bulunan Package Manager Console'da ```update-database``` komutu çalıştırılır) \
3-Docker ile ayağa kaldırılan servisin adresine gidilerek test edilebilir.

NOT: Veritabanları arasında senkronizasyon şimdilik bulunmadığından okuma için kullanılan veri tabanını (MongoDB) uygun modelde data ekleyebilirsiniz.
