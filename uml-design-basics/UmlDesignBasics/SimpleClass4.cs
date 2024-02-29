// ReSharper disable InconsistentNaming

#pragma warning disable SA1201
#pragma warning disable CS8618

using System.Xml.Linq;

namespace UmlDesignBasics
{
    public class SimpleClass4
    {
        private int intField;

        public int GetInteger()
        {
            return this.intField;
        }

        public void SetInteger(int arg)
        {
            this.intField = arg;
        }

        private long longField;

        public long GetLong()
        {
            return this.longField;
        }

        public void SetLong(long arg)
        {
            this.longField = arg;
        }

        private float floatField;

        public float GetFloat()
        {
            return this.floatField;
        }

        public void SetFloat(float arg)
        {
            this.floatField = arg;
        }

        private double doubleField;

        public double GetDouble()
        {
            return this.doubleField;
        }

        public void SetDouble(double arg)
        {
            this.doubleField = arg;
        }

        private char charField;

        public char GetChar()
        {
            return this.charField;
        }

        public void SetChar(char arg)
        {
            this.charField = arg;
        }

        private bool booleanField;

        public bool GetBoolean()
        {
            return this.booleanField;
        }

        public void SetBoolean(bool arg)
        {
            this.booleanField = arg;
        }

        private string stringField;

        public string GetString()
        {
            return this.stringField;
        }

        public void SetString(string arg)
        {
            this.stringField = arg;
        }

        private object objectField;

        public object GetObject()
        {
            return this.objectField;
        }

        public void SetObject(object arg)
        {
            this.objectField = arg;
        }
    }
}
