Console.Clear();

int Kartenwert = 0;
int randomKarte = 0;
int ZweiteKarte = 0;
int dritteKarte = 0;
int Gesamtwert = 0;
int DealersGesamtwert = 0;
int Bet = 0;
int wert = 0;
string n;
const int ASS = 1;
const int BUBE = 11;
const int DAME = 12;
const int KÖNIG = 13;
decimal Guthaben = 100;
decimal DealersGuthaben = 100;

void PrintWelcome()
{
    System.Console.WriteLine("*** WELCOME TO BLACKJACK ***");
    System.Console.WriteLine("You have 100€ in your pocket. Try to double it!");
    System.Console.WriteLine("You will lose if you have no money left");
}
System.Console.WriteLine("*** ROUND 1 du hast 100 euro ***");

void HandoutRandomCard()
{
    randomKarte = Random.Shared.Next(1, 14);

    switch (randomKarte)
    {
        case 2:
            Kartenwert += 2;
            break;

        case 3:
            Kartenwert += 3;
            break;

        case 4:
            Kartenwert += 4;
            break;

        case 5:
            Kartenwert += 5;
            break;

        case 6:
            Kartenwert += 6;
            break;

        case 7:
            Kartenwert += 7;
            break;

        case 8:
            Kartenwert += 8;
            break;

        case 9:
            Kartenwert += 9;
            break;

        case BUBE:
        case DAME:
        case KÖNIG:
            Kartenwert += 10;
            break;

        case ASS:
            Kartenwert += 11;
            break;
    }
}

void PrintCard()
{
    System.Console.WriteLine("Deine random Karte ist " + randomKarte);
    System.Console.WriteLine("Dein Kartenwert ist " + Kartenwert);
}

void AskForBet()
{
    do
    {
        System.Console.WriteLine("How much do you want to bet? Bet must be >= 10€ and <= 100€.");
        Bet = int.Parse(Console.ReadLine()!);

        if (Bet <= 10)
        {
            System.Console.WriteLine("Mindestbetrag ist 10 Euro");
        }
    }
    while (Bet >= 100 || Bet <= 10);
}

void PrintSecondCard()
{
    ZweiteKarte = Random.Shared.Next(1, 14);
    System.Console.WriteLine("Deine random Karte ist " + ZweiteKarte);
    wert = ZweiteKarte + randomKarte;
    System.Console.WriteLine("dein gesamtwert ist " + wert);
}

void AskIfAnotherCard()
{
    System.Console.WriteLine("willst du noch eine Karte? j/n");
    string j = Console.ReadLine()!;

    if (j == "j")
    {
        dritteKarte = Random.Shared.Next(1, 14);
        System.Console.WriteLine("Deine random Karte ist " + dritteKarte);
        Gesamtwert = wert + randomKarte;
        System.Console.WriteLine("dein gesamtwert ist " + Gesamtwert);
    }   
}

void ComputerHandoutCard()
{
    do
    {
        DealersGesamtwert = Random.Shared.Next(1, 14);
        System.Console.WriteLine("Dealers random Karte ist " + randomKarte);
        System.Console.WriteLine("Dealers Kartenwert ist " + Kartenwert);
    }
    while (DealersGesamtwert == 16 || DealersGesamtwert >= 16);
}

void PrintWinner()
{
    if (DealersGesamtwert >= 21 || Gesamtwert > DealersGesamtwert)
    {
        System.Console.WriteLine("You won. Dealer lose!");
        Guthaben += Bet * 2;
    }
    else if (DealersGesamtwert >= Gesamtwert || Gesamtwert >= 21)
    {
        System.Console.WriteLine("You lost. Dealer wins!");
        DealersGuthaben += Bet;
    }
    else if (DealersGesamtwert == Gesamtwert)
    {
        System.Console.WriteLine("Standoff");
        Guthaben += Bet;
    }
}

void EndingGame()
{
    if (Guthaben <= 10)
    {
        System.Console.WriteLine("You lost the game");
    }
    else if (Guthaben >= 200)
    {
        System.Console.WriteLine("You won the game");
    }
}

PrintWelcome();
HandoutRandomCard();
PrintCard();
AskForBet();
PrintSecondCard();
AskIfAnotherCard();
ComputerHandoutCard();
PrintWinner();
EndingGame();