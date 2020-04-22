using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    // Lemon() IS AN EXAMPLE OF THE OPEN/CLOSED PRINCIPLE. Since it is treated like an object, it can have methods added (additional functionality),
    // but due to its inheritence from Ingredient(), it cannot be treated as anything other than an Ingredient().
    class Lemon : Ingredient
    {
    }
}
