using Raylib_cs;
using Slutprojektet;


Raylib.InitWindow(1280, 800, "Untitled");
Raylib.SetTargetFPS(60); 
Outside outside = new Outside();
House house = new House();
Character character;
string currentScene = "HouseScene";
Color backgroundcolor = new Color(255, 255, 255, 255);
Texture2D berryImage = Raylib.LoadTexture("berry.png");
Texture2D playerModel = Raylib.LoadTexture("CharacterImage.png");
Texture2D outsideImage = Raylib.LoadTexture("OutsideBackground.png");
Texture2D HouseImage = Raylib.LoadTexture("HouseImage.png");
Texture2D wrenchTexture = Raylib.LoadTexture("WrenchImage.png");
Texture2D doorImage = Raylib.LoadTexture("DoorImage.png");


character = new Character(playerModel);
List<string> inventory = new List<string>();


while (Raylib.WindowShouldClose() == false)
{
    
    Raylib.BeginDrawing();
    Raylib.ClearBackground(backgroundcolor);

    if (currentScene == "outside")
    {
    outside.DrawOutsideroomScene(character, outsideImage, doorImage, wrenchTexture, berryImage); 
    character.Update();

    Rectangle brokenCar = new Rectangle(1050, 230, wrenchTexture.Width, wrenchTexture.Height);
    if (Raylib.CheckCollisionRecs(character.player, brokenCar) && house.hasWrench)
    {
        outside.workingCar = true;
        character.AddToInventory("Car");
     }

    Rectangle berry1 = new Rectangle(300, 560, wrenchTexture.Width, wrenchTexture.Height);
    Rectangle berry2 = new Rectangle(400, 560, wrenchTexture.Width, wrenchTexture.Height);
    Rectangle berry3 = new Rectangle(500, 560, wrenchTexture.Width, wrenchTexture.Height);

    if (Raylib.CheckCollisionRecs(character.player, berry1))
    {
         outside.allBerries = true;
     }




    if (character.currentScene == "HouseScene")
        {
            currentScene = "HouseScene";
        }
    }
    
    else if (currentScene == "HouseScene")
    {
        house.DrawInsideHouseScene(character, HouseImage, wrenchTexture, doorImage);
        Rectangle wrenchRect = new Rectangle(1100, 500, wrenchTexture.Width, wrenchTexture.Height);


        if (Raylib.CheckCollisionRecs(character.player, wrenchRect))
        {
            house.hasWrench = true;
            wrenchRect.X = -10000;
            wrenchRect.Y = -10000;  
            character.AddToInventory("Wrench");
        }

        if (character.currentScene == "outside")
        {
            currentScene = "outside";
        }
    }




    Raylib.EndDrawing();
}





// För Godkänt - Behövs Generisk klass (List) (das it)
// ideee:
// day in the life of farmer,  vakna upp,  gör tasks?,  somna, game over
// olika hus/gårdar osv = olika klasser, därmed arv?
// list????,   inventory,  att han har wrench, ksk även ho