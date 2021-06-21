using System.Collections.Generic;
using System.Linq;

public static class ConditionExtension
{
    public static bool AreMet(this List<Condition> conditions) => conditions.All(item => item.IsMet);
}