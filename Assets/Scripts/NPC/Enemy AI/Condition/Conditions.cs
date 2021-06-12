using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public abstract class Conditions : ScriptableObject
{
    public abstract bool IsMet();
    public static bool CheckAllConditions(List<Conditions> conditions) => !conditions.Any(item => item.IsMet() == false);
}
