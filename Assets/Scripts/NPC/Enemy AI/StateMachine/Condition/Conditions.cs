using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Conditions : ScriptableObject
{
    public abstract bool IsMet();
}

public static class ConditionExtension
{
    public static bool AreMet(this List<Conditions> conditions) => conditions.All(item => item.IsMet());
}