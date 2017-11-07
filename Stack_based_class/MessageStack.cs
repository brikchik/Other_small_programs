using System;
using System.Collections.Generic;
namespace Stack_based_class
{
    class Message
    {
        public Exception MessageException = new Exception("Future dates are not allowed");
        public Message(DateTime date,uint number=0,string message="empty")
        {
            setNumber(number);
            setMessage(message);
            setDate(date);
        }//with date
        public Message(uint number = 0, string message = "empty")
        {
            setNumber(number);
            setMessage(message);
            setDate(DateTime.Now);
        }//without date
        ~Message() { }
        private uint number;
        private string message;
        private DateTime date;
        public uint getNumber() { return number; }
        public string getMessage() { return message; }
        public DateTime getDate() { return date; }
        public void setNumber(uint x) { number=x; }
        public void setMessage(string s) { message=s; }
        public void setDate(DateTime date)
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
        public static Exception StackEmpty=new Exception("Stack empty. Unable to get element");
        public static Exception NotEnoughMemory = new Exception("Stack is too big. Unable to insert element");
        private Stack<Message> stack=new Stack<Message>();
        public MessageStack() { }//empty
        public MessageStack(int count)
        {
            for (int i = 0; i < count; i++) push(new Message());
        }// for fixed memory size
        public void push(Message element)
        {
            try { stack.Push(element); }
            catch (Exception x) { throw NotEnoughMemory; }
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
        public static bool operator&(MessageStack a, MessageStack b)
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
            }
            for (int i = 0; i < x.getSize(); i++)
            {
                DateTime date = x.peek().getDate();
                uint number = x.peek().getNumber();
                string message = x.peek().getMessage();
                x.pop();
                a.push(new Message(date, number, message));
                b.push(new Message(date, number, message));
            }
            return true;
        }
    }
}