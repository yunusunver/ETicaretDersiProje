##### Trello Adresi `https://trello.com/b/sSu3Zfa5/e-ticaret`

# Kullanılan Teknolojiler
- Asp.net MVC
- Entity Framework
- Ninject
- MS Sql Server
- PostSharp
- Log4Net
- Fluent Validation

# Veri Sözlüğü

## Sizes Tablosu

| Değişken Adı | Veri Tipi | Uzunluk | Açıklama |
| --- | --- | --- | --- |
| SizeID | İnt |   | Boyut ID Numarası |
| Size | Nvarchar | 50 | Boyut Değeri |

## Colors Tablosu

| Değişken Adı | Veri Tipi | Uzunluk | Açıklama |
| --- | --- | --- | --- |
| ColorID | İnt |   | Renk ID Numarası |
| Color | Nvarchar | 50 | Renk Değeri |

## Shippers Tablosu

| Değişken Adı | Veri Tipi | Uzunluk | Açıklama |
| --- | --- | --- | --- |
| ShipperID | İnt |   | Kargo ID Numarası |
| CompanyName | nvarchar | 50 | Şirket İsmi |
| Phone | nvharchar | 50 | Telefon Numarası |

## Categories Tablosu

| Değişken Adı | Veri Tipi | Uzunluk | Açıklama |
| --- | --- | --- | --- |
| CategoryID | int |   | Kategori ID Numarası |
| CategoryName | Nvarchar | 50 | Kategori İsmi |
| Description | nvarchar | MAX | Kategori Açıklaması |
| Picture | nvarchar | MAX | Kategori Resmi |
| Active | bit |   | Aktif mi değilmi Kontrolü |



## Payments Tablosu

| Değişken Adı | Veri Tipi | Uzunluk | Açıklama |
| --- | --- | --- | --- |
| PaymentID | int |   | Ödeme ID Numarası |
| PaymentType | nvarchar | 50 | Ödeme Tipi |
| Allowed | bit |   | İzin verilmiş mi? |







## Product Tablosu

| Değişken Adı | Veri Tipi | Uzunluk | Açıklama |
| --- | --- | --- | --- |
| ProductID | İnt |   | Ürün ID Numarası |
| ProductName | nvarchar | 50 | Ürün Adı |
| ProductDescription | Nvarchar | 50 | Ürün Açıklaması |
| SupplierID | int |   | Satıcı ID Numarası |
| CategoryID | int |   | Kategori ID Numarası |
| QuantityPerUnit | int |   | Miktar |
| UnitPrice | int |   | Fiyat |
| SizeID | int |   | Boyut ID Numarası |
| ColorID | int |   | Renk ID Numarası |
| Discount | int |   | İndirim |
| Picture | nvarchar | MAX | Resim |
| DiscountAvailable | bit |   | İndirim var mı? |
| CurrentOrder | bit |   | Ürün Mevcut mu? |

## Customers Tablosu

| Değişken Adı | Veri Tipi | Uzunluk | Açıklama |
| --- | --- | --- | --- |
| CustomerID | int |   | Müşteri ID Numarası |
| FirstName | Nvarchar | 50 | İsim |
| LastName | Nvarchar | 50 | Soyisim |
| Address1 | Nvarchar | MAX | Adres 1 |
| Address2 | Nvarchar | MAX | Adres 2 |
| City | Nvarchar | 50 | Şehir |
| PostalCode | Nvarchar | 50 | Posta Kodu |
| Country | Nvarchar | 50 | Ülke |
| Phone | Nvarchar | 50 | Telefon |
| Email | Nvarchar | 50 | Email |
| Password | Nvarchar | MAX | Parola |
| CreditCard | Nvarchar | 50 | Kredi Kartı |
| CardExpMo | İnt | İnt | Kart Ay Tarihi |
| CardExpYr | İnt | İnt | Kart Yıl Tarihi |
| CreditCardTypeID | İnt | 50 | Kart Numarası |
| BillingAddress | Nvarchar | MAX | Fatura Adresi |
| BillingCity | Nvarchar | 50 | Fatura Şehri |
| BillingCountry | Nvarchar | 50 | Fatura Ülkesi |
| BillingPostalCode | Nvarchar | 50 | Fatura Posta Kodu |
| ShipAddress | Nvarchar | MAX | Gönderenin Adresi |
| ShipCity | Nvarchar | 50 | Gönderenin Şehri |
| ShipPostalCode | Nvarchar | 50 | Gönderenin Posta Kodu |
| ShipCountry | nvarchar | 50 | Gönderenin Ülkesi |
| RegistrationDate | datetime | datetime | Kayıt Tarihi |



## Orders Tablosu

| Değişken Adı | Veri Tipi | Uzunluk | Açıklama |
| --- | --- | --- | --- |
| OrderID | İnt |   | Sipariş ID Numarası |
| CustomerID | İnt |   | Müşteri ID Numarası |
| PaymentID | İnt |   | Ödeme ID Numarası |
| OrderNumber | Bigint |   | Sipariş Numarası |
| OrderDate | Datetime |   | Sipariş Tarihi |
| ShipDate | Datetime |   | Kargo Tarihi |
| ShipperID | İnt |   | Kargo ID Numarası |
| Freight | Money |   | Kargo Ücreti |
| SalesTax | Money |   | Satış Vergisi |
| FulFilled | Bit |   | Sipariş Tamamlandı mı? |
| Deleted | Bit |   | Silindi mi? |
| PaymentDate | Datetime |   | Ödeme Tarihi |
| Paid | Money |   | Fiyatı |
| TransactStatus | Nvarchar | 50 | Kredi Kartı İşlem Onayı |
| ErrLoc | Nvarchar | 50 | Kredi Kartı İşlem Onayı |
| ErrMsg | nvarchar | 250 | Kredi Kartı İşlem Onayı |



