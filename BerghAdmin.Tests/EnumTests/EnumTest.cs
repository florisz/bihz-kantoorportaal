﻿using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using BerghAdmin.Data;
using System;

namespace BerghAdmin.Tests.EnumTests
{
    [TestFixture]
    public class MailMergeTests
    {
        [Test]
        public void TestTextIsEmpty()
        {
            var rolData = GetAlleRollen();
            Assert.AreEqual(10, rolData.Length);
        }

        private static RolData[] GetAlleRollen()
            =>
            Enum.GetNames<RolTypeEnum>()
                .Select(t => new RolData { Text = t })
                .ToArray();
    }

    public class RolData
    {
        public string Text { get; set; } = "admin";
        public int Id { get; set; } = 1;
    }
}
