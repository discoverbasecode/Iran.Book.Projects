namespace Framework.Application.MessegeUtils;

public static class TemplateMessages
{
    public static string invalidNationalCode = " کد ملی معتبر نیست";
    public const string Required = "وارد کردن این فیلد اجباری است";
    public const string InvalidPhoneNumber = "شماره تلفن نامعتبر است";
    public const string NotFound = "اطلاعات درخواستی یافت نشد";
    public const string MaxLength = "تعداد کاراکتر های وارد شده بیشتر از حد مجاز است";
    public const string MinLength = "تعداد کاراکتر های وارد شده کمتر از حد مجاز است";
    public const string InvalidEmail = "ایمیل وارد شده معتبر نیست";
    public const string InvalidPassword = "پسورد وارد شده معتبر نیست";
    public const string InvalidDate = "تاریخ وارد شده معتبر نیست";
    public const string InvalidFileType = "نوع فایل انتخاب شده معتبر نیست";
    public const string InvalidUsername = "نام کاربری معتبر نیست";
    public const string NotEmpty = "این فیلد نمی‌تواند خالی باشد";
    public const string InvalidCreditCard = "شماره کارت اعتباری معتبر نیست";
    public const string MismatchedPasswords = "پسوردها با هم تطابق ندارند";
    public const string InvalidZipCode = "کد پستی معتبر نیست";
    public const string TooManyRequests = "تعداد درخواست‌ها بیش از حد مجاز است";
    public const string Unauthorized = "دسترسی مجاز نیست";
    public const string InvalidUrl = "آدرس اینترنتی معتبر نیست";
    public const string InvalidName = "نام وارد شده معتبر نیست";

    public static string required(string field) => $"{field} اجباری است.";
    public static string maxLength(string field, int maxLength) => $"{field} باید کمتر از {maxLength} کاراکتر باشد.";
    public static string minLength(string field, int minLength) => $"{field} باید بیشتر از {minLength} کاراکتر باشد.";
    public static string invalidPhoneNumber(string phone) => $"شماره تلفن {phone} نامعتبر است.";
    public static string invalidEmail(string email) => $"ایمیل {email} معتبر نیست.";
    public static string invalidPassword(string password) => $"پسورد {password} معتبر نیست.";
    public static string invalidDate(string date) => $"تاریخ {date} معتبر نیست.";
    public static string invalidFileType(string fileType) => $"نوع فایل {fileType} معتبر نیست.";
    public static string invalidUsername(string username) => $"نام کاربری {username} معتبر نیست.";
    public static string notEmpty(string field) => $"{field} نمی‌تواند خالی باشد.";
    public static string invalidCreditCard(string cardNumber) => $"شماره کارت اعتباری {cardNumber} معتبر نیست.";
    public static string mismatchedPasswords() => "پسوردها با هم تطابق ندارند.";
    public static string invalidZipCode(string zipCode) => $"کد پستی {zipCode} معتبر نیست.";
    public static string tooManyRequests() => "تعداد درخواست‌ها بیش از حد مجاز است.";
    public static string unauthorized() => "دسترسی مجاز نیست.";
    public static string invalidUrl(string url) => $"آدرس اینترنتی {url} معتبر نیست.";
    public static string invalidName(string name) => $"نام {name} معتبر نیست.";
}