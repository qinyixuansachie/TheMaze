using System.Data;

class TheMazeApplication
{
    const string MENU = "1 - Read Game Instruction\n" + 
    "2 - Play!\n" +
    "3 - Check Your Points\n" +
    "4 - Clear Your Points (CAUTION!)\n" +
    "5 - Quit";
    const string INSTRUCTION = "Hi! Welcome to The Maze!\n\n" +
    "The game is very simple -- use direction keys to explore the map and move to the exit.\n" + 
    "# - This is a wall, you are not allowed to go here.\n" + 
    "& - This is you, the player.\n" + 
    "$ - This is the key, you have to obtain the key for the exit to show.\n" + 
    "O - This is a portal, stepping on it will send you to the other portal.\n" + 
    "You can check your score from the main menu.\n\n" + 
    "Now, let's start!";
    const string LEVEL_SELECTION = "Select the level you want to play:\n" + 
    "0 - Tutorial (1 PT)\n" + 
    "1 - Level 1 (2 PT)\n" + 
    "2 - level 2 (3 PT)\n" + 
    "3 - Back";

    static int points = 0;

    static void Main(string[] args)
    {   
        //display main menu
        int channel = SelectChannel();
        while (channel != 5){
            if (channel == 1){
                Console.Clear();
                Console.WriteLine(INSTRUCTION);
                channel = SelectChannel();
            }
            else if (channel == 2){
                Console.Clear();
                int level = SelectLevel();
                while (level != 3){
                    if (level == 0){
                        Console.Clear();
                        RunLevel0();
                        level = SelectLevel();
                    }
                    else if (level == 1){
                        Console.Clear();
                        RunLevel1();
                        level = SelectLevel();
                    }
                    else if (level == 2){
                        Console.Clear();
                        RunLevel2();
                        level = SelectLevel();
                    }
                    else {
                        Console.WriteLine("Please enter an option between 0 to 3:");
                        level = SelectLevel();
                    }
                }
                //if player selects 3 - return to main menu
                Console.Clear();
                channel = SelectChannel();
            }
            else if (channel == 3) {
                Console.Clear();
                Console.WriteLine("You currently have: " + points + " points!");
                channel = SelectChannel();
            }
            else if (channel == 4) {
                points = 0;
                Console.Clear();
                Console.WriteLine("Your points have been reset.");
                Console.WriteLine("You currently have: " + points + " points.");
                channel = SelectChannel();
            }
            else {
                Console.WriteLine("Please enter an option between 1 to 5:");
                channel = SelectChannel();
            }
        }
        if (channel == 5){
            Console.WriteLine("Thank you for playing The Maze!");
        }
        
        
    }
    static void RunLevel0()
    {
        char[][] map = 
        {
            "####################".ToCharArray(),
            "####################".ToCharArray(),
            "&         $         ".ToCharArray(),
            "####################".ToCharArray(),
            "####################".ToCharArray()
        };
        int exit_i = 2;
        int exit_j = 19;
        int player_i = 2;
        int player_j = 0;
        int key_i = 2;
        int key_j = 10;
        int stepsAllowed = 19;
        DrawMap(map, stepsAllowed);
        while (! (player_i == exit_i && player_j == exit_j)){
            (player_i, player_j) = MakeAMove(map, player_i, player_j);
            stepsAllowed -= 1;
            if (stepsAllowed < 0){
                Console.WriteLine("Game failed - You are out of steps!");
                break;
            }
            if (player_i == key_i && player_j == key_j){
                map[exit_i][exit_j] = 'E';
            }
            DrawMap(map, stepsAllowed);
        }
        points += 1;
        Console.WriteLine("Game Success - Congratulations!");
        Console.WriteLine("You have gained 1 PT!\n");
    }
    static void RunLevel1()
    {
       char[][] map = 
        {
            "####################".ToCharArray(),
            "            $      #".ToCharArray(),
            "  #######  ######  #".ToCharArray(),
            "& ##       ##      #".ToCharArray(),
            "####   #############".ToCharArray(),
            "####               #".ToCharArray(),
            "####################".ToCharArray()
        };
        int exit_i = 5;
        int exit_j = 18;
        int player_i = 3;
        int player_j = 0;
        int key_i = 1;
        int key_j = 12;
        int stepsAllowed = 36;
        DrawMap(map, stepsAllowed);
        while (! (player_i == exit_i && player_j == exit_j)){
            (player_i, player_j) = MakeAMove(map, player_i, player_j);
            stepsAllowed -= 1;
            if (stepsAllowed < 0){
                Console.WriteLine("Game failed - You are out of steps!");
                break;
            }
            if (player_i == key_i && player_j == key_j){
                map[exit_i][exit_j] = 'E';
            }
            DrawMap(map, stepsAllowed);
        }
        points += 2;
        Console.WriteLine("Game Success - Congratulations!");
        Console.WriteLine("You have gained 2 PT!\n");
    }
     static void RunLevel2()
    {
       char[][] map = 
        {
            "####################".ToCharArray(),
            "            $      #".ToCharArray(),
            "  #######  ######  #".ToCharArray(),
            "& ##       ##O     #".ToCharArray(),
            "####   #############".ToCharArray(),
            "####         O     #".ToCharArray(),
            "####################".ToCharArray()
        };
        int exit_i = 5;
        int exit_j = 18;
        int player_i = 3;
        int player_j = 0;
        int key_i = 1;
        int key_j = 12;
        int stepsAllowed = 30;
        DrawMap(map, stepsAllowed);
        while (! (player_i == exit_i && player_j == exit_j)){
            (player_i, player_j) = MakeAMove(map, player_i, player_j);
            stepsAllowed -= 1;
            if (stepsAllowed < 0){
                Console.WriteLine("Game failed - You are out of steps!\n");
                break;
            }
            if (player_i == key_i && player_j == key_j){
                map[exit_i][exit_j] = 'E';
            }
            DrawMap(map, stepsAllowed);
        }
        points += 3;
        Console.WriteLine("Game Success - Congratulations!");
        Console.WriteLine("You have gained 3 PT!\n");
    }

