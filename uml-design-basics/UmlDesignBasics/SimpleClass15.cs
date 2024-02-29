// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
#pragma warning disable S107 // Methods should not have too many parameters
#pragma warning disable CS8625
#pragma warning disable SA1201

namespace UmlDesignBasics
{
    public class SimpleClass15
    {
        public int IntValue { get; private set; }

        public long LongValue { get; private set; }

        public float FloatValue { get; private set; }

        public double DoubleValue { get; private set; }

        public char CharValue { get; private set; }

        public bool BooleanValue { get; private set; }

        public string StringValue { get; private set; }

        public object ObjectValue { get; private set; }

        private SimpleClass15(int intValue, long longValue, float floatValue, double doubleValue, char charValue, bool boolValue, string stringValue, object objectValue)
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

        public static SimpleClass15 Create(int intValue = 12354, long longValue = -12134, float floatValue = -12846.9727f, double doubleValue = 12923.6374, char charValue = 'j', bool boolValue = true, string stringValue = "pqrmno", object objectValue = null)
        {
            return new SimpleClass15(intValue, longValue, floatValue, doubleValue, charValue, boolValue, stringValue, objectValue);
        }
    }
}
