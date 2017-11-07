using System;
using System.Windows.Forms;
namespace lab6_user_oriented_app
{
    class Timetable
    {
        private RichTextBox richTextBox1;
        ListBox listBox1;
        ListBox listBox2;
        ListBox listBox3;
        DateTimePicker dateTimePicker1;
        public Group[] groups = new Group[2];
        public Room[] rooms = new Room[3];
        public Lesson[] lessons = new Lesson[3];
        public Timetable(RichTextBox richTextBox1, ListBox listBox1, ListBox listBox2,
            ListBox listBox3, DateTimePicker dateTimePicker1)
        {
            this.richTextBox1 = richTextBox1;
            this.listBox1 = listBox1;
            this.listBox2 = listBox2;
            this.listBox3 = listBox3;
            this.dateTimePicker1 = dateTimePicker1;
        }
        public void updateComponents()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            foreach (Group g in groups) { listBox1.Items.Add(g.number); }
            foreach (Room r in rooms) { listBox3.Items.Add(r.number); }
            foreach (Lesson l in lessons) { listBox2.Items.Add(l.name); }
            listBox1.SelectedIndex = 0;
            listBox2.SelectedIndex = 0;
            listBox3.SelectedIndex = 0;
        }
        public void showLB2()
        {
            richTextBox1.Text = "Lesson: \n" + (lessons[listBox2.SelectedIndex].lection ? "Lecture " : "Practice ") +
                lessons[listBox2.SelectedIndex].name;
            richTextBox1.Text += "\nFaculty: " + lessons[listBox2.SelectedIndex].faculty;
            richTextBox1.Text += "\nYear : " + lessons[listBox2.SelectedIndex].study_year + "\nGroups num: ";
            foreach (int i in lessons[listBox2.SelectedIndex].groups) richTextBox1.Text += " " + i + " ";
            richTextBox1.Text += '\n' + "Room: " + lessons[listBox2.SelectedIndex].roomNumber +
                "\nAt " + lessons[listBox2.SelectedIndex].time.start.DayOfWeek +
                " с " + lessons[listBox2.SelectedIndex].time.start.ToShortTimeString() +
                '-' + lessons[listBox2.SelectedIndex].time.end.ToShortTimeString();
            if (lessons[listBox2.SelectedIndex].oddPara == 0) richTextBox1.Text += " odd weeks\n";
            else
            if (lessons[listBox2.SelectedIndex].oddPara == 1) richTextBox1.Text += " even weeks\n";
            else
            if (lessons[listBox2.SelectedIndex].oddPara == 2) richTextBox1.Text += " every week\n";
        }
        public void showLB3()
        {
            richTextBox1.Text = "Room №: " + rooms[listBox3.SelectedIndex].number;
            richTextBox1.Text += "\nBuilding №: " + rooms[listBox3.SelectedIndex].building;
            richTextBox1.Text += "\nPlaces: " + rooms[listBox3.SelectedIndex].chairs;
            richTextBox1.Text += "\nPicked day lessons: \n";
            foreach (Lesson l in lessons)
            {
                if (l.time.start.Day == dateTimePicker1.Value.Day && l.roomNumber == (int)listBox3.Items[listBox3.SelectedIndex])
                {
                    richTextBox1.Text += "" + l.name + " - " + ((l.lection) ? "Lecture" : "Practice");
                    richTextBox1.Text += " at " + l.time.start.DayOfWeek + ' ' +
                        l.time.start.ToShortTimeString() + '-' + l.time.end.ToShortTimeString();
                    if (l.oddPara == 0) richTextBox1.Text += " odd weeks\n";
                    else
                    if (l.oddPara == 1) richTextBox1.Text += " even weeks\n";
                    else
                    if (l.oddPara == 2) richTextBox1.Text += " every week ";
                    richTextBox1.Text += "Groups:";
                    foreach (int i in l.groups) richTextBox1.Text += i + " ";
                }
            }
            richTextBox1.Text += "\nLessons for chosen day: \n";
            foreach (Lesson l in lessons)
            {
                int delta = DayOfWeek.Monday - l.time.start.DayOfWeek;
                if (delta > 0) delta -= 7;
                DateTime monday = l.time.start.AddDays(delta + 2);//monday
                DateTime sunday = l.time.start.AddDays(8 - delta);//sunday
                if (l.time.start >= monday && l.time.start <= sunday && l.roomNumber == (int)listBox3.Items[listBox3.SelectedIndex])
                {
                    richTextBox1.Text += "" + l.name + " - " + ((l.lection) ? "Lecture" : "Practice");
                    richTextBox1.Text += " at " + l.time.start.DayOfWeek + ' ' +
                        l.time.start.ToShortTimeString() + '-' + l.time.end.ToShortTimeString();
                    if (l.oddPara == 0) richTextBox1.Text += " odd weeks\n";
                    else
                    if (l.oddPara == 1) richTextBox1.Text += " even weeks\n";
                    else
                    if (l.oddPara == 2) richTextBox1.Text += " every week\n";
                    richTextBox1.Text += "Groups:";
                    foreach (int i in l.groups) richTextBox1.Text += i + " ";
                }
            }
        }
        public void showLB1()
        {
            richTextBox1.Text = "Group: " + groups[listBox1.SelectedIndex].number + "\nFaculty: " +
                groups[listBox1.SelectedIndex].faculty + "\nYear: " + groups[listBox1.SelectedIndex].study_year +
                "\nStudents (count): " + groups[listBox1.SelectedIndex].students_count;
            richTextBox1.Text += "\nLessons:\n";
            foreach (Lesson l in lessons)
            {
                foreach (int groupNumber in l.groups)
                {
                    if (groupNumber == groups[listBox1.SelectedIndex].number)
                    {
                        richTextBox1.Text += "" + l.name + " - " + ((l.lection) ? "Lecture" : "Practice");
                        richTextBox1.Text += " at " + l.time.start.DayOfWeek + " in " + l.roomNumber + " room " +
                            l.time.start.ToShortTimeString() + '-' + l.time.end.ToShortTimeString();
                        if (l.oddPara == 0) richTextBox1.Text += " odd weeks\n";
                        else
                        if (l.oddPara == 1) richTextBox1.Text += " even weeks\n";
                        else
                        if (l.oddPara == 2) richTextBox1.Text += " every week\n";
                    }
                }
            }
        }
        public void addSomeValues()
        {
            groups[0] = new Group(1, "f1", 1, 20);
            groups[1] = new Group(2, "f2", 4, 32);
            rooms[0] = new Room(4, 5, 40);
            rooms[1] = new Room(6, 87, 35);
            rooms[2] = new Room(4, 60, 22);
            lessons[0] = new Lesson(true, "math", "f3", 2);
            lessons[0].groups = new int[2]; lessons[0].groups[0] = 1; lessons[0].groups[1] = 2;
            lessons[1] = new Lesson(false, "phys", "f2", 3);
            lessons[1].groups = new int[1]; lessons[1].groups[0] = 1;
            lessons[2] = new Lesson(true, "pc", "f1", 5);
            lessons[2].groups = new int[1]; lessons[2].groups[0] = 2;
        }
    }
    public class Room
    {
        public Room(int a, int b, int c) { building = a; number = b; chairs = c; }
        public int building;
        public int number;
        public int chairs;
    }
    public class Lesson
    {
        public Lesson(bool t, string n, string f, int kurs)
        { lection = t; name = n; faculty = f; study_year = kurs; numberOfGroups = 0; time = new Para(); }
        public bool lection;
        public string name;
        public string faculty;
        public int study_year;
        public int numberOfGroups;
        public int[] groups; //number of groups=groups.Count
        public Para time;//date+time
        public int oddPara;//0-odd, 1-even, 2-both
        public int roomNumber;//room num
    }
    public class Para
    {
        public DateTime start;//date
        public DateTime end;
    }
    public class Group
    {
        public Group(int n, string f, int year, int count) { number = n; faculty = f; study_year = year; students_count = count; }
        public int number;
        public string faculty;
        public int study_year;
        public int students_count;
    }
}