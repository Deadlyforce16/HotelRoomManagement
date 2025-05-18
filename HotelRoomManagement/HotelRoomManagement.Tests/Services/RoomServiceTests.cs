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
    public class RoomServiceTests
    {
        private readonly Mock<IRoomRepository> _mockRoomRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IRoomService _roomService;

        public RoomServiceTests()
        {
            _mockRoomRepository = new Mock<IRoomRepository>();
            _mockMapper = new Mock<IMapper>();
            _roomService = new RoomService(_mockRoomRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllRoomsAsync_ShouldReturnListOfRoomDtos()
        {
            var rooms = new List<Room> { new Room(), new Room() };
            var roomDtos = new List<RoomDto> { new RoomDto(), new RoomDto() };

            _mockRoomRepository.Setup(repo => repo.GetAllAsync())
                                .ReturnsAsync(rooms);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<RoomDto>>(rooms))
                         .Returns(roomDtos);

            var result = await _roomService.GetAllRoomsAsync();

            Assert.NotNull(result);
            Assert.Equal(roomDtos.Count, ((List<RoomDto>)result).Count);
        }

        [Fact]
        public async Task GetRoomByIdAsync_ShouldReturnRoomDto_WhenRoomExists()
        {
            var roomId = 1;
            var room = new Room { Id = roomId };
            var roomDto = new RoomDto { Id = roomId };

            _mockRoomRepository.Setup(repo => repo.GetByIdAsync(roomId))
                                .ReturnsAsync(room);
            _mockMapper.Setup(mapper => mapper.Map<RoomDto>(room))
                         .Returns(roomDto);

            var result = await _roomService.GetRoomByIdAsync(roomId);

            Assert.NotNull(result);
            Assert.Equal(roomId, result.Id);
        }

        [Fact]
        public async Task CreateRoomAsync_ShouldReturnCreatedRoomDto()
        {
            var createRoomDto = new CreateRoomDto { Number = 101 };
            var roomEntity = new Room { Number = 101 };
            var createdRoomEntity = new Room { Id = 1, Number = 101 };
            var roomDto = new RoomDto { Id = 1, Number = 101 };

            _mockMapper.Setup(mapper => mapper.Map<Room>(createRoomDto))
                         .Returns(roomEntity);
            _mockRoomRepository.Setup(repo => repo.AddAsync(roomEntity))
                                .Callback(() => roomEntity.Id = 1)
                                .Returns(Task.CompletedTask);
            _mockMapper.Setup(mapper => mapper.Map<RoomDto>(roomEntity))
                         .Returns(roomDto);

            var result = await _roomService.CreateRoomAsync(createRoomDto);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(101, result.Number);
            _mockRoomRepository.Verify(repo => repo.AddAsync(roomEntity), Times.Once);
        }

    }
} 