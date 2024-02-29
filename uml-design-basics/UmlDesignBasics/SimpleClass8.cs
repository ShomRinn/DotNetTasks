// ReSharper disable ConvertToAutoProperty
#pragma warning disable S2292 // Trivial properties should be auto-implemented
#pragma warning disable CS8603
#pragma warning disable CA1822
#pragma warning disable S23400

namespace UmlDesignBasics
{
    public class SimpleClass8
    {
        private int intField;
        private long longField;
        private float floatField;
        private double doubleField;
        private char charField;
        private bool booleanField;
        private string? stringField;
        private object? objectField;

        public int IntValue
        {
            get { return this.intField; }
            set { this.intField = value; }
        }

        public long LongValue
        {
            get { return this.longField; }
            set { this.longField = value; }
        }

        public float FloatValue
        {
            get { return this.floatField; }
            set { this.floatField = value; }
        }

        public double DoubleValue
        {
            get { return this.doubleField; }
            set { this.doubleField = value; }
        }

        public char CharValue
        {
            get { return this.charField; }
            set { this.charField = value; }
        }

        public bool BooleanValue
        {
            get { return this.booleanField; }
            set { this.booleanField = value; }
        }

        public string StringValue
        {
            get { return this.stringField; }
            set { this.stringField = value; }
        }

        public object ObjectValue
        {
            get { return this.objectField; }
            set { this.objectField = value; }
        }
    }
}
