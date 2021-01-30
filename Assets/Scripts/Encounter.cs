using System;

[Serializable]
public class Encounter
{
    public int id, runchance, encounterrate;
    public string[] enemies;
    public string formation, setupflag;
}

[Serializable]
public class Encounters
{
    public Encounter[] encounters;
}