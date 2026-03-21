using CasoI.API.BussinessLogic;
using CasoI.API.BussinessLogic.Interfaces;
using CasoI.API.DTOS;
using CasoI.API.Models;
using CasoI.API.Models.BoardViewModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CasoI.API.DTOS.BoardViewModelDTO;
/*
namespace TestCases
{
    public  class UserStoryLogicTest
    {
        //prueba sobre creacion de user story
            [Fact]
            public async Task CreateUserStory_ShouldReturnTrue()
            {
                // Arrange
                var mockLogic = new Mock<I_TaskBL>();
            mockLogic.Setup(s=>s.CreateTask(It.IsAny<CreateTaskDTO>())).ReturnsAsync(Task.CompletedTask);
            var service = new I_TaskBL(Mockservice.Object);
            var NewTask = new BoardViewModel
            {
                Nombre = "Test Task",
                Descripcion = "This is a test task",
                AsignadoA = "Tester",
                
            };
            await service.CreateTask(NewTask);
            mockLogic.Verify(s => s.CreateTask(It.IsAny<CreateTaskDTO>(dto => dto.Nombre == NewTask.Nombre && dto.Descripcion == NewTask.Descripcion && dto.AsignadoA == NewTask.AsignadoA


            )), Times.Once);
            mockService.Verify(s => s.GetAllTasks, Times.Never);



        }
    }
}
*/
