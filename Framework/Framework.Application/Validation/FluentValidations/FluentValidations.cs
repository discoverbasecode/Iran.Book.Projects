using FluentValidation;
using Framework.Application.FileUtil;
using Framework.Application.SecurityUtil;
using Framework.Domain;
using Microsoft.AspNetCore.Http;

namespace Framework.Application.Validation.FluentValidations;
public static class FluentValidations
{
    /// <summary>
    /// اعتبارسنجی تصویر
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    /// <param name="ruleBuilder"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static IRuleBuilderOptionsConditions<T, TProperty> JustImageFile<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string errorMessage = "شما فقط قادر به وارد کردن عکس میباشید") where TProperty : IFormFile?
    {
        return ruleBuilder.Custom((file, context) =>
        {
            if (file != null && !ImageValidator.IsImage(file))
            {
                context.AddFailure(errorMessage); // افزودن خطا به context
            }
        });
    }

    /// <summary>
    /// اعتبارسنجی کد ملی
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ruleBuilder"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static IRuleBuilderOptionsConditions<T, string> ValidNationalId<T>(this IRuleBuilder<T, string> ruleBuilder, string errorMessage = "کدملی نامعتبر است")
    {
        return ruleBuilder.Custom((nationalCode, context) =>
        {
            if (!IranianNationalIdChecker.IsValid(nationalCode))
                context.AddFailure(errorMessage);
        });
    }

    /// <summary>
    /// اعتبارسنجی شماره تلفن
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ruleBuilder"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static IRuleBuilderOptionsConditions<T, string> ValidPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder, string errorMessage = ValidationMessages.InvalidPhoneNumber)
    {
        return ruleBuilder.Custom((phoneNumber, context) =>
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length != 11)
                context.AddFailure(errorMessage);
        });
    }

    /// <summary>
    /// اعتبارسنجی فایل معتبر
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    /// <param name="ruleBuilder"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static IRuleBuilderOptionsConditions<T, TProperty> JustValidFile<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string errorMessage = "فایل نامعتبر است") where TProperty : IFormFile
    {
        return ruleBuilder.Custom((file, context) =>
        {
            if (file != null && !FileValidation.IsValidFile(file))
            {
                context.AddFailure(errorMessage); // افزودن خطا به context
            }
        });
    }

}