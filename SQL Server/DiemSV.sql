create DATABASE DIEMDOANCK1
USE DIEMDOANCK1
--INSERT INTO SinhVien (MaSV,TenSV,Gioitinh,Tuoi,Diachi,SDT,Email,NgayThangNamsinh,Lop,Khoa,Nganh),@MaSV, @TenSV, @Gioitinh, @Tuoi,@Diachi,@SDT,@Email,@NgayThangNamsinh,@Lop,@Khoa,@Nganh
create table SinhVien
(
	MaSV nchar(10) primary key,
	TenSV nvarchar(150),
	Gioitinh nvarchar(15),
	Tuoi int,
	Diachi nvarchar(150),
	SDT nchar(11),
	Email nchar(50),
	NgayThangNamsinh datetime,
	Lop nchar(10),
	Khoa nchar(10),
	Nganh nchar(10)
)
--"INSERT INTO MonHoc (MaMH, TenMH, SoTinChi, Hocky,NienKhoa,magv,makhoa) VALUES (@MaMH, @TenMH, @SoTinChi, @Hocky,@NienKhoa,@magv,@makhoa)"
create table MonHoc
(
	MaMH nchar(10) primary key,
	TenMH nvarchar(100),
	SoTinChi int check (SoTinChi >0),
	Hocky nchar(10),
	NienKhoa nvarchar(100),
	magv nchar(10),
	makhoa nchar(10)
)
--"INSERT INTO Diem (MaSV,TenSV,MaMH,TenMH,DiemCC,DiemKT,DiemTH,DiemTB,DGHS) VALUES (@MaSV,@TenSV,@MaMH,@TenMH,@DiemCC,@DiemKT,@DiemTH,@DiemTB,@DGHS)"
create table Diem
(
	MaSV nchar(10),
	TenSV nvarchar(150),
	MaMH nchar(10),
	TenMH nvarchar(150),
	DiemCC float check (DiemCC>=0 and DiemCC<=10),
	DiemKT float check (DiemKT>=0 and DiemKT<=10),
	DiemTH float check (DiemTH>=0 and DiemTH<=10),
	DiemTB float check (DiemTB>=0 and DiemTB<=10),
	DGHS nvarchar(100)
)
--"INSERT INTO GiaoVien (magv,tengv, makhoa, tenkhoa,mabm,tenbm,cocnlopkhong,malopchunhiem,sodienthoai,email,diachi) VALUES (@magv,@tengv,@makhoa,@tenkhoa,@mabm,@tenbm,@cocnlopkhong,@malopchunhiem,@sodienthoai,@email,@diachi)"
create table GiaoVien
(
	magv nchar(10) primary key,
	tengv nvarchar(100),
	makhoa nchar(10),
	tenkhoa nvarchar(100),
	cocnlopkhong nvarchar(10),
	malopchunhiem nvarchar(10),
	sodienthoai nchar(11),
	email nchar(100),
	diachi nvarchar(100)
)
--"INSERT INTO Khoa (makhoa,tenkhoa, soluongbm, soluonggv,soluongsv,soluongmh,soluongnganh,soluonglop) VALUES (@makhoa,@tenkhoa, @soluongbm, @soluonggv,@soluongsv,@soluongmh,@soluongnganh,@soluonglop)"
create table Khoa
(
	makhoa nchar(10) primary key,
	tenkhoa nvarchar(100),
	soluongbm int check (soluongbm>0),
	soluonggv int check (soluonggv>0),
	soluongsv int check (soluongsv>0),
	soluongmh int check (soluongmh>0),
	soluongnganh int check (soluongnganh>0),
	soluonglop int check (soluonglop>0)
)
--"INSERT INTO Nganh (manganh,tennganh) VALUES (@manganh,@tennganh)"
create table Nganh
(
	manganh nchar(10) primary key,
	tennganh nvarchar(100)
)
