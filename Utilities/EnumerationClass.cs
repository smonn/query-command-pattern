using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SampleEntityFramework.Utilities
{
    public abstract class Enumeration : IComparable
    {
        private readonly int _value;
        private readonly string _displayName;

        protected Enumeration() { }

        protected Enumeration(int value, string displayName)
        {
            _value = value;
            _displayName = displayName;
        }

        public int Value
        {
            get { return _value; }
        }

        public string DisplayName
        {
            get { return _displayName; }
        }

        public override string ToString()
        {
            return DisplayName;
        }

        public static IEnumerable<TEnum> GetAll<TEnum>() where TEnum : Enumeration, new()
        {
            var type = typeof(TEnum);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return (from info in fields
                    let instance = new TEnum()
                    select info.GetValue(instance)).OfType<TEnum>();
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = GetType() == obj.GetType();
            var valueMatches = _value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
            return absoluteDifference;
        }

        public static TEnum FromValue<TEnum>(int value) where TEnum : Enumeration, new()
        {
            var matchingItem = Parse<TEnum, int>(value, "value", item => item.Value == value);
            return matchingItem;
        }

        public static TEnum FromDisplayName<TEnum>(string displayName) where TEnum : Enumeration, new()
        {
            var matchingItem = Parse<TEnum, string>(displayName, "display name", item => item.DisplayName == displayName);
            return matchingItem;
        }

        private static TEnum Parse<TEnum, TValue>(TValue value, string description, Func<TEnum, bool> predicate) where TEnum : Enumeration, new()
        {
            var matchingItem = GetAll<TEnum>().FirstOrDefault(predicate);
            if (matchingItem != null) return matchingItem;
            var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(TEnum));
            throw new ApplicationException(message);
        }

        public int CompareTo(object other)
        {
            return Value.CompareTo(((Enumeration)other).Value);
        }
    }
}