using System;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using UltraPlayProject.Data;
using UltraPlayProject.Data.Models;
using UltraPlayProject.Data.Repositories;
using XmlEntityFramework;

namespace ConsoleApplication1
{
    public class StartUp
    {
        public static void Main()
        {
            var stopwatch = new Stopwatch();
            var context = new UltraPlayDbContext();
            var uow = new UnitOfWork(context);
            var xmlRepo = new EfGenericRepository<XmlSports>(context);
            var sportRepo = new EfGenericRepository<Sport>(context);
            var sportEventRepo = new EfGenericRepository<SportEvent>(context);
            var matchRepo = new EfGenericRepository<Match>(context);
            var betRepo = new EfGenericRepository<Bet>(context);
            var oddRepo = new EfGenericRepository<Odd>(context);


            string inputUri = "http://vitalbet.net/sportxml";
            string inputFile = @"..\..\new.xml";

            stopwatch.Start();
            var xmlReader = XmlReader.Create(inputUri);
            XmlSerializer serializer = new XmlSerializer(typeof(XmlSports));
            XmlSports xmlSport = (XmlSports) serializer.Deserialize(xmlReader);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " serialization");
            stopwatch.Reset();
            xmlSport.ID = 1;

            stopwatch.Start();
            foreach (var sport in xmlSport.Sports)
            {
                sport.XmlSportsID = xmlSport.ID;
                sport.XmlSports = xmlSport;

                foreach (var sportEvent in sport.SportEvents)
                {
                    sportEvent.SportID = sport.ID;
                    sportEvent.Sport = sport;

                    foreach (var match in sportEvent.Matches)
                    {
                        match.SportEventID = sportEvent.ID;
                        match.SportEvent = sportEvent;

                        foreach (var bet in match.Bets)
                        {
                            bet.MatchID = match.ID;
                            bet.Match = match;

                            foreach (var odd in bet.Odds)
                            {
                                odd.BetID = bet.ID;
                                odd.Bet = bet;
                            }
                        }
                    }
                }
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " add Id values to new parsed object");
            stopwatch.Reset();

            stopwatch.Start();

            xmlRepo.Context.Entry(xmlSport).State = EntityState.Modified;
            Console.WriteLine(sportEventRepo.GetById(19722).IsLive);
            Console.WriteLine(matchRepo.GetById(877682).StartDate);
            

            context.ChangeTracker.DetectChanges();
            Console.WriteLine("---------");
            foreach (var sport in xmlSport.Sports)
            {
                context.Sports.Add(sport);

                foreach (var sportEvent in sport.SportEvents)
                {
                    context.SportEvents.Add(sportEvent);

                    foreach (var match in sportEvent.Matches)
                    {
                        context.Matches.Attach(match);
                        

                    }
                }
            }

            uow.Commit();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed + " update changes");
        }

        public static void InitDb()
        {
            var context = new UltraPlayDbContext();
            var uow = new UnitOfWork(context);

            if (!context.Database.Exists())
            {
                string inputUri = "http://vitalbet.net/sportxml";
                var xmlReader = XmlReader.Create(inputUri);
                XmlSerializer serializer = new XmlSerializer(typeof(XmlSports));
                XmlSports xmlSport = (XmlSports) serializer.Deserialize(xmlReader);
                xmlSport.ID = 1;
                foreach (var sport in xmlSport.Sports)
                {
                    sport.XmlSportsID = xmlSport.ID;
                    sport.XmlSports = xmlSport;

                    foreach (var sportEvent in sport.SportEvents)
                    {
                        sportEvent.SportID = sport.ID;
                        sportEvent.Sport = sport;

                        foreach (var match in sportEvent.Matches)
                        {
                            match.SportEventID = sportEvent.ID;
                            match.SportEvent = sportEvent;

                            foreach (var bet in match.Bets)
                            {
                                bet.MatchID = match.ID;
                                bet.Match = match;

                                foreach (var odd in bet.Odds)
                                {
                                    odd.BetID = bet.ID;
                                    odd.Bet = bet;
                                }
                            }
                        }
                    }
                }
                context.XmlSports.Add(xmlSport);
                uow.Commit();
            }
        }
    }
}






