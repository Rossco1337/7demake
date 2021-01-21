[System.Serializable]
public class Encounter {
    public int id, runchance, encounterrate;
    public string[] enemies;
    public string formation, setupflag;
}
[System.Serializable]
public class Encounters
{
    public Encounter[] encounters;
}