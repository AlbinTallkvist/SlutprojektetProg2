using Raylib_cs;

namespace Slutprojektet
{
    public class House
    {

        public void DrawInsideHouseScene(Character character, Texture2D HouseImage, Texture2D wrenchTexture)
        {
            character.Update();
            Raylib.DrawTexture(HouseImage, 0, 0, Color.White);
            Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, Color.White);
            Raylib.DrawTexture(wrenchTexture, 600, 700, Color.White); 
            System.Console.WriteLine("hola");  // JAG HITTADE BUGGEN (FIXA IMORN)

        }
    }
}
