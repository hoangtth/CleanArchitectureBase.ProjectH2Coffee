using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Domain.Helpers
{
    public static class EnumHelper
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            if(Attribute.GetCustomAttribute(field,typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                return attribute.Description;
            return null;
        }

        public static T ParseEnumByName<T>(this Enum enumValue) where T : struct
        {
            string[] itemEnum = Enum.GetNames(typeof(T));
            var name = itemEnum.SingleOrDefault(p => p == enumValue.ToString());
            return Enum.TryParse<T>(name, true, out T result) ? result : default;
        }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum EStatus
    {
        Inactive = 0,
        Active = 1,
    }

    public enum ECode
    {
        None,
        Success,
        InternalServerError,
        CIFNotExisted,
        RefIdNotExisted,
        InvalidOTP,
        UserBlocked,
        UserNotFound,
        UserClosed,
        InvalidPassword,
        InvalidCredentials,
        RequireChangePasscode,
        PasswordAttemptsExceeded,
        CifCodeExist,
        PhoneNumberExist,
        UserNameExist,
        Processing,
        BadRequest,
        Unauthorized,
        PasscodeExpired,
        PasscodeExpiredActive,
        ResourceNotFound,
        ServerError,
        DeviceIdError,
        DeviceOther,
        TimeOut,
        KeyAuthenError,
        InvalidVerifyLoan,
        ExpiredTransaction,
        RequireChangePasscodeActive,
        NotExistPilotOnboarding,
        CustomerNotFound
    }
}
