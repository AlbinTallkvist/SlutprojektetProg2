using Raylib_cs;

namespace Slutprojektet
{
    public class House
    {


        public void DrawInsideHouseScene(Character character, Texture2D HouseImage)
        {
            character.Update();
            
            Raylib.DrawTexture(HouseImage, 0, 0, Color.White);
            Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, Color.White);
        }
    }
}
