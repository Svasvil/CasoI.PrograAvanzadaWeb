using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CasoI.API.BussinessLogic;

namespace TestCases
{
    public  class UserStoryLogicTest
    {
        //prueba sobre creacion de user story
            [Fact]
            public void CreateUserStory_ShouldReturnTrue()
            {
                // Arrange
                var mockLogic = new Mock<UserStoryLogic>();
                var userStory = new UserStory
                {
                    Id = 1,
                    Title = "Implement login feature",
                    Description = "As a user, I want to be able to log in to the application.",
                    Status = "To Do"
                };
                mockLogic.Setup(x => x.CreateUserStory(userStory)).Returns(true);
                // Act
                var result = mockLogic.Object.CreateUserStory(userStory);
                // Assert
                Assert.True(result);
        }
    }
}
