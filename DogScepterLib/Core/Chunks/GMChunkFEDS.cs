﻿using DogScepterLib.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DogScepterLib.Core.Chunks
{
    public class GMChunkFEDS : GMChunk
    {
        public GMUniquePointerList<GMFilterEffect> List;

        public override void Serialize(GMDataWriter writer)
        {
            base.Serialize(writer);

            writer.Pad(4);
            writer.Write(1);

            List.Serialize(writer);
        }

        public override void Unserialize(GMDataReader reader)
        {
            base.Unserialize(reader);

            reader.Pad(4);

            int chunkVersion = reader.ReadInt32();
            if (chunkVersion != 1)
                reader.Warnings.Add(new GMWarning($"FEDS version is {chunkVersion}, expected 1"));

            int count = reader.ReadInt32();
            List = new GMUniquePointerList<GMFilterEffect>();
            List.Unserialize(reader);
        }
    }
}