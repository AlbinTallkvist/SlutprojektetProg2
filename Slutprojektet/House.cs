using Raylib_cs;
using System.Numerics;

namespace Slutprojektet
{
    public class House
    {
        // gör så att spelaren inte har skiftnyckeln när dom börjar spelet
        public bool hasWrench = false;

        // Metoden för att rita ut världen/rummet/scenen, karaktären kolliderar med dörr = byt map, kolliderar med säng och har allt = game over, kollidear skiftnyckel = pick up, dörrens textur/bild, 
        public void DrawInsideHouseScene(Character character, Texture2D HouseImage, Texture2D wrenchTexture, Texture2D doorImage)
        {
            character.Update();
            Raylib.DrawTexture(HouseImage, 0, 0, Color.White);
            Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, Color.White);

            // spelare spawnpoint, rita ut gå & sov funktion, rita ut dörr 
            Rectangle sceneChangeToOutside = new Rectangle(600, 650, doorImage.Width, doorImage.Height);
            Raylib.DrawTexture(doorImage, 600, 630, Color.White);
            Vector2 newPosition = new Vector2(300, 300); 
            Rectangle bedSleep = new Rectangle(675, 200, doorImage.Width, doorImage.Height);

            // om spelaren har fullt inventory(allt), avsluta spel om i säng
            if (Raylib.CheckCollisionRecs(character.player, bedSleep) && character.Inventory.Contains("Car") && character.Inventory.Contains("Berry"))
            {
                System.Environment.Exit(1);
            }

            // om spelaren inte har skiftnyckel, rita ut den
            if (!hasWrench)
            {
                Raylib.DrawTexture(wrenchTexture, 1100, 500, Color.White);
            }

            // om spelaren kollidear med dörr, gå utomhus, byt scen
            if (Raylib.CheckCollisionRecs(character.player, sceneChangeToOutside))
            {
                character.currentScene = "outside";
                character.SetPosition(newPosition);
            }

        }
  
    }
}
