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
    Raylib.DrawText("Objectives", 5, 10, 35, Color.Red);
    Raylib.DrawText("#1 Fix The Car", 5, 50, 30, Color.Red);
    Raylib.DrawText("#2 Collect Berries", 5, 80, 30, Color.Red);
    Raylib.DrawText("#3 Go to Sleep", 5, 110, 30, Color.Red);


    Rectangle brokenCar = new Rectangle(1050, 230, wrenchTexture.Width, wrenchTexture.Height);
    if (Raylib.CheckCollisionRecs(character.player, brokenCar) && house.hasWrench)
    {
        outside.workingCar = true;
        character.AddToInventory("Car");
        System.Console.WriteLine("Car Fixed");
     }

    List<Rectangle> berryRectangles = new List<Rectangle>();
    berryRectangles.Add(new Rectangle(300, 560, wrenchTexture.Width, wrenchTexture.Height));
    berryRectangles.Add(new Rectangle(400, 560, wrenchTexture.Width, wrenchTexture.Height));
    berryRectangles.Add(new Rectangle(500, 560, wrenchTexture.Width, wrenchTexture.Height));

    foreach (Rectangle berry in berryRectangles)
    {
        if (Raylib.CheckCollisionRecs(character.player, berry))
        {
            berryRectangles.Remove(berry);
            character.AddToInventory("Berry");
            System.Console.WriteLine("Berry collected");
            break;
        }
    }

    foreach (Rectangle berry in berryRectangles)
    {
        Raylib.DrawTexture(wrenchTexture, (int)berry.X, (int)berry.Y, Color.White);
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
        Raylib.DrawText("Objectives", 5, 10, 35, Color.Red);
        Raylib.DrawText("#1 Fix The Car", 5, 50, 30, Color.Red);
        Raylib.DrawText("#2 Collect Berries", 5, 80, 30, Color.Red);
        Raylib.DrawText("#3 Go to Sleep", 5, 110, 30, Color.Red);



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



        // ADDA HÄR GÅ LÄGG DIG SAKEN
        Rectangle bedSleep = new Rectangle(675, 200, doorImage.Width, doorImage.Height);
        if (Raylib.CheckCollisionRecs(character.player, bedSleep) && inventory.Contains("Car") && inventory.Contains("Berry"))
        {
            Console.WriteLine("WHY WONT THIS WORK");
            System.Environment.Exit(1);
        }

    Raylib.EndDrawing();
}





// För Godkänt - Behövs Generisk klass (List) (das it)
// ideee:
// day in the life of farmer,  vakna upp,  gör tasks?,  somna, game over
// olika hus/gårdar osv = olika klasser, därmed arv?
// list????,   inventory,  att han har wrench, ksk även ho