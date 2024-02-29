using System;

namespace UmlDesignBasics
{
    public static class CreatingSimpleClass15
    {
        public static SimpleClass15 CreateSimpleClass15WithDefaultValues()
        {
            return SimpleClass15.Create();
        }

        public static SimpleClass15 CreateSimpleClass15(double doubleValue)
        {
            return SimpleClass15.Create(doubleValue: doubleValue);
        }

        public static SimpleClass15 CreateSimpleClass15(int intValue)
        {
            return SimpleClass15.Create(intValue: intValue);
        }

        public static SimpleClass15 CreateSimpleClass15(long longValue, char charValue)
        {
            return SimpleClass15.Create(longValue: longValue, charValue: charValue);
        }

        public static SimpleClass15 CreateSimpleClass15(float floatValue, bool boolValue, object objectValue)
        {
            return SimpleClass15.Create(floatValue: floatValue, boolValue: boolValue, objectValue: objectValue);
        }
    }
}
