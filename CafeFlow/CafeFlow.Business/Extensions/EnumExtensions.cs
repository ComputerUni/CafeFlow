using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace CafeFlow.Business.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            return value.GetType().GetMember(value.ToString()).FirstOrDefault()?.GetCustomAttribute<DisplayAttribute>()?.Name ?? value.ToString();
        }
    }
}