    static int SelectChannel(){
        Console.WriteLine(MENU);
        return int.Parse(Console.ReadLine());
    }

    static int SelectLevel(){
        Console.WriteLine(LEVEL_SELECTION);
        return int.Parse(Console.ReadLine());
    }

    static void DrawMap(char[][] map, int stepsAllowed){
        Console.Clear();
        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[0].Length; x++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(map[y][x]);
            }
        }
        Console.WriteLine("Step limit:" + stepsAllowed);
    }

    static (int, int) MakeAMove(char[][] map, int i, int j){
        ConsoleKeyInfo k = Console.ReadKey();
        if (k.Key == ConsoleKey.RightArrow){
            if(CanMove(map, i, j + 1)){
                map[i][j] = ' ';
                map[i][j + 1] = '&';
                return (i, j + 1);
            }
        }
        else if (k.Key == ConsoleKey.LeftArrow){
            if(CanMove(map, i, j - 1)){
                if (map[i][j - 1] == 'O'){
                    map[i][j] = ' ';
                    map[i][j - 1] = '&';
                    return CrossPortal(map, i, j - 1);
                }
                map[i][j] = ' ';
                map[i][j - 1] = '&';
                return (i, j - 1);
            }
        }
        else if (k.Key == ConsoleKey.UpArrow){
            if(CanMove(map, i - 1, j)){
                map[i][j] = ' ';
                map[i - 1][j] = '&';
                return (i - 1, j);
            }
        }
        else if (k.Key == ConsoleKey.DownArrow){
            if(CanMove(map, i + 1, j)){
                map[i][j] = ' ';
                map[i + 1][j] = '&';
                return (i + 1, j);
            }
        }
        return (i, j);
        
    }

    static bool CanMove(char[][] map, int i, int j){
        if (j < 0 || j >= map[0].Length || i < 0 || i >= map.Length){
            return false;
        }
        if (map[i][j] == '#'){
            return false;
        }
        return true;
    }

    static (int, int) CrossPortal(char[][] map, int i, int j){
        map[i][j] = ' ';
        map[5][13] = '&';
        return (5, 13);
    }
}
