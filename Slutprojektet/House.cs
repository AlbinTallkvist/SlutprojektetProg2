using Raylib_cs;
using System.Numerics;

namespace Slutprojektet
{
    public class House
    {
        public bool hasWrench = false;

        public void DrawInsideHouseScene(Character character, Texture2D HouseImage, Texture2D wrenchTexture, Texture2D doorImage)
        {
            character.Update();

            Raylib.DrawTexture(HouseImage, 0, 0, Color.White);
            Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, Color.White);
           
            Rectangle sceneChangeToOutside = new Rectangle(600, 650, doorImage.Width, doorImage.Height);
            Raylib.DrawTexture(doorImage, 600, 630, Color.White);
            Vector2 newPosition = new Vector2(300, 300); 

            if (!hasWrench)
            {
                Raylib.DrawTexture(wrenchTexture, 1100, 500, Color.White);
            }

            if (Raylib.CheckCollisionRecs(character.player, sceneChangeToOutside))
            {
                character.currentScene = "outside";
                character.SetPosition(newPosition);
            }

        }
    }
}
