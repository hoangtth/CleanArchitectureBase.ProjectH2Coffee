using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Domain.Helpers
{
    public struct ErrorMessage
    {
        public const string Exists = "{0} đã tồn tại";
        public const string NotExists = "{0} không tồn tại";
        public const string PropertyRequired = "{0} là bắt buộc";
        public const string NotFound = "Không tìm thấy {0}";
        public const string Completed = "{0} đã hoàn thành. không thể thực hiện hành động !";
        public const string Deleted = "{0} đã xóa !";
        public const string Cancelled = "{0} đã hủy. Không thể thực hiện hành động !";
        public const string SmallerThan = "{0} nhỏ hơn {1}";
        public const string BiggerThan = "{0} lớn hơn {1}";
        public const string Processing = "{0} đang thực hiện. không thể thực hiện hành động";
        public const string Cancel = "{0} đã hủy. Không thể thực hiện hành động";
        public const string TextFormat = "{0} chưa đúng định dạng !";
        public const string TextDuplicate = "{0} không được trùng với {1} !";
        public const string PhoneLenght = "{0} bắt buộc phải 10 số.";
        public const string PhoneNotSupport = "Đầu số {0} hiện tại chưa được hỗ trợ online.";
        public const string CharInRange = "{0} từ {1} đến {2} ký tự.";
        public const string UnableAction = "{0} không thể thực hiện hành động!";
        public const string UnableStatus = "{0} không thể cập nhật!";
        public const string RequiredLogin = "Vui lòng đăng nhập để sử dụng dịch vụ.";
        public const string ExpiredTransaction = "Phiên làm việc hết hiệu lực!";
        public const string LoginOtherDevice = "Đăng nhập bằng thiết bị khác cần xác thực lại!";
        public const string NotChangePassword = "Thiết bị không có quyền thay đổi mật khẩu!";
        public const string NotSupport = "{0} không được hỗ trợ!";
    }

    public struct JwtConstant
    {
        public const string KeyUserId = @"uid";
        public const string KeyUsername = @"unique_name";
        public const string KeyUserType = @"utp";
        public const string KeyCifCode = @"username";
    }

    public struct PagingDefault
    {
        public const int PageIndex = 1;
        public const int PageSize = 25;
    }
}
