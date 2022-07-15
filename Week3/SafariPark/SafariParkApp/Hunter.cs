using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public class Hunter : Person, IShootable
    {

        public IShootable Shooter { get; set; }
        public Hunter()
        {

        }
        public Hunter(string fName, string lName, IShootable shooter) : base (fName, lName)
        {
            Shooter = shooter;
        }

        public string Shoot()
        {
            
            return Shooter == null ? $"{FullName} with no shooter" : $"{FullName}. {Shooter.Shoot()}";
        }



        //sealed keyword means that overriden inherited methods 
        //cannot be overriden in derived classes
        public /*sealed*/ override string ToString()
        {
            return $"{base.ToString()}";
        }

    }

    //public class MonsterHunter : Hunter
    //{
    //    private string? _monsterHuntingWeapon;

    //    public MonsterHunter(string fName, string lName, string camera, string weapon) : base (fName, lName, camera)
    //    {
    //        _monsterHuntingWeapon = weapon;
    //    }

    //    public override string ToString()
    //    {
    //        return base.ToString();
    //    }

    //}
}
