Create database Organic
GO

Use Organic
Go

Create table PhanQuyen
(
	IDQuyen int not null primary key,
	TenQuyen nvarchar(50)
)

insert into PhanQuyen
Values(1, N'admin'),
	  (2, N'user')

Create table NguoiDung
(
	MaNguoiDung int Identity(1, 1) not null primary key,
	IDQuyen int,
	HoTen nvarchar(100),
	NgaySinh datetime,
	SoDienThoai nvarchar(15),
	GioiTinh nvarchar(10),
	DiaChi nvarchar(max),
	Email nvarchar(50),
	MatKhau nvarchar(15),
	constraint fk_IDQuyen_NguoiDung foreign key (IDQuyen) references PhanQuyen(IDQuyen)
)
set dateformat dmy
insert into NguoiDung(IDQuyen, HoTen, NgaySinh, SoDienThoai, GioiTinh, DiaChi, Email, MatKhau)
values( 2, N'Trần Minh Nhựt','12/11/2002', N'0123456789', N'Nam', N'Hồ Chí Minh', N'tmn12112002@gmail.com', N'123456')
	  
set dateformat dmy
insert into NguoiDung(IDQuyen, HoTen, NgaySinh, SoDienThoai, GioiTinh, DiaChi, Email, MatKhau)
values(1, N'Admin là tôi', '12/11/2002', N'0937187003', N'Nam', N'Hồ Chí Minh', N'Admin@gmail.com', N'0123456')

select * from NguoiDung

Create table NhaCungCap
(
	MaNCC int Identity(1, 1) not null primary key,
	TenNCC nvarchar(50),
	DiaChi nvarchar(max),
	SDT nvarchar(12)
)

insert into NhaCungCap(TenNCC, DiaChi, SDT)
values (N'Công Ty TNHH Nông Sản Thủ Đức', N'Thủ Đức', N'0123456789'),
	   (N'Công Ty TNHH MTV Nông Sản Nội Bài', N'Hà Nội', N'0321654987')
Create table Loai
(
	IDLoai int Identity(1, 1) not null primary key,
	TenLoai nvarchar(100),
	MaNCC int
	constraint fk_MaNCC_NhaCungCap foreign key(MaNCC) references NhaCungCap(MaNCC)
)
Insert into Loai (TenLoai, MaNCC)
Values( N'Trái Cây Miền Nam', 1),
	  ( N'Trái Cây Miền Trung', 1),
	  ( N'Trái Cây Miền Bắc', 2),
	  ( N'Trái Cây Nhập Khẩu', 2)
select* from Loai


Create table SanPham
(
	MaSanPham int Identity(1, 1) not null primary key,
	TenSanPham nvarchar(50),
	HinhAnh nvarchar(20),
	GiaTien decimal,
	MoTa nvarchar(max),
	SoLuong int,
	IDLoai int,
	constraint fk_IDLoai_SanPham foreign key(IDLoai) references Loai(IDLoai)
)

