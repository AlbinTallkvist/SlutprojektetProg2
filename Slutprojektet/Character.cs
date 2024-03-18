using Raylib_cs;

namespace Slutprojektet
{
    public class Character
    {
        public Texture2D PlayerModel;
        float WalkSpeed = 2f;
        public Rectangle player;

        public Character(Texture2D playerModel)
        {
            PlayerModel = playerModel;
            player = new Rectangle(415, 60, PlayerModel.Width, PlayerModel.Height);
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