using Raylib_cs;

namespace Slutprojektet
{
    public class Outside
    {


        public void DrawOutsideroomScene(Character character, Texture2D outsideImage)
        {
            character.Update();
            
            Raylib.DrawTexture(outsideImage, 0, 0, Color.White);
            Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, Color.White);
        }
    }
}
