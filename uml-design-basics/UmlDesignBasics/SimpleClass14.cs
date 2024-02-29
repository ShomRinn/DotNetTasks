// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable IntroduceOptionalParameters.Global
#pragma warning disable S107 // Methods should not have too many parameters
#pragma warning disable SA1201
#pragma warning disable CS8625

namespace UmlDesignBasics
{
    public class SimpleClass14
    {
        public int IntValue { get; private set; }

        public long LongValue { get; private set; }

        public float FloatValue { get; private set; }

        public double DoubleValue { get; private set; }

        public char CharValue { get; private set; }

        public bool BooleanValue { get; private set; }

        public string StringValue { get; private set; }

        public object ObjectValue { get; private set; }

        private SimpleClass14(int intValue, long longValue, float floatValue, double doubleValue, char charValue, bool boolValue, string stringValue, object objectValue)
        {
            this.IntValue = intValue;
            this.LongValue = longValue;
            this.FloatValue = floatValue;
            this.DoubleValue = doubleValue;
            this.CharValue = charValue;
            this.BooleanValue = boolValue;
            this.StringValue = stringValue;
            this.ObjectValue = objectValue;
        }

        public static SimpleClass14 Create()
        {
            return new SimpleClass14(-1132, -11537, 11369.321F, 11867.3854, 'i', true, "pqr", null);
        }

        public static SimpleClass14 Create(int intValue)
        {
            return Create(intValue, -11537);
        }

        public static SimpleClass14 Create(int intValue, long longValue)
        {
            return Create(intValue, longValue, 11369.321F);
        }

        public static SimpleClass14 Create(int intValue, long longValue, float floatValue)
        {
            return Create(intValue, longValue, floatValue, 11867.3854);
        }

        public static SimpleClass14 Create(int intValue, long longValue, float floatValue, double doubleValue)
        {
            return Create(intValue, longValue, floatValue, doubleValue, 'i');
        }

        public static SimpleClass14 Create(int intValue, long longValue, float floatValue, double doubleValue, char charValue)
        {
            return Create(intValue, longValue, floatValue, doubleValue, charValue, true);
        }

        public static SimpleClass14 Create(int intValue, long longValue, float floatValue, double doubleValue, char charValue, bool boolValue)
        {
            return Create(intValue, longValue, floatValue, doubleValue, charValue, boolValue, "pqr");
        }

        public static SimpleClass14 Create(int intValue, long longValue, float floatValue, double doubleValue, char charValue, bool boolValue, string stringValue)
        {
            return Create(intValue, longValue, floatValue, doubleValue, charValue, boolValue, stringValue, null);
        }

        public static SimpleClass14 Create(int intValue, long longValue, float floatValue, double doubleValue, char charValue, bool boolValue, string stringValue, object objectValue)
        {
            return new SimpleClass14(intValue, longValue, floatValue, doubleValue, charValue, boolValue, stringValue, objectValue);
        }
    }
}
