using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysInClass
{
    internal class Program
    {
            static string weaponName;
            static int[] maxLightAmmo;
            static int[] lightAmmo;
            static int curWeaponIndex; // Current Weapon
            static string starLine;
            static List<string> weaponType;
            static int health;
            static int[] lightAmmoTotal;
        static void Main()
        {
            StartUp();
            Console.WriteLine("Arrays of bullets!");
            Console.WriteLine("-------------------");
            Console.WriteLine("A text shooter game");
            Console.WriteLine("\n");//Gameplay is going between line breaks
            ShowHUD();
            FireLoop();
            ShowHUD();
            LightAmmoPickup(50);
            ShowHUD();

            Console.WriteLine("\n");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
        static void StartUp()
        {
            // Function to initialize values
            health = 100;
            maxLightAmmo = new int[3];
            lightAmmo = new int[3];
            lightAmmoTotal = new int[2];
            curWeaponIndex = 0; // starting with pistol
            maxLightAmmo[0] = 16; // light pistol max ammo
            maxLightAmmo[1] = 30; // smg max ammo
            maxLightAmmo[2] = 10; // low cal DMR max ammo
            lightAmmo[0] = 16; // light pistol current ammo
            lightAmmo[1] = 0; // smg current ammo
            lightAmmo[2] = 0; // low cal DMR current ammo
            lightAmmoTotal[0] = 100; // Current light ammo stock
            lightAmmoTotal[1] = 200; // Max light ammo stock
            starLine = "*****************************";
            weaponType = new List<string> {"Light Pistol", "SMG", "Light DMR"};
        }
        static void Fire()
        {
            AmmoRangeCheck();
            if(lightAmmo[curWeaponIndex] > 0 && lightAmmo[curWeaponIndex] <= maxLightAmmo[curWeaponIndex])
            {
                Console.WriteLine("Bang!");
                lightAmmo[curWeaponIndex] -= 1;
            }
            else if(lightAmmo[curWeaponIndex] <= 0)
            {
                Console.WriteLine("*Click*");
            }
            else if(lightAmmo[curWeaponIndex] > maxLightAmmo[curWeaponIndex])
            {
                Console.WriteLine("You cant have more than max ammo, you cheat!");
            }
        }
        static void AmmoRangeCheck()
        {
            if(lightAmmo[curWeaponIndex] <= 0)
            {
                lightAmmo[curWeaponIndex] = 0;
            }
            if(lightAmmo[curWeaponIndex] > maxLightAmmo[curWeaponIndex])
            {
                lightAmmo[curWeaponIndex] = maxLightAmmo[curWeaponIndex];
            }
        }
        static void ShowHUD()
        {
            SetWeapon();
            Console.WriteLine(string.Format("You have {0} HP", health));
            Console.WriteLine(string.Format("Your weapon is a {0}", weaponName));
            Console.WriteLine(string.Format("You have {0} ammo for your {1}",lightAmmo[curWeaponIndex], weaponName));
            Console.WriteLine(string.Format("You have {0}/{1} Light ammo", lightAmmoTotal[0], lightAmmoTotal[1]));
        }
        static void SetWeapon()
        {
            if(curWeaponIndex >= 0 && curWeaponIndex < 3)
            {
                weaponName = weaponType.ElementAt(curWeaponIndex);
            }
            else
            {
                Console.WriteLine("You cannot equip a weapon that dose not exist!");
                return;
            }
        }
        static void Reload()
        {
            if(maxLightAmmo[curWeaponIndex] <= lightAmmoTotal[0])
            {
                Console.WriteLine("Reloading weapon");
                lightAmmo[curWeaponIndex] = maxLightAmmo[curWeaponIndex];
                lightAmmoTotal[0] -= maxLightAmmo[curWeaponIndex];
            }
            else
            {
                Console.WriteLine("You dont need to reload");
                return;
            }
        }
        static void LightAmmoPickup(int ammo)
        {
            if(ammo <= 0)
            {
                Console.WriteLine("You cant lose ammo from a pickup");
                return;
            }
            Console.WriteLine(string.Format("You picked up {0} ammo", ammo));
            if(lightAmmoTotal[0] > lightAmmoTotal[1])
            {
                lightAmmoTotal[0] += ammo;
                if(lightAmmoTotal[0] > lightAmmoTotal[1])
                {
                    lightAmmoTotal[0] = lightAmmoTotal[1];
                    Console.WriteLine("You are at max ammo");
                }
            }
            if(lightAmmo[curWeaponIndex] == 0 && lightAmmoTotal[0] > maxLightAmmo[curWeaponIndex])
            {
                Reload();
            }
        }
        static void FireLoop()
        {
            while(lightAmmo[curWeaponIndex] > 0)
            {
                Fire();
            }
        }
    }
}
