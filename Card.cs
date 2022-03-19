using System;

namespace ToDoApp
{
    class Card
    {
       String title;
       String content;
       String personId;
       Enum size;

        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public string PersonId { get => personId; set => personId = value; }
        public Enum Size { get => size; set => size = value; }

        
    }
}