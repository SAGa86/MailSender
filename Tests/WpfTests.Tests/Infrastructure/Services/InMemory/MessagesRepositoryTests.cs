﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTests.Infrastructure.Services.InMemory;
using WpfTests.Models;

namespace WpfTests.Tests.Infrastructure.Services.InMemory
{
    [TestClass]
    public class MessagesRepositoryTests
    {

        [TestMethod]

        public void GetAll_Test()
        {
            var repository = new MessagesRepository();

            var all = repository.GetAll();

            Assert.IsTrue(all.Any());
        }

        [TestMethod]
        public void Add_Test()
        {
            var repository = new MessagesRepository();

            var message = new Message
            {
                Title = "Unit test Title",
                Body = "unit test Body"
            };

            var actual_id = repository.Add(message);

            var all = repository.GetAll().ToArray();

            Assert.AreEqual(actual_id, message.Id);
            CollectionAssert.Contains(all, message);
            //StringAssert.Matches(all.Body, message.Body);

        }
    }
}