## OrderDetail Tablosu

| Değişken Adı | Veri Tipi | Uzunluk | Açıklama |
| --- | --- | --- | --- |
| OrderDetailID | İnt |   | Sipariş Detayı ID Numarası |
| ProductID | İnt |   | Ürün ID Numarası |
| OrderID | İnt |   | Sipariş ID Numarası |
| OrderNumber | Bigint |   | Sipariş Numarası |
| Price | İnt |   | Fiyat |
| Quantity | İnt |   | Adet |
| Discount | İnt |   | İndirim Yüzdesi |
| Total | İnt |   | Toplam Fiyat |
| Size | Nvarchar | 50 | Boyut |
| Color | Nvarchar | 50 | Renk |
| FulFilled | Bit |   | Sipariş Tamamlandı mı? |
| ShipDate | Datetime |   | Kargo Tarihi |
| BillDate | datetime |   | Fatura Tarihi |







## Suppliers Tablosu

| Değişken Adı | Veri Tipi | Uzunluk | Açıklama |
| --- | --- | --- | --- |
| SupplierID | İnt |   | Satıcı ID Numarası |
| CompanyName | nvarchar | 50 | Şirket Adı |
| ContactFName | Nvarchar | 50 | Satıcı İsmi |
| ContactLName | Nvarchar | 50 | Satıcı Soyismi |
| Address1 | Nvarchar | MAX | Adres 1 |
| Address2 | Nvarchar | MAX | Adres 2 |
| City | Nvarchar | 50 | Şehir |
| PostalCode | Nvarchar | 50 | Posta Kodu |
| Country | Nvarchar | 50 | Ülke |
| Phone | Nvarchar | 50 | Telefon |
| Fax | Nvarchar | 50 | Fax |
| Email | Nvarchar | 50 | Mail Adresi |
| Website | Nvarchar | 50 | Website Adresi |
| DiscountType | Nvarchar | 50 | İndirim Tipi |
| DiscountRate | İnt | İnt | İndirim Oranı |
| DiscountAvailable | Bit | Bit | İndirim Var mı? |
| CustomerID | İnt | İnt | Müşteri ID Numarası |
| Logo | Nvarchar | MAX | Resim/Logo |
| Note | nvarchar | MAX | Açıklama |

## Complaints Tablosu

| Değişken Adı | Veri Tipi | Uzunluk | Açıklama |
| --- | --- | --- | --- |
| ComplaintID | int |   | Şikayet Id |
| Title | String | 50 | Şikayet Başlığı |
| CustomerID | İnt |   | Kullanıcı Id |
| Description | string | MAX | Açıklama |
| CreatedDate | datetime |   | Oluşturulma Tarihi |

## Roles Tablosu

| Değişken Adı | Veri Tipi | Uzunluk | Açıklama |
| --- | --- | --- | --- |
| Id | int |   | Rol Id |
| RoleName | String | 50 | Rol Adı |

# Veri Tabanı Tasarımı
![veri tabani er diyagrami2](https://user-images.githubusercontent.com/24482512/51867201-ea374e80-235b-11e9-84b6-cda2c5ba37a6.PNG)

# Use Case Diyagramları
## Admin Use Case
![adminusecaseresim](https://user-images.githubusercontent.com/24482512/51867588-ed7f0a00-235c-11e9-85ae-252919797036.png)

## Müşteri Use Case
![musteriusecaseresim](https://user-images.githubusercontent.com/24482512/51867629-08ea1500-235d-11e9-9f63-67abdde4157e.png)

## Satıcı Use Case
![saticiusecaseresim](https://user-images.githubusercontent.com/24482512/51867691-27e8a700-235d-11e9-8620-dd8333f3369c.png)

# Projeye Başlamadan Önce Yaptığım Mockup Örnekleri
## Üye İşlemleri
![uye islemleri](https://user-images.githubusercontent.com/24482512/51867849-99c0f080-235d-11e9-95c1-0bbc80b3c45f.png)
## Admin ve Anasayfa 
![admin ve e ticaret](https://user-images.githubusercontent.com/24482512/51867888-ad6c5700-235d-11e9-972c-2f47e1317cb7.png)



# Arayüz


![eticaret1](https://user-images.githubusercontent.com/24482512/51867019-8ca30200-235b-11e9-9eb9-45917cd62101.png)
![eticaret2](https://user-images.githubusercontent.com/24482512/51867020-8ca30200-235b-11e9-81ed-1d34bd748c29.png)
![eticaret3](https://user-images.githubusercontent.com/24482512/51867021-8d3b9880-235b-11e9-9f8d-d73371ee2849.png)
![eticaret4](https://user-images.githubusercontent.com/24482512/51867022-8d3b9880-235b-11e9-9c31-f331d85d053a.png)

# Admin Paneli
![eticaret5](https://user-images.githubusercontent.com/24482512/51867023-8d3b9880-235b-11e9-8abb-b76500afbcd3.png)
