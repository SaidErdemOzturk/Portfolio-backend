using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public class Messages
    {
        public static string PasswordError = "Girdiğiniz şifre yanlıştır.";
        public static string SuccessfulLogin = "Giriş başarılı.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string? AuthorizationDenied = "Yetkisiz işlem";
        public static string UserAlreadyExists = "Bu email ile zaten bir kullanıcı mevcut.";
        public static string AccessTokenCreated = "Token oluşturuldu.";
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserRegistered = "Kullanıcı kayıt oldu.";
    }
}
