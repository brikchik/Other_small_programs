using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace TDD
{
    class tdd
    {
        public double min_pressure = 0;
        public double max_pressure = 3000000;
        //                                                  ЗНАЧЕНИЕ ХРАНИТСЯ В ПАСКАЛЯХ
        const double min_current = 4;//мА=0Па
        const double max_current = 20;//мА=3000000Па
        private double current = 0;//датчик отключён
        private double pressure = 0;  //если пользователь забыл проверить, работает ли датчик, он должен сразу понять это
        private string[] unit = { "мм.рт.ст.", "МПа", "кПа", "кгс/кв.м" };
        private byte currentUnit = 1; //МПа по умолчанию, хотя хранится в Па - во все варианты надо переводить.
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
            //находим процент от макс.значения датчика
            //если ток всегда корректен(что проверяется в set_current), доп.проверок не требуется
        }
        public bool set_current(double received_current) //ток
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
        } //текущий ток
        public string units() { return unit[currentUnit]; }  //единицы измерения
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
        //получить показания в текущих единицах измерения
        public double get_pressure()
        {
            if (!is_valid()) return -1;
            count();//пересчитываем заново
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
            if (!is_valid()) return "За пределом шкалы измерений";
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
        //определение выхода датчика за пределы измерения
        public bool is_valid() { if (current == 0) return false; else return true; }
        //работает ли(нормален ли ток на входе). если ток ненормален, будет стоять current=0 ->датчик не работает
        //перегрузка операторов сравнения
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
        ////////////////////////////////
        //Задание 2
        //перегрузка операций
        public static double operator /(tdd a,tdd b) { return a.get_pressure() / b.get_pressure(); }
        public static tdd operator +(tdd a, double k)
        {
            a.set_current(a.get_current() + k);
            return a;
        }//вместе с + перегружаем и += автоматически
    }
}
