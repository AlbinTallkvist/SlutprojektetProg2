using Raylib_cs;
using System.Numerics;

namespace Slutprojektet
{
    public class Outside
    {
        // gör så att spelaren inte har bär i början och att bilen inte är fixad (dvs den är trasig)
        public bool workingCar = false;
        public bool allBerries = false;

        // Metoden för att rita ut världen/rummet/scenen, karaktären kolliderar med dörr = byt map, och dörrens textur/bild
        public void DrawOutsideroomScene(Character character, Texture2D outsideImage, Texture2D doorImage, Texture2D wrenchTexture, Texture2D berryImage)
        {
            character.Update();
            Raylib.DrawTexture(outsideImage, 0, 0, Color.White);
            Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, Color.White);

            // skapa & rita ut dörren, samt välj spawnpoint på utsidan för karaktären
            Rectangle sceneChangeToHouse = new Rectangle(300, 110, doorImage.Width, doorImage.Height);
            Raylib.DrawTexture(doorImage, 300, 110, Color.White);
            Vector2 newPosition = new Vector2(500, 500); 

            // kollar om spelaren kolliderar med dörren, såntfall byt till hus-scenen
            if (Raylib.CheckCollisionRecs(character.player, sceneChangeToHouse))
            {
                character.currentScene = "HouseScene";
                character.SetPosition(newPosition);
            }            

        }
    }
}
