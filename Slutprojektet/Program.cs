﻿using Raylib_cs;
using Slutprojektet;

Raylib.InitWindow(1280, 800, "Farm");
Raylib.SetTargetFPS(60); 

// Skapar 3 instanser av de 3 klasser/scener i spelet
Outside outside = new Outside();
House house = new House();
Character character;

// Laddar in texturerna för alla karktärer osv, Standard inställningar, hur stor ska resolutionen vara och fps
string currentScene = "HouseScene";
Color backgroundcolor = new Color(255, 255, 255, 255);
Texture2D berryImage = Raylib.LoadTexture("berry.png");
Texture2D playerModel = Raylib.LoadTexture("CharacterImage.png");
Texture2D outsideImage = Raylib.LoadTexture("OutsideBackground.png");
Texture2D HouseImage = Raylib.LoadTexture("HouseImage.png");
Texture2D wrenchTexture = Raylib.LoadTexture("WrenchImage.png");
Texture2D doorImage = Raylib.LoadTexture("DoorImage.png"); 
character = new Character(playerModel);

// Starten till game-loopen
while (Raylib.WindowShouldClose() == false)
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(backgroundcolor);

    // Rita ut utsidan-map
    if (currentScene == "outside")
    {
    // Rita utsidan via metod
    outside.DrawOutsideroomScene(character, outsideImage, doorImage, wrenchTexture, berryImage); 
    character.Update();
    // Info-text ritas ut i hörn
    Raylib.DrawText("Objectives", 5, 10, 35, Color.Red);
    Raylib.DrawText("#1 Fix The Car", 5, 50, 30, Color.Red);
    Raylib.DrawText("#2 Collect Berries", 5, 80, 30, Color.Red);
    Raylib.DrawText("#3 Go to Sleep", 5, 110, 30, Color.Red);

    // Rita ut bilen
    Rectangle brokenCar = new Rectangle(1050, 230, wrenchTexture.Width, wrenchTexture.Height);
    // Om spelaren kollidear med bilen och har skiftnyckel, fixa bilen
    if (Raylib.CheckCollisionRecs(character.player, brokenCar) && house.hasWrench)
    {
        outside.workingCar = true;
        character.AddToInventory("Car");
        System.Console.WriteLine("Car Fixed");
     }

    // Skapa ny list för alla bär spelaren kan plocka upp
    List<Rectangle> berryRectangles = new List<Rectangle>();
    // Rita ut bär på map
    berryRectangles.Add(new Rectangle(300, 560, wrenchTexture.Width, wrenchTexture.Height));
    berryRectangles.Add(new Rectangle(400, 560, wrenchTexture.Width, wrenchTexture.Height));
    berryRectangles.Add(new Rectangle(500, 560, wrenchTexture.Width, wrenchTexture.Height));

    // Ta bort bär om man kollidear med bär, gäller alla bär i list
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

    // Rita ut bär på map, med alla settings valda ovan ^
    foreach (Rectangle berry in berryRectangles)
    {
        Raylib.DrawTexture(wrenchTexture, (int)berry.X, (int)berry.Y, Color.White);
    }

    if (character.currentScene == "HouseScene")
        {
            currentScene = "HouseScene";
        }
    }
    
    // Rita ut inomhus-scenen
    else if (currentScene == "HouseScene")
    {
        // Rita ut map via metoden från klass
        house.DrawInsideHouseScene(character, HouseImage, wrenchTexture, doorImage);
        // Rit aut skiftnyckeln
        Rectangle wrenchRect = new Rectangle(1100, 500, wrenchTexture.Width, wrenchTexture.Height);
        // Info-text ritas ut i hörn
        Raylib.DrawText("Objectives", 5, 10, 35, Color.Red);
        Raylib.DrawText("#1 Fix The Car", 5, 50, 30, Color.Red);
        Raylib.DrawText("#2 Collect Berries", 5, 80, 30, Color.Red);
        Raylib.DrawText("#3 Go to Sleep", 5, 110, 30, Color.Red);

        // Om spelaren kollidear med den utritade skiftnyckeln, gör "har skiftnyckel" till true så kan använda på bil och tp bort från map
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