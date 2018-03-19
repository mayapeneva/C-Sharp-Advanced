using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var rows = int.Parse(Console.ReadLine());

        var samRow = 0;
        var samCol = 0;
        var nikoladzeRow = 0;
        var nikoladzeCol = 0;
        var enemies = new List<Enemy>();

        var room = new char[rows][];
        FillTheRoomIn(rows, ref samRow, ref samCol, ref nikoladzeRow, ref nikoladzeCol, enemies, room);

        var samDead = false;
        var nikoladzeDead = false;
        var directions = Console.ReadLine().ToCharArray();
        for (int j = 0; j < directions.Length; j++)
        {
            samDead = EnemiesMove(samRow, samCol, enemies, room);
            if (samDead)
            {
                break;
            }

            switch (directions[j])
            {
                case 'U':
                    room[samRow][samCol] = '.';
                    samRow -= 1;

                    nikoladzeDead = CheckForNikoladze(room, samRow, nikoladzeRow, nikoladzeCol);
                    if (!nikoladzeDead)
                    {
                        samDead = CheckForEnemyAfterVerticalMove(room, samRow, samCol, enemies);
                    }

                    if (!samDead)
                    {
                        room[samRow][samCol] = 'S';
                    }
                    break;

                case 'D':
                    room[samRow][samCol] = '.';
                    samRow += 1;

                    nikoladzeDead = CheckForNikoladze(room, samRow, nikoladzeRow, nikoladzeCol);
                    if (!nikoladzeDead)
                    {
                        samDead = CheckForEnemyAfterVerticalMove(room, samRow, samCol, enemies);
                    }

                    if (!samDead)
                    {
                        room[samRow][samCol] = 'S';
                    }
                    break;

                case 'L':
                    room[samRow][samCol] = '.';
                    samCol -= 1;
                    CheckForEnemyAferSideMove(room, samRow, samCol, enemies);
                    room[samRow][samCol] = 'S';
                    break;

                case 'R':
                    room[samRow][samCol] = '.';
                    samCol += 1;
                    CheckForEnemyAferSideMove(room, samRow, samCol, enemies);
                    room[samRow][samCol] = 'S';
                    break;

                case 'W':
                    break;
            }

            if (nikoladzeDead || samDead)
            {
                break;
            }
        }

        PrintResult(rows, samRow, samCol, room, samDead, nikoladzeDead);
    }

    private static void PrintResult(int rows, int samRow, int samCol, char[][] room, bool samDead, bool nikoladzeDead)
    {
        if (samDead)
        {
            Console.WriteLine($"Sam died at {samRow}, {samCol}");
        }
        else if (nikoladzeDead)
        {
            Console.WriteLine("Nikoladze killed!");
        }

        for (int r = 0; r < rows; r++)
        {
            Console.WriteLine(string.Join("", room[r]));
        }
    }

    private static bool CheckForEnemyAfterVerticalMove(char[][] room, int samRow, int samCol, List<Enemy> enemies)
    {
        var samDead = false;
        if (enemies.Any(e => e.Row == samRow))
        {
            var theEnemy = enemies.First(e => e.Row == samRow);
            if (theEnemy.Col == samCol)
            {
                enemies.Remove(theEnemy);
            }
            else if (theEnemy.Col < samCol && theEnemy.Type.Equals('b'))
            {
                room[samRow][samCol] = 'X';
                samDead = true;
            }
            else if (theEnemy.Col > samCol && theEnemy.Type.Equals('d'))
            {
                room[samRow][samCol] = 'X';
                samDead = true;
            }
        }

        return samDead;
    }

    private static void CheckForEnemyAferSideMove(char[][] room, int samRow, int samCol, List<Enemy> enemies)
    {
        if (enemies.Any(e => e.Row == samRow))
        {
            var theEnemy = enemies.First(e => e.Row == samRow);
            if (theEnemy.Col == samCol)
            {
                enemies.Remove(theEnemy);
            }
        }
    }

    private static bool CheckForNikoladze(char[][] room, int samRow, int nikoladzeRow, int nikoladzeCol)
    {
        if (nikoladzeRow == samRow)
        {
            room[nikoladzeRow][nikoladzeCol] = 'X';
            return true;
        }

        return false;
    }

    private static bool EnemiesMove(int samRow, int samCol, List<Enemy> enemies, char[][] room)
    {
        var samDead = false;
        foreach (var enemy in enemies)
        {
            if (enemy.CanMove)
            {
                if (enemy.Type.Equals('b'))
                {
                    if (enemy.Col < room[enemy.Row].Length - 1)
                    {
                        room[enemy.Row][enemy.Col] = '.';
                        enemy.Col += 1;
                        room[enemy.Row][enemy.Col] = 'b';
                    }
                    else if (enemy.Col == room[enemy.Row].Length - 1)
                    {
                        room[enemy.Row][enemy.Col] = 'd';
                        enemy.Type = 'd';
                        enemy.CanMove = false;
                        if (samRow == enemy.Row)
                        {
                            room[samRow][samCol] = 'X';
                            samDead = true;
                        }
                    }
                }
                else
                {
                    if (enemy.Col > 0)
                    {
                        room[enemy.Row][enemy.Col] = '.';
                        enemy.Col -= 1;
                        room[enemy.Row][enemy.Col] = 'd';
                    }
                    else if (enemy.Col == 0)
                    {
                        room[enemy.Row][enemy.Col] = 'b';
                        enemy.Type = 'b';
                        enemy.CanMove = false;
                        if (samRow == enemy.Row)
                        {
                            room[samRow][samCol] = 'X';
                            samDead = true;
                        }
                    }
                }
            }
        }

        return samDead;
    }

    private static void FillTheRoomIn(int rows, ref int samRow, ref int samCol, ref int nikoladzeRow, ref int nikoladzeCol, List<Enemy> enemies, char[][] room)
    {
        for (int i = 0; i < rows; i++)
        {
            room[i] = Console.ReadLine().ToCharArray();
            if (room[i].Contains('N'))
            {
                nikoladzeRow = i;
                nikoladzeCol = room[i].ToList().FindIndex(c => c == 'N');
            }

            if (room[i].Contains('S'))
            {
                samRow = i;
                samCol = room[i].ToList().FindIndex(c => c == 'S');
            }

            FindTheEnemies(enemies, room, i, 'b');
            FindTheEnemies(enemies, room, i, 'd');
        }
    }

    private static void FindTheEnemies(List<Enemy> enemies, char[][] room, int i, char type)
    {
        if (room[i].Contains(type))
        {
            var enemyRow = i;
            var enemyCol = room[i].ToList().FindIndex(c => c == type);
            enemies.Add(new Enemy(type, enemyRow, enemyCol));
        }
    }
}