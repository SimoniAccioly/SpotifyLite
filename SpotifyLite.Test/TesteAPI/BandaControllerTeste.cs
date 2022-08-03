using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SpofityLite.Application.Album.Dto;
using SpofityLite.Application.Album.Handler.Query;
using SpofityLite.Application.Album.Service;
using SpotifyLite.Api.Controllers;
using SpotifyLite.Domain.Album;
using SpotifyLite.Domain.Album.Repository;
using SpotifyLite.Domain.Album.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Test.TesteAPI
{
    public class BandaControllerTests
    {
        [Fact]
        public async Task DeveBuscarTodasBandasComSucesso()
        {
            Mock<IMediator> mockMediator = new Mock<IMediator>();
            Mock<IBandaRepository> mockRepository = new Mock<IBandaRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            List<Banda> bandas = new List<Banda>()
            {
                new Banda()
                {
                    Nome = "TesteBanda1",
                    Descricao = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non elementum ipsum. Aliquam leo sapien, vulputate vel mauris at, rutrum pharetra mi. Sed scelerisque vehicula efficitur. Phasellus cursus ultrices feugiat. Duis suscipit velit ac magna venenatis, sed dignissim dui sodales. Nulla sodales est ex, quis suscipit neque varius consectetur."
                },

                new Banda()
                {
                    Nome = "TesteBanda2",
                    Descricao = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas cursus ligula tristique feugiat lobortis. Nam varius posuere elit sit amet scelerisque. Donec maximus augue id diam varius fringilla. Cras nec neque elementum risus ultrices dapibus vitae quis massa. Phasellus ultricies ullamcorper metus, et volutpat nunc blandit et. Nullam pharetra ipsum ut velit aliquam, eget ullamcorper sem mollis."
                }
            };

            List<BandaOutputDto> bandaOutputDto = new List<BandaOutputDto>()
            {
                new BandaOutputDto(Guid.NewGuid(), "TesteBanda1","https://teste1.com/foto.png","Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non elementum ipsum. Aliquam leo sapien, vulputate vel mauris at, rutrum pharetra mi. Sed scelerisque vehicula efficitur. Phasellus cursus ultrices feugiat. Duis suscipit velit ac magna venenatis, sed dignissim dui sodales. Nulla sodales est ex, quis suscipit neque varius consectetur."),
                new BandaOutputDto(Guid.NewGuid(), "TesteBanda2","https://teste2.com/foto.png","Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas cursus ligula tristique feugiat lobortis. Nam varius posuere elit sit amet scelerisque. Donec maximus augue id diam varius fringilla. Cras nec neque elementum risus ultrices dapibus vitae quis massa. Phasellus ultricies ullamcorper metus, et volutpat nunc blandit et. Nullam pharetra ipsum ut velit aliquam, eget ullamcorper sem mollis.")
            };

            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(bandas.AsEnumerable());
            mockMapper.Setup(x => x.Map<List<BandaOutputDto>>(bandas)).Returns(bandaOutputDto);

            var service = new BandaService(mockRepository.Object, mockMapper.Object);
            var result = await service.GetAll();

            mockMediator.Setup(x => x.Send(It.IsAny<GetAllBandaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetAllBandaQueryResponse(result));

            var controller = new BandaController(mockMediator.Object);
            var resultController = controller.GetAll();

            var okObjectResult = (OkObjectResult)resultController.Result;
            Assert.NotNull(okObjectResult);

            var response = okObjectResult.Value as GetAllBandaQueryResponse;
            Assert.NotNull(response.Bandas);

        }

        [Fact]
        public async Task DeveBuscarBandaPorIdComSucesso()
        {
            Mock<IMediator> mockMediator = new Mock<IMediator>();
            Mock<IBandaRepository> mockRepository = new Mock<IBandaRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            var id = Guid.NewGuid();

            Banda banda = new Banda()
            {
                Nome = "TesteBanda1",
                Descricao = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non elementum ipsum. Aliquam leo sapien, vulputate vel mauris at, rutrum pharetra mi. Sed scelerisque vehicula efficitur. Phasellus cursus ultrices feugiat. Duis suscipit velit ac magna venenatis, sed dignissim dui sodales. Nulla sodales est ex, quis suscipit neque varius consectetur."
            };

            BandaOutputDto bandaOutputDto = new BandaOutputDto(id, "TesteBanda1", "https://teste1.com/foto.png", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse non elementum ipsum. Aliquam leo sapien, vulputate vel mauris at, rutrum pharetra mi. Sed scelerisque vehicula efficitur. Phasellus cursus ultrices feugiat. Duis suscipit velit ac magna venenatis, sed dignissim dui sodales. Nulla sodales est ex, quis suscipit neque varius consectetur.");

            mockRepository.Setup(x => x.Get(id)).ReturnsAsync(banda);
            mockMapper.Setup(x => x.Map<BandaOutputDto>(banda)).Returns(bandaOutputDto);

            var service = new BandaService(mockRepository.Object, mockMapper.Object);
            var result = await service.GetId(id);

            mockMediator.Setup(x => x.Send(It.IsAny<GetIdBandaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetIdBandaQueryResponse(result));

            var controller = new BandaController(mockMediator.Object);
            var resultController = controller.GetId(id);

            var okObjectResult = (OkObjectResult)resultController.Result;
            Assert.NotNull(okObjectResult);

            var response = okObjectResult.Value as GetIdBandaQueryResponse;
            Assert.NotNull(response.Banda);

        }
    }
}
