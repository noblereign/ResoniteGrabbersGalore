using FrooxEngine;
using HarmonyLib;
using ResoniteModLoader;

namespace GrabbersGalore;
//More info on creating mods can be found https://github.com/resonite-modding-group/ResoniteModLoader/wiki/Creating-Mods
public class GrabbersGalore : ResoniteMod {
	internal const string VERSION_CONSTANT = "1.0.0"; //Changing the version here updates it in all locations needed
	public override string Name => "GrabbersGalore";
	public override string Author => "Noble";
	public override string Version => VERSION_CONSTANT;
	public override string Link => "https://github.com/resonite-modding-group/GrabbersGalore/";

	public override void OnEngineInit() {
		Harmony harmony = new("dog.glacier.GrabbersGalore");
		harmony.PatchAll();
	}

	//Example of how a HarmonyPatch can be formatted, Note that the following isn't a real patch and will not compile.
	[HarmonyPatch(typeof(ClassNameHere), "MethodNameHere")]
	class ClassNameHere_MethodNameHere_Patch {
		static void Postfix(ClassNameHere __instance) {
			Msg("Postfix from GrabbersGalore");
		}
	}
}
