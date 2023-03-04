using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StrategyPattern;

//var ch = new Character(new AgressiveCombatStrategy());
//ch.ApplyAttactStrategy();

//ch.SetCombatStrategy(new DefensiveCombatStrategy());
//ch.ApplyAttactStrategy();

//Console.ReadLine();


class Character
{
    private ICombatStrategy combatStrategy;

    public Character(ICombatStrategy combatStrategy)
    {
        this.combatStrategy = combatStrategy;
    }

    public Character()
    {

    }

    public void SetCombatStrategy(ICombatStrategy combatStrategy)
    {
        this.combatStrategy = combatStrategy;
    }

    public void ApplyAttactStrategy()
    {
        combatStrategy.Attack();
    }

}


interface ICombatStrategy
{
    void Attack();
}

class AgressiveCombatStrategy : ICombatStrategy
{
    public void Attack()
    {
        Console.WriteLine("Agressive Attack");
    }
}

class DefensiveCombatStrategy : ICombatStrategy
{
    public void Attack()
    {
        Console.WriteLine("Defensive Attack");
    }
}
