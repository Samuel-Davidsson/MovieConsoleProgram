using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movieprogram.MovieDataBase.Repositories;
using Movieprogram.MovieDataBase.Domain;
using Movieprogram.MovieDataBase.Domain.ValueObjects;
using Movieprogram.MovieDataBase.Services;
using Movieprogram.MovieDataBase.Domain.Entities;

namespace Movieprogram
{
    class Program
    {
        public MovieService _movieService;
        public CastOrCrewService _castOrCrewService;

        public bool keepRunning;
        static void Main(string[] args)
        {
            var program = new Program();
            program.MainLoop();
        }
        public Program()
        {
            _movieService = new MovieService();
            _castOrCrewService = new CastOrCrewService();
        }
        private void MainLoop()
        {
            keepRunning = true;
            do
            {
                PrintMenu();
                var command = GetCommand();
                ExecuteCommand(command);
            } while (keepRunning);
        }
        private char GetCommand()
        {
            var command = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();
            return command;
        }


        private void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("1='Add new movie', 2='Find a movie', 3='Find actor/director', 4='Quit'");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine();
        }
        private void ExecuteCommand(char command)
        {
            switch (command)
            {
                case '1':
                    AddMovie();
                    break;
                case '2':
                    SearchMovie();
                    break;
                case '3':
                    SearchDirectorActor();
                    break;
                case '4':
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
        public void AddMovie()
        {
            string title;
            AskforTitle(out title, "Enter the title of the movie: ");


            ProductionYear productionYear;
            AskFor(out productionYear, "When was the movie produced?");

            Movie movie = new Movie(title, productionYear);
            _movieService.Add(movie);
            
            string name;
            AskFor(out name, "Enter the name of the director.");
            CastOrCrew director = _castOrCrewService.FindBy(name);
            if (director == null)
            {
                director = NewCastOrCrew(name);
            }

            _castOrCrewService.AddPeople(director);
            movie.Director = director;

            bool keepAskingForNewActor = false;
            do
            {
                AskFor(out name, "Enter the name of an actor: ");
                CastOrCrew actor = _castOrCrewService.FindBy(name);
                if (actor == null)
                {
                    actor = NewCastOrCrew(name);
                }
                _castOrCrewService.AddPeople(actor);
                movie.AddActor(actor);
                Console.Write("Do you want to add a new actor to the movie? (y/n)");
                char c = Console.ReadKey().KeyChar;
                keepAskingForNewActor = (char.ToLower(c) == 'y');
                Console.WriteLine();
            } while (keepAskingForNewActor);



        }

        public void SearchMovie()
        {
            string title;
            AskforTitle(out title, "Enter the title of the movie you are searching for?");

            var movie = _movieService.SearchMovie(title);
            if (movie == null)
            {
                Console.WriteLine($"Cant find the movie called {title}");
            }
            else
            {
                PrintMovie(movie);
            }
            
        }

        private void SearchDirectorActor()
        {
            string name;
            AskFor(out name, "Enter the name of the director or actor you´r lookin for");
            var castOrCrew = _castOrCrewService.FindBy(name);
            if (castOrCrew == null)
            {
                Console.WriteLine($"Cannot find {name}");
            }
            else
            {
                PrintCastOrCrew(castOrCrew);
            }

        }
        public void AskFor(out ProductionYear result, string question)
        {
            Console.Write(question);
            var line = Console.ReadLine();
            while (!ProductionYear.TryParse(line, out result))
            {
                Console.WriteLine("Please enter a valid production year");
                line = Console.ReadLine();
            }
        }
        public void AskforTitle(out string result, string askingPhrase)
        {
            Console.Write(askingPhrase);
            result = Console.ReadLine();
        }

        public void AskFor(out string result, string askingPfrase)
        {
            Console.Write(askingPfrase);
            result = Console.ReadLine();
        }
        public void AskFor(out DateTime result, string askingPfrase)
        {
            Console.Write(askingPfrase);
            var line = Console.ReadLine();
            while (!DateTime.TryParse(line, out result))
            {
                Console.Write("Please enter a valid date: ");
                line = Console.ReadLine();
            }
        }
        public CastOrCrew NewCastOrCrew(string name)
        {
            DateTime DateOfBirth;
            AskFor(out DateOfBirth, "Enter the date of birth: ");
            return new CastOrCrew(name, DateOfBirth);
        }

        public void CastOrCrew(CastOrCrew castOrCrew)
        {
            Console.WriteLine();
            Console.WriteLine("Acted in this movies:");
            Console.WriteLine();
            foreach (var movie in castOrCrew.ActedMovies)
            {
                Console.WriteLine($"{movie.Title}");
            }
            
        }
        public void PrintCastOrCrew(CastOrCrew castOrCrew)
        {
            Console.WriteLine($"{castOrCrew.Name}");
            Console.WriteLine($"{castOrCrew.JobTitle}");
            Console.WriteLine($"Born {castOrCrew.DateOfBirth:yyyy-MM-dd}");
            if (castOrCrew.IsActor)
            {
                Console.WriteLine();
                Console.WriteLine("Actor in the following movies:");
                Console.WriteLine("------------------------------");
                foreach (var movie in castOrCrew.ActedMovies)
                {
                    Console.WriteLine($"{movie.Title}");
                }
            }

            if (castOrCrew.IsDirector)
            {
                Console.WriteLine();
                Console.WriteLine("Director for the following movies:");
                Console.WriteLine("----------------------------------");
                foreach (var movie in castOrCrew.DirectedMovies)
                {
                    Console.WriteLine($"{movie.Title}");
                }
            }
        }



        public void PrintMovie(Movie movie)
        {
            Console.WriteLine($"{movie.Title} ({movie.ProductionYear})");
            Console.WriteLine($"Director: {movie.Director.Name}");
            Console.WriteLine("List of actors:");
            Console.WriteLine("---------------");
            foreach (var actor in movie.Actors)
            {
                Console.WriteLine($"{actor.Name}");
            }
        }
    }
  }
  
    


