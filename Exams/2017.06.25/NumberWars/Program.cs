using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var firstPC = Console.ReadLine().Split().ToArray();
        var firstPlayersCards = new Queue<string>(firstPC);

        var secondPC = Console.ReadLine().Split().ToArray();
        var secondPlayersCards = new Queue<string>(secondPC);

        var numberOfTurns = 1000000;
        for (int i = 0; i < 1000000; i++)
        {
            if (firstPlayersCards.Count < 1 || secondPlayersCards.Count < 1)
            {
                numberOfTurns = i;
                break;
            }

            var cardFirst = firstPlayersCards.Dequeue();
            var cardFirstPower = GetCardIntPower(cardFirst);

            var cardSecond = secondPlayersCards.Dequeue();
            var cardSecondPower = GetCardIntPower(cardSecond);
            if (cardFirstPower > cardSecondPower)
            {
                firstPlayersCards.Enqueue(cardFirst);
                firstPlayersCards.Enqueue(cardSecond);
            }
            else if (cardFirstPower < cardSecondPower)
            {
                secondPlayersCards.Enqueue(cardSecond);
                secondPlayersCards.Enqueue(cardFirst);
            }
            else
            {
                var cardsSumFirst = 0;
                var cardsSumSecond = 0;
                while (cardsSumFirst == cardsSumSecond)
                {
                    if (firstPlayersCards.Count < 3 || secondPlayersCards.Count < 3)
                    {
                        numberOfTurns = i;
                        break;
                    }

                    var cardOneFirst = firstPlayersCards.Dequeue();
                    var cardTwoFirst = firstPlayersCards.Dequeue();
                    var cardThreeFirst = firstPlayersCards.Dequeue();

                    cardsSumFirst = GetCardLetterPower(cardOneFirst) + GetCardLetterPower(cardTwoFirst) +
                                    GetCardLetterPower(cardThreeFirst);

                    var cardOneSecond = secondPlayersCards.Dequeue();
                    var cardTwoSecond = secondPlayersCards.Dequeue();
                    var cardThreeSecond = secondPlayersCards.Dequeue();

                    cardsSumSecond = GetCardLetterPower(cardOneSecond) + GetCardLetterPower(cardTwoSecond) +
                                     GetCardLetterPower(cardThreeSecond);

                    var tempCards = new List<string>();
                    tempCards.Add(cardOneFirst);
                    tempCards.Add(cardTwoFirst);
                    tempCards.Add(cardThreeFirst);
                    tempCards.Add(cardOneSecond);
                    tempCards.Add(cardTwoSecond);
                    tempCards.Add(cardThreeSecond);
                    tempCards.Add(cardFirst);
                    tempCards.Add(cardSecond);
                    tempCards = tempCards.OrderByDescending(c => c).ToList();
                    if (cardsSumFirst > cardsSumSecond)
                    {
                        for (int j = 0; j < tempCards.Count; j++)
                        {
                            firstPlayersCards.Enqueue(tempCards[j]);
                        }
                    }
                    else if (cardsSumFirst < cardsSumSecond)
                    {
                        for (int j = 0; j < tempCards.Count; j++)
                        {
                            secondPlayersCards.Enqueue(tempCards[j]);
                        }
                    }
                }
            }
        }

        if (firstPlayersCards.Count == secondPlayersCards.Count)
        {
            Console.WriteLine($"Draw after {numberOfTurns} turns");
        }
        else if (firstPlayersCards.Count > secondPlayersCards.Count)
        {
            Console.WriteLine($"First player wins after {numberOfTurns} turns");
        }
        else
        {
            Console.WriteLine($"Second player wins after {numberOfTurns} turns");
        }
    }

    private static int GetCardLetterPower(string cardOneFirst)
    {
        return (int)cardOneFirst.ToCharArray()[cardOneFirst.Length - 1];
    }

    private static int GetCardIntPower(string cardFirst)
    {
        return int.Parse(string.Join("", cardFirst.ToCharArray().Take(cardFirst.Length - 1)));
    }
}