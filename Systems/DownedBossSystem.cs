using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ExxoAvalonOrigins.Systems;
public class DownedBossSystem : ModSystem
{
    public static bool downedBacteriumPrime = false;
    public static bool downedDesertBeak = false;
    public static bool downedPhantasm = false;
    public static bool downedDragonLord = false;
    public static bool downedMechasting = false;
    public static bool oblivionDead = false;
    public static bool downedKingSting = false;
    public static bool stoppedArmageddon = false;

    public override void OnWorldLoad()
    {
        downedBacteriumPrime = false;
        downedDesertBeak = false;
        downedPhantasm = false;
        downedDragonLord = false;
        downedMechasting = false;
        oblivionDead = false;
        downedKingSting = false;
        stoppedArmageddon = false;
    }
    public override void OnWorldUnload()
    {
        downedBacteriumPrime = false;
        downedDesertBeak = false;
        downedPhantasm = false;
        downedDragonLord = false;
        downedMechasting = false;
        oblivionDead = false;
        downedKingSting = false;
        stoppedArmageddon = false;
    }
    public override void SaveWorldData(TagCompound tag)
    {
        if (downedBacteriumPrime)
        {
            tag["downedBacteriumPrime"] = true;
        }
        if (downedDesertBeak)
        {
            tag["downedDesertBeak"] = true;
        }
        if (downedPhantasm)
        {
            tag["downedPhantasm"] = true;
        }
        if (downedDragonLord)
        {
            tag["downedDragonLord"] = true;
        }
        if (downedMechasting)
        {
            tag["downedMechasting"] = true;
        }
        if (oblivionDead)
        {
            tag["oblivionDead"] = true;
        }
        if (downedKingSting)
        {
            tag["downedKingSting"] = true;
        }
        if (stoppedArmageddon)
        {
            tag["stoppedArmageddon"] = true;
        }
    }
    public override void LoadWorldData(TagCompound tag)
    {
        downedBacteriumPrime = tag.ContainsKey("downedBacteriumPrime");
        downedDesertBeak = tag.ContainsKey("downedDesertBeak");
        downedPhantasm = tag.ContainsKey("downedPhantasm");
        downedDragonLord = tag.ContainsKey("downedDragonLord");
        downedMechasting = tag.ContainsKey("downedMechasting");
        oblivionDead = tag.ContainsKey("oblivionDead");
        downedKingSting = tag.ContainsKey("downedKingSting");
        stoppedArmageddon = tag.ContainsKey("stoppedArmageddon");
    }
    public override void NetSend(BinaryWriter writer)
    {
        var flags = new BitsByte();
        flags[0] = downedBacteriumPrime;
        flags[1] = downedDesertBeak;
        flags[2] = downedPhantasm;
        flags[3] = downedDragonLord;
        flags[4] = downedMechasting;
        flags[5] = oblivionDead;
        flags[6] = downedKingSting;
        flags[7] = stoppedArmageddon;
        writer.Write(flags);
    }
    public override void NetReceive(BinaryReader reader)
    {
        BitsByte flags = reader.ReadByte();
        downedBacteriumPrime = flags[0];
        downedDesertBeak = flags[1];
        downedPhantasm = flags[2];
        downedDragonLord = flags[3];
        downedMechasting = flags[4];
        oblivionDead = flags[5];
        downedKingSting = flags[6];
        stoppedArmageddon = flags[7];
    }
}
