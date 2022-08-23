using System;
using System.Runtime.CompilerServices;
using PoC.Microservice.Interfaces;
using PoC.Microservice.Models;
[assembly: InternalsVisibleTo("PoC.Tests")]

namespace PoC.Microservice.Services
{
    public class HaromszogService : IHaromszogService
    {
        const int oldalHossz = 150;
        const int atloHossz = 213;
        private IHaromszogRepository _repository;
        internal HaromszogModel haromszog;
        public HaromszogService(IHaromszogRepository repository)
        {
            _repository = repository;
        }

        public HaromszogModel CreateHaromszog(string guid, int screenWidth, int screenHeight)
        {
            PontModel P1 = GenerateKezdoKoordinatak(screenWidth, screenHeight);
            PontModel P2 = new PontModel() { X = P1.X + oldalHossz, Y = P1.Y };
            PontModel P3 = new PontModel() { X = P1.X + oldalHossz, Y = P1.Y + oldalHossz };
            PontModel M = GenerateIrany();
            haromszog = new HaromszogModel() { Guid = guid, Pont1 = P1, Pont2 = P2, Pont3 = P3, Irany = M,Color="aqua" };
            _repository.Persist(haromszog);
            return haromszog;
        }

        public HaromszogModel UpdateHaromszogKoordinatak(int screenWidth, int screenHeight)
        {
            if (FalnalJarEllenorzes(screenWidth, screenHeight))
                UjIranyMeghatarozasa(screenWidth, screenHeight);
            SetKoordinate();
            _repository.Update(haromszog);
            return haromszog;
        }

        public HaromszogModel Load(string guid)
        {
            return haromszog = _repository.Load(guid);
        }

        #region PrivateMethods

        private PontModel GenerateKezdoKoordinatak(int screenwidth, int screenheight)
        {
            Random r = new Random();
            int randomX = r.Next(0, screenwidth - oldalHossz);
            int randomY = r.Next(0, screenheight - oldalHossz);
            return new PontModel() { X = randomX, Y = randomY };
        }

        private PontModel GenerateIrany()
        {
            Random r = new Random();
            int randomX;
            int randomY;
            do
            {
                randomX = r.Next(-4, 4);
                randomY = r.Next(-4, 4);
            } while (randomX == 0 && randomY == 0);

            
            return new PontModel() { X = randomX, Y = randomY };
        }

        private void SetKoordinate()
        {
            haromszog.Pont1.X += haromszog.Irany.X;
            haromszog.Pont1.Y += haromszog.Irany.Y;
            haromszog.Pont2.X += haromszog.Irany.X;
            haromszog.Pont2.Y += haromszog.Irany.Y;
            haromszog.Pont3.X += haromszog.Irany.X;
            haromszog.Pont3.Y += haromszog.Irany.Y;
        }

        private bool FalnalJarEllenorzes(int screenWidth, int screenHeight)
        {
            return haromszog.Pont1.X + oldalHossz >= screenWidth || haromszog.Pont1.Y + atloHossz >= screenHeight ||
                   haromszog.Pont1.Y <= 0 || haromszog.Pont1.X <= 0;
        }

        private void UjIranyMeghatarozasa(int screenwidth, int screenheight)
        {
            if (haromszog.Pont1.X <= 0 || (haromszog.Pont1.X +oldalHossz) >= screenwidth)
            {
                haromszog.Irany.X *= -1;
                if (haromszog.Irany.Y == 0)
                {
                    Random r = new Random();
                    haromszog.Irany.Y = r.Next(-4, 4);
                }
            }

            if (haromszog.Pont1.Y <= 0 || (haromszog.Pont1.Y +atloHossz) >= screenheight)
            {
                haromszog.Irany.Y *= -1;
                if (haromszog.Irany.X == 0)
                {
                    Random r = new Random();
                    haromszog.Irany.X = r.Next(-4, 4);
                }
            }

        }

        #endregion
    }
}