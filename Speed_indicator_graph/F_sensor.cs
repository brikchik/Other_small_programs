using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speed_indicator_graph
{
    public class F_sensor
    {
        // values limits
        private double max_freq;
        private double min_freq;

        // values
        private double curr_freq;
        private string m_units;
        private double K;

        public F_sensor(double min, double max, string units)
        {
            max_freq = max;
            min_freq = min;
            switch (units)
            {
                case "km/h":
                    K = 3.6;
                    m_units = units;
                    break;
                case "m/s":
                    K = 1;
                    m_units = units;
                    break;
            }
        }

        public F_sensor()
        {
            Units = "m/s";
            K = 1;
            max_freq = 1000;
            min_freq = 0;
            curr_freq = 0;
        }

        public F_sensor(double freq)
        {
            Units = "m/s";
            K = 1;
            max_freq = 1000;
            min_freq = 0;
            curr_freq = freq;
        }

        public double Max
        {
            get
            {
                return max_freq;
            }
            set
            {
                max_freq = value;
            }
        }

        public double Min
        {
            get
            {
                return min_freq;
            }
            set
            {
                min_freq = value;
            }
        }

        public double Speed
        {
            get
            {
                double rez = K * curr_freq;
                if (Overflow())
                {
                    rez = K * max_freq;
                }
                if (Underflow())
                {
                    rez = K * min_freq;
                }
                return rez;
            }
        }

        public double Frequency
        {
            get
            {
                return curr_freq;
            }
            set
            {
                curr_freq = value;
            }
        }

        public string Units
        {
            get
            {
                return m_units;
            }
            set
            {
                switch (value)
                {
                    case "km/h":
                        K = 3.6;
                        m_units = value;
                        break;
                    case "m/s":
                        K = 1;
                        m_units = value;
                        break;
                }
            }
        }

        public bool Overflow()
        {
            return (curr_freq > max_freq);
        }

        public bool Underflow()
        {
            return (curr_freq < min_freq);
        }

        public string GetSpeed()
        {
            return Speed.ToString() + m_units;
        }

        public static bool operator >(F_sensor left, F_sensor right)
        {
            return (left.Speed > right.Speed);
        }

        public static bool operator <(F_sensor left, F_sensor right)
        {
            return (left.Speed < right.Speed);
        }

        public static bool operator ==(F_sensor left, F_sensor right)
        {
            return ((left.Speed - right.Speed) < 0.001);
        }

        public static bool operator !=(F_sensor left, F_sensor right)
        {
            return ((left.Speed - right.Speed) > 0.001);
        }
        public static double operator /(F_sensor left, F_sensor right)
        {
            string tmp = right.Units;
            right.Units = left.Units;
            double rez = ((double)left.Speed / (double)right.Frequency);
            right.Units = tmp;
            return rez;
        }

        public static F_sensor operator + (F_sensor left, double right)
        {
            F_sensor rez = new F_sensor(left.Min, left.Max, left.Units);
            rez.Frequency = left.Frequency + right;
            return rez;
        }

        public static implicit operator string(F_sensor s)
        {
            return s.GetSpeed();
        }

        public static implicit operator F_sensor(double f)
        {
            return new F_sensor(f);
        }
    }
}
