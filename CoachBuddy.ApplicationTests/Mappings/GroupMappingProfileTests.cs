using AutoMapper;
using CoachBuddy.Application.ApplicationUser;
using CoachBuddy.Application.Group;
using Moq;
using CoachBuddy.Application.CoachBuddy;
using Xunit;
using Assert = Xunit.Assert;

namespace CoachBuddy.Application.Mappings.Tests
{
    public class GroupMappingProfileTests
    {
        [Fact()]
        public void Group_To_GroupDto_Mapping_Is_Valid()
        {
            // Arrange
            var userContextMock = new Mock<IUserContext>();

            userContextMock.Setup(x => x.GetCurrentUser()).Returns(new CurrentUser(
                "user123",             
                "JohnDoe",             
                new List<string> { "Moderator" }  
            ));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new GroupMappingProfile(userContextMock.Object));
            });
            var mapper = config.CreateMapper();

            var source = new Domain.Entities.Group.Group
            {
                Name = "Test Group",
                CreatedById = "user123"
            };

            // Act
            var dto = mapper.Map<GroupDto>(source);

            // Assert
            Assert.NotNull(dto);
            Assert.Equal("Test Group", dto.Name);
            Assert.True(dto.IsEditable);  // Assuming 'IsEditable' should be true if user matches 'CreatedById'
        }
        [Fact()]
        public void GroupList_To_GroupDtoList_Mapping_Is_Valid()
        {
            // Arrange
            var userContextMock = new Mock<IUserContext>();

            userContextMock.Setup(x => x.GetCurrentUser()).Returns(new CurrentUser(
                "user123",             
                "JohnDoe",             
                new List<string> { "Moderator" }  
            ));

            // Arrange
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new GroupMappingProfile(userContextMock.Object));
            });
            var mapper = config.CreateMapper();

            var sourceList = new List<Domain.Entities.Group.Group>
    {
        new Domain.Entities.Group.Group { Name = "Test Group 1", CreatedById = "user123" },
        new Domain.Entities.Group.Group { Name = "Test Group 2", CreatedById = "user456" }
    };

            // Act
            var dtoList = mapper.Map<List<GroupDto>>(sourceList);

            // Assert
            Assert.NotNull(dtoList);
            Assert.Equal(2, dtoList.Count);
            Assert.Equal("Test Group 1", dtoList[0].Name);
            Assert.Equal("Test Group 2", dtoList[1].Name);
        }
    }
}