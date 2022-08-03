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
    public class AlbumControllerTests
    {
        [Fact]
        public async Task DeveBuscarTodosAlbunsComSucesso()
        {
            Mock<IMediator> mockMediator = new Mock<IMediator>();
            Mock<IAlbumRepository> mockRepository = new Mock<IAlbumRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            List<MusicaOutputDto> musicaOutputDto = new List<MusicaOutputDto>(){
                new MusicaOutputDto(Guid.NewGuid(), "MusicaTeste1", "60"),
                new MusicaOutputDto(Guid.NewGuid(), "MusicaTeste2", "120"),
                new MusicaOutputDto(Guid.NewGuid(), "MusicaTeste3", "160")
            };

            List<AlbumOutputDto> albumOutputDto = new List<AlbumOutputDto>() {
                new AlbumOutputDto(Guid.NewGuid(), "AlbumTeste", DateTime.Now, "https://teste.com/capa.png", musicaOutputDto)
            };

            List<Musica> musicas = new List<Musica>()
            {
                new Musica(){ Nome = "MusicaTeste1", Duracao = new Duracao(60) },
                new Musica(){ Nome = "MusicaTeste2", Duracao = new Duracao(120) },
                new Musica(){ Nome = "MusicaTeste3", Duracao = new Duracao(160) }
            };

            List<Album> album = new List<Album>()
            {
                new Album()
                {
                    Nome = "AlbumTeste",
                    DataLancamento = DateTime.Now,
                    Musicas = musicas
                }
            };

            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(album.AsEnumerable());
            mockMapper.Setup(x => x.Map<List<AlbumOutputDto>>(album)).Returns(albumOutputDto);

            var service = new AlbumService(mockRepository.Object, mockMapper.Object);
            var result = await service.GetAll();

            mockMediator.Setup(x => x.Send(It.IsAny<GetAllAlbumQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetAllAlbumQueryResponse(result));

            var controller = new AlbumController(mockMediator.Object);
            var resultController = controller.GetAll();

            var okObjectResult = (OkObjectResult)resultController.Result;
            Assert.NotNull(okObjectResult);

            var response = okObjectResult.Value as GetAllAlbumQueryResponse;
            Assert.NotNull(response.Albums);

        }

        [Fact]
        public async Task DeveBuscarALbumPorIdComSucesso()
        {
            Mock<IMediator> mockMediator = new Mock<IMediator>();
            Mock<IAlbumRepository> mockRepository = new Mock<IAlbumRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            var id = Guid.NewGuid();

            List<MusicaOutputDto> musicaOutputDto = new List<MusicaOutputDto>(){
                new MusicaOutputDto(Guid.NewGuid(), "MusicaTeste1", "60"),
                new MusicaOutputDto(Guid.NewGuid(), "MusicaTeste2", "120"),
                new MusicaOutputDto(Guid.NewGuid(), "MusicaTeste3", "160")
            };

            AlbumOutputDto albumOutputDto = new AlbumOutputDto(id, "Album Teste", DateTime.Now, "https://teste.com/capa.png", musicaOutputDto);

            List<Musica> musicas = new List<Musica>()
            {
                new Musica(){ Nome = "MusicaTeste1", Duracao = new Duracao(60) },
                new Musica(){ Nome = "MusicaTeste2", Duracao = new Duracao(120) },
                new Musica(){ Nome = "MusicaTeste3", Duracao = new Duracao(160) }
            };

            Album album = new Album()
            {
                Nome = "AlbumTeste",
                DataLancamento = DateTime.Now,
                Musicas = musicas
            };



            mockRepository.Setup(x => x.Get(id)).ReturnsAsync(album);
            mockMapper.Setup(x => x.Map<AlbumOutputDto>(album)).Returns(albumOutputDto);

            var service = new AlbumService(mockRepository.Object, mockMapper.Object);
            var result = await service.GetId(id);

            mockMediator.Setup(x => x.Send(It.IsAny<GetIdAlbumQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetIdAlbumQueryResponse(result));

            var controller = new AlbumController(mockMediator.Object);
            var resultController = controller.GetId(id);

            var okObjectResult = (OkObjectResult)resultController.Result;
            Assert.NotNull(okObjectResult);

            var response = okObjectResult.Value as GetIdAlbumQueryResponse;
            Assert.NotNull(response.Album);

        }
    }
}
