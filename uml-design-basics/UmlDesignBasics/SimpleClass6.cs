// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Local
#pragma warning disable S2933 // Fields that are only assigned in the constructor should be "readonly"
#pragma warning disable IDE0044 // Add readonly modifier

namespace UmlDesignBasics
{
    public class SimpleClass6
    {
        private int intField;
        private long longField;
        private float floatField;
        private double doubleField;
        private char charField;
        private bool booleanField;
        private string stringField;
        private object objectField;

        public SimpleClass6()
        {
            this.intField = 754;
            this.longField = 721;
            this.floatField = -76.67f;
            this.doubleField = 372.127;
            this.charField = 'e';
            this.booleanField = true;
            this.stringField = "ghi";
            this.objectField = typeof(float);
        }

        public int GetInteger()
        {
            return this.intField;
        }

        public long GetLong()
        {
            return this.longField;
        }

        public float GetFloat()
        {
            return this.floatField;
        }

        public double GetDouble()
        {
            return this.doubleField;
        }

        public char GetChar()
        {
            return this.charField;
        }

        public bool GetBoolean()
        {
            return this.booleanField;
        }

        public string GetString()
        {
            return this.stringField;
        }

        public object GetObject()
        {
            return this.objectField;
        }
    }
}
