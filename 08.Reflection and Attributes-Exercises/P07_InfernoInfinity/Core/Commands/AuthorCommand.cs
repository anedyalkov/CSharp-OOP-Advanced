﻿namespace _07.InfernoInfinity.Core.Commands
{
    using _07.InfernoInfinity.Models.Weapons;
    using System.Linq;

    public class AuthorCommand : Command
    {

        public AuthorCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            var field = this.Data[0];

            var weaponAtr = typeof(Weapon).GetCustomAttributes(false).FirstOrDefault();
            WeaponAttribute fieldToPrint = (WeaponAttribute)weaponAtr;

            var result = fieldToPrint.PrintInfo(field);

            return result;
        }
    }
}
