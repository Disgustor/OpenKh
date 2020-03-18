﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xe.BinaryMapper;

namespace OpenKh.Kh2
{
    public class Objentry
    {
        public enum Type : byte
        {
            Player = 0x0,
            PartyMember = 0x1,
            Dummy = 0x2,
            Boss = 0x3,
            NormalEnemy = 0x4,
            Keyblade = 0x5,
            Placeholders = 0x6, //???
            WorldSavePoint = 0x7,
            Neutral = 0x8,
            OutOfPartyPartner = 0x9,
            Chest = 0xA,
            Moogle = 0xB,
            GiantBoss = 0xC,
            Unknown1 = 0xD,
            PauseMenuDummy = 0xE,
            NPC = 0xF,
            Unknown2 = 0x10,
            WorldMapObject = 0x11,
            DropPrize = 0x12,
            Summon = 0x13,
            ShopPoint = 0x14,
            NormalEnemy2 = 0x15,
            CrowdSpawner = 0x16,
            Unknown3 = 0x17, //pots in hercules world?
        }
        [Data] public ushort ObjectId { get; set; }
        [Data] public ushort Unknown02 { get; set; } // has something to do with if the obj is rendered or not, NO: ObjectId is actually an uint, but it's bitshifted afterwards?! see z_un_003216b8
        [Data] public Type ObjectType { get; set; }
        [Data] public byte Unknown05{ get; set; } //padding? isn't used ingame
        [Data] public byte Unknown06 { get; set; }
        [Data] public byte WeaponJoint { get; set; }
        [Data(Count = 32)] public string ModelName { get; set; }
        [Data(Count = 32)] public string AnimationName { get; set; }
        [Data] public uint Unknown48 { get; set; }
        [Data] public ushort NeoStatus { get; set; }
        [Data] public ushort NeoMoveset { get; set; }
        [Data] public ushort Unknown50 { get; set; } // some kind of floating point calculation? z_un_0016a0a0
        [Data] public short Weight { get; set; }
        [Data] public byte SpawnLimiter { get; set; }
        [Data] public byte Unknown55 { get; set; } // padding?
        [Data] public byte Unknown56{ get; set; }
        [Data] public byte Unknown57{ get; set; } //Unknown 57 on the other hand, I was sorta right about. It controls the inventory and and command menu options that the Object has access to.Haven't dug through the files to figure out what it's pulling from yet though, but it basically works like this:
        [Data] public ushort SpawnObject1 { get; set; }
        [Data] public ushort SpawnObject2 { get; set; }
        [Data] public ushort SpawnObject3 { get; set; }
        [Data] public ushort Unknown5e { get; set; }

        public static BaseTable<Objentry> Read(Stream stream) => BaseTable<Objentry>.Read(stream);
        public static void Write(Stream stream, IEnumerable<Objentry> entries) =>
            BaseTable<Objentry>.Write(stream, 3, entries.ToList());
    }
}
