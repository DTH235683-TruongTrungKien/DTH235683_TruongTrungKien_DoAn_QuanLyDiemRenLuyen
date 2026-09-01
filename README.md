# Quản Lý Điểm Rèn Luyện (QLDRL)

Đây là dự án phần mềm Quản lý Điểm rèn luyện dành cho sinh viên. Ứng dụng được phát triển dưới dạng Windows Forms (WinForms) sử dụng .NET và Entity Framework Core với cơ sở dữ liệu SQL Server.

## Yêu cầu hệ thống
- **.NET SDK** (phiên bản tương thích với dự án, thường là .NET 6/7/8).
- **SQL Server** (hoặc SQL Server Express).
- **Visual Studio 2022** (hoặc các IDE hỗ trợ .NET WinForms).

## Hướng dẫn cài đặt và sử dụng

### 1. Cấu hình Cơ sở dữ liệu (Database)
- Mở SQL Server Management Studio (SSMS) và đảm bảo SQL Server của bạn đang hoạt động.
- Mở file `DRLManagement/App.config`.
- Tìm thẻ `<connectionStrings>` và cập nhật `connectionString` cho phù hợp với máy của bạn. Thiết lập mặc định là:
  ```xml
  Server=.\MSSQLSERVER01;Database=QLDRL;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True
  ```
  *(Bạn có thể đổi `.\MSSQLSERVER01` thành `.` hoặc `.\SQLEXPRESS` hoặc tên instance SQL Server tương ứng trên máy tính của bạn).*

### 2. Khởi chạy ứng dụng
- Mở Solution `QLDRL.sln` bằng Visual Studio.
- Nhấp chuột phải vào Solution chọn **Restore NuGet Packages** (nếu IDE không tự động restore).
- (Tuỳ chọn) Bạn có thể cần chạy Migration để tạo các bảng trong Database. Mở **Package Manager Console** và chạy lệnh:
  ```powershell
  Update-Database
  ```
- Nhấn `F5` hoặc nút **Start** để chạy ứng dụng (chọn project mặc định là `DRLManagement`).
- **Lưu ý quan trọng:** Lần đầu tiên chạy, hệ thống sẽ tự động gọi `DbSeeder` để khởi tạo dữ liệu mẫu mặc định như: Thông tin trường, Phân quyền (Role), Người dùng (User), Học kỳ, Sự kiện, v.v.

### 3. Đăng nhập
Sau khi ứng dụng khởi chạy và thêm dữ liệu mẫu thành công, bạn có thể đăng nhập bằng các tài khoản mặc định.
*(Vui lòng tham khảo file `DRLManagement/Services/DbSeeder.cs` để lấy tài khoản/mật khẩu đăng nhập dành cho Admin/Student/Manager).*

## Cấu trúc dự án
- `DRLManagement/`: Thư mục chính chứa mã nguồn.
  - `Models/`: Các định nghĩa lớp (Entity) cho Database.
  - `Data/`: `AppDbContext` quản lý kết nối và Entity Framework.
  - `Services/`: Các lớp xử lý logic, nghiệp vụ, và Seeder dữ liệu mẫu.
  - `Presentation/`: Các Giao diện (Form, UserControl) được phân chia rõ ràng theo từng phân hệ người dùng (Admin, Manager, Organizer, Student).
