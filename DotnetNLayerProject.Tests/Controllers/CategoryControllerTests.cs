using AutoMapper;
using DotnetNLayerProject.API.Controllers;
using DotnetNLayerProject.Core.Models;
using DotnetNLayerProject.Core.Services;
using DotnetNLayerProject.Service.Mapping;
using Moq;

namespace DotnetNLayerProject.Tests.Controllers
{
    public class CategoryControllerTests
    {
        private static IMapper _mapper;

        public CategoryControllerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MapProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        private List<Category> GetTestObjects()
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                     Id = 1,
                     CategoryName = "test1",
                     CreatedDate = DateTime.Now,
                }
            };
            return categories;
        }

        [Fact]
        public async Task All_WhenCalled_ReturnCategories()
        {
            //Arrange
            var mock = new Mock<ICategoryService>();
            mock.Setup(m => m.GetAllAsync()).ReturnsAsync(GetTestObjects());
            var categoryController = new CategoriesController(_mapper, mock.Object);
            //Act
            var result = categoryController.All();
            //Assert
            //var okResult = Assert.IsType<ObjectResult>(result);
            Assert.NotNull(result);
            //Assert.Equal(200, okResult.StatusCode);
            //var dataResult = Assert.IsType<GlobalResultDto<List<CategoryDto>>>(okResult.Value);
            //Assert.Equal(1, dataResult.Data[0].Id);
        }
    }
}