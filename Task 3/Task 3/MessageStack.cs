using System;
using System.Collections.Generic;
namespace Task_3
{
    class Message
    {
        public Exception MessageException = new Exception("Регистрировать сообщения из далекого будущего нельзя");
        public Message(DateTime date,uint number=0,string message="empty")
        {
            setNumber(number);
            setMessage(message);
            setDate(date);
        } //все варианты с датой
        public Message(uint number = 0, string message = "empty")
        {
            setNumber(number);
            setMessage(message);
            setDate(DateTime.Now);
        } // учитывает все варианты без даты, датой становится текущее время(нельзя передать текущее время по умолчанию)
        ~Message() { }
        private uint number;
        private string message;
        private DateTime date;
        public uint getNumber() { return number; }
        public string getMessage() { return message; }
        public DateTime getDate() { return date; }
        public void setNumber(uint x) { number=x; } //ограничений кроме беззнаковости не накладывается
        public void setMessage(string s) { message=s; } //ограничений тоже нет, вдруг нужен элемент с пустой строкой
        public void setDate(DateTime date)//обязательные ограничения корректности 
            //(конечно, DateTime проверит корректность, остаётся только убедиться, что нет слишком старых)
        {
            if ( ( date.Year - DateTime.Today.Year) < 5) this.date = date; else throw MessageException;
        }
        public string getFullMessage()
        {
            string Fstring="";
            Fstring += "Number = " + number + "; ";
            Fstring += "Message = " + message + "; ";
            Fstring += "Date = " + date + ".";
            return Fstring;
        }
    }
    class MessageStack
    {
        //получается слишком простая реализация из-за наличия готового примитива Stack<тип объекта>
        //но писать интерфейс на WinAPI в C++ очень уж трудоёмко
        //а использовать адресацию мешает требование безопасной среды(которую не понял, как выключить)
        public static Exception StackEmpty=new Exception("Stack empty. Unable to get element");
        public static Exception NotEnoughMemory = new Exception("Stack is too big. Unable to insert element");
        private Stack<Message> stack=new Stack<Message>();
        public MessageStack() { }//пустой стек
        public MessageStack(int count)
        {
            for (int i = 0; i < count; i++) push(new Message());
        }//если понадобится гарантированно выделить нужный объём памяти
        public void push(Message element)
        {
            try { stack.Push(element); }
            catch (Exception x) { throw NotEnoughMemory; }
            //исключения типа "повреждение стека" не рассмотрены, т.к. в методах и так есть проверки;
            //нет прямой работы с элементами извне
        }
        public Message pop()
        {
            if (isEmpty()) throw StackEmpty;
            return stack.Pop();
        }
        public Message peek()
        {
            if (isEmpty()) throw StackEmpty;
            return stack.Peek();
        }
        public bool isEmpty()
        {
            bool empty = false;
            if (stack.Count == 0) empty = true;
            return empty;
        }
        public int getSize() { return stack.Count; }
        public static bool operator&(MessageStack a, MessageStack b)//вместо непереопределяемого =
        {
            for (int i = 0; i < a.getSize(); i++) a.pop();
            MessageStack x=new MessageStack();
            for (int i = 0; i < b.getSize(); i++)
            {
                DateTime date = b.peek().getDate();
                uint number = b.peek().getNumber();
                string message = b.peek().getMessage();
                b.pop();
                x.push(new Message(date, number, message));
            }//теперь в x весь b наоборот
            for (int i = 0; i < x.getSize(); i++)
            {
                DateTime date = x.peek().getDate();
                uint number = x.peek().getNumber();
                string message = x.peek().getMessage();
                x.pop();
                a.push(new Message(date, number, message));
                b.push(new Message(date, number, message));
            }//специфика в том, что стек приходится "переворачивать"->лишняя операция
            return true;
        }
    }
}