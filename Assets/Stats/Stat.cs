using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    private StatManager statManager;
    private StatData data;
    private string name;
    private string shortName;
    private int baseValue;

    private List<StatModifier> statModifierList = new List<StatModifier>();

    public event EventHandler<StatChangedEventArgs> OnStatChanged;

    public StatManager StatManager { get => statManager; set => statManager = value; }
    public StatData Data { get => data; }
    public string Name { get => name; }
    public string ShortName { get => shortName; }
    public int BaseValue { get => baseValue; }
    public int Value { get => CalculateValue(); }

    public List<StatModifier> StatModifierList { get => statModifierList; }

    public Stat(StatManager statManager, StatData data, string baseValue)
    {
        this.statManager = statManager;
        this.data = data;
        this.name = data.Name;
        this.shortName = data.ShortName;
        if (baseValue == "")
            this.baseValue = ParseFormulae(data.BaseValue);
        else
            this.baseValue = ParseFormulae(baseValue);

        GamePhaseManager.current.OnGamePhaseChanged += UpdateStatModifiers;
    }

    private int ParseFormulae(string baseValueString)
    {
        int parseResult = 0;

        if (!baseValueString.Contains("d"))
            return int.Parse(baseValueString);

        string[] formulae1 = baseValueString.Split("d");
        int numberOfDice = int.Parse(formulae1[0]);
        string[] formulae2 = formulae1[1].Split("+");
        int valueOfDice = int.Parse(formulae2[0]);
        int bonus = int.Parse(formulae2[1]);

        for (int i = numberOfDice; numberOfDice > 0; numberOfDice--)
        {
            int roll = UnityEngine.Random.Range(1, valueOfDice);
            parseResult += roll;
        }
        parseResult += bonus;
        return parseResult;
    }

    private int CalculateValue()
    {
        int value = BaseValue;

        foreach (StatModifier statModifier in StatModifierList)
            value += statModifier.Value;
        return value;
    }

    private void UpdateStatModifiers(object sender, GamePhaseChangeEventArgs e)
    {
        if (e.newGamePhase.Name == EGamePhaseName.STATUS_UPDATE)
        {
            for (int i = StatModifierList.Count - 1; i >= 0; i--)
            {
                if (StatModifierList[i].Update())
                {
                    StatModifierList.RemoveAt(i);
                    OnStatChanged?.Invoke(this, new StatChangedEventArgs
                    {
                        stat = this
                    });
                }
            }
        }
    }

    public void AddModifier(int value, int duration, object source, string description)
    {
        StatModifierList.Add(new StatModifier(value, duration, source, description));

        OnStatChanged?.Invoke(this, new StatChangedEventArgs
        {
            stat = this
        });
    }

    public void RemoveModifier(StatModifier statModifier)
    {
        StatModifierList.Remove(statModifier);

        OnStatChanged?.Invoke(this, new StatChangedEventArgs
        {
            stat = this
        });
    }

    public void RemoveAllModifiersFromSource(object source)
    {
        for (int i = StatModifierList.Count - 1; i >= 0; i--)
        {
            if (StatModifierList[i].Source == source)
            {
                StatModifierList.RemoveAt(i);
            }
        }

        OnStatChanged?.Invoke(this, new StatChangedEventArgs
        {
            stat = this
        });
    }
}

public class StatChangedEventArgs : EventArgs
{
    public Stat stat;
}
