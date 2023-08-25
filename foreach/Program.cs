using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @foreach
{

    class Program
    {
       static Vector3 position ;
        private delegate void InputHandler(List<Buttons> dir);
        private static event InputHandler playerInput;
        enum Buttons {NULL,A,W,S,D}
        private static void Start() 
        {
            playerInput += INPUT;  
            position = new Vector3();
            
        }
        private static void Update() 
        {
            InputOnButtons();
            
        }
        private static void InputOnButtons() 
        {
            ConsoleKeyInfo input=Console.ReadKey(true);
            List<Buttons> direct = new List<Buttons>();
            if (ConsoleKey.A == input.Key)
                direct.Add(Buttons.A);
            if (ConsoleKey.S == input.Key)
                direct.Add(Buttons.S);
            if (ConsoleKey.W == input.Key)
                direct.Add(Buttons.W);
            if (ConsoleKey.D == input.Key)
                direct.Add(Buttons.D);
            playerInput?.Invoke(direct);
        }
        private static void INPUT(List<Buttons> dir) 
        {
            move(dir);
        }
        private static void move(List<Buttons>dir) 
        {
          
            if (dir.Contains(Buttons.A)) 
            {
                position = new Vector3(--position.x,position.y,position.z);
            }
            if (dir.Contains(Buttons.D))
            {
                // Console.WriteLine("D");
                position = new Vector3(++position.x, position.y, position.z);
            }
            if (dir.Contains(Buttons.S))
            {
                //Console.WriteLine("S");
                position = new Vector3(position.x, --position.y, position.z);
            }
            if (dir.Contains(Buttons.W))
            {
                //Console.WriteLine("W");
                position = new Vector3(position.x, ++position.y, position.z);
            }
        }
        static void Main(string[] args)
        {
            Start();
            while (true)
                Update();
        }
    }
    class Vector3 
    {
        public Vector3(float x=0,float y=0, float z=0) 
        {
            this.x = x;
            this.y = y;
            this.z = z;
            Console.WriteLine($"X:{x} Y:{y} z:{z}");
        }
        public float x, y, z;
    }
}
