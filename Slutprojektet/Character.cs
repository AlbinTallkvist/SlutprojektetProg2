using Raylib_cs;
using System.Collections.Generic;
using System.Numerics;


namespace Slutprojektet
{
    public class Character
    {
        // Saker som behövs för spel ska funka, karaktärs speed, list:n, världen 
        public Texture2D PlayerModel;
        float WalkSpeed = 4f;
        public Rectangle player;
        public List<string> Inventory;
        public string currentScene;

        // Skapar kontrollerbara rektangeln/huvudkaraktären med sprites/bilderna som laddades in & skapa Inventory list  
        public Character(Texture2D playerModel)
        {
            PlayerModel = playerModel;
            player = new Rectangle(415, 60, PlayerModel.Width, PlayerModel.Height);
            Inventory = new List<string>();
        }
    
        // skapar en metod "addtoinventory" som lägger till en string (item) i inventoryn
        public void AddToInventory(string item)
        {
            Inventory.Add(item);
        }

        // uppdatera spelarens position genom att tilldela de nya x och y världen till spelarens position (så att jag kan ändra start-position i ny map)
         public void SetPosition(Vector2 position)
        {
            player.X = position.X;
            player.Y = position.Y;
        }


    // Movement-controls i spelet, WASD för röra sig
    public void Update()
    {
        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            player.X += WalkSpeed;

            if (player.X > Raylib.GetScreenWidth() - player.Width)
            {
                player.X = Raylib.GetScreenWidth() - player.Width;
            }
        }

        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            player.X -= WalkSpeed;

            if (player.X < 0)
            {
                player.X = 0;
            }
        }

        if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            player.Y += WalkSpeed;

            if (player.Y > Raylib.GetScreenHeight() - player.Height)
            {
                player.Y = Raylib.GetScreenHeight() - player.Height;
            }
        }

        if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            player.Y -= WalkSpeed;

            if (player.Y < 0)
            {
                player.Y = 0;
            }
        }
    
       

    }
}
}