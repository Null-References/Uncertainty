using System;
using System.Collections.Generic;

public interface ITakeDamage
{
    void TakeDamage(Dictionary<Type,IDamage> damageTypes);
}
