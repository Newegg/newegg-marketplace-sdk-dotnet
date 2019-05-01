using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newegg.Marketplace.SDK.Base.Util
{
    public class CommonManager
    {

        public static string DealDateFrom(string dateFrom)
        {
            string maxDateTimeStr = "2199-01-01";
            string minDateTimeStr = "1753-01-01";

            if (string.IsNullOrWhiteSpace(dateFrom))
                return minDateTimeStr;

            DateTime time = DateTime.MinValue;

            try
            {
                time = DateTime.Parse(dateFrom);
            }
            catch (System.Exception e)
            {
                throw new Exception.InvalidValueException("CE003", e);//TODO
            }

            if (time > DateTime.Parse(maxDateTimeStr))
                return maxDateTimeStr;
            else if (time < DateTime.Parse(minDateTimeStr))
                return minDateTimeStr;

            return time.ToString("yyyy-MM-dd HH:mm:ss");
        }



        public static string DealDateTo(string dateTo)
        {
            string maxDateTimeStr = "2199-01-01";
            string minDateTimeStr = "1753-01-01";
            if (string.IsNullOrWhiteSpace(dateTo))
                return maxDateTimeStr;

            DateTime time = DateTime.MaxValue;

            try
            {
                time = DateTime.Parse(dateTo);
                if (time == DateTime.MinValue)
                    return maxDateTimeStr;
            }
            catch (System.Exception e)
            {
                throw new Exception.InvalidValueException("CE003", e);//TODO
            }

            if (time > DateTime.Parse(maxDateTimeStr))
                return maxDateTimeStr;
            else if (time < DateTime.Parse(minDateTimeStr))
                return minDateTimeStr;


            if (time.Hour == 0 && time.Minute == 0 && time.Second == 0 && time.Millisecond == 00)
                time = time.AddDays(1).AddMilliseconds(-1);
            string returnVal = time.ToString("yyyy-MM-dd HH:mm:ss");
            return returnVal + "";
        }

        public static string ToXmlEnumString<TEnum>(TEnum value) where TEnum : struct, IConvertible
        {
            Type enumType = typeof(TEnum);
            if (!enumType.IsEnum)
                return null;

            System.Reflection.MemberInfo member = enumType.GetMember(value.ToString()).FirstOrDefault();
            if (member == null)
                return null;

            System.Xml.Serialization.XmlEnumAttribute xmlEnumAttribute = member.GetCustomAttributes(false).OfType<System.Xml.Serialization.XmlEnumAttribute>().FirstOrDefault();
            if (xmlEnumAttribute == null)
                return member.Name;

            return xmlEnumAttribute.Name;
        }

        public static T GetXmlEnum<T>(string MapID) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enum");
            }
            var members = typeof(T).GetMembers();
            var map = new Dictionary<string, T>();
            foreach (var member in members)
            {
                var enumAttrib = member.GetCustomAttributes(typeof(System.Xml.Serialization.XmlEnumAttribute), false).FirstOrDefault() as System.Xml.Serialization.XmlEnumAttribute;
                if (enumAttrib == null)
                {
                    continue;
                }
                var xmlEnumValue = enumAttrib.Name;
                var enumVal = ((System.Reflection.FieldInfo)member).GetRawConstantValue();
                map.Add(xmlEnumValue, (T)enumVal);
            }
            return map[MapID];
        }
    }

    public static class StringExtension
    {
        public static string ToStringWithNonSpace(this object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            return obj.ToString().Trim();
        }
    }
}
