using System;

namespace UmlDesignBasics
{
    public static class CreatingSimpleClass16
    {
        public static SimpleClass16 CreateSimpleClass16WithDefaultValues()
        {
            return new SimpleClass16();
        }

        public static SimpleClass16 CreateSimpleClass16(long longValue)
        {
            return new SimpleClass16(longValue: longValue);
        }

        public static SimpleClass16 CreateSimpleClass16(float floatValue)
        {
            return new SimpleClass16(floatValue: floatValue);
        }

        public static SimpleClass16 CreateSimpleClass16(int intValue, bool boolValue)
        {
            return new SimpleClass16(intValue: intValue, booleanValue: boolValue);
        }

        public static SimpleClass16 CreateSimpleClass16(double doubleValue, char charValue, string stringValue)
        {
            return new SimpleClass16(doubleValue: doubleValue, charValue: charValue, stringValue: stringValue);
        }
    }
}
