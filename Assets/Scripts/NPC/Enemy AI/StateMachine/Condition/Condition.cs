using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public abstract class Condition : MonoBehaviour
{
    public abstract bool IsMet();
}

public static class ConditionExtension
{
    public static bool AreMet(this List<Condition> conditions) => conditions.All(item => item.IsMet());
}