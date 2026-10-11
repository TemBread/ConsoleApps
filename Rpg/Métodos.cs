using System;
using System.Linq;
using System.Collections.Generic;

namespace Jogo_de_RPG;

public class Rpg
{
    int hP;
    int mP;
    int iQ;
    string name;
    int damage;
    
    // Variável para definir o valor do dado
    int diceValue;
    
    // Variável do loop
    bool loop = true;
    
    // Gerador de números
    Random dice = new Random();
    
    bool sair = true;
    
    private void Dice()
    {
        int diceValue = dice.Next(1, 21);
        this.diceValue = diceValue;
        
        while (loop)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Text.Info("\nDeseja girar o D20 para seus atributos? (S/N) => ");
            Console.ResetColor();
            string rollDice = Text.Lead();
            
            if (string.Equals(rollDice, "S", StringComparison.OrdinalIgnoreCase)
            || string.Equals(rollDice, "SIM", StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Text.Message($"O número sorteado foi: {diceValue}");
                Console.ResetColor();
                loop = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Text.Message("Você deve girar o dado para continuar!");
                Text.Info("Se deseja sair, digite \"S\", se deseja continuar, digite \"C\" => ");
                string sC = Text.Lead();
                if (string.Equals(sC, "S", StringComparison.OrdinalIgnoreCase))
                {
                    this.sair = false;
                    this.loop = false;
                }
            }
        }
    }
    
    private void Attributes()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Text.Message("\n--- Vamos distribuir seus atributos ---");
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.Magenta;
        Text.Info("\nQual o nome do seu personagem? ");
        Console.ResetColor();
        name = Text.Lead();
        
        do
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Text.Info("\nDigite seu HP: ");
            Console.ResetColor(); 
            hP = Convert.ToInt32(Text.Lead());

            if (hP > diceValue)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Text.Message($"O valor não deve ser maior do que {diceValue}");
                Console.ResetColor();
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Text.Message($"(você tem {diceValue} pontos para usar)");
            Console.ResetColor();
        } while (hP < 0 || hP > diceValue);
        

        do
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Text.Info("\nDigite seu MP: ");
            Console.ResetColor();
            mP = Convert.ToInt32(Text.Lead());

            if (mP > diceValue)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Text.Message($"O valor não deve ser maior do que {diceValue}");
                Console.ResetColor();
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Text.Message($"(você tem {diceValue} pontos para usar)");
            Console.ResetColor();
        } while (mP < 0 || mP > diceValue);
        
        do
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Text.Info("\nDigite seu QI: ");
            Console.ResetColor();
            iQ = Convert.ToInt32(Text.Lead());

            if (iQ > diceValue)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Text.Message($"O valor não deve ser maior do que {diceValue}");
                Console.ResetColor();
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Text.Message($"(você tem {diceValue} pontos para usar)");
            Console.ResetColor();
        } while (iQ < 0 || iQ > diceValue);
        
        do
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Text.Info("\nDigite seu dano: ");
            Console.ResetColor();
            damage = Convert.ToInt32(Text.Lead());

            if (damage > diceValue)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Text.Message($"O valor não deve ser maior do que {diceValue}");
                Console.ResetColor();
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Text.Message($"(você tem {diceValue} pontos para usar)");
            Console.ResetColor();
        } while (damage < 0 || damage > diceValue);
        
        Text.Message("");
        
        if (diceValue >= 0 && damage >= 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Text.Message($"""
            ----- Atributos -----
            • Nome: {name}
            • Vida: {hP}
            • Mana: {mP}
            • QI = {iQ}
            • Dano: {damage}
            """);
        }
    }
    
    int enemyHP;
    int enemyDamage;
    private void EnemyGoblin()
    {
        enemyHP = 20;
        enemyDamage = 5;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Text.Message("\n--- Um Goblin apareceu! ---");
        Text.Info("""
        Ele tem 20 de vida, 5 de dano por golpe e 2 de resistência.

        O que você deseja fazer?
        1 - Atacar
        2 - Fugir
        """);
        int choice = Convert.ToInt32(Text.Lead());

        if (choice == 1)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Text.Message($"\nVocê atacou o Goblin e causou {damage} de dano!");
                enemyHP -= damage;
                Text.Message($"\nO Goblin tem {enemyHP} de vida restante.");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Text.Message($"\nO Goblin atacou você e causou {enemyDamage} de dano!");
                hP -= enemyDamage;
                Text.Message($"\nVocê tem {hP} de vida restante.");
                Console.ResetColor();
            } while (hP > 0 && enemyHP > 0);

        }
    }

    public void Apply()
    {
        Dice();
        
        if (!sair)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Text.Message("\nAté logo!");
            Console.ResetColor();
            return;
        }
        
        Attributes();
    }
}