using UnityEngine;

namespace CommonTools.Logging
{
    public class BeautyLog
    {
        private readonly string _header;
        private readonly string _hexColor;

        public BeautyLog(string header, Color color)
        {
            _header = header;
            _hexColor = ColorUtility.ToHtmlStringRGB(color);
        }

        public void Log(string message)
        {
            Debug.Log($"<color=#{_hexColor}>{_header}:</color> {message}");
        }
    }
}
