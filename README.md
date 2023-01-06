# Project.Kaizen_Case2

Proje Adımları:

- Name (Identifier olarak kullanılır, Multi Language olmasına gerek yok. Ingilizce yazılır) <br /> 
- Title (Multi Language) <br /> 
- Detail (Multi Language) <br />  
- ImageUrls (Multi Language, Bir içerik birden fazla imaja sahip olabilir) <br />  
- Category (Multi Language) <br /> 



Projemizde Birden fazla dilde hizmet istendiğinden, "Mssql'de"  çoklu dil desteğine uygun tablo yapısını oluşturdum.
Projemizde "Db First" yöntemi kullancağımızdan oluşturduğumuz tablolara direk değer atayabiliriz.


![sql_result](https://user-images.githubusercontent.com/58344612/210905680-22e10968-b267-4147-8676-fcd1a2875e3f.png)



Bizden istenilen çıktıda "en" ve "tr" ye göre News kolonunun listelenmesidir.
İlk önce sql sorgusu yazarak istenilen sonuca ulaştım.

![join_result](https://user-images.githubusercontent.com/58344612/210905616-af9218c0-ac77-4244-80a1-1f2c5009ce71.png)


Oluşturduğumuz .netCore(6.0) Web Mvc projemizi Scaffold db first yöntemi ile bağladık.
Oluşturduğumuz web sitesi çok dildesteğine uygun yapabilmek için alternatif yöntem izleyebiliriz.
Verilerin dil uyumlu db de tutup veya resource oluşturup, her iki türlü de  dil seçeneğine göre verilerin listelenmesini sağlayabiliriz.
Bu projede iki yol ilede çalışmalar yapılmıştır.


Oluşturduğumuz sitede dil değiştirme butonunun değişme özelliğine göre seçilen dili Cookie'ye atamaktadır.

![Cookie](https://user-images.githubusercontent.com/58344612/210906459-994f08b2-ec93-40e7-85b3-c378126ecbf2.png)


Projemizde BaseController oluşturdum. OnActionExecutionAsync methodu  kullanarak Controller daha ayağa kalmadan önce seçilen dil ayarlamalarını yaptım.
Bu sayese hangi controller ayağa kalkarsa kalksın cookieden gelen dil seçeneği ile ayağa kalkacaktır. Cookie boş ise default değer olarak "tr-TR" ayarlanmıştır.

![baseco](https://user-images.githubusercontent.com/58344612/210906832-5fcfbf4a-a7b6-41cc-9475-70ebc33d0fa4.png)


Bu işlem yapıldıktan sonra artık sistemin dili belirlenmiştir ve static içerik dediğimiz kısımlar için "Resourcesler" oluşturulmuştur ve program.cs classına
tanımlamaları yapılmıştır.

Resourceslarımız Key value değeri tutmakta sistemin dile göre Key'in karşılığı olan Valueları dönmektedir.
![res](https://user-images.githubusercontent.com/58344612/210907270-a0d2bd89-8b71-47f9-b6e2-22db920d9280.png)

Data base uyumlu dil desteği için Dbye göndereceğimiz sorguda seçilen dilin ismini göndermemiz yeterli olacaktır. Db bize seçilen dile göre verileri getirecektir.

![join_c](https://user-images.githubusercontent.com/58344612/210907398-95a23340-8a25-4633-a3dd-47219c4b68ad.png)


BaseControllerda aldığımız dil değerini hem Resourceslarımıza hemde Dbye gönderip, dil isteğine göre sonuçlar aşağıdaki görsellerdeki gibi  dönülmüştür. 

![en-result](https://user-images.githubusercontent.com/58344612/210907704-ac6cc6b2-a816-4958-9b17-f0a2d27fa47f.png)
![tr_result](https://user-images.githubusercontent.com/58344612/210907706-b2ab7671-ad5e-402e-bab2-cf7398ad6fe9.png)


PROJEDE KULLANILAN KÜTÜPHANELER :

Veri tabanlı işlemleri için => EntityFrameworkCore (6.0.12) <br /> 
Veri tabanı ve Visual Studio Code arasındaki ilişkiler için => EntityFrameworkCore.Design (6.0.12) , EntityFrameworkCore.Tools (6.0.12), EntityFrameworkCore.SqlServer (6.0.12)



