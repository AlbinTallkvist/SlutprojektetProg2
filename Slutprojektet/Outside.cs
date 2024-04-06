using Raylib_cs;
using System.Numerics;

namespace Slutprojektet
{
    public class Outside
    {
        public bool workingCar = false;
        public bool allBerries = false;

        public void DrawOutsideroomScene(Character character, Texture2D outsideImage, Texture2D doorImage, Texture2D wrenchTexture, Texture2D berryImage)
        {
            character.Update();
            Raylib.DrawTexture(outsideImage, 0, 0, Color.White);
            Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, Color.White);


            //berries 1050, 230

            Rectangle sceneChangeToHouse = new Rectangle(300, 110, doorImage.Width, doorImage.Height);
            Raylib.DrawTexture(doorImage, 300, 110, Color.White);
            Vector2 newPosition = new Vector2(500, 500); 


            if (Raylib.CheckCollisionRecs(character.player, sceneChangeToHouse))
            {
                character.currentScene = "HouseScene";
                character.SetPosition(newPosition);
            }            

        }
    }
}
