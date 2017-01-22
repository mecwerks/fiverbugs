using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace bugTesting
{
    //
    // failed to load type VehicleModCollection
    public class Bug_VehicleModCollection : BaseScript
    {
        public Bug_VehicleModCollection()
        {
            Debug.Write("Testing type " + typeof(VehicleModCollection));
            Debug.WriteLine();
            Debug.Write("Testing type " + typeof(VehicleMod));
            Debug.WriteLine();
        }
    }

    //
    // Weapon.Ammo returns 0 on first call
    // Weapons.HasWeapon() returns false on first call
    public class Bug_AmmoHasWeapFalse : BaseScript
    {
        public Bug_AmmoHasWeapFalse()
        {
            Tick += async () =>
            {
                if (Game.IsControlPressed(Game.CurrentInputMode == InputMode.GamePad ? 0 : 1, Control.MultiplayerInfo))
                {
                    if (LocalPlayer.Character.Weapons.Current != WeaponHash.Unarmed)
                    {
                        Debug.Write("Current Weapon: " + LocalPlayer.Character.Weapons.Current.Hash + " Ammo: " + LocalPlayer.Character.Weapons.Current.Ammo);
                        Debug.WriteLine();

                        Debug.Write("Has Current Weapon: " + LocalPlayer.Character.Weapons.HasWeapon(LocalPlayer.Character.Weapons.Current));
                        Debug.WriteLine();
                    }
                }

                await Task.FromResult(0);
            };
        }
    }
}