insert into SanPham (TenSanPham, HinhAnh, GiaTien, MoTa, SoLuong, IDLoai)
Values ( N'Táo Đỏ', N'01.jpg', 20000, N'Táo đỏ là một loại quả có nguồn gốc từ họ Rosaceae, với màu sắc thường là hồng, đỏ hoặc hồng đậm. Quả táo đỏ có hương vị ngọt ngào và thường được sử dụng tươi hoặc trong các món ăn và thức uống.Chức năng của táo đỏ là cung cấp dinh dưỡng và vitamin cho cơ thể, đặc biệt là vitamin C và chất xơ. Nó giúp tăng cường hệ miễn dịch, duy trì sức khỏe tim mạch và hỗ trợ quá trình tiêu hóa. Táo đỏ cũng chứa chất chống oxy hóa, có thể giúp giảm nguy cơ mắc một số bệnh mãn tính.',300, 4),
	   ( N'Chuối', N'02.jpg', 10000, N'Chuối là loại quả vỏ màu vàng/xanh lá cây, thịt ngọt mềm. Cung cấp năng lượng, vitamin, khoáng chất, tốt cho sức khỏe tim mạch, hỗ trợ tiêu hóa.',1000, 2),
	   ( N'Xoài', N'03.jpg', 15000,N'Xoài là một loại quả có vỏ mỏng, màu sắc thường là vàng hoặc xanh, thịt quả mềm và ngọt ngào. Chức năng của xoài là cung cấp vitamin A, vitamin C và chất xơ, tăng cường miễn dịch, bảo vệ mắt và hỗ trợ tiêu hóa.',400, 2),
	   ( N'Mận Hà Nội',N'04.jpg', 35000,N'Mận Hà Nội là một giống mận đặc biệt của Việt Nam, có màu đỏ tươi, thịt quả mềm mịn và ngọt ngào. Chức năng của mận Hà Nội là cung cấp vitamin C, chất chống oxi hóa và chất xơ, hỗ trợ sức khỏe tim mạch, giảm nguy cơ mắc bệnh và tăng cường hệ miễn dịch.',1000, 3 ),
	   ( N'Dâu Tây', N'05.jpg', 60000, N'Dâu tây là loại quả nhỏ, hình tròn và màu đỏ tươi. Thịt quả mềm mịn, ngọt ngào và có hương vị đặc trưng. Chức năng của dâu tây là cung cấp nhiều vitamin C, chất chống oxy hóa và chất xơ, hỗ trợ hệ miễn dịch, giảm nguy cơ mắc bệnh và có lợi cho sức khỏe tim mạch.',1500, 1),
	   ( N'Sầu Riêng', N'06.jpg', 85000, N'Sầu riêng là một loại quả có vỏ nâu gai, thịt quả mềm, màu trắng và có mùi thơm đặc trưng. Quả sầu riêng thường có hương vị ngọt đậm và độc đáo. Chức năng của sầu riêng là cung cấp năng lượng, vitamin C và chất xơ, hỗ trợ hệ tiêu hóa và tăng cường sức khỏe da.',600,1),
	   ( N'Dưa Lưới', N'07.jpg', 50000, N'Dưa lưới là loại quả có vỏ màu xanh nhạt hoặc trắng với các đường gân dọc vàng nhạt. Thịt quả mềm, mọng nước và có hương vị ngọt ngào. Chức năng của dưa lưới là cung cấp nước và khoáng chất, giúp giữ cho cơ thể được cân bằng nước và duy trì sự mát mẻ trong những ngày nóng.',750, 2),
	   ( N'Ổi Xá Lị', N'08.jpg', 26000, N'Ổi xá lị là một loại cây ổi có trái nhỏ, hình cầu với màu sắc từ xanh đến vàng. Thịt quả mềm mịn, có hương vị độc đáo, hậu ngọt và chua. Chức năng của ổi xá lị là cung cấp nhiều vitamin C, chất xơ và chất chống oxy hóa, hỗ trợ hệ miễn dịch, duy trì sức khỏe da và giảm nguy cơ mắc bệnh.',1305, 4),
	   ( N'Nho', N'09.jpg', 180000, N'Nho là quả nhỏ, tròn có màu tím, xanh hoặc đỏ. Thịt quả mềm mịn và hương vị ngọt ngào. Chức năng của nho là cung cấp nhiều vitamin, chất chống oxy hóa và chất xơ, giúp bảo vệ sức khỏe tim mạch, hỗ trợ hệ miễn dịch và duy trì sức khỏe tốt.',600, 4),
	   ( N'Dưa Hấu', N'10.jpg', 20000, N'Dưa hấu là quả hình cầu có vỏ màu xanh, thịt quả mềm, mọng nước và ngọt ngào. Chức năng của dưa hấu là cung cấp nước và vitamin C, giúp giảm nhiệt độ cơ thể, giải khát và làm dịu cảm giác mệt mỏi trong những ngày nóng.',5000,1),
	   ( N'Quả Cà Chua', N'18.jpg', 50000, N'Quả cà chua có màu đỏ, hình cầu và thịt mềm. Chức năng của quả cà chua là cung cấp vitamin C, chất chống oxy hóa và lycopene, giúp bảo vệ tim mạch, chống viêm nhiễm và duy trì làn da khỏe mạnh',3000, 3)
	  
select * from NguoiDung

Create table DonHang
(
	MaDonHang int Identity(1, 1) not null primary key,
	MaNguoiDung int,
	NgayDat datetime,
	ThanhToan int,
	TinhTrangGiaoHang int,
	TongTien decimal,
	DiaChiNhanHang nvarchar(max)
	constraint fk_MaNguoiDung_DonHang foreign key (MaNguoiDung) references NguoiDung(MaNguoiDung)
)

Create table ChiTietDonHang
(
	MaDonHang int not null,
	MaSanPham int not null,
	SoLuong int,
	DonGia decimal,
	ThanhTien decimal,
	PhuongThucThanhToan int,
	constraint pk_ChiTietDonHang primary key(MaDonHang, MaSanPham),
	constraint fk_MaDonHang_ChiTietDonHang foreign key (MaDonHang) references DonHang(MaDonHang),
	constraint fk_MaSanPham_ChiTietDonHang foreign key (MaSanPham) references SanPham(MaSanPham)
)

select TenLoai, TenSanPham, GiaTien, SanPham.HinhAnh from Loai, SanPham where SanPham.IDLoai=Loai.IDLoai


set dateformat dmy
insert into NguoiDung(IDQuyen, HoTen, NgaySinh, SoDienThoai, GioiTinh, DiaChi, Email, MatKhau)
values(2, N'Đinh Thị C', '10/01/2002', N'0123654987', N'Nữ', N'Hồ Chí Minh', N'CDinhThi@gmail.com', N'0123456')

insert into SanPham (TenSanPham, HinhAnh, GiaTien, MoTa,SoLuong, IDLoai)
Values ( N'Chôm Chôm', N'25.jpg', 20000, N'Táo đỏ là một loại quả có nguồn gốc từ họ Rosaceae, với màu sắc thường là hồng, đỏ hoặc hồng đậm. Quả táo đỏ có hương vị ngọt ngào và thường được sử dụng tươi hoặc trong các món ăn và thức uống.Chức năng của táo đỏ là cung cấp dinh dưỡng và vitamin cho cơ thể, đặc biệt là vitamin C và chất xơ. Nó giúp tăng cường hệ miễn dịch, duy trì sức khỏe tim mạch và hỗ trợ quá trình tiêu hóa. Táo đỏ cũng chứa chất chống oxy hóa, có thể giúp giảm nguy cơ mắc một số bệnh mãn tính.',6000,  2)

select TenNCC, TenLoai, TenSanPham, SoLuong from Loai, NhaCungCap, SanPham where TenSanPham=N'Chôm Chôm'