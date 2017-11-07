using System;
namespace Pressure_indicator_graph
{
    class tdd
    {
        public double min_pressure = 0;
        public double max_pressure = 3000000;
        //                                                  VALUE IN PASCALs
        const double min_current = 4;//4mA=0Pa
        const double max_current = 20;//20mA=3000000Pa
        private double current = 0;//turned off?
        private double pressure = 0;
        private string[] unit = { "mm.Hg", "MPa", "kPa", "kgs/m^2" };
        private byte currentUnit = 1;
        public tdd() { }
        public tdd(Form1 reference, double received_current)
        {
            this.set_current(received_current);
            reference.Text = get_full_pressure();
            reference.Update();
        }
        public tdd(int k) { this.set_current(k); }
        public tdd(double k) { this.set_current(k); }
        private void count()
        {
            pressure = (current - min_current) / (max_current - min_current) * (max_pressure - min_pressure);
            // % of max possible value
        }
        public bool set_current(double received_current) //current
        {
            if (received_current < 4 || received_current > 20) return false;
            current = received_current;
            return true;
        }
        public bool set_current(string text)
        {
            double value = 0;
            if (!Double.TryParse(text.Replace('.',','), out value)) return false;
            if (value < 4 || value > 20)
            {
                current = 0; return false;
            }
            current = value;
            return true;
        }
        public double get_current()
        {
            return current;
        }
        public string units() { return unit[currentUnit]; } 
        public bool set_units(string units)
        {
            switch (units)
            {
                case "мм.рт.ст.": currentUnit = 0; break;
                case "Мпа": currentUnit = 1; break;
                case "кПа": currentUnit = 2; break;
                case "кгс/кв.см": currentUnit = 3; break;
                default: return false;
            }
            return true;
        }
        public bool set_units(byte units)
        {
            if(units>=0 && units<4)currentUnit = units;
            return true;
        }
        public double toMM(double press) { return press / 133.322; }
        public double toMP(double press) { return press / 1000000; }
        public double toKP(double press) { return press / 1000; }
        public double toKGSSM(double press) { return press / 98066.5; }
        public double get_pressure()
        {
            if (!is_valid()) return -1;
            count();
            double value = 0;
            if (currentUnit == 0) value = toMM(pressure);
            else
            if (currentUnit == 1) value = toMP(pressure);
            else
            if (currentUnit == 2) value = toKP(pressure);
            else
            if (currentUnit == 3) value = toKGSSM(pressure);
            return value;
        }
        public string get_full_pressure()
        {
            if (!is_valid()) return "Out of range";
            else
            return get_pressure().ToString() + ' ' + unit[currentUnit];
        }
        public double get_min_pressure()
        {
            double value = 0;
            if (currentUnit == 0) value = toMM(min_pressure);
            else
            if (currentUnit == 1) value = toMP(min_pressure);
            else
            if (currentUnit == 2) value = toKP(min_pressure);
            else
            if (currentUnit == 3) value = toKGSSM(min_pressure);
            return value;
        }
        public double get_max_pressure()
        {
            double value = 0;
            if (currentUnit == 0) value = toMM(max_pressure);
            else
            if (currentUnit == 1) value = toMP(max_pressure);
            else
            if (currentUnit == 2) value = toKP(max_pressure);
            else
            if (currentUnit == 3) value = toKGSSM(max_pressure);
            return value;
        }
        public string get_full_min_pressure()
        {
            return get_min_pressure().ToString() + ' ' + unit[currentUnit];
        }
        public string get_full_max_pressure()
        {
            return get_max_pressure().ToString() + ' ' + unit[currentUnit];
        }
        public bool is_valid() { if (current == 0) return false; else return true; }
        public static bool operator <(tdd x, tdd y)
        {
            if (x.get_pressure() < y.get_pressure()) return true; else return false;
        }
        public static bool operator >(tdd x, tdd y)
        {
            if (x.get_pressure() > y.get_pressure()) return true; else return false;
        }
        public static bool operator ==(tdd x, tdd y)
        {
            if (x.get_pressure() == y.get_pressure()) return true; else return false;
        }
        public static bool operator !=(tdd x, tdd y)
        {
            if (x.get_pressure() != y.get_pressure()) return true; else return false;
        }
        public static double operator /(tdd a,tdd b) { return a.get_pressure() / b.get_pressure(); }
        public static tdd operator +(tdd a, double k)
        {
            a.set_current(a.get_current() + k);
            return a;
        }
    }
}
