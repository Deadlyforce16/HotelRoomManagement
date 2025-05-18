using Xunit;
using Moq;
using System.Threading.Tasks;
using HotelRoomManagement.Service.Interfaces;
using HotelRoomManagement.Data.Interfaces;
using HotelRoomManagement.Service.Services;
using AutoMapper;
using System.Collections.Generic;
using HotelRoomManagement.Data.Entities;
using HotelRoomManagement.Service.DTOs;

namespace HotelRoomManagement.Tests.Services
{
    public class GuestServiceTests
    {
        private readonly Mock<IGuestRepository> _mockGuestRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IGuestService _guestService;

        public GuestServiceTests()
        {
            _mockGuestRepository = new Mock<IGuestRepository>();
            _mockMapper = new Mock<IMapper>();
            _guestService = new GuestService(_mockGuestRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllGuestsAsync_ShouldReturnListOfGuestDtos()
        {
            var guests = new List<Guest> { new Guest(), new Guest() };
            var guestDtos = new List<GuestDto> { new GuestDto(), new GuestDto() };

            _mockGuestRepository.Setup(repo => repo.GetAllAsync())
                                .ReturnsAsync(guests);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<GuestDto>>(guests))
                         .Returns(guestDtos);

            var result = await _guestService.GetAllGuestsAsync();

            Assert.NotNull(result);
            Assert.Equal(guestDtos.Count, ((List<GuestDto>)result).Count);
        }

        [Fact]
        public async Task GetGuestByIdAsync_ShouldReturnGuestDto_WhenGuestExists()
        {
            var guestId = 1;
            var guest = new Guest { Id = guestId };
            var guestDto = new GuestDto { Id = guestId };

            _mockGuestRepository.Setup(repo => repo.GetByIdAsync(guestId))
                                .ReturnsAsync(guest);
            _mockMapper.Setup(mapper => mapper.Map<GuestDto>(guest))
                         .Returns(guestDto);

            var result = await _guestService.GetGuestByIdAsync(guestId);

            Assert.NotNull(result);
            Assert.Equal(guestId, result.Id);
        }

        [Fact]
        public async Task CreateGuestAsync_ShouldReturnCreatedGuestDto()
        {
            var createGuestDto = new CreateGuestDto { FirstName = "Test" };
            var guestEntity = new Guest { FirstName = "Test" };
            var createdGuestEntity = new Guest { Id = 1, FirstName = "Test" };
            var guestDto = new GuestDto { Id = 1, FirstName = "Test" };

            _mockMapper.Setup(mapper => mapper.Map<Guest>(createGuestDto))
                         .Returns(guestEntity);
            _mockGuestRepository.Setup(repo => repo.AddAsync(guestEntity))
                                .Callback(() => guestEntity.Id = 1)
                                .Returns(Task.CompletedTask);
             _mockMapper.Setup(mapper => mapper.Map<GuestDto>(guestEntity))
                         .Returns(guestDto);

            var result = await _guestService.CreateGuestAsync(createGuestDto);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Test", result.FirstName);
            _mockGuestRepository.Verify(repo => repo.AddAsync(guestEntity), Times.Once);
        }

    }
} 