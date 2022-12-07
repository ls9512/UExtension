/////////////////////////////////////////////////////////////////////////////
//
//  How to use :	emailSettings
//					.Validate(setting => setting.UserName.Length < 12, "User is too long" )
//					.Validate(setting => setting.Password.Length > 12, "User is too short")
//					.Validate(setting => setting.Pop3Server != "pop.live.com", "Don't support pop.live.com")
//					.ErrorsList
//					.ForEach(Console.WriteLine);
//
/////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;

namespace Aya.Extension
{
    public static class ValidateExtension
    {
        public static ValidateResult<T> Validate<T>(this T target, Predicate<T> predicate, string errorMessage)
        {
            var result = new ValidateResult<T>(target);
            if (!predicate(target))
            {
                result.Errors.Add(errorMessage);
            }

            return result;
        }

        public static ValidateResult<T> Validate<T>(this ValidateResult<T> target, Predicate<T> predicate, string errorMessage)
        {
            if (!predicate(target.Entity))
            {
                target.Errors.Add(errorMessage);
            }

            return target;
        }

        public class ValidateResult<T>
        {
            internal List<string> Errors { get; set; }
            internal T Entity { get; private set; }

            internal ValidateResult(T entity)
            {
                Errors = new List<string>();
                Entity = entity;
            }

            public string[] ErrorsArray => Errors.ToArray();
            public List<string> ErrorsList => Errors;
        }
    }
}