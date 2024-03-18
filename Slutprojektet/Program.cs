using Raylib_cs;
using Slutprojektet;


Raylib.InitWindow(1280, 800, "Untitled");
Raylib.SetTargetFPS(60); 
Outside outside = new Outside();
House house = new House();
Character character;
string currentScene = "StartScreen";
Color backgroundcolor = new Color(255, 255, 255, 255);
Texture2D playerModel = Raylib.LoadTexture("CharacterImage.png");
Texture2D outsideImage = Raylib.LoadTexture("OutsideBackground.png");
Texture2D HouseImage = Raylib.LoadTexture("HouseImage.png");
character = new Character(playerModel);

while (Raylib.WindowShouldClose() == false)
{
    
    Raylib.BeginDrawing();
    Raylib.ClearBackground(backgroundcolor);

    if (currentScene == "StartScreen")
    {
    outside.DrawOutsideroomScene(character, outsideImage);
    character.Update();
    }
    
    else if (currentScene == "HouseScene")
    {
        house.DrawInsideHouseScene(character, HouseImage);
    }



    Raylib.EndDrawing();
}





// För Godkänt - Behövs Generisk klass (List) (das it)
// ideee:
// day in the life of farmer,  vakna upp,  gör tasks?,  somna, game over
// olika hus/gårdar osv = olika klasser, därmed arv?
// list????,   inventory,  att han har wrench, ksk även hoe