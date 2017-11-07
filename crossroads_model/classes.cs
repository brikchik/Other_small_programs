using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Crossroads_model
{
    public class car
    {
        int initialRoadlight = 2;//left
        int direction = 2;//right
        public int x = 0, y = 0;
        int speed = 25;
        public void next(crossroads cr)
        {
            if (x > 600) x = 0;
            if (x < 0) x = 600;
            if (y > 300) y = 0;
            if (y < 0) y = 300;
            if ((x > 170 && x < 200 || x < 430 && x > 370) && (direction == 2 || direction == 0))
            { if (cr.getLight(initialRoadlight).state == 3)
                    x += speed*(direction-1);//0/2 -> -1, 1
            }
            else
            if ((y > 70 && y < 100 || y > 200 && y < 230) && (direction == 3 || direction == 1))
            { if (cr.getLight(initialRoadlight).state == 3)
                    y += speed*(direction-2); // 1/3 -> -1,1
            }
            else
                switch (direction)
                {
                    case 0:x -= speed; break;
                    case 1:y -= speed; break;
                    case 2:x += speed; break;
                    case 3:y += speed; break;
                    default: break;
                }
        }
        public car(int x,int y, int dir, int roadlight)
        {
            this.x = x;
            this.y = y;
            this.direction = dir;
            this.initialRoadlight = roadlight;
        }
        public Point coords() {
            return new Point(x, y);
        }
    }
    public class crossroads
    {
        public roadlight[] mas = new roadlight[12];
        Panel screen;
        public crossroads(Panel screen)
        {
            this.screen = screen;
            mas[0] = new car_roadlight(0);
            mas[1] = new car_roadlight(1);
            mas[2] = new car_roadlight(3);
            mas[3] = new car_roadlight(2);
            for(int i=4;i<12;i++) mas[i] = new ped_roadlight(0);
        }
        public bool project = true;//if model is running
        public roadlight getLight(int i) { return mas[i]; }
        public car c1 = new car(0, 170, 2, 2);
        public car c2 = new car(600, 130, 0, 1);
        public car c3 = new car(240, 0, 3, 0);
        public car c4 = new car(340, 300, 1, 3);
        public int carsN = 2;
        public void refresh()
        {
            Bitmap bm = new Bitmap(490, 320);
            Graphics g = Graphics.FromImage(bm);

            lock (g)
            {
                g.FillRectangle(Brushes.LightSteelBlue, 200, 0, 200, 300);
                g.FillRectangle(Brushes.Indigo, 0, 100, 600, 100);
                g.DrawLine(Pens.Black, 0, 100, 600, 100);
                g.DrawLine(Pens.Aqua, 0, 150, 490, 150);
                g.DrawLine(Pens.Black, 0, 200, 490, 200);
                g.DrawLine(Pens.Black, 200, 0, 200, 300);
                g.DrawLine(Pens.Aqua, 300, 0, 300, 300);
                g.DrawLine(Pens.Black, 400, 0, 400, 300);
                for (int i = 0; i < carsN; i++) g.FillRectangle(Brushes.Black, c1.x - i * 30, c1.y, 20, 10);
                for (int i = 0; i < carsN; i++) g.FillRectangle(Brushes.Black, c2.x + i * 30, c2.y, 20, 10);
                for (int i = 0; i < carsN; i++) g.FillRectangle(Brushes.Black, c3.x , c3.y - i * 30, 10, 20);
                for (int i = 0; i < carsN; i++) g.FillRectangle(Brushes.Black, c4.x , c4.y + i * 30, 10, 20);
                for (int i = 0; i < mas.Count(); i++) mas[i].paint();
                screen.BackgroundImage = bm;
            }
        }
    }
    public abstract class roadlight
    {
        private List<int> program = new List<int>();
        protected int angle = 0;
        public roadlight()
        {
            program.Add(1); program.Add(2); program.Add(3); program.Add(2);
            paint();
        }
        public Image pic = new Bitmap(50, 50);
        public int state = -1;//default
        public abstract void paint();
        private int index = 0;
        public void nextState()
        {
            try
            {
                if (state == 0) { index++; return; }
                if (index == program.Count) index = 0;
                state = program.ElementAt(index);
                index++;
            } catch (Exception e) { };
        }
        public void setProgram(int[] l)
        {
            program.Clear();
            program.AddRange(l);
        }
    }
    public class car_roadlight : roadlight
    {
        private int v;
        public car_roadlight(int v)
        {
            this.v = v;
        }
        public override void paint()
        {
            lock (pic)
            {
                Graphics g = Graphics.FromImage(pic);
                int w = 50;
                g.FillRectangle(Brushes.Bisque, 0, 0, w, w);
                if (state == 1) g.FillRectangle(Brushes.Red, 0, 0, w, w / 3);
                if (state == 2) g.FillRectangle(Brushes.Yellow, 0, w / 3, w, 2 * w / 3);
                if (state == 3) g.FillRectangle(Brushes.Green, 0, 2 * w / 3, w, w);
                for (int i = 1; i <= v; i++) pic.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
        }
    }
    public class ped_roadlight : roadlight
    {
        public ped_roadlight(int flip) { angle = flip; }
        public override void paint()
        {
            lock (pic)
            {
                Graphics g = Graphics.FromImage(pic);
                int w = 30;
                g.FillRectangle(Brushes.Bisque, 0, 0, w, w);
                if (state == 1) g.FillRectangle(Brushes.Red, 0, 0, w, w / 2);
                if (state == 2) g.FillRectangle(Brushes.Green, 0, w / 2, w, w);
                for (int i = 0; i < angle; i++) pic.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
        }
    }
    public class arrowed_roadlight : roadlight //arrow
    {
        public arrowed_roadlight(int flip = 0) { angle = flip; }
        public override void paint()
        {
            lock (pic)
            {
                Graphics g = Graphics.FromImage(pic);
                int w = 30;
                g.FillRectangle(Brushes.Bisque, 0, 0, w, w);
                if (state == 1) g.FillRectangle(Brushes.Red, 0, 0, w, w);
                if (state == 2) g.FillRectangle(Brushes.Green, 0, 0, w, w);
                Point[] p = new Point[5];
                p[0] = new Point(0, w / 2);
                p[1] = new Point(w, w / 2);
                p[2] = new Point(w - 20, 0);
                p[3] = new Point(w, w / 2);
                p[4] = new Point(w - 20, w);
                g.DrawLines(Pens.Black, p);
                for (int i = 0; i < angle; i++) pic.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
        }
    }
}
