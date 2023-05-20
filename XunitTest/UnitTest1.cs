using API.Controllers;
using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using System.Data.Entity.Migrations.Model;

namespace XunitTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task ReturnListWithTypeFridge()
        {
            //Arrange
            var mock = new Mock<IFridgeRepository>();
            var contoller = new FridgeController(mock.Object);
            mock.Setup(x => x.GetAll()).ReturnsAsync(new List<Fridge>());
            ////Act
            var result = await contoller.GetAsync();
            ////Assert
            Assert.NotNull(result); //ReturnFullList
            Assert.IsType<ActionResult<IEnumerable<Fridge>>>(result); //Type = True
        }

        [Fact]
        public async Task ReurnListObjectsToId()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            var mock = new Mock<IFridgeRepository>();
            var controller = new FridgeController(mock.Object);
            mock.Setup(x => x.GetFridgeToId(id)).ReturnsAsync(new Fridge());
            //Act
            var result = await controller.Get(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsNotType<ActionResult<Guid>>(result);
            Assert.IsType<ActionResult<IEnumerable<Fridge>>>(result);
        }

        [Fact]
        public async Task AddOblectInList()
        {
            //Arrange
            var mock = new Mock<IFridgeRepository>();
            var controller = new FridgeController(mock.Object);
            Fridge newFridge = new Fridge()
            {
                Id = new Guid(),
                Name = "Name",
                OwnerName = "OwnerName"
            };
            //Act
            var result = await controller.AddFridge(newFridge);
            Assert.NotNull(result);
        }
    }
}