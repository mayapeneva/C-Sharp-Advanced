using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var firstPlayersCards = new Queue<string>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        var secondPlayersCards = new Queue<string>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

        var turns = 0;
        for (int i = 0; i < 1000000; i++)
        {
            if (firstPlayersCards.Count < 1 || secondPlayersCards.Count < 1)
            {
                break;
            }

            var cardOneFirstPlayer = firstPlayersCards.Dequeue();
            var cardOneSecondPlayer = secondPlayersCards.Dequeue();

            var firstCardPower = GetCardIntPower(cardOneFirstPlayer);
            var secondCardPower = GetCardIntPower(cardOneSecondPlayer);

            if (firstCardPower > secondCardPower)
            {
                firstPlayersCards.Enqueue(cardOneFirstPlayer);
                firstPlayersCards.Enqueue(cardOneSecondPlayer);
            }
            else if (firstCardPower < secondCardPower)
            {
                secondPlayersCards.Enqueue(cardOneSecondPlayer);
                secondPlayersCards.Enqueue(cardOneFirstPlayer);
            }
            else
            {
                var tempCards = new List<string>();
                tempCards.Add(cardOneFirstPlayer);
                tempCards.Add(cardOneSecondPlayer);

                while (true)
                {
                    if (firstPlayersCards.Count < 3 || secondPlayersCards.Count < 3)
                    {
                        Console.WriteLine($"Draw after {turns + 1} turns");
                        Environment.Exit(0);
                    }

                    string cardTwoFirstPlayer, cardThreeFirstPlayer, cardFourFirstPlayer;
                    int sumFirstPlayer = TakeTheSumOfPlayersCardsWhenWarOn(firstPlayersCards, out cardTwoFirstPlayer, out cardThreeFirstPlayer, out cardFourFirstPlayer);

                    string cardTwoSecondPlayer, cardThreeSecondPlayer, cardFourSecondPlayer;
                    int sumSecondPlayer = TakeTheSumOfPlayersCardsWhenWarOn(secondPlayersCards, out cardTwoSecondPlayer, out cardThreeSecondPlayer, out cardFourSecondPlayer);

                    AddCardInTempList(tempCards, cardTwoFirstPlayer);
                    AddCardInTempList(tempCards, cardThreeFirstPlayer);
                    AddCardInTempList(tempCards, cardFourFirstPlayer);
                    AddCardInTempList(tempCards, cardTwoSecondPlayer);
                    AddCardInTempList(tempCards, cardThreeSecondPlayer);
                    AddCardInTempList(tempCards, cardFourSecondPlayer);

                    if (sumFirstPlayer > sumSecondPlayer)
                    {
                        AddCardsAfterAWarIsWon(firstPlayersCards, tempCards);
                        break;
                    }

                    if (sumFirstPlayer < sumSecondPlayer)
                    {
                        AddCardsAfterAWarIsWon(secondPlayersCards, tempCards);
                        break;
                    }
                }
            }

            turns++;
        }

        Console.WriteLine(firstPlayersCards.Count > secondPlayersCards.Count
            ? $"First player wins after {turns} turns"
            : $"Second player wins after {turns} turns");
    }

    private static int GetCardIntPower(string card)
    {
        return int.Parse(card.Substring(0, card.Length - 1));
    }

    private static int TakeTheSumOfPlayersCardsWhenWarOn(Queue<string> playersCards, out string cardTwo, out string cardThree, out string cardFour)
    {
        cardTwo = playersCards.Dequeue();
        cardThree = playersCards.Dequeue();
        cardFour = playersCards.Dequeue();
        return GetCardLetterPower(cardTwo)
                         + GetCardLetterPower(cardThree)
                         + GetCardLetterPower(cardFour);
    }

    private static char GetCardLetterPower(string card)
    {
        return card.ToCharArray()[card.Length - 1];
    }

    private static void AddCardInTempList(List<string> tempCards, string card)
    {
        tempCards.Add(card);
    }

    private static void AddCardsAfterAWarIsWon(Queue<string> firstPlayersCards, List<string> tempCards)
    {
        tempCards = tempCards.OrderByDescending(c => c).ToList();
        foreach (string card in tempCards)
        {
            firstPlayersCards.Enqueue(card);
        }
    }
}