using UnityEngine;

namespace CommonTools.Extensions
{
    public static class StringExtensions
    {
        public static string B(this string obj)
        {
            return $"<b>{obj}</b>";
        }
        
        public static string I(this string obj)
        {
            return $"<i>{obj}</i>";
        }
        
        public static string Size(this string obj, int size)
        {
            return $"<size={size}>{obj}</size>";
        }
        
        public static string Color(this string obj, Color color)
        {
            return $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{obj}</color>";
        }
    }
}