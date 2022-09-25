﻿using System;

namespace xChanger.Core.POC.Models.Foundations.Pets
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PetType Type { get; set; }

        public Guid PersonId { get; set; }
    }
}
