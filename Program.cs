using System;
using System.Collections.Generic;
using System.Linq;
namespace ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Card> toDo = new List<Card>();
            List<Card> inProgress = new List<Card>();
            List<Card> done = new List<Card>();

            Dictionary<int, string> teamsMember = new Dictionary<int, string>()
            {
                {1,"Oguzhan"},
                {2,"Esen"},
                {3,"Nuran"},
                {4,"Erdal"},
                {5,"Nazim"},
                {6,"Rezan"},
                {7,"Orhan"},
            };
            Card card = new Card();

            Card card1 = new Card();
            card1.Title = "Fenerbahce";
            card1.Content = "FootballPlayer";
            card1.Size = size.XS;
            card1.PersonId = teamsMember[1];

            Card card2 = new Card();
            card2.Title = "Besiktas";
            card2.Content = "BasketballPlayer";
            card2.Size = size.S;
            card2.PersonId = teamsMember[2];

            Card card3 = new Card();
            card3.Title = "Fenerbahce";
            card3.Content = "VoleyballPlayer";
            card3.Size = size.M;
            card3.PersonId = teamsMember[3];

            toDo.Add(card1);
            toDo.Add(card2);
            toDo.Add(card3);

            MainMenu();

            void MainMenu()
            {
                Console.WriteLine("Please select the action you want to do :");
                Console.WriteLine("******************************************");
                Console.WriteLine("(1) List the board");
                Console.WriteLine("(2) Add a card in board");
                Console.WriteLine("(3) Remove the card from board");
                Console.WriteLine("(4) Move the card to an another board");

                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        ListBoard();
                        break;
                    case 2:
                        AddCard();
                        break;
                    case 3:
                        RemoveCard();
                        break;
                    case 4:
                        MoveCard();
                        break;
                }
            }
            void ListBoard()
            {
                Console.WriteLine("TODO Line");
                Console.WriteLine("**************");
                foreach (var item in toDo)
                {
                    Console.WriteLine("Title : " + item.Title);
                    Console.WriteLine("Content : " + item.Content);
                    Console.WriteLine("Person : " + item.PersonId);
                    Console.WriteLine("Size : " + item.Size);
                    Console.WriteLine("---------------\n");
                }

            }
            void AddCard()
            {
                Console.WriteLine("Enter a title :");
                card.Title = Console.ReadLine();
                Console.WriteLine("Enter a content :");
                card.Content = Console.ReadLine();
                Console.WriteLine("Select a size -> XS(1),S(2),M(3),L(4),XL(5) :");
                int a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        card.Size = size.XS;
                        break;
                    case 2:
                        card.Size = size.S;
                        break;
                    case 3:
                        card.Size = size.M;
                        break;
                    case 4:
                        card.Size = size.L;
                        break;
                    case 5:
                        card.Size = size.XL;
                        break;
                }
                Console.WriteLine("Select a person :");
                int b = int.Parse(Console.ReadLine());
                if (!teamsMember.ContainsKey(b))
                {
                    Console.WriteLine("Incorrect entry has done! Try again");
                    AddCard();
                }
                else
                {
                    card.PersonId = teamsMember[b];
                }
                Console.WriteLine("Select the board type you want to add the card :");
                Console.WriteLine("(1)TODO, (2)INPROGRESS, (3)DONE");
                int c = int.Parse(Console.ReadLine());
                if (c == 1)
                {
                    toDo.Add(card);
                    foreach (var item in toDo)
                    {
                        Console.WriteLine("Title : " + item.Title);
                        Console.WriteLine("Content : " + item.Content);
                        Console.WriteLine("Person : " + item.PersonId);
                        Console.WriteLine("Size : " + item.Size);
                        Console.WriteLine("---------------\n");
                    }
                }
                else if (c == 2)
                {
                    inProgress.Add(card);
                    foreach (var item in inProgress)
                    {
                        Console.WriteLine("Title : " + item.Title);
                        Console.WriteLine("Content : " + item.Content);
                        Console.WriteLine("Person : " + item.PersonId);
                        Console.WriteLine("Size : " + item.Size);
                        Console.WriteLine("---------------\n");
                    }
                }
                else if (c == 3)
                {
                    done.Add(card);
                    foreach (var item in done)
                    {
                        Console.WriteLine("Title : " + item.Title);
                        Console.WriteLine("Content : " + item.Content);
                        Console.WriteLine("Person : " + item.PersonId);
                        Console.WriteLine("Size : " + item.Size);
                        Console.WriteLine("---------------\n");
                    }
                }
                MainMenu();
            }
            void RemoveCard()
            {
                Console.WriteLine("First you should select the card you want to delete.");
                Console.WriteLine("Enter the card's name :");
                String name = Console.ReadLine();

                toDo.RemoveAll(i => i.Title.ToLower() == name.ToLower());
                inProgress.RemoveAll(i => i.Title.ToLower() == name.ToLower());
                done.RemoveAll(i => i.Title.ToLower() == name.ToLower());

                foreach (var item in toDo)
                {
                    Console.WriteLine("Title : " + item.Title);
                    Console.WriteLine("Content : " + item.Content);
                    Console.WriteLine("Person : " + item.PersonId);
                    Console.WriteLine("Size : " + item.Size);
                    Console.WriteLine("---------------\n");
                }
                bool a = toDo.Any(i => i.Title.ToLower() != name.ToLower());
                if (a)
                {
                    Console.WriteLine("The card matching your search criteria was not found in the board. Please make a selection :");
                    Console.WriteLine("For ending removing (1)");
                    Console.WriteLine("For try again (2)");
                    int n = int.Parse(Console.ReadLine());
                    if (n == 2)
                    {
                        RemoveCard();
                    }
                }
            }
            void MoveCard()
            {
                Console.WriteLine("First you should select the card you want to delete.");
                Console.WriteLine("Enter the card's name :");
                String cardTitle = Console.ReadLine();

                var titlesTodo = toDo.Where(i => i.Title.ToLower() == cardTitle.ToLower()).ToList();
                var titlesInprogress = inProgress.Where(i => i.Title.ToLower() == cardTitle.ToLower()).ToList();
                var titlesDone = done.Where(i => i.Title.ToLower() == cardTitle.ToLower()).ToList();

                foreach (var item in titlesTodo)
                {
                    Console.WriteLine("Card Informations :");
                    Console.WriteLine("********************");
                    Console.WriteLine("Title : " + item.Title);
                    Console.WriteLine("Content : " + item.Content);
                    Console.WriteLine("Person : " + item.PersonId);
                    Console.WriteLine("Size : " + item.Size);
                    Console.WriteLine("---------------\n");
                }

                foreach (var item in titlesInprogress)
                {
                    Console.WriteLine("Card Informations :");
                    Console.WriteLine("********************");
                    Console.WriteLine("Title : " + item.Title);
                    Console.WriteLine("Content : " + item.Content);
                    Console.WriteLine("Person : " + item.PersonId);
                    Console.WriteLine("Size : " + item.Size);
                    Console.WriteLine("---------------\n");
                }

                foreach (var item in titlesDone)
                {
                    Console.WriteLine("Card Informations :");
                    Console.WriteLine("********************");
                    Console.WriteLine("Title : " + item.Title);
                    Console.WriteLine("Content : " + item.Content);
                    Console.WriteLine("Person : " + item.PersonId);
                    Console.WriteLine("Size : " + item.Size);
                    Console.WriteLine("---------------\n");
                }

                Console.WriteLine("Please select the board you want to move :");
                Console.WriteLine("(1)TODO (2)INPROGRESS (3)DONE");
                int n = int.Parse(Console.ReadLine());

                if (n == 1)
                {
                    titlesInprogress.ForEach(i => inProgress.Remove(i));
                    titlesDone.ForEach(i => done.Remove(i));
                    titlesDone.ForEach(i => toDo.Add(i));
                    titlesInprogress.ForEach(i => toDo.Add(i));
                }
                else if (n == 2)
                {
                    titlesTodo.ForEach(i => toDo.Remove(i));
                    titlesDone.ForEach(i => done.Remove(i));
                    titlesDone.ForEach(i => inProgress.Add(i));
                    titlesTodo.ForEach(i => inProgress.Add(i));
                    foreach (var item in inProgress)
                    {
                        Console.WriteLine("Title : " + item.Title);
                        Console.WriteLine("Content : " + item.Content);
                        Console.WriteLine("Person : " + item.PersonId);
                        Console.WriteLine("Size : " + item.Size);
                        Console.WriteLine("---------------\n");
                    }
                }
                else if (n == 3)
                {
                    titlesInprogress.ForEach(i => inProgress.Remove(i));
                    titlesTodo.ForEach(i => toDo.Remove(i));
                    titlesInprogress.ForEach(i => done.Add(i));
                    titlesTodo.ForEach(i => done.Add(i));
                }
                bool a = toDo.Any(i => i.Title.ToLower() != cardTitle.ToLower());
                if (a)
                {
                    Console.WriteLine("The card matching your search criteria was not found in the board. Please make a selection :");
                    Console.WriteLine("For ending removing (1)");
                    Console.WriteLine("For try again (2)");
                    int b = int.Parse(Console.ReadLine());
                    if (b == 2)
                    {
                        MoveCard();
                    }
                }
            }







        }
    }
}
