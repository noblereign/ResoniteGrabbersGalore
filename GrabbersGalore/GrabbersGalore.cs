using System.Runtime.CompilerServices;

using FrooxEngine;
using HarmonyLib;
using ResoniteModLoader;

namespace GrabbersGalore;
//More info on creating mods can be found https://github.com/resonite-modding-group/ResoniteModLoader/wiki/Creating-Mods
public class GrabbersGalore : ResoniteMod {
	internal const string VERSION_CONSTANT = "1.1.0"; //Changing the version here updates it in all locations needed
	public override string Name => "GrabbersGalore";
	public override string Author => "Noble";
	public override string Version => VERSION_CONSTANT;
	public override string Link => "https://github.com/noblereign/ResoniteGrabbersGalore/";

	public static ModConfiguration? Config;

	[AutoRegisterConfigKey]
	public static ModConfigurationKey<bool> Enabled = new("Enabled", "Enables the mod, pretty self-explanatory.", () => true);

	public override void OnEngineInit() {
		Config = GetConfiguration()!;
		Config!.Save(true);

		Harmony harmony = new("dog.glacier.GrabbersGalore");
		harmony.PatchAll();
	}

	private static readonly ConditionalWeakTable<Grabber, StrongBox<bool>> lastGrabState = new();

	[HarmonyPatch(typeof(Grabber), "OnCommonUpdate")]
	class Grabber_OnCommonUpdate_Patch {
		static void Postfix(Grabber __instance) {
			if (!Config!.GetValue(Enabled)) return;
			if (__instance.AutoUpdateUser.Target == __instance.World.LocalUser && __instance.World.Focus != FrooxEngine.World.WorldFocus.Background) {
				DynamicVariableSpace varSpace = __instance.Slot.FindSpace("GrabbersGalore");
				if (varSpace != null) {
					varSpace.TryReadValue<bool>("Grabbing", out bool doGrab);
					bool hasCustomGrabSize = varSpace.TryReadValue<float>("Radius", out float customGrabSize);

					if (!lastGrabState.TryGetValue(__instance, out var box)) {
						box = new StrongBox<bool>(false);
						lastGrabState.Add(__instance, box);
					}
					bool _lastGrab = box.Value;

					if (doGrab && !_lastGrab) {
						__instance.Grab(__instance.Slot.GlobalPosition, __instance.Slot.LocalScaleToGlobal(hasCustomGrabSize ? customGrabSize : 0.02f));
						box.Value = true;
					} else if (!doGrab && _lastGrab) {
						__instance.Release();
						box.Value = false;
					}
				} else {
					lastGrabState.Remove(__instance);
				}
			}
		}
	}
}
