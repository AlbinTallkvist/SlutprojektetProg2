using Raylib_cs;
using System.Collections.Generic;
using System.Numerics;


namespace Slutprojektet
{
    public class Character
    {
        public Texture2D PlayerModel;
        float WalkSpeed = 4f;
        public Rectangle player;
        public List<string> Inventory;
        public string currentScene;


        public Character(Texture2D playerModel)
        {
            PlayerModel = playerModel;
            player = new Rectangle(415, 60, PlayerModel.Width, PlayerModel.Height);
            Inventory = new List<string>();
        }
    
        public void AddToInventory(string item)
        {
            Inventory.Add(item);
        }

         public void SetPosition(Vector2 position)
        {
            player.X = position.X;
            player.Y = position.Y;
        }



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