using System;
using System.Collections.Generic;
using System.Text;

namespace _09_UpcastingDowncastingExplicitImplicit
{
    internal class Eagle : Animal
    {
        public int FlySpeed { get; set; }
        public void Fly()
        {
            Console.WriteLine("flied away");
        }
    }
}
